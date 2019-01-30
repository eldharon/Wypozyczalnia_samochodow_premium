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
        
        public IQueryable<ImageDowodOsobisty> FindAllImagesForOsobaId(int id)
        {
            return entities.imagesDowodOsobisty.Where(x=>x.DowodOsobisty.OsobaId==id);
        }
        public IEnumerable<PhotoProp> GetPhotoPropsForOsobaId(int id)
        {
            return entities.imagesDowodOsobisty.Where(x => x.DowodOsobisty.OsobaId == id).Select(c => new PhotoProp
            {
                id = c.ImageId,
                Name = c.Image.ImageName,
                AlternateText = c.Image.ImageAlt,
                ReferencedObjectId = id
            }).AsEnumerable();
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