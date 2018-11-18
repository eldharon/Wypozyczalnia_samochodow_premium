using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class PracownikRepository
    {
        WypozyczenieEntities entities = new WypozyczenieEntities();

        public IQueryable<Pracownik> FindAllPracownik()
        {
            return entities.pracownicy;
        }

        public Pracownik GetPracownikById(int id)
        {
            return entities.pracownicy.SingleOrDefault(p => p.PracownikId == id);
        }

        public void Add(Pracownik pracownik)
        {
            entities.pracownicy.Add(pracownik);
        }

        public void Delete(Pracownik pracownik)
        {
            entities.pracownicy.Remove(pracownik);
        }

        public void Save()
        {
            entities.SaveChanges();
        }
    }
}