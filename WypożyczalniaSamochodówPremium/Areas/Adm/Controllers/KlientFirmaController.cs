using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WypożyczalniaSamochodówPremium.Models;

namespace WypożyczalniaSamochodówPremium.Areas.Adm.Controllers
{
    [Authorize(Roles = "Admin, Manager, Employee")]
    public class KlientFirmaController : Controller
    {
        KlientFirmaRepository klientfirmaRepository = new KlientFirmaRepository();
        // GET: Adm/Wydarzenie
        public ActionResult Index()
        {
            var model = klientfirmaRepository.GetAllKlienciFirmy();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var wydarzenie = klientfirmaRepository.GetKlientFirmaById(id);
            return View(wydarzenie);
        }
    }
}