using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WypożyczalniaSamochodówPremium.Models;

namespace WypożyczalniaSamochodówPremium.Areas.Adm.Controllers
{
    [Authorize(Roles = "Admin, Manager, Employee")]
    public class OsobaController : Controller
    {
        OsobaRepository osobaRepository = new OsobaRepository();
        ImageDowodOsobistyRepository imageDowodOsobistyRepository = new ImageDowodOsobistyRepository();
        ImagePaszportRepository imagePaszportRepository = new ImagePaszportRepository();
        ImageRepository imageRepository = new ImageRepository();
        DowodOsobistyRepository dowodOsobistyRepository = new DowodOsobistyRepository();
        PaszportRepository paszportRepository = new PaszportRepository();
        // GET: Adm/Wydarzenie
        public ActionResult Index()
        {
            var model = osobaRepository.FindAllOsoba();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var osoba = osobaRepository.GetOsobaById(id);
            ViewBag.modedowod = "1";
            ViewBag.modepaszport = "2";
            return View(osoba);
        }

        public ActionResult Create()
        {
            Osoba osoba = new Osoba();
            return View(osoba);
        }


        [HttpPost]
        public ActionResult Create(Osoba osoba, FormCollection collection)
        {
            osoba.Hash = Guid.NewGuid();
            if (ModelState.IsValid)
            {
                osobaRepository.Add(osoba);
                osobaRepository.Save();

                TempData["okMessage"] = "Osoba: " + osoba.Imie + " " + osoba.Nazwisko + " została dodana.";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["errorMessage"] = "Nie dodano osoby";
                return View(osoba);
            }
        }

        public ActionResult Edit(int id)
        {
            Osoba osoba = osobaRepository.GetOsobaById(id);
            return View(osoba);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Osoba osoba = osobaRepository.GetOsobaById(id);
            if (TryUpdateModel(osoba))
            {
                osobaRepository.Save();
                TempData["okMessage"] = "Osoba: " + osoba.Imie+" "+osoba.Nazwisko + " została zapisana!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["errorMessage"] = "Osoba: " + osoba.Imie + " " + osoba.Nazwisko + "nie została zapisana!";
                return View(osoba);
            }
        }

        public ActionResult Delete(int id)
        {
            var osoba = osobaRepository.GetOsobaById(id);
            return View(osoba);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var osoba = osobaRepository.GetOsobaById(id);
                osobaRepository.Delete(osoba);
                osobaRepository.Save();
                TempData["okMessage"] = "Usunięto " + osoba.Imie + " " + osoba.Nazwisko + "!";
                return RedirectToAction("Index", "Osoba");
            }
            catch (Exception e)
            {
                TempData["errorMessage"] = "Wystąpił błąd : " + e;
                return RedirectToAction("Index", "Osoba");
            }
        }

        public ActionResult Upload(int id, string mode)
        {
            ViewBag.OsobaId = id;
            ViewBag.mode = mode;
            PhotoProp model = new PhotoProp();
            var imgid = 0;
            var sam = osobaRepository.GetOsobaById(id);
            //var samimg = imageSamochodRepository.GetPhotoPropsForSamochodId(id).Count()+1;
            switch (mode)
            {
                case "1":
                    imgid = imageDowodOsobistyRepository.FindAllImagesForOsobaId(id).Count() + 1;
                    model.AlternateText = "Dowod osobisty " + sam.Imie + " " + sam.Nazwisko + " " + imgid;
                    model.Name = sam.OsobaId + "_DowodOsobisty_" + imgid;
                    break;
                case "2":
                    imgid = imagePaszportRepository.FindAllImagesForOsobaId(id).Count() + 1;
                    model.AlternateText = "Paszport " + sam.Imie + " " + sam.Nazwisko + " " + imgid;
                    model.Name = sam.OsobaId + "_paszport_" + imgid;
                    break;
                default:
                    break;
            }
            
            
            return PartialView("Upload", model);

        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Upload(string Name, string AlternateText, int id, string mode)
        {
            try
            {
                PhotoViewModel photoVM = new PhotoViewModel();
                HttpPostedFileBase file = Request.Files["OriginalLocation"];
                photoVM.Name = Name;
                photoVM.AlternateText = AlternateText;

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

                switch (mode)
                {
                    case "1":
                        ImageDowodOsobisty imageDowodOsobisty = new ImageDowodOsobisty();
                        DowodOsobisty dowod = new DowodOsobisty();
                        dowod.NrDowodu = "tbd";
                        dowod.TerminWaznosci = DateTime.Now;
                        dowod.PESEL = 00000000000;
                        dowod.OsobaId = id;
                        dowodOsobistyRepository.Add(dowod);
                        dowodOsobistyRepository.Save();
                        
                        imageDowodOsobisty.Opis = photoVM.AlternateText;
                        imageDowodOsobisty.ImageId = image.ImageId;
                        imageDowodOsobisty.DowodOsobistyId = dowod.DowodOsobistyId; 
                        imageDowodOsobistyRepository.Add(imageDowodOsobisty);
                        imageDowodOsobistyRepository.Save();

                        break;
                    case "2":
                        ImagePaszport imagePaszport = new ImagePaszport();
                        Paszport paszport = new Paszport();
                        paszport.NrPaszportu = "tbd";
                        paszport.TerminWaznosci = DateTime.Now;
                        paszport.OsobaId = id;
                        paszportRepository.Add(paszport);
                        paszportRepository.Save();
                        
                        imagePaszport.Opis = photoVM.AlternateText;
                        imagePaszport.ImageId = image.ImageId;
                        imagePaszport.PaszportId = paszport.PaszportId;
                        imagePaszportRepository.Add(imagePaszport);
                        imagePaszportRepository.Save();
                        break;
                    default:
                        break;
                }

                return RedirectToAction("DisplayZdjecia", "Osoba", new { OsobaId = id });
            }
            catch (Exception e)
            {
                TempData["errorMessage"] = "Nie udało się dodać zdjęcia!\n" + e;
                return RedirectToAction("Details", "Osoba", id);

            }
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ShowPhoto(int id)
        {
            PhotoViewModel image = imageRepository.GetImageVMById(id);
            return File(image.Image, image.ContentType);
        }
        public ActionResult DisplayZdjecia(int OsobaId)
        {
            var model = imagePaszportRepository.GetPhotoPropsForOsobaId(OsobaId);
            var model2 = imageDowodOsobistyRepository.GetPhotoPropsForOsobaId(OsobaId);
            var model3 = model.Concat(model2);
            return PartialView("DisplayZdjecia", model3);
        }

    }
}
