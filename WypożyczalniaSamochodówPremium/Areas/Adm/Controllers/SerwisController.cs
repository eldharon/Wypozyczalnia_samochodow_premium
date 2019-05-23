using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WypożyczalniaSamochodówPremium.Models;

namespace WypożyczalniaSamochodówPremium.Areas.Adm.Controllers
{
    [Authorize(Roles = "Admin, Manager, Employee")]
    public class SerwisController : Controller
    {
        SerwisRepository serwisRepository = new SerwisRepository();
        DostepnoscRepository dostepnoscRepository = new DostepnoscRepository();
       
        public ActionResult Index(int? idS)
        {
            if(idS.HasValue)
            {
                return RedirectToAction("ShowSerwisyForSamochod", new { id = idS.Value});
            }
            else
            {
                var model = serwisRepository.FindAllSerwis();
                return View(model);

            }
        }

        public ActionResult ShowSerwisyForSamochod(int id)
        {
            var model = serwisRepository.ShowSerwisyForSamochod(id);
            ViewBag.SamochodId = id;
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var serwis = serwisRepository.GetUSeriwsById(id);
            return View(serwis);
        }


        public ActionResult Create(int id)
        {
            Serwis serwis = new Serwis();
            serwis.SamochodId = id;
            return View(serwis);
        }


        [HttpPost]
        public ActionResult Create(Serwis serwis, FormCollection collection)
        {
            var samid = serwis.SamochodId;
            Dostepnosc dostepnosc = new Dostepnosc();
            dostepnosc.NiedostepnyOd = serwis.DataOddania;
            dostepnosc.NiedostepnyDo = serwis.DataOdbioru;
            dostepnosc.SamochodId = serwis.SamochodId;

            if (ModelState.IsValid)
            {
                dostepnoscRepository.Add(dostepnosc);
                dostepnoscRepository.Save();

                serwisRepository.Add(serwis);
                serwisRepository.Save();



                TempData["okMessage"] = "Serwis został zapisany.";
                return RedirectToAction("ShowSerwisyForSamochod", "Serwis", new { id = samid });
            }
            else
            {
                TempData["errorMessage"] = "Nie dodano serwisu";
                return View(serwis);
            }
        }


        public ActionResult Edit(int id)
        {
            Serwis serwis = serwisRepository.GetUSeriwsById(id);
            return View(serwis);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            
            Serwis serwis = serwisRepository.GetUSeriwsById(id);
            var samid = serwis.SamochodId;
            if (TryUpdateModel(serwis))
            {
                serwisRepository.Save();
                TempData["okMessage"] = "Serwis został zapisany.";
                return RedirectToAction("ShowSerwisyForSamochod","Serwis", new { id = samid });
            }
            else
            {
                TempData["errorMessage"] = "Serwis nie został zapisany!";
                return View(serwis);
            }
        }


        public ActionResult Delete(int id)
        {
            var serwis = serwisRepository.GetUSeriwsById(id);
            return View(serwis);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            var serwis = serwisRepository.GetUSeriwsById(id);
            var samid = serwis.SamochodId;

            var dostepnosc = dostepnoscRepository.GetDostepnoscByDate(serwis.DataOddania, serwis.DataOdbioru);
            try
            {
                dostepnoscRepository.Delete(dostepnosc);
                dostepnoscRepository.Save();

                serwisRepository.Delete(serwis);
                serwisRepository.Save();
                TempData["okMessage"] = "Usunięto Serwis!";
                return RedirectToAction("ShowSerwisyForSamochod", "Serwis", new { id = samid });
            }
            catch (Exception e)
            {
                TempData["errorMessage"] = "Wystąpił błąd : " + e;
                return RedirectToAction("ShowSerwisyForSamochod", "Serwis", new { id = samid });
            }
        }
    }
}