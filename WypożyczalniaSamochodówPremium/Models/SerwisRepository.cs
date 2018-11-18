using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class SerwisRepository
    {
        WypozyczenieEntities entities = new WypozyczenieEntities();

        public IQueryable<Serwis> FindAllSerwis()
        {
            return entities.serwisy;
        }

        public Serwis GetUSeriwsById(int id)
        {
            return entities.serwisy.SingleOrDefault(s => s.SerwisId == id);
        }

        public void Add(Serwis serwis)
        {
            entities.serwisy.Add(serwis);
        }

        public void Delete(Serwis serwis)
        {
            entities.serwisy.Remove(serwis);
        }

        public void Save()
        {
            entities.SaveChanges();
        }
    }
}