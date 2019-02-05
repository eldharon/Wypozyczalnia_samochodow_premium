using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WypożyczalniaSamochodówPremium.Models;

namespace WypożyczalniaSamochodówPremium.Areas.Adm.Controllers
{
    [Authorize(Roles = "Admin, Manager, Employee")]
    public class RozliczenieController : Controller
    {
        RozliczenieRepository rozliczenieRepository = new RozliczenieRepository();
        // GET: Adm/Wydarzenie
        public ActionResult Index()
        {
            var model = rozliczenieRepository.FindAllRozliczenia();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var wydarzenie = rozliczenieRepository.GetRozliczeniaById(id);
            return View(wydarzenie);
        }
    }
}