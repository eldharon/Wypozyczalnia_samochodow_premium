using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WypożyczalniaSamochodówPremium.Models;

namespace WypożyczalniaSamochodówPremium.Areas.Adm.Controllers
{
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

        public ActionResult Create()
        {
            List<SelectListItem> stanowiskoList = new SelectList(PracownikSelectList.StanowikoList, "Key", "Value").ToList();
            ViewData["stanowiskoList"] = stanowiskoList;

            List<SelectListItem> osobaList = new SelectList(osobaRepository.FindAllOsoba(), "OsobaId", "Nazwisko").ToList();
            ViewData["osobaList"] = osobaList;


            Pracownik pracownik = new Pracownik();

            return View(pracownik);
        }


    }
}