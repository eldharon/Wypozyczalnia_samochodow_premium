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

        public IQueryable<ImageSamochod> FindAllImages()
        {
            return entities.imagesSamochod;
        }

        public IQueryable<ImageSamochod> FindImegerForSamochodId(int id)
        {
            return entities.imagesSamochod.Where(i => i.SamochodId == id);
        }

        public ImageSamochod GetImageById(int id)
        {
            return entities.imagesSamochod.SingleOrDefault(o => o.ImageId == id);
        }
        public IEnumerable<PhotoProp> GetPhotoPropsForSamochodId(int id)
        {
            return entities.imagesSamochod.Where(x => x.SamochodId == id).Select(c => new PhotoProp
            {
                id = c.ImageId,
                Name = c.Image.ImageName,
                AlternateText = c.Image.ImageAlt,
                ReferencedObjectId = c.SamochodId
            }).AsEnumerable();
        }

        public ImageSamochod GetDefaultImageIdForSamochodId(int id)
        {
            return entities.imagesSamochod.FirstOrDefault(x => x.SamochodId == id);
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
    }
}