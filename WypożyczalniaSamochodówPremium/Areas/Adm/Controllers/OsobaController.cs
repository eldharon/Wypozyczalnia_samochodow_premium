using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WypożyczalniaSamochodówPremium.Models;

namespace WypożyczalniaSamochodówPremium.Areas.Adm.Controllers
{
    public class OsobaController : Controller
    {
        OsobaRepository osobaRepository = new OsobaRepository();
        // GET: Adm/Wydarzenie
        public ActionResult Index()
        {
            var model = osobaRepository.FindAllOsoba();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var wydarzenie = osobaRepository.GetOsobaById(id);
            return View(wydarzenie);
        }

        public ActionResult Create()
        {
            Osoba osoba = new Osoba();
            return View(osoba);
        }


        [HttpPost]
        public ActionResult Create(Osoba osoba, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                osobaRepository.Add(osoba);
                osobaRepository.Save();

                TempData["okMessage"] = "Osoba: " + osoba.Imie + " " + osoba.Nazwisko + " została dodana.";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["errorMessage"] = "Nie dodano osoby";
                return View(osoba);
            }
        }

        public ActionResult Edit(int id)
        {
            Osoba osoba = osobaRepository.GetOsobaById(id);
            return View(osoba);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Osoba osoba = osobaRepository.GetOsobaById(id);
            if (TryUpdateModel(osoba))
            {
                osobaRepository.Save();
                TempData["okMessage"] = "Osoba: " + osoba.Imie+" "+osoba.Nazwisko + " została zapisana!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["errorMessage"] = "Osoba: " + osoba.Imie + " " + osoba.Nazwisko + "nie została zapisana!";
                return View(osoba);
            }
        }

        public ActionResult Delete(int id)
        {
            var osoba = osobaRepository.GetOsobaById(id);
            return View(osoba);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var osoba = osobaRepository.GetOsobaById(id);
                osobaRepository.Delete(osoba);
                osobaRepository.Save();
                TempData["okMessage"] = "Usunięto " + osoba.Imie + " " + osoba.Nazwisko + "!";
                return RedirectToAction("Index", "Osoba");
            }
            catch (Exception e)
            {
                TempData["errorMessage"] = "Wystąpił błąd : " + e;
                return RedirectToAction("Index", "Osoba");
            }
        }
    }
}
