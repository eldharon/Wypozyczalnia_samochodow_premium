using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WypożyczalniaSamochodówPremium.Models;

namespace WypożyczalniaSamochodówPremium.Controllers
{
    public class CarsController : Controller
    {
        SamochodRepository samochodyRepository = new SamochodRepository();
        // GET: Cars
        public ActionResult Index()
        {
            var model = samochodyRepository.FindAllSamochod().OrderBy(m => m.Marka);
            return View(model);
        }
    }
}