using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WypożyczalniaSamochodówPremium.Models;

namespace WypożyczalniaSamochodówPremium.Areas.Adm.Controllers
{
    public class AutaBazaController : Controller
    {
        AutaBazaRepository autaBazaRepository = new AutaBazaRepository();
        // GET: Adm/AutaBaza
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            AutaBaza model = new AutaBaza();
            return PartialView("Create", model);
        }

        [HttpPost]
        public ActionResult Create(AutaBaza autaBaza, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    autaBazaRepository.Add(autaBaza);
                    autaBazaRepository.Save();

                    return RedirectToAction("Create", "Samochod");
                }
                catch
                {
                    return PartialView("Create", autaBaza);
                }
            }
            else
            {
                return PartialView("Create", autaBaza);
            }
        }
    }
}