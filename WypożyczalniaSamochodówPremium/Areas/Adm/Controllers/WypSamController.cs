using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WypożyczalniaSamochodówPremium.Models;

namespace WypożyczalniaSamochodówPremium.Areas.Adm.Controllers
{
    public class WypSamController : Controller
    {
        WypozyczenieRepository wypozyczenieRepository = new WypozyczenieRepository();
        // GET: Adm/WypSam
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateAjax()
        {

            return View(); 
        }
    }
}