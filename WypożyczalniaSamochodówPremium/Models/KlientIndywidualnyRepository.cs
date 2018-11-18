using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class KlientIndywidualnyRepository
    {
        WypozyczenieEntities entities = new WypozyczenieEntities();

        public IQueryable<KlientIndywidualny> GetAllKlienciFirmowi()
        {
            return entities.klienciIndywidualni;
        }
        public KlientIndywidualny GetKlientFirmaById(int id)
        {
            return entities.klienciIndywidualni.SingleOrDefault(h => h.KlientIndywidualnyId == id);
        }
        public void Add(KlientIndywidualny klientIndywidualny)
        {
            entities.klienciIndywidualni.Add(klientIndywidualny);
        }
        public void Delete(KlientIndywidualny klientIndywidualny)
        {
            entities.klienciIndywidualni.Remove(klientIndywidualny);
        }
        public void Save()
        {
            entities.SaveChanges();
        }
    }
}