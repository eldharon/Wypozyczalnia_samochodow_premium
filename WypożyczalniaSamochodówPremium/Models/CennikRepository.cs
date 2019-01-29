using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class CennikRepository
    {
        WypozyczenieEntities entities = new WypozyczenieEntities();

        public IQueryable<Cennik> GetAllCenniki()
        {
            return entities.cenniki;
        }
        public Cennik GetCennikById(int id)
        {
            return entities.cenniki.SingleOrDefault(h => h.CennikId == id);
        }

        public IQueryable<Cennik> ShowCennikiForSamochod(int id)
        {
            return entities.cenniki.Where(s => s.SamochodId == id).OrderByDescending(x => x.Opis);
        }
 
        public void Add(Cennik cennik)
        {
            entities.cenniki.Add(cennik);
        }
        public void Delete(Cennik cennik)
        {
            entities.cenniki.Remove(cennik);
        }
        public void Save()
        {
            entities.SaveChanges();
        }
    }
}