using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class WypSamRepository
    {
        WypozyczenieEntities entities = new WypozyczenieEntities();

        public IQueryable<WypSam> FindAllWypSam()
        {
            return entities.wypozyczeniaSamochody;
        }
        public IQueryable<WypSam> FindWypSamForIdWypozyczenie(int id)
        {
            return entities.wypozyczeniaSamochody.Where(x => x.WypozyczenieId == id);
        }

        public WypSam GetWypSamById(int id)
        {
            return entities.wypozyczeniaSamochody.SingleOrDefault(x => x.WypSamId == id);
        }

        public void Add(WypSam wypSam)
        {
            entities.wypozyczeniaSamochody.Add(wypSam);
        }

        public void Delete(WypSam wypSam)
        {
            entities.wypozyczeniaSamochody.Remove(wypSam);
        }

        public void Save()
        {
            entities.SaveChanges();
        }
    }
}