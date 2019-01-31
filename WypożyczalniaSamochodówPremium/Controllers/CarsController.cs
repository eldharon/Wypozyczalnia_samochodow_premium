using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WypożyczalniaSamochodówPremium.Models;

namespace WypożyczalniaSamochodówPremium.Controllers
{


    public class CarsController : Controller
    {
        SamochodRepository samochodyRepository = new SamochodRepository();
        ImageSamochodRepository imageSamochodRepository = new ImageSamochodRepository();
        WypozyczenieRepository wypozyczenieRepository = new WypozyczenieRepository();
        OsobaRepository osobaRepository = new OsobaRepository();
        WypozyczenieTempRepository wypozyczenieTempRepository = new WypozyczenieTempRepository();
        OpisRepository opisRepository = new OpisRepository();

        public object PagedList { get; private set; }

        // GET: Cars
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.MarkaSortParm = String.IsNullOrEmpty(sortOrder) ? "Marka_desc" : "";
            ViewBag.ModelSortParm = sortOrder == "Model" ? "Model_desc" : "Model";

            var model = samochodyRepository.FindAllSamochod();
            var opisy = opisRepository.GetAllOpisy();
            var images = imageSamochodRepository.FindAllImages();

            foreach (var item in model)
            {
                item.opisy = opisy.Where(s => s.SamochodId == item.SamochodId);
                item.photos = images.Where(s => s.SamochodId == item.SamochodId);
            }

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Marka.Contains(searchString) || x.Model.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Marka_desc":
                    model = model.OrderByDescending(s => s.Marka);
                    break;
                case "Model":
                    model = model.OrderBy(s => s.Model);
                    break;
                case "Model_desc":
                    model = model.OrderByDescending(s => s.Model);
                    break;
                default:
                    model = model.OrderBy(s => s.Marka);
                    break;
            }


            int pageSize = 12;
            int pageNumber = (page ?? 1);

            return View(model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult DetailsAjax(int id)
        {
            var samochod = samochodyRepository.GetSamochodById(id);
            var opisy = opisRepository.GetOpisForSamochodId(id);
            var images = imageSamochodRepository.FindImegerForSamochodId(id);
            samochod.opisy = opisy;
            samochod.photos = images;
            
        

            return PartialView("_Details", samochod);
        }

        public ActionResult Details(int id)
        {
            var samochod = samochodyRepository.GetSamochodById(id);
            var opisy = opisRepository.GetOpisForSamochodId(id);
            var images = imageSamochodRepository.FindImegerForSamochodId(id);
            samochod.opisy = opisy;
            samochod.photos = images;



            return View(samochod);
        }

        [Authorize]
        public ActionResult SearchCar()
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            var osoba = osobaRepository.GetOsobaByHash(user.UserHash);
            SearchViewModel searchViewModel = new SearchViewModel();

            searchViewModel.wypTemp = wypozyczenieTempRepository.FindWypozyczenieTempForOsobaId(osoba.OsobaId);

            if (searchViewModel.wypTemp.Count() > 0)
            {
                searchViewModel.dataWyp = searchViewModel.wypTemp.FirstOrDefault().DataWypozyczenia;
                searchViewModel.dataZwr = searchViewModel.wypTemp.FirstOrDefault().DataZwrotu;
            }
            else
            {
                searchViewModel.dataWyp = DateTime.Now.AddDays(1);
                searchViewModel.dataZwr = DateTime.Now.AddDays(8);
            }
            ViewBag.OsobaId = osobaRepository.GetOsobaByHash(user.UserHash).OsobaId;

            return View(searchViewModel);
        }

        [Authorize]
        [AllowAnonymous]
        [HttpPost]
        public ActionResult SearchCar(SearchViewModel svm, FormCollection collection)
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            var osoba = osobaRepository.GetOsobaByHash(user.UserHash);


