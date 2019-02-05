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
        DostepnoscRepository dostepnoscRepository = new DostepnoscRepository();
        WypSamRepository wypSamRepository = new WypSamRepository();
        RozliczenieRepository rozliczenieRepository = new RozliczenieRepository();
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
            var lengthOfRent = wypTemp.FirstOrDefault().DataZwrotu.Date.Day - wypTemp.FirstOrDefault().DataWypozyczenia.Date.Day;


            List<SelectListItem> wydarzenieList = new SelectList(wydarzenieRepository.FindAllWydarzenie(), "WydarzenieId", "NazwaWydarzenia").ToList();
            ViewData["wydarzenieList"] = wydarzenieList;

            RentCarViewModel rentCar = new RentCarViewModel();
            rentCar.CarInCartList = wypTemp;

            foreach (var item in rentCar.CarInCartList)
            {
                if (item.Samochod.Cennik.Count() > 0)
                {
                    if (lengthOfRent < 7)
                    {
                        if (item.Samochod.Cennik.Where(c => c.Opis == "dzien").Count() > 0)
                        {
                            item.PricePerDay = (item.Samochod.Cennik.Where(c => c.Opis == "dzien").SingleOrDefault().Cena);
                            rentCar.TotalPrice += item.PricePerDay * lengthOfRent;
                        }
                    }
                    else if (lengthOfRent >= 7 && lengthOfRent < 30)
                    {
                        if (item.Samochod.Cennik.Where(c => c.Opis == "tydzien").Count() > 0)
                        {
                            item.PricePerDay = (item.Samochod.Cennik.Where(c => c.Opis == "tydzien").SingleOrDefault().Cena);
                            rentCar.TotalPrice += item.PricePerDay * lengthOfRent;

                        }
                    }
                    else if (lengthOfRent >= 30)
                    {
                        if (item.Samochod.Cennik.Where(c => c.Opis == "miesiac").Count() > 0)
                        {
                            item.PricePerDay = (item.Samochod.Cennik.Where(c => c.Opis == "miesiac").SingleOrDefault().Cena);
                            rentCar.TotalPrice += item.PricePerDay * lengthOfRent;

                        }
                    }
                }
            }

            rentCar.DataWypozyczenia = wypTemp.FirstOrDefault().DataWypozyczenia;
            rentCar.DataZwrotu = wypTemp.FirstOrDefault().DataZwrotu;
            rentCar.OsobaId = osoba.OsobaId;

            return View(rentCar);
        }

        [HttpPost]
        public ActionResult RentCar(RentCarViewModel rcv, FormCollection collection)
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            var osoba = osobaRepository.GetOsobaByHash(user.UserHash);

            var wypTemp = wypozyczenieTempRepository.FindWypozyczenieTempForOsobaId(osoba.OsobaId);
            Wypozyczenie wypozyczenie = new Wypozyczenie();

            rcv.DataWypozyczenia = wypTemp.FirstOrDefault().DataWypozyczenia;
            rcv.DataZwrotu = wypTemp.FirstOrDefault().DataZwrotu;
            rcv.OsobaId = osoba.OsobaId;
            rcv.CarInCartList = wypTemp;



            if (ModelState.IsValid)
            {
                wypozyczenie.OsobaId = rcv.OsobaId;
                wypozyczenie.DataWypozyczenia = rcv.DataWypozyczenia;
                wypozyczenie.DataZwrotu = rcv.DataZwrotu;
                wypozyczenie.CzyDostarczany = rcv.CzyDostarczany;
                wypozyczenie.CzyKierowca = rcv.CzyKierowca;
                wypozyczenie.AdresDojazdu = rcv.AdresDojazdu;
                wypozyczenie.WydarzenieId = rcv.WydarzenieId;

                wypozyczenieRepository.Add(wypozyczenie);
                wypozyczenieRepository.Save();

                
                //wypozyczenie.MetodaPlatnosci = rcv.PaymentMethod; <<-- Nie ma takiego pola w bazie
                
                foreach (var item in rcv.CarInCartList)
                {

                    Dostepnosc dostepnosc = new Dostepnosc();
                    dostepnosc.NiedostepnyOd = rcv.DataWypozyczenia;
                    dostepnosc.NiedostepnyDo = rcv.DataZwrotu;
                    dostepnosc.SamochodId = item.SamochodId;

                    dostepnoscRepository.Add(dostepnosc);

                    Rozliczenie rozliczenie = new Rozliczenie();
                    rozliczenie.WypozyczenieId = wypozyczenie.WypozyczenieId;
                    rozliczenie.Zaliczka = 0;
                    rozliczenie.CalkowityKoszt = rcv.TotalPrice;

                    rozliczenieRepository.Add(rozliczenie);

                }
                dostepnoscRepository.Save();
                rozliczenieRepository.Save();

                foreach (var item in wypTemp)
                {
                    WypSam wypSam = new WypSam();
                    wypSam.SamochodId = item.SamochodId;
                    wypSam.WypozyczenieId = wypozyczenie.WypozyczenieId;

                    wypSamRepository.Add(wypSam);

                }
                wypSamRepository.Save();



                var wypTempForDate = wypozyczenieTempRepository.FindAllWypozyczenieTempForDate(rcv.DataWypozyczenia, rcv.DataZwrotu);

                foreach (var item in wypTempForDate)
                {
                    wypozyczenieTempRepository.Delete(item);
                }

                //foreach (var item in wypTemp)
                //{
                //    wypozyczenieTempRepository.Delete(item);
                //}

                wypozyczenieTempRepository.Save();
                

                return RedirectToAction("RentDetails", new {id =  wypozyczenie.WypozyczenieId});
            }
            else
            {
                return View();
            }
        }

        public ActionResult RentDetails(int id)
        {
            var wypozyczenie = wypozyczenieRepository.GetWypozyczenieById(id);
            wypozyczenie.wypSamList = wypSamRepository.FindWypSamForIdWypozyczenie(wypozyczenie.WypozyczenieId);

            return View(wypozyczenie);
        }

        public ActionResult RentList()
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            var osoba = osobaRepository.GetOsobaByHash(user.UserHash);

            var model = wypozyczenieRepository.FindAllWypozyczeniaForOsobaId(osoba.OsobaId); 

            return View(model);
        }

        public ActionResult Summary()
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            var osoba = osobaRepository.GetOsobaByHash(user.UserHash);
            var wypTemp = wypozyczenieTempRepository.FindWypozyczenieTempForOsobaId(osoba.OsobaId);

            if (wypTemp.Count() == 0)
            {
                return RedirectToAction("SearchCar", "Cars");
            }

            var lengthOfRent = wypTemp.FirstOrDefault().DataZwrotu.Date.Day - wypTemp.FirstOrDefault().DataWypozyczenia.Date.Day;

            

            RentCarViewModel rentCar = new RentCarViewModel();
            rentCar.CarInCartList = wypTemp;
            foreach (var item in rentCar.CarInCartList)
            {
                if (item.Samochod.Cennik.Count() > 0)
                {
                    if (lengthOfRent < 7)
                    {
                        if (item.Samochod.Cennik.Where(c => c.Opis == "dzien").Count() > 0)
                        {
                            item.PricePerDay = (item.Samochod.Cennik.Where(c => c.Opis == "dzien").SingleOrDefault().Cena);
                            rentCar.TotalPrice += item.PricePerDay * lengthOfRent;
                        }
                    }
                    else if (lengthOfRent >= 7 && lengthOfRent < 30)
                    {
                        if (item.Samochod.Cennik.Where(c => c.Opis == "tydzien").Count() > 0)
                        {
                            item.PricePerDay = (item.Samochod.Cennik.Where(c => c.Opis == "tydzien").SingleOrDefault().Cena);
                            rentCar.TotalPrice += item.PricePerDay * lengthOfRent;
                        }
                    }
                    else if (lengthOfRent >= 30)
                    {
                        if (item.Samochod.Cennik.Where(c => c.Opis == "miesiac").Count() > 0)
                        {
                            item.PricePerDay = (item.Samochod.Cennik.Where(c => c.Opis == "miesiac").SingleOrDefault().Cena);
                            rentCar.TotalPrice += item.PricePerDay * lengthOfRent;
                        }
                    }
                }
            }
            
            rentCar.OsobaId = osoba.OsobaId;
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