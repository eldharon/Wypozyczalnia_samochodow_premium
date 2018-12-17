using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WypożyczalniaSamochodówPremium.Models;

namespace WypożyczalniaSamochodówPremium.Areas.Adm.Controllers
{
    public class SamochodController : Controller
    {
        SamochodRepository samochodRepository = new SamochodRepository();


        // GET: Samochod
        public ActionResult Index()
        {
            var samochod = samochodRepository.FindAllSamochod();
            return View(samochod);
        }

        public ActionResult Create()
        {
            var MarkiSelectList = SamochodSelectLists.MarkiList.Select(x => new SelectListItem() { Value = x, Text = x }).ToList();
            ViewData["MarkiList"] = MarkiSelectList;

            var RodzajSkrzyniSelectList = SamochodSelectLists.RodzajSkrzyniList.Select(x => new SelectListItem() { Value = x, Text = x }).ToList();
            ViewData["RodzajSkrzyniList"] = RodzajSkrzyniSelectList;

            var LiczbaDrzwiSelectList = SamochodSelectLists.LiczbaDrzwiList.Select(x => new SelectListItem() { Value = x, Text = x }).ToList();
            ViewData["LiczbaDrzwiList"] = LiczbaDrzwiSelectList;

            var RodzajSilnikaSelectList = SamochodSelectLists.PaliwaList.Select(x => new SelectListItem() { Value = x, Text = x }).ToList();
            ViewData["RodzajSilnikaList"] = RodzajSilnikaSelectList;

            Samochod samochod = new Samochod();

            return View(samochod);
        }

        [HttpPost]
        public ActionResult Create(Samochod samochod, FormCollection collection)
        {

            if (ModelState.IsValid)
            {
                samochodRepository.Add(samochod);
                samochodRepository.Save();

                TempData["okMessage"] = "Samochod: " + samochod.Marka + " " + samochod.Marka + " został zapisany";
                return RedirectToAction("Index");
            }
            else
            {
                return View(samochod);
            }
        }
        public ActionResult Delete(int id)
        {
            var auto = samochodRepository.GetSamochodById(id);
            return View(auto);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var auto = samochodRepository.GetSamochodById(id);
                samochodRepository.Delete(auto);
                samochodRepository.Save();
                TempData["okMessage"] = "Usunięto "+auto.Marka+" "+auto.Model+"!";
                return RedirectToAction("Index", "Samochod");
            }
            catch(Exception e)
            {
                TempData["errorMessage"] = "Wystąpił błąd : "+e;
                return RedirectToAction("Index", "Samochod");
            }
        }
    }
}