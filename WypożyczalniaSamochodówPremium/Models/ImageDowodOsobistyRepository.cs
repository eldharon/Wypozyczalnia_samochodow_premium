using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class ImageDowodOsobistyRepository
    {
        WypozyczenieEntities entities = new WypozyczenieEntities();

        public IQueryable<ImageDowodOsobisty> FindAllImages()
        {
            return entities.imagesDowodOsobisty;
        }

        public ImageDowodOsobisty GetImageById(int id)
        {
            return entities.imagesDowodOsobisty.SingleOrDefault(o => o.ImageId == id);
        }

        public void Add(ImageDowodOsobisty image)
        {
            entities.imagesDowodOsobisty.Add(image);
        }

        public void Delete(ImageDowodOsobisty image)
        {
            entities.imagesDowodOsobisty.Remove(image);
        }

        public void Save()
        {
            entities.SaveChanges();
        }
    }
}