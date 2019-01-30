using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WypożyczalniaSamochodówPremium.Models;

namespace WypożyczalniaSamochodówPremium.Areas.Adm.Controllers
{
    public class WydarzenieController : Controller
    {
        WydarzenieRepository wydarzenieRepository = new WydarzenieRepository();
        WypozyczenieRepository wypozyczenieRepository = new WypozyczenieRepository();
        // GET: Adm/Wydarzenie
        public ActionResult Index()
        {
            var model = wydarzenieRepository.FindAllWydarzenie();               
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var wydarzenie = wydarzenieRepository.GetWydarzenieById(id);
            return View(wydarzenie);
        }
        public ActionResult Create()
        {
            Wydarzenie wydarzenie = new Wydarzenie();
            return View(wydarzenie);
        }
        

        [HttpPost]
        public ActionResult Create(Wydarzenie wydarzenie, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                wydarzenieRepository.Add(wydarzenie);
                wydarzenieRepository.Save();

                TempData["okMessage"] = "Wydarzenie: " + wydarzenie.NazwaWydarzenia+ " zostało zapisane.";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["errorMessage"] = "Nie dodano wydarzenia";
                return View(wydarzenie);
            }
        }
        public ActionResult Edit(int id)
        {
            Wydarzenie wydarzenie = wydarzenieRepository.GetWydarzenieById(id);
            return View(wydarzenie);
        }
        [HttpPost]
        public ActionResult Edit(int id , FormCollection collection)
        {
            Wydarzenie wydarzenie = wydarzenieRepository.GetWydarzenieById(id);
            if(TryUpdateModel(wydarzenie))
            {
                wydarzenieRepository.Save();
                TempData["okMessage"] = "Wydarzenie " + wydarzenie.NazwaWydarzenia + " zostało zapisane!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["errorMessage"] = "Wydarzenie " + wydarzenie.NazwaWydarzenia + "nie zostało zapisane!";
                return View(wydarzenie);
            }
        }

        public ActionResult Delete(int id)
        {
            var wydarzenie = wydarzenieRepository.GetWydarzenieById(id);
            return View(wydarzenie);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            var wyp = wypozyczenieRepository.FindAllWypozyczeniaForWydarzenieId(id);

            try
            {

                if (wyp.Count() == 0)
                {
                    var wydarzenie = wydarzenieRepository.GetWydarzenieById(id);
                    wydarzenieRepository.Delete(wydarzenie);
                    wydarzenieRepository.Save();
                    TempData["okMessage"] = "Usunięto wydarzenie!";
                    return RedirectToAction("Index", "Wydarzenie");
                }
                else
                {

                    TempData["errorMessage"] = "Nie usunięto wydarzenia - rekord znajduje sie w innych tabelach!";
                    return RedirectToAction("Index", "Wydarzenie");
                }
            }
            catch (Exception e)
            {
                TempData["errorMessage"] = "Wystąpił błąd : " + e;
                return RedirectToAction("Index", "Wydarzenie");
            }
        }
    }
}