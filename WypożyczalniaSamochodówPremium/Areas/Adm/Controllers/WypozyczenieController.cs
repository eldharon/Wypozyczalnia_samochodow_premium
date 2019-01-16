using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WypożyczalniaSamochodówPremium.Models;

namespace WypożyczalniaSamochodówPremium.Areas.Adm.Controllers
{
    public class WypozyczenieController : Controller
    {
        WypozyczenieRepository wypozyczenieRepository = new WypozyczenieRepository();
        WydarzenieRepository wydarzenieRepository = new WydarzenieRepository();
        WypSamRepository WypSamRepository = new WypSamRepository();
        // GET: Adm/Wydarzenie
        public ActionResult Index()
        {
            var model = wypozyczenieRepository.FindAllWypozyczenia();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var wydarzenie = wypozyczenieRepository.GetWypozyczenieById(id);
            return View(wydarzenie);
        }

        public ActionResult Create(int id)
        {
            List<SelectListItem> wydarzenieList = new SelectList(wydarzenieRepository.FindAllWydarzenie(), "WydarzenieId", "NazwaWydarzenia").ToList();
            ViewData["wydarzenieList"] = wydarzenieList;

            WypozyczenieVM wyp = new WypozyczenieVM();
            wyp.wypozyczenie.OsobaId = id;
            return View(wyp);
        }

        [HttpPost]
        public ActionResult Create(WypozyczenieVM wyp, FormCollection collection)
        {
            new 
            List<SelectListItem> wydarzenieList = new SelectList(wydarzenieRepository.FindAllWydarzenie(), "WydarzenieId", "NazwaWydarzenia").ToList();
            ViewData["wydarzenieList"] = wydarzenieList;

            if (ModelState.IsValid)
            {

                wypSamRepository.Add
                wypozyczenieRepository.Add(wyp.wypozyczenie);
                wypozyczenieRepository.Save();

                TempData["okMessage"] = "Wypożyczenie zostało dodane.";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["errorMessage"] = "Nie dodano osoby";
                return View(wyp);
            }
        }
    }
}