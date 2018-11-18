using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class AkcesoriaRepository
    {
        WypozyczenieEntities entities = new WypozyczenieEntities();

        public IQueryable<Akcesoria> GetAllAkcesoria()
        {
            return entities.akcesoria;
        }
        public Akcesoria GetAkcesoriaById(int id)
        {
            return entities.akcesoria.SingleOrDefault(h => h.IdAkcesoria == id);
        }
        public void Add(Akcesoria akcesoria)
        {
            entities.akcesoria.Add(akcesoria);
        }
        public void Delete(Akcesoria akcesoria)
        {
            entities.akcesoria.Remove(akcesoria);
        }
        public void Save()
        {
            entities.SaveChanges();
        }
    }
}