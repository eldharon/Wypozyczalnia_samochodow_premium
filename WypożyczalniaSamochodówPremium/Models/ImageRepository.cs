using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class ImageRepository
    {
        WypozyczenieEntities entities = new WypozyczenieEntities();

        public IQueryable<Image> FindAllImages()
        {
            return entities.images;
        }
        
        public Image GetImageById(int id)
        {
            return entities.images.SingleOrDefault(o => o.ImageId == id);
        }

        public PhotoViewModel GetImageVMById(int id)
        {
            return entities.images.Where(x => x.ImageId == id).Select
            (c => new PhotoViewModel
            {
                AlternateText = c.ImageAlt,
                Name = c.ImageName,
                ContentType = c.ContentType,
                Image = c.ImageData
            }).FirstOrDefault();
        }

        public void Add(Image image)
        {
            entities.images.Add(image);
        }

        public void Delete(Image image)
        {
            entities.images.Remove(image);
        }

        public void Save()
        {
            entities.SaveChanges();
        }
    }
}