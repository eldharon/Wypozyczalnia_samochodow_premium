using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WypożyczalniaSamochodówPremium.Models;

namespace WypożyczalniaSamochodówPremium.Controllers
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
    }
}