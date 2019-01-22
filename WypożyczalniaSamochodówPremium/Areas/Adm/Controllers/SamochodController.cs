using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WypożyczalniaSamochodówPremium.Models;

namespace WypożyczalniaSamochodówPremium.Areas.Adm.Controllers
{
    public class SamochodController : Controller
    {
        SamochodRepository samochodRepository = new SamochodRepository();
        AutaBazaRepository autaBazaRepository = new AutaBazaRepository();
        ModelRepository modelRepository = new ModelRepository();
        WypozyczenieRepository wypozyczenieRepository = new WypozyczenieRepository();
        WypSamRepository wypSamRepository = new WypSamRepository();
        ImageSamochodRepository imageSamochodRepository = new ImageSamochodRepository();
        ImageRepository imageRepository = new ImageRepository();



        // GET: Samochod
        public ActionResult Index()
        {
            var samochod = samochodRepository.FindAllSamochod();
            return View(samochod);
        }

        public ActionResult Details(int id)
        {
            var samochod = samochodRepository.GetSamochodById(id);

            return View(samochod);
            
        }

        public ActionResult Create()
        {
            var MarkiSelectList = autaBazaRepository.GetAllMarki().Select(x => new SelectListItem() { Value = x, Text = x }).ToList();
            ViewData["Marka"] = MarkiSelectList;

            var ModeleSelectList = new List<string>().Select(x => new SelectListItem() { Value = x, Text = x }).ToList();
            ViewData["Model"] = ModeleSelectList;

            var RodzajSkrzyniSelectList = SamochodSelectLists.RodzajSkrzyniList.Select(x => new SelectListItem() { Value = x, Text = x }).ToList();
            ViewData["SkrzyniaBiegow"] = RodzajSkrzyniSelectList;

            var LiczbaDrzwiSelectList = SamochodSelectLists.LiczbaDrzwiList.Select(x => new SelectListItem() { Value = x, Text = x }).ToList();
            ViewData["LiczbaDrzwi"] = LiczbaDrzwiSelectList;

            var RodzajSilnikaSelectList = SamochodSelectLists.PaliwaList.Select(x => new SelectListItem() { Value = x, Text = x }).ToList();
            ViewData["RodzajSilnika"] = RodzajSilnikaSelectList;

            Samochod samochod = new Samochod();

            return View(samochod);
        }

        [HttpPost]
        public ActionResult Create(Samochod samochod, FormCollection collection)
        {

            var MarkiSelectList = autaBazaRepository.GetAllMarki().Select(x => new SelectListItem() { Value = x, Text = x }).ToList();
            ViewData["Marka"] = MarkiSelectList;

            var ModeleSelectList = new List<string>().Select(x => new SelectListItem() { Value = x, Text = x }).ToList();
            ViewData["Model"] = ModeleSelectList;

            var RodzajSkrzyniSelectList = SamochodSelectLists.RodzajSkrzyniList.Select(x => new SelectListItem() { Value = x, Text = x }).ToList();
            ViewData["SkrzyniaBiegow"] = RodzajSkrzyniSelectList;

            var LiczbaDrzwiSelectList = SamochodSelectLists.LiczbaDrzwiList.Select(x => new SelectListItem() { Value = x, Text = x }).ToList();
            ViewData["LiczbaDrzwi"] = LiczbaDrzwiSelectList;

            var RodzajSilnikaSelectList = SamochodSelectLists.PaliwaList.Select(x => new SelectListItem() { Value = x, Text = x }).ToList();
            ViewData["RodzajSilnika"] = RodzajSilnikaSelectList;
            //samochod.Marka = collection.
            //samochod.SkrzyniaBiegow = ViewData["SkrzyniaBiegow"].ToString();
            //samochod.LiczbaDrzwi = ViewData["LiczbaDrzwi"].ToString();
            //samochod.RodzajSilnika = ViewData["RodzajSilnika"].ToString();


            if (ModelState.IsValid)
            {
                samochodRepository.Add(samochod);
                samochodRepository.Save();

                TempData["okMessage"] = "Samochod: " + samochod.Marka + " " + samochod.Model + " został zapisany";
                return RedirectToAction("Index");
            }
            else
            {
                return View(samochod);
            }
        }

