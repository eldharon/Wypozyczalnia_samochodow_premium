using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class ImagePaszportRepository
    {
        WypozyczenieEntities entities = new WypozyczenieEntities();

        public IQueryable<ImagePaszport> FindAllImages()
        {
            return entities.imagesPaszport;
        }

        public ImagePaszport GetImageById(int id)
        {
            return entities.imagesPaszport.SingleOrDefault(o => o.ImageId == id);
        }

        public void Add(ImagePaszport image)
        {
            entities.imagesPaszport.Add(image);
        }

        public void Delete(ImagePaszport image)
        {
            entities.imagesPaszport.Remove(image);
        }

        public void Save()
        {
            entities.SaveChanges();
        }
    }
}