using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class DostepnoscRepository
    {
        WypozyczenieEntities entities = new WypozyczenieEntities();

        public IQueryable<Dostepnosc> GetAllDostepnosci()
        {
            return entities.dostepnosci;
        }
        public Dostepnosc GetDostepnoscById(int id)
        {
            return entities.dostepnosci.SingleOrDefault(h => h.DostepnoscId == id);
        }

        public Dostepnosc GetDostepnoscByDate(DateTime from, DateTime to)
        {
            return entities.dostepnosci.Where(x => x.NiedostepnyOd == from && x.NiedostepnyDo == to).SingleOrDefault();
        }

        public void Add(Dostepnosc dostepnosc)
        {
            entities.dostepnosci.Add(dostepnosc);
        }
        public void Delete(Dostepnosc dostepnosc)
        {
            entities.dostepnosci.Remove(dostepnosc);
        }
        public void Save()
        {
            entities.SaveChanges();
        }
    }
}