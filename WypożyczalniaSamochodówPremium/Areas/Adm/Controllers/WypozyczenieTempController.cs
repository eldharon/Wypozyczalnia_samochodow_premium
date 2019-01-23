using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WypożyczalniaSamochodówPremium.Models;

namespace WypożyczalniaSamochodówPremium.Areas.Adm.Controllers
{
    public class WypozyczenieTempController : Controller
    {
        WypozyczenieTempRepository wypozyczenieTempRepository = new WypozyczenieTempRepository();
        // GET: Adm/WypozyczenieTemp
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DeleteAjax(int id, FormCollection collection)
        {
            var model = wypozyczenieTempRepository.GetWypozyczenieTempById(id);
            return PartialView("_Delete", model);
        }

        // POST: Adm/ProgramRoom/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var model = wypozyczenieTempRepository.GetWypozyczenieTempById(id);
            var Osobaid = model.OsobaId;

            try
            {
                wypozyczenieTempRepository.Delete(model);
                wypozyczenieTempRepository.Save();


                return RedirectToAction("SamochodyForWypozyczenieTemp", "Samochod", new { osobaId = Osobaid });
            }
            catch
            {
                TempData["errorMessage"] = "Nie usunięto usługi!";
                return View();
            }
        }
    }
}