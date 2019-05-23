using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WypożyczalniaSamochodówPremium.Models;

namespace WypożyczalniaSamochodówPremium.Areas.Adm.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
    public class PracownikController : Controller
    {
        PracownikRepository pracownikRepository = new PracownikRepository();
        OsobaRepository osobaRepository = new OsobaRepository();

        // GET: Adm/Wydarzenie
        public ActionResult Index()
        {
            var model = pracownikRepository.FindAllPracownik();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var pracownik = pracownikRepository.GetPracownikById(id);
            return View(pracownik);
        }

        public ActionResult Create(Guid UserHash)
        {
            List<SelectListItem> stanowiskoList = new SelectList(PracownikSelectList.StanowikoList, "Key", "Value").ToList();
            ViewData["stanowiskoList"] = stanowiskoList;

            var osoba = osobaRepository.GetOsobaByHash(UserHash);

            Pracownik pracownik = new Pracownik();
            pracownik.OsobaId = osoba.OsobaId;

            return View(pracownik);
        }

        [HttpPost]
        public ActionResult Create (Pracownik pracownik, FormCollection collection)
        {
            if(ModelState.IsValid)
            {
                pracownikRepository.Add(pracownik);
                pracownikRepository.Save();

                TempData["okMessage"] = "Pracownik został zapisany";
                return RedirectToAction("Index");
            }
            else
            {
                return View(pracownik);
            }
        }

        public ActionResult Edit(int id)
        {
            List<SelectListItem> stanowiskoList = new SelectList(PracownikSelectList.StanowikoList, "Key", "Value").ToList();
            ViewData["stanowiskoList"] = stanowiskoList;

            var pracownik = pracownikRepository.GetPracownikById(id);

            return View(pracownik);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            List<SelectListItem> stanowiskoList = new SelectList(PracownikSelectList.StanowikoList, "Key", "Value").ToList();
            ViewData["stanowiskoList"] = stanowiskoList;

            var pracownik = pracownikRepository.GetPracownikById(id);

            if(TryUpdateModel(pracownik))
            {
                pracownikRepository.Save();

                TempData["okMessage"] = "Pracownik został zapisany";
                return RedirectToAction("Index");
            }
            else
            {
                return View(pracownik);
            }


        }



    }
}