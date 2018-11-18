using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class WydarzenieRepository
    {
        WypozyczenieEntities entities = new WypozyczenieEntities();

        public IQueryable<Wydarzenie> FindAllWydarzenie()
        {
            return entities.wydarzenia;
        }

        public Wydarzenie GetWydarzenieById(int id)
        {
            return entities.wydarzenia.SingleOrDefault(w => w.WydarzenieId == id);
        }

        public void Add(Wydarzenie wydarzenie)
        {
            entities.wydarzenia.Add(wydarzenie);
        }

        public void Delete(Wydarzenie wydarzenie)
        {
            entities.wydarzenia.Remove(wydarzenie);
        }

        public void Save()
        {
            entities.SaveChanges();
        }
    }
}