using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class PaszportRepository
    {
        WypozyczenieEntities entities = new WypozyczenieEntities();

        public IQueryable<Paszport> FindAllPaszport()
        {
            return entities.paszporty;
        }

        public Paszport GetPaszportById(int id)
        {
            return entities.paszporty.SingleOrDefault(p => p.PaszportId == id);
        }

        public void Add(Paszport paszport)
        {
            entities.paszporty.Add(paszport);
        }

        public void Delete(Paszport paszport)
        {
            entities.paszporty.Remove(paszport);
        }

        public void Save()
        {
            entities.SaveChanges();
        }
    }
}