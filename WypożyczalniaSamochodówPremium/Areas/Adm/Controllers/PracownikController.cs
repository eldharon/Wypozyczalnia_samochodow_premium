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
        // GET: Adm/Wydarzenie
        public ActionResult Index()
        {
            var model = pracownikRepository.FindAllPracownik();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var wydarzenie = pracownikRepository.GetPracownikById(id);
            return View(wydarzenie);
        }
    }
}