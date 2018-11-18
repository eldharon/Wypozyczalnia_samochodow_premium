using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class RozliczenieRepository
    {
        WypozyczenieEntities entities = new WypozyczenieEntities();

        public IQueryable<Rozliczenie> FindAllRozliczenia()
        {
            return entities.rozliczenia;
        }

        public Rozliczenie GetRozliczeniaById(int id)
        {
            return entities.rozliczenia.SingleOrDefault(r => r.RozliczenieId == id);
        }

        public void Add(Rozliczenie rozliczenie)
        {
            entities.rozliczenia.Add(rozliczenie);
        }

        public void Delete(Rozliczenie rozliczenie)
        {
            entities.rozliczenia.Remove(rozliczenie);
        }

        public void Save()
        {
            entities.SaveChanges();
        }
    }
}