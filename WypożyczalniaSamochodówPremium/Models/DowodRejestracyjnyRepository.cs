using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class DowodRejestracyjnyRepository
    {
        WypozyczenieEntities entities = new WypozyczenieEntities();

        public IQueryable<DowodRejestracyjny> GetAllDowodyRejestracyjne()
        {
            return entities.dowodyRejestracyjne;
        }
        public DowodRejestracyjny GetDowodRejestracyjnyById(int id)
        {
            return entities.dowodyRejestracyjne.SingleOrDefault(h => h.DowodRejId == id);
        }
        public void Add(DowodRejestracyjny dowodRejestracyjny)
        {
            entities.dowodyRejestracyjne.Add(dowodRejestracyjny);
        }
        public void Delete(DowodRejestracyjny dowodRejestracyjny)
        {
            entities.dowodyRejestracyjne.Remove(dowodRejestracyjny);
        }
        public void Save()
        {
            entities.SaveChanges();
        }
    }
}