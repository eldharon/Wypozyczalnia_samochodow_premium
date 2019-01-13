using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WypożyczalniaSamochodówPremium.Models;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class ImageSamochodRepository
    {
        WypozyczenieEntities entities = new WypozyczenieEntities();
        ImageRepository imageRepository = new ImageRepository();
        ImageSamochodRepository imageSamochodRepository = new ImageSamochodRepository();

        public IQueryable<ImageSamochod> FindAllImages()
        {
            return entities.imagesSamochod;
        }

        public ImageSamochod GetImageById(int id)
        {
            return entities.imagesSamochod.SingleOrDefault(o => o.ImageId == id);
        }

        public void Add(ImageSamochod image)
        {
            entities.imagesSamochod.Add(image);
        }

        public void Delete(ImageSamochod image)
        {
            entities.imagesSamochod.Remove(image);
        }

        public void Save()
        {
            entities.SaveChanges();
        }
        public void AddImage(PhotoViewModel photoVM, int id)
        {
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
        }
    }
}