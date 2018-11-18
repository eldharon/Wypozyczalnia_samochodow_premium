using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class WypozyczenieRepository
    {
        WypozyczenieEntities entities = new WypozyczenieEntities();

        public IQueryable<Wypozyczenie> FindAllWypyczenia()
        {
            return entities.wypozyczenia;
        }

        public Wypozyczenie GetWypozyczenieById(int id)
        {
            return entities.wypozyczenia.SingleOrDefault(w => w.WypozyczenieId == id);
        }

        public void Add(Wypozyczenie wypozyczenie)
        {
            entities.wypozyczenia.Add(wypozyczenie);
        }

        public void Delete(Wypozyczenie wypozyczenie)
        {
            entities.wypozyczenia.Remove(wypozyczenie);
        }

        public void Save()
        {
            entities.SaveChanges();
        }
    }
}