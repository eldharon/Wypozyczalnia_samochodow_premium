using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WypożyczalniaSamochodówPremium.Models;

namespace WypożyczalniaSamochodówPremium.Areas.Adm.Controllers
{
    [Authorize(Roles = "Admin, Manager, Employee")]
    public class CennikController : Controller
    {
        CennikRepository cennikRepository = new CennikRepository();

        public ActionResult Index(int? id)
        {
            if (id.HasValue)
            {
                return RedirectToAction("ShowCennikiForSamochod", new { id = id.Value });
            }
            else
            {
                var model = cennikRepository.GetAllCenniki();
                return View(model);
            }
            
        }

        public ActionResult ShowCennikiForSamochod(int id)
        {
            var model = cennikRepository.ShowCennikiForSamochod(id);
            ViewBag.SamochodId = id;
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var serwis = cennikRepository.GetCennikById(id);
            return View(serwis);
        }


        public ActionResult Create(int id)
        {
            List<SelectListItem> opisList = new SelectList(CennikSelectList.OpisList, "Key", "Value").ToList();
            ViewData["opisList"] = opisList;

            Cennik cennik = new Cennik();
            cennik.SamochodId = id;
            return View(cennik);
        }


        [HttpPost]
        public ActionResult Create(Cennik cennik, FormCollection collection)
        {
            var samid = cennik.SamochodId;
            if (ModelState.IsValid)
            {
                cennikRepository.Add(cennik);
                cennikRepository.Save();

                TempData["okMessage"] = "Cennik został zapisany.";
                return RedirectToAction("ShowCennikiForSamochod", "Cennik", new { id = samid });
            }
            else
            {
                TempData["errorMessage"] = "Nie dodano Cennika";
                return View(cennik);
            }
        }


        public ActionResult Edit(int id)
        {
            List<SelectListItem> opisList = new SelectList(CennikSelectList.OpisList, "Key", "Value").ToList();
            ViewData["opisList"] = opisList;
            Cennik cennik = cennikRepository.GetCennikById(id);
            return View(cennik);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {

            Cennik cennik = cennikRepository.GetCennikById(id);
            var samid = cennik.SamochodId;
            if (TryUpdateModel(cennik))
            {
                cennikRepository.Save();
                TempData["okMessage"] = "Cennik został zapisany.";
                return RedirectToAction("ShowCennikiForSamochod", "Cennik", new { id = samid });
            }
            else
            {
                TempData["errorMessage"] = "Cennik nie został zapisany!";
                return View(cennik);
            }
        }


        public ActionResult Delete(int id)
        {
            var cennik = cennikRepository.GetCennikById(id);
            return View(cennik);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            var cennik = cennikRepository.GetCennikById(id);
            var samid = cennik.SamochodId;
            try
            {

                cennikRepository.Delete(cennik);
                cennikRepository.Save();
                TempData["okMessage"] = "Usunięto Cennik!";
                return RedirectToAction("ShowCennikiForSamochod", "Cennik", new { id = samid });
            }
            catch (Exception e)
            {
                TempData["errorMessage"] = "Wystąpił błąd : " + e;
                return RedirectToAction("ShowCennikiForSamochod", "Cennik", new { id = samid });
            }
        }
    }
}