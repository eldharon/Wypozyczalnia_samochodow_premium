using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class OpisRepository
    {
        WypozyczenieEntities entities = new WypozyczenieEntities();

        public IQueryable<Opis> GetAllOpisy()
        {
            return entities.opisy;
        }
        public Opis GetOpisById(int id)
        {
            return entities.opisy.SingleOrDefault(h => h.OpisId == id);
        }
        public void Add(Opis opis)
        {
            entities.opisy.Add(opis);
        }
        public void Delete(Opis opis)
        {
            entities.opisy.Remove(opis);
        }
        public void Save()
        {
            entities.SaveChanges();
        }
        public IQueryable<Opis> GetOpisForSamochodId(int id)
        {
            return entities.opisy.Where(x => x.SamochodId == id);
        }
    }
}