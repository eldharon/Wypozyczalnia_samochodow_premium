using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class PracownikWypozycznieRepository
    {
        WypozyczenieEntities entities = new WypozyczenieEntities();

        public IQueryable<PracownikWypozyczenie> FindAllPracownikWypozyczenie()
        {
            return entities.pracownicyWypozyczenia;
        }

        public PracownikWypozyczenie GetPracownikWypozyczenieById(int id)
        {
            return entities.pracownicyWypozyczenia.SingleOrDefault(p => p.PracownikWypozyczenieId == id);
        }

        public void Add(PracownikWypozyczenie pracownikWypozyczenie)
        {
            entities.pracownicyWypozyczenia.Add(pracownikWypozyczenie);
        }

        public void Delete(PracownikWypozyczenie pracownikWypozyczenie)
        {
            entities.pracownicyWypozyczenia.Remove(pracownikWypozyczenie);
        }

        public void Save()
        {
            entities.SaveChanges();
        }
    }
}