using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WypożyczalniaSamochodówPremium.Models;

namespace WypożyczalniaSamochodówPremium.Controllers
{
    [Authorize]
    public class RentController : Controller
    {
        WypozyczenieRepository wypozyczenieRepository = new WypozyczenieRepository();
        WypozyczenieTempRepository wypozyczenieTempRepository = new WypozyczenieTempRepository();
        WydarzenieRepository wydarzenieRepository = new WydarzenieRepository();
        OsobaRepository osobaRepository = new OsobaRepository();
        // GET: Rent
        public ActionResult RentCar()
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            var osoba = osobaRepository.GetOsobaByHash(user.UserHash);

            if (osoba.Adres == null || osoba.DataUrodzenia == null || osoba.KodPocztowy == null || osoba.Kraj == null || osoba.NrTelefonu == null || osoba.Miasto == null)
            {
                return View("AddYourPersonalData");
            }

            var wypTemp = wypozyczenieTempRepository.FindWypozyczenieTempForOsobaId(osoba.OsobaId);

            List<SelectListItem> wydarzenieList = new SelectList(wydarzenieRepository.FindAllWydarzenie(), "WydarzenieId", "NazwaWydarzenia").ToList();
            ViewData["wydarzenieList"] = wydarzenieList;

            RentCarViewModel rentCar = new RentCarViewModel();
            rentCar.CarInCartList = wypTemp;
            rentCar.DataWypozyczenia = wypTemp.FirstOrDefault().DataWypozyczenia;
            rentCar.DataZwrotu = wypTemp.FirstOrDefault().DataZwrotu;
            rentCar.Osoba = osoba;

            return View(rentCar);
        }

        [HttpPost]
        public ActionResult RentCar(RentCarViewModel rentCar, FormCollection collection)
        {

            return View();
        }

        public ActionResult Summary()
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            var osoba = osobaRepository.GetOsobaByHash(user.UserHash);
            var wypTemp = wypozyczenieTempRepository.FindWypozyczenieTempForOsobaId(osoba.OsobaId);
            if(wypTemp.Count()==0)
            {
                return RedirectToAction("SearchCar","Cars");
            }

            RentCarViewModel rentCar = new RentCarViewModel();
            rentCar.CarInCartList = wypTemp;
            rentCar.Osoba = osoba;
            rentCar.DataWypozyczenia = wypTemp.FirstOrDefault().DataWypozyczenia;
            rentCar.DataZwrotu = wypTemp.FirstOrDefault().DataZwrotu;

            return View(rentCar);
        }

        public ActionResult DeleteAjax(int id, FormCollection collection)
        {
            var model = wypozyczenieTempRepository.GetWypozyczenieTempById(id);
            return PartialView("Delete", model);
        }

        // POST: Adm/ProgramRoom/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var model = wypozyczenieTempRepository.GetWypozyczenieTempById(id);


            try
            {
                wypozyczenieTempRepository.Delete(model);
                wypozyczenieTempRepository.Save();


                return RedirectToAction("Summary", "Rent");
            }
            catch
            {
                TempData["errorMessage"] = "Nie usunięto usługi!";
                return View();
            }
        }

    }
}