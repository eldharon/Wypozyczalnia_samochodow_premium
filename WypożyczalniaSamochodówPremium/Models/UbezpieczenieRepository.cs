using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class UbezpieczenieRepository
    {
        WypozyczenieEntities entities = new WypozyczenieEntities();

        public IQueryable<Ubezpieczenie> FindAllUbezpieczenie()
        {
            return entities.ubezpieczenia;
        }

        public Ubezpieczenie GetUbezpieczenieById(int id)
        {
            return entities.ubezpieczenia.SingleOrDefault(u => u.UbezpieczenieId == id);
        }

        public void Add(Ubezpieczenie ubezpieczenie)
        {
            entities.ubezpieczenia.Add(ubezpieczenie);
        }

        public void Delete(Ubezpieczenie ubezpieczenie)
        {
            entities.ubezpieczenia.Remove(ubezpieczenie);
        }

        public void Save()
        {
            entities.SaveChanges();
        }
    }
}