﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WypożyczalniaSamochodówPremium.Models;

namespace WypożyczalniaSamochodówPremium.Areas.Adm.Controllers
{
    [Authorize(Roles = "Admin, Manager, Employee")]
    public class WypozyczenieController : Controller
    {
        WypozyczenieRepository wypozyczenieRepository = new WypozyczenieRepository();
        WydarzenieRepository wydarzenieRepository = new WydarzenieRepository();
        WypSamRepository WypSamRepository = new WypSamRepository();
        WypozyczenieTempRepository wypozyczenieTempRepository = new WypozyczenieTempRepository();
        OsobaRepository osobaRepository = new OsobaRepository();
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

            List<SelectListItem> StatusList = new SelectList(StatusSelectList.StatusList, "Key", "Value").ToList();
            ViewData["StatusList"] = StatusList;


            var search = wypozyczenieTempRepository.FindWypozyczenieTempForOsobaId(id);

            Wypozyczenie wypozyczenie = new Wypozyczenie();
            if (search.Count() > 0)
            {
                wypozyczenie.DataWypozyczenia = search.FirstOrDefault().DataWypozyczenia;
                wypozyczenie.DataZwrotu = search.FirstOrDefault().DataZwrotu; ;
                wypozyczenie.OsobaId = id;
                ViewBag.OsobaId = id;
            }
            else
            {
                wypozyczenie.DataWypozyczenia = DateTime.Now;
                wypozyczenie.DataZwrotu = DateTime.Now.AddDays(1);
                wypozyczenie.OsobaId = id;
                ViewBag.OsobaId = id;
            }
            

            return View(wypozyczenie);
        }

        [HttpPost]
        public ActionResult Create(Wypozyczenie wypozyczenie, FormCollection collection)
        {
            List<SelectListItem> wydarzenieList = new SelectList(wydarzenieRepository.FindAllWydarzenie(), "WydarzenieId", "NazwaWydarzenia").ToList();
            ViewData["wydarzenieList"] = wydarzenieList;

            List<SelectListItem> StatusList = new SelectList(StatusSelectList.StatusList, "Key", "Value").ToList();
            ViewData["StatusList"] = StatusList;


            var wypTemp = wypozyczenieTempRepository.FindWypozyczenieTempForOsobaId(wypozyczenie.OsobaId);
            try
            {
                if (ModelState.IsValid)
                {

                    wypozyczenieRepository.Add(wypozyczenie);
                    wypozyczenieRepository.Save();

                
                    foreach (var item in wypTemp)
                    {
                        WypSam wypSam = new WypSam();
                        wypSam.SamochodId = item.SamochodId;
                        wypSam.WypozyczenieId = wypozyczenie.WypozyczenieId;

                        WypSamRepository.Add(wypSam);
                       
                    }
                    WypSamRepository.Save();

                    foreach (var item in wypTemp)
                    {
                        wypozyczenieTempRepository.Delete(item);
                    }
                    wypozyczenieTempRepository.Save();

                    TempData["okMessage"] = "Wypożyczenie zostało dodane.";
                    return RedirectToAction("Details",new { id = wypozyczenie.WypozyczenieId});

                }
                else
                {
                    TempData["errorMessage"] = "Nie dodano wypożyczenia";
                    return View(wypozyczenie);
                }
            }
            catch (Exception e)
            {
                TempData["errorMessage"] = "Wystąpił błąd : " + e;
                return View();
            }

        }

        public ActionResult Edit(int id)
        {
            List<SelectListItem> wydarzenieList = new SelectList(wydarzenieRepository.FindAllWydarzenie(), "WydarzenieId", "NazwaWydarzenia").ToList();
            ViewData["wydarzenieList"] = wydarzenieList;

            List<SelectListItem> StatusList = new SelectList(StatusSelectList.StatusList, "Key", "Value").ToList();
            ViewData["StatusList"] = StatusList;


            var wypozyczenie = wypozyczenieRepository.GetWypozyczenieById(id);
            return View(wypozyczenie);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {

            List<SelectListItem> wydarzenieList = new SelectList(wydarzenieRepository.FindAllWydarzenie(), "WydarzenieId", "NazwaWydarzenia").ToList();
            ViewData["wydarzenieList"] = wydarzenieList;

            List<SelectListItem> StatusList = new SelectList(StatusSelectList.StatusList, "Key", "Value").ToList();
            ViewData["StatusList"] = StatusList;


            var wypozyczenie = wypozyczenieRepository.GetWypozyczenieById(id);


            if (TryUpdateModel(wypozyczenie))
            {
                wypozyczenieRepository.Save();
                TempData["okMessage"] = "Wypozyczenie zostało zapisane!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["errorMessage"] = "Wypozyczenie nie zostało zapisane!";
                return View(wypozyczenie);
            }

        }
    }
}