        public ActionResult Edit(int id)
        {
            var samochod = samochodRepository.GetSamochodById(id);
            var autoVM = new SamochodVM();
            autoVM.Samochod = samochod;
            List<AutaBazaSelectListDTO> LisMar = new List<AutaBazaSelectListDTO>();
            foreach (var item in autaBazaRepository.GetAllMarki())
            {
                AutaBazaSelectListDTO a = new AutaBazaSelectListDTO();
                a.Marka = item;
                LisMar.Add(a);
            } 
            var MarkiList = new SelectList(LisMar, "Marka", "Marka");
            autoVM.ListaMarki = MarkiList;

            var ModeleList = new SelectList(autaBazaRepository.GetModelsForMake(samochod.Marka), "Model", "Model");
            autoVM.ListaModele = ModeleList;

            var RodzajSkrzyniSelectList = SamochodSelectLists.RodzajSkrzyniList.Select(x => new SelectListItem() { Value = x, Text = x }).ToList();
            ViewData["SkrzyniaBiegow"] = RodzajSkrzyniSelectList;

            var LiczbaDrzwiSelectList = SamochodSelectLists.LiczbaDrzwiList.Select(x => new SelectListItem() { Value = x, Text = x }).ToList();
            ViewData["LiczbaDrzwi"] = LiczbaDrzwiSelectList;

            var RodzajSilnikaSelectList = SamochodSelectLists.PaliwaList.Select(x => new SelectListItem() { Value = x, Text = x }).ToList();
            ViewData["RodzajSilnika"] = RodzajSilnikaSelectList;


            ViewBag.Marki = samochod.Model;
            ViewBag.Modele = samochod.Marka;

            return View(autoVM);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var samochod = samochodRepository.GetSamochodById(id);
            //var MarkiSelectList = autaBazaRepository.GetAllMarki().Select(x => new SelectListItem() { Value = x, Text = x }).ToList();
            //ViewData["Marka"] = MarkiSelectList;

            //var ModeleSelectList = new List<string>().Select(x => new SelectListItem() { Value = x, Text = x }).ToList();
            //ViewData["Model"] = ModeleSelectList;
            
            var RodzajSkrzyniSelectList = SamochodSelectLists.RodzajSkrzyniList.Select(x => new SelectListItem() { Value = x, Text = x }).ToList();
            ViewData["SkrzyniaBiegow"] = RodzajSkrzyniSelectList;

            var LiczbaDrzwiSelectList = SamochodSelectLists.LiczbaDrzwiList.Select(x => new SelectListItem() { Value = x, Text = x }).ToList();
            ViewData["LiczbaDrzwi"] = LiczbaDrzwiSelectList;

            var RodzajSilnikaSelectList = SamochodSelectLists.PaliwaList.Select(x => new SelectListItem() { Value = x, Text = x }).ToList();
            ViewData["RodzajSilnika"] = RodzajSilnikaSelectList;


            if(TryUpdateModel(samochod))
            {
                samochodRepository.Save();
                TempData["okMessage"] = "Samochod: " + samochod.Marka + " " + samochod.Model + " został zaaktualizowany";

                return RedirectToAction("Index");
            }
            else
            {
                return View(samochod);
            }

        }

        public ActionResult Delete(int id)
        {
            var auto = samochodRepository.GetSamochodById(id);
            return View(auto);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var auto = samochodRepository.GetSamochodById(id);
                samochodRepository.Delete(auto);
                samochodRepository.Save();
                TempData["okMessage"] = "Usunięto "+auto.Marka+" "+auto.Model+"!";
                return RedirectToAction("Index", "Samochod");
            }
            catch(Exception e)
            {
                TempData["errorMessage"] = "Wystąpił błąd : "+e;
                return RedirectToAction("Index", "Samochod");
            }
        }
        public ActionResult PopulateAutaBaza(FormCollection collection, HttpPostedFileBase file)
        {
            AutaBazaRepository autaBazaRepository = new AutaBazaRepository();
            string extension = Path.GetExtension(file.FileName);
            List<string> ErrorObjects = new List<string>();
            List<AutaBaza> Objects = new List<AutaBaza>();
            if (Path.GetExtension(file.FileName).ToLower() == ".json" && file!=null)
            {
                try
                {
                        List<string> rows = new List<string>();
                        StreamReader reader = new StreamReader(file.InputStream);
                    string record = reader.ReadToEnd();
                        List<AutaBazaDTO> ABD = JsonConvert.DeserializeObject<List<AutaBazaDTO>>(record);
                    foreach (var row in ABD)
                    {
                        foreach (var item in row.models)
                        {
                            AutaBaza Auto = new AutaBaza();
                            Auto.Marka = row.brand; 
                            Auto.Model = item;
                            
                            if (autaBazaRepository.GetRecordByMakeModel(Auto.Marka, Auto.Model).Count()==0) //Przeszukiwanie bazy czy nie ma już takiego rekordu
                            {
                                Objects.Add(Auto);
                            }
                            else
                            {
                                ErrorObjects.Add("Rekord : " + Auto.Marka + ", " + Auto.Model + " figuruje już w bazie danych!");
                            }                        
                        }
                        
                    }
                    if (Objects.Count() > 0)
                    {
                        foreach (var item in Objects)
                        {
                            if (ModelState.IsValid)
                            {
                                autaBazaRepository.Add(item);
                                autaBazaRepository.Save();
                            }
                            else
                            {
                                TempData["errorMessage"] = "Wystąpił błąd przy dodawaniu samochodu "+item.Marka+" "+item.Model+ "; ModelState.IsValid==false!";
                                return RedirectToAction("Index", "Samochod");
                            }
                        }
                       
                        TempData["okMessage"] = "Dodano samochody (" + Objects.Count() + ")";
                        if(ErrorObjects.Count>0)
                        {
                            TempData["okMessage"] += "Pominięto samochody (" + ErrorObjects.Count() + ")";
                        }
                        return RedirectToAction("Index", "Samochod");
                    }
                    else
                    {
                        TempData["errorMessage"] = "Nie dodano żadnych samochodów!";
                        return RedirectToAction("Index", "Samochod");
                    }
                }
                catch(Exception e)
                {
                    TempData["errorMessage"] = "Wystąpił błąd : "+e;
                    return RedirectToAction("Index", "Samochod");
                }
            }
            else
            {
                TempData["errorMessage"] = "Proszę używać tylko plików o formacie .json!";
                return RedirectToAction("Index", "Samochod");
            }
        }

