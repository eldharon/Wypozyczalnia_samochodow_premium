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
    }
}