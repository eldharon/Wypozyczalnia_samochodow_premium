using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class WypozyczenieTempRepository
    {
        WypozyczenieEntities entities = new WypozyczenieEntities();

        public IQueryable<WypozyczenieTemp> FindAllWypozyczeniaTemp()
        {
            return entities.wypozyczeniaTemp;
        }

        public WypozyczenieTemp GetWypozyczenieTempById(int id)
        {
            return entities.wypozyczeniaTemp.SingleOrDefault(w => w.WypozyczenieTempId == id);
        }

        public IQueryable<WypozyczenieTemp> FindWypozyczenieTempForOsobaId(int id)
        {
            return entities.wypozyczeniaTemp.Where(x => x.OsobaId == id);
        }

        public void Add(WypozyczenieTemp wypozyczenieTemp)
        {
            entities.wypozyczeniaTemp.Add(wypozyczenieTemp);
        }

        public void Delete(WypozyczenieTemp wypozyczenieTemp)
        {
            entities.wypozyczeniaTemp.Remove(wypozyczenieTemp);
        }

        public void Save()
        {
            entities.SaveChanges();
        }

    }
}