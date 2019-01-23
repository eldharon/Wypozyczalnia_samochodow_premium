using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class PrzegladRepository
    {
        WypozyczenieEntities entities = new WypozyczenieEntities();

        public IQueryable<Przeglad> FindAllPrzeglad()
        {
            return entities.przeglady;
        }
        

        public Przeglad GetPrzegladById(int id)
        {
            return entities.przeglady.SingleOrDefault(s => s.PrzegladId == id);
        }

        public IQueryable<Przeglad> ShowPrzegladForSamochod(int id)
        {
            return entities.przeglady.Where(s => s.SamochodId == id).OrderByDescending(x => x.DataPrzegladu);
        }

        public void Add(Przeglad przeglad)
        {
            entities.przeglady.Add(przeglad);
        }

        public void Delete(Przeglad przeglad)
        {
            entities.przeglady.Remove(przeglad);
        }

        public void Save()
        {
            entities.SaveChanges();
        }
    }
}