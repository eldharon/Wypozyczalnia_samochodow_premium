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
        // GET: Adm/Wydarzenie
        public ActionResult Index()
        {
            var model = wypozyczenieRepository.FindAllWypyczenia();
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

            Wypozyczenie wypozyczenie = new Wypozyczenie();
            wypozyczenie.OsobaId = id;
            return View(wypozyczenie);
        }

        [HttpPost]
        public ActionResult Create(Wypozyczenie wypozyczenie, FormCollection collection)
        {
            List<SelectListItem> wydarzenieList = new SelectList(wydarzenieRepository.FindAllWydarzenie(), "WydarzenieId", "NazwaWydarzenia").ToList();
            ViewData["wydarzenieList"] = wydarzenieList;

            if (ModelState.IsValid)
            {
                wypozyczenieRepository.Add(wypozyczenie);
                wypozyczenieRepository.Save();

                TempData["okMessage"] = "Wypożyczenie zostało dodane.";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["errorMessage"] = "Nie dodano osoby";
                return View(wypozyczenie);
            }
        }
    }
}