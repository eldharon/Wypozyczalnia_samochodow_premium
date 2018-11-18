using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class KlientFirmaRepository
    {
        WypozyczenieEntities entities = new WypozyczenieEntities();

        public IQueryable<KlientFirma> GetAllKlienciFirmy()
        {
            return entities.klienciFirmy;
        }
        public KlientFirma GetKlientFirmaById(int id)
        {
            return entities.klienciFirmy.SingleOrDefault(h => h.KlientFirmaId == id);
        }
        public void Add(KlientFirma klientFirma)
        {
            entities.klienciFirmy.Add(klientFirma);
        }
        public void Delete(KlientFirma klientFirma)
        {
            entities.klienciFirmy.Remove(klientFirma);
        }
        public void Save()
        {
            entities.SaveChanges();
        }
    }
}