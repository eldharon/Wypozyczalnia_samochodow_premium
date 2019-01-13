using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class ImageDowodRejestracyjnyRepository
    {
        WypozyczenieEntities entities = new WypozyczenieEntities();

        public IQueryable<ImageDowodRejestracyjny> FindAllImages()
        {
            return entities.imagesDowodRejestracyjny;
        }

        public ImageDowodRejestracyjny GetImageById(int id)
        {
            return entities.imagesDowodRejestracyjny.SingleOrDefault(o => o.ImageId == id);
        }

        public void Add(ImageDowodRejestracyjny image)
        {
            entities.imagesDowodRejestracyjny.Add(image);
        }

        public void Delete(ImageDowodRejestracyjny image)
        {
            entities.imagesDowodRejestracyjny.Remove(image);
        }

        public void Save()
        {
            entities.SaveChanges();
        }
    }
}