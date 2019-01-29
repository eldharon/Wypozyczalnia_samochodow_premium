using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WypożyczalniaSamochodówPremium.Models;

namespace WypożyczalniaSamochodówPremium.Areas.Adm.Controllers
{
    public class PrzegladController : Controller
    {
        PrzegladRepository przegladRepository = new PrzegladRepository();

        public ActionResult Index()
        {
            var model = przegladRepository.FindAllPrzeglad();
            return View(model);
        }

        public ActionResult ShowPrzegladyForSamochod(int id)
        {
            var model = przegladRepository.ShowPrzegladForSamochod(id);
            ViewBag.SamochodId = id; 
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var przeglad = przegladRepository.GetPrzegladById(id);
            return View(przeglad);
        }


        public ActionResult Create(int id)
        {
            Przeglad przeglad = new Przeglad();
            przeglad.SamochodId = id;
            return View(przeglad);
        }


        [HttpPost]
        public ActionResult Create(Przeglad przeglad, FormCollection collection)
        {
            var samid = przeglad.SamochodId; 
            if (ModelState.IsValid)
            {
                przegladRepository.Add(przeglad);
                przegladRepository.Save();

                TempData["okMessage"] = "Serwis został zapisany.";
                return RedirectToAction("ShowPrzegladyForSamochod", "Przeglad", new { id = samid });
            }
            else
            {
                TempData["errorMessage"] = "Nie dodano serwisu";
                return View(przeglad);
            }
        }


        public ActionResult Edit(int id)
        {
            Przeglad przeglad= przegladRepository.GetPrzegladById(id);
            return View(przeglad);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Przeglad przeglad = przegladRepository.GetPrzegladById(id);
            var samid = przeglad.SamochodId;
            if (TryUpdateModel(przeglad))
            {
                przegladRepository.Save();
                TempData["okMessage"] = "Przeglad został zapisany.";
                return RedirectToAction("ShowPrzegladyForSamochod", "Przeglad", new { id = samid });
            }
            else
            {
                TempData["errorMessage"] = "Przeglad nie został zapisany!";
                return View(przeglad);
            }
        }
        public ActionResult Delete(int id)
        {
            var przeglad = przegladRepository.GetPrzegladById(id);
            return View(przeglad);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            var przeglad = przegladRepository.GetPrzegladById(id);
            var samid = przeglad.SamochodId;
            try
            {

                przegladRepository.Delete(przeglad);
                przegladRepository.Save();
                TempData["okMessage"] = "Usunięto Serwis!";
                return RedirectToAction("ShowPrzegladyForSamochod", "Przeglad", new { id = samid });
            }
            catch (Exception e)
            {
                TempData["errorMessage"] = "Wystąpił błąd : " + e;
                return RedirectToAction("ShowPrzegladyForSamochod", "Przeglad", new { id = samid });
            }
        }

    }
}