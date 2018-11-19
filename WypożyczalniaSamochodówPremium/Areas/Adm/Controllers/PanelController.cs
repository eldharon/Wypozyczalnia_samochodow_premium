using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WypożyczalniaSamochodówPremium.Areas.Adm.Controllers
{
    public class PanelController : Controller
    {
        // GET: Adm/Panel
        public ActionResult Index()
        {
            return View();
        }
    }
}