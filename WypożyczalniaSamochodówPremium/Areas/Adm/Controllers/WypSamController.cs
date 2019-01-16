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
        WypSamRepository wypSamRepository = new WypSamRepository();
        // GET: Adm/WypSam
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateAjax()
        {

            return View(); 
        }
        public ActionResult DeleteSamochodAjax(int id)
        {
            var model = wypSamRepository.GetWypSamById(id);
            return PartialView("_DeleteSamochodAjax", model);
        }
        [HttpPost]
        public ActionResult DeleteSamochodAjax(int id, FormCollection collection)
        {

            var model = wypSamRepository.GetWypSamById(id);
            var WypozyczenieId = model.WypozyczenieId;
            try
            {
                wypSamRepository.Delete(model);
                wypSamRepository.Save();
                TempData["okMessage"] = "Usuwanie powiodło się!";
                return RedirectToAction("SamochodyForWypozyczenie","Samochod", new {id = WypozyczenieId });
            }
            catch (Exception)
            {
                TempData["errorMessage"] = "Usuwanie nie powiodło się!";
                return View();
            }
        }
    }
}