            return RedirectToAction("CarsForTimeRange", "Cars", new { dataWyp = svm.dataWyp, dataZwr = svm.dataZwr });
        }


        [Authorize]
        [AllowAnonymous]
        public ActionResult CarsForTimeRange(int? page, DateTime dataWyp, DateTime dataZwr)
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            var osoba = osobaRepository.GetOsobaByHash(user.UserHash);
            var wypTemp = wypozyczenieTempRepository.FindWypozyczenieTempForOsobaId(osoba.OsobaId);

            if (wypTemp.Count() > 0)
            {
                int pageSize = 18;
                int pageNumber = page ?? 1;

                var list = wypozyczenieRepository.FindCarsForTimeRange(dataWyp, dataZwr, osoba.OsobaId).ToList().ToPagedList(pageNumber, pageSize);

                foreach (var item in list)
                {
                        item.photos = imageSamochodRepository.FindAllImages().Where(x => x.SamochodId == item.SamochodId);
                }

                ViewBag.dataWyp = wypTemp.FirstOrDefault().DataWypozyczenia;
                ViewBag.dataZwr = wypTemp.FirstOrDefault().DataZwrotu;

                

                return PartialView("CarsForTimeRange", list);
            }
            else
            {

                int pageSize = 18;
                int pageNumber = page ?? 1;

                var list = wypozyczenieRepository.FindCarsForTimeRange(dataWyp, dataZwr, osoba.OsobaId).ToList().ToPagedList(pageNumber, pageSize);

                foreach (var item in list)
                {
                        item.photos = imageSamochodRepository.FindAllImages().Where(x => x.SamochodId == item.SamochodId);
                }

                ViewBag.dataWyp = dataWyp;
                ViewBag.dataZwr = dataZwr;

                

                return PartialView("CarsForTimeRange", list);
            }

        }

        [Authorize]
        [AllowAnonymous]
        public ActionResult CarInCart()
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            var osoba = osobaRepository.GetOsobaByHash(user.UserHash);

            var wypTemp = wypozyczenieTempRepository.FindWypozyczenieTempForOsobaId(osoba.OsobaId);

            return PartialView("_CarInCart", wypTemp);
        }

        [Authorize]
        [AllowAnonymous]
        public ActionResult DeleteCarFromCart()
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            var osoba = osobaRepository.GetOsobaByHash(user.UserHash);

            var wypTemp = wypozyczenieTempRepository.FindWypozyczenieTempForOsobaId(osoba.OsobaId);

            try
            {
                foreach (var item in wypTemp)
                {
                    wypozyczenieTempRepository.Delete(item);
                }
                wypozyczenieTempRepository.Save();
            }
            catch
            {
                return RedirectToAction("SearchCar", "Cars");
            }

            return RedirectToAction("SearchCar", "Cars");
        }

        [Authorize]
        [AllowAnonymous]
        public ActionResult AddCarToCart(int samId, DateTime dataWyp, DateTime dataZwr)
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            var osoba = osobaRepository.GetOsobaByHash(user.UserHash);

            var wypTemp = wypozyczenieTempRepository.FindWypozyczenieTempForOsobaId(osoba.OsobaId);

            if (wypTemp.Count() > 0)
            {
                WypozyczenieTemp wypozyczenieTemp = new WypozyczenieTemp();
                wypozyczenieTemp.DataWypozyczenia = wypTemp.FirstOrDefault().DataWypozyczenia;
                wypozyczenieTemp.DataZwrotu = wypTemp.FirstOrDefault().DataZwrotu;
                wypozyczenieTemp.SamochodId = samId;
                wypozyczenieTemp.OsobaId = osoba.OsobaId;

                try
                {
                    wypozyczenieTempRepository.Add(wypozyczenieTemp);
                    wypozyczenieTempRepository.Save();

                    return RedirectToAction("SearchCar");
                }
                catch
                {
                    return View("Error");
                }
            }
            else
            {
                WypozyczenieTemp wypozyczenieTemp = new WypozyczenieTemp();
                wypozyczenieTemp.DataWypozyczenia = dataWyp;
                wypozyczenieTemp.DataZwrotu = dataZwr;
                wypozyczenieTemp.SamochodId = samId;
                wypozyczenieTemp.OsobaId = osoba.OsobaId;

                try
                {
                    wypozyczenieTempRepository.Add(wypozyczenieTemp);
                    wypozyczenieTempRepository.Save();

                    return RedirectToAction("SearchCar");
                }
                catch
                {
                    return View("Error");
                }
            }

        }

    }
}