using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WypożyczalniaSamochodówPremium.Models;

namespace WypożyczalniaSamochodówPremium.Areas.Adm.Controllers
{
    [Authorize(Roles = "Admin, Manager, Employee")]
    public class OpisController : Controller
    {
        OpisRepository opisRepository = new OpisRepository();
        SamochodRepository samochodRepository = new SamochodRepository();

        // GET: Adm/Opis
        public ActionResult Index()
        {
            var opis = opisRepository.GetAllOpisy();
            return View(opis);
        }

        public ActionResult Details(int id)
        {
            var opis = opisRepository.GetOpisById(id);
            return View(opis);
        }

        public ActionResult Create(int id)
        {
           
            Opis opis = new Opis();
            opis.SamochodId = id;
            return View(opis);
        }

        [HttpPost]
        public ActionResult Create(Opis opis, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                opisRepository.Add(opis);
                opisRepository.Save();

                TempData["okMessage"] = "Opis został dodany.";
                return RedirectToAction("Details","Samochod",new { samId = opis.SamochodId});
            }
            else
            {
                TempData["errorMessage"] = "Nie dodano opisu";
                return View(opis);
            }
        }

        public ActionResult Delete(int id)
        {
            var opis = opisRepository.GetOpisById(id);
            return View(opis);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            var opis = opisRepository.GetOpisById(id);
            var samid = opis.SamochodId;
            try
            {
                
                opisRepository.Delete(opis);
                opisRepository.Save();
                TempData["okMessage"] = "Usunięto Opis!";
                return RedirectToAction("Details", "Samochod", new { samId = samid });
            }
            catch (Exception e)
            {
                TempData["errorMessage"] = "Wystąpił błąd : " + e;
                return RedirectToAction("Index", "Samochod");
            }
        }

        public ActionResult  DisplayOpisy(int id)
        {
           
            var list = opisRepository.GetOpisForSamochodId(id);
            var model = new List<Opis>().AsEnumerable();
            if(list != null)
            {
                model=list;
            }
            

            return PartialView(model);
        }
    }
}