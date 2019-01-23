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
        // GET: Cars
        public ActionResult Index()
        {
            var model = samochodyRepository.FindAllSamochod().OrderBy(m => m.Marka);


            foreach (var item in model)
            {
                if(imageSamochodRepository.GetDefaultImageIdForSamochodId(item.SamochodId) != null)
                {
                    item.PhotoId = imageSamochodRepository.GetDefaultImageIdForSamochodId(item.SamochodId).ImageId;
                }

            }
            return View(model);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult RentCar(int id)
        {
            return View();
        }

        public ActionResult SearchCar()
        {
            return View();
        }
    }
}