        [HttpGet]
        public ActionResult PopulateMarkiDropdown()
        {
            AutaBazaRepository autaBazaRepository = new AutaBazaRepository();
            return Json(autaBazaRepository.GetAllMarki(), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult PopulateModeleDropdown(string marka)
        {
            if (!string.IsNullOrWhiteSpace(marka))
            {
                return Json(modelRepository.GetModels(marka), JsonRequestBehavior.AllowGet);
            }
            return null;

        }
        public ActionResult PopulateModeleDropdownAJAX(string marka, string startDate, string endDate)
        {
            if (!string.IsNullOrWhiteSpace(marka))
            {
                return Json(wypozyczenieRepository.GetModelsForTimeRange(marka,Convert.ToDateTime(startDate), Convert.ToDateTime(endDate)), JsonRequestBehavior.AllowGet);
            }
            return null;

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Upload(PhotoProp photo, int id)
        {
            PhotoViewModel photoVM = new PhotoViewModel();
            HttpPostedFileBase file = Request.Files["OriginalLocation"];
            photoVM.Name = photo.Name;
            photoVM.AlternateText = photo.AlternateText;

            photoVM.ContentType = file.ContentType;

            Int32 length = file.ContentLength;
            byte[] tempImg = new byte[length];
            file.InputStream.Read(tempImg, 0, length);
            photoVM.Image = tempImg;
            Image image = new Image();
            image.ImageName = photoVM.Name;
            image.ImageAlt = photoVM.AlternateText;
            image.ContentType = photoVM.ContentType;
            image.ImageData = photoVM.Image;
            imageRepository.Add(image);
            imageRepository.Save();

            ImageSamochod imageSamochod = new ImageSamochod();
            imageSamochod.Opis = photoVM.AlternateText;
            imageSamochod.ImageId = image.ImageId;
            imageSamochod.SamochodId = id;
            imageSamochodRepository.Add(imageSamochod);
            imageSamochodRepository.Save();

            return View();

        }
        public ActionResult CarsForAjax(DateTime from, DateTime to)
        {
            var model = new SamochodTimeRangeSelectionVM();
            model.ListaMarki = new SelectList(wypozyczenieRepository.FindCarsForTimeRange(from, to).GroupBy(x=>x.Marka).Select(group => group.First()), "Marka", "Marka");
            model.ListaModele = new SelectList(new List<Samochod>(), "Model", "Model");
            model.from = from;
            model.to = to;
            //wypozyczenieRepository.FindCarsForTimeRange(from, to).Select(f => f.Model)
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult CarsForAjax(SamochodTimeRangeSelectionVM model, FormCollection collection)
        {
            return RedirectToAction("Create", "Wypozyczenie", null);
        }

        public ActionResult SamochodyForWypozyczenie(int id)
        {
            var model = new WypSam();           
            var list = wypSamRepository.FindWypSamForIdWypozyczenie(id);
            if (list != null)
            {
                model.WypSamList = list;
            }
            return PartialView("_SamochodyForWypozyczenie", model);
        }
        
    }
}