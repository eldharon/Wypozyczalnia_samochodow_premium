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
    }
}