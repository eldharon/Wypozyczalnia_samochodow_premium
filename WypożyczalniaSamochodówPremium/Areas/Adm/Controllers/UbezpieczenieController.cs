using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WypożyczalniaSamochodówPremium.Models;

namespace WypożyczalniaSamochodówPremium.Areas.Adm.Controllers
{
    [Authorize(Roles = "Admin, Manager, Employee")]
    public class UbezpieczenieController : Controller
    {
        UbezpieczenieRepository ubezpieczenieRepository = new UbezpieczenieRepository();

        public ActionResult Index(int? id)
        {
            if (id.HasValue)
            {
                var model = ubezpieczenieRepository.ShowUbezpieczeniaForSamochod(id.Value);
                ViewBag.SamochodId = id;
                return View("ShowUbezpieczeniaForSamochod",model);
            }
            else
            {
                var model = ubezpieczenieRepository.FindAllUbezpieczenie();
                return View(model);
            }


        }

        public ActionResult ShowUbezpieczeniaForSamochod(int id)
        {
            var model = ubezpieczenieRepository.ShowUbezpieczeniaForSamochod(id);
            ViewBag.SamochodId = id;
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var ubezpieczenie = ubezpieczenieRepository.GetUbezpieczenieById(id);
            return View(ubezpieczenie);
        }


        public ActionResult Create(int id)
        {
            Ubezpieczenie ubezpieczenie = new Ubezpieczenie();
            ubezpieczenie.SamochodId = id;
            return View(ubezpieczenie);
        }


        [HttpPost]
        public ActionResult Create(Ubezpieczenie ubezpieczenie, FormCollection collection)
        {
            var samid = ubezpieczenie.SamochodId;
            if (ModelState.IsValid)
            {
                ubezpieczenieRepository.Add(ubezpieczenie);
                ubezpieczenieRepository.Save();

                TempData["okMessage"] = "Ubezpieczenie został zapisany.";
                return RedirectToAction("ShowUbezpieczeniaForSamochod", "Ubezpieczenie", new { id = samid });
            }
            else
            {
                TempData["errorMessage"] = "Nie dodano serwisu";
                return View(ubezpieczenie);
            }
        }


        public ActionResult Edit(int id)
        {
            Ubezpieczenie ubezpieczenie = ubezpieczenieRepository.GetUbezpieczenieById(id);
            return View(ubezpieczenie);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {

            Ubezpieczenie ubezpieczenie = ubezpieczenieRepository.GetUbezpieczenieById(id);
            var samid = ubezpieczenie.SamochodId;
            if (TryUpdateModel(ubezpieczenie))
            {
                ubezpieczenieRepository.Save();
                TempData["okMessage"] = "Ubezpieczenie został zapisany.";
                return RedirectToAction("ShowUbezpieczeniaForSamochod", "Ubezpieczenie", new { id = samid });
            }
            else
            {
                TempData["errorMessage"] = "Ubezpieczenie nie został zapisany!";
                return View(ubezpieczenie);
            }
        }


        public ActionResult Delete(int id)
        {
            var ubezpieczenie = ubezpieczenieRepository.GetUbezpieczenieById(id);
            return View(ubezpieczenie);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            var ubezpieczenie = ubezpieczenieRepository.GetUbezpieczenieById(id);
            var samid = ubezpieczenie.SamochodId;
            try
            {

                ubezpieczenieRepository.Delete(ubezpieczenie);
                ubezpieczenieRepository.Save();
                TempData["okMessage"] = "Usunięto Ubezpieczenie!";
                return RedirectToAction("ShowUbezpieczenieForSamochod", "Ubezpieczenie", new { id = samid });
            }
            catch (Exception e)
            {
                TempData["errorMessage"] = "Wystąpił błąd : " + e;
                return RedirectToAction("ShowUbezpieczenieForSamochod", "Ubezpieczenie", new { id = samid });
            }
        }
    }
}