using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class SamochodRepository
    {
        WypozyczenieEntities entities = new WypozyczenieEntities();

        public IQueryable<Samochod> FindAllSamochod()
        {
            return entities.samochody;
        }

        public Samochod GetSamochodById(int id)
        {
            return entities.samochody.SingleOrDefault(s => s.SamochodId == id);
        }

        public Samochod GetSamochodIdForMarkaAndModel(string marka, string model)
        {
            return entities.samochody.Where(s => s.Marka == marka && s.Model == model).FirstOrDefault();
        }

        public void Add(Samochod samochod)
        {
            entities.samochody.Add(samochod);
        }

        public void Delete(Samochod samochod)
        {
            entities.samochody.Remove(samochod);
        }

        public void Save()
        {
            entities.SaveChanges();
        }
    }
}