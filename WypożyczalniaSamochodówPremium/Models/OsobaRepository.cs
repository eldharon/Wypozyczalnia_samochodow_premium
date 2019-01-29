using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class OsobaRepository
    {
        WypozyczenieEntities entities = new WypozyczenieEntities();

        public IQueryable<Osoba> FindAllOsoba()
        {
            return entities.osoby;
        }

        public Osoba GetOsobaById(int id)
        {
            return entities.osoby.SingleOrDefault(o => o.OsobaId == id);
        }

        public Osoba GetOsobaByHash(Guid hash)
        {
            return entities.osoby.SingleOrDefault(o => o.Hash == hash);
        }

        public void Add(Osoba osoba)
        {
            entities.osoby.Add(osoba);
        }

        public void Delete(Osoba osoba)
        {
            entities.osoby.Remove(osoba);
        }

        public void Save()
        {
            entities.SaveChanges();
        }
    }
}