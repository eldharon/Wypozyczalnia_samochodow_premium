using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class DowodOsobistyRepository
    {
        WypozyczenieEntities entities = new WypozyczenieEntities();

        public IQueryable<DowodOsobisty> GetAllDowodyOsobiste()
        {
            return entities.dowodyOsobiste;
        }
        public DowodOsobisty GetDowodOsobistyById(int id)
        {
            return entities.dowodyOsobiste.SingleOrDefault(h => h.DowodOsobistyId == id);
        }
        public void Add(DowodOsobisty dowod)
        {
            entities.dowodyOsobiste.Add(dowod);
        }
        public void Delete(DowodOsobisty dowod)
        {
            entities.dowodyOsobiste.Remove(dowod);
        }
        public void Save()
        {
            entities.SaveChanges();
        }
    }
}