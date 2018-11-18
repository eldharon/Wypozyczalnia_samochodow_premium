using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class PrawoJazdyRepository
    {
        WypozyczenieEntities entities = new WypozyczenieEntities();

        public IQueryable<PrawoJazdy> FindAllPrawoJazdy()
        {
            return entities.prawaJazdy;
        }

        public PrawoJazdy GetPrawoJazdyById(int id)
        {
            return entities.prawaJazdy.SingleOrDefault(p => p.PrawoJazdyId == id);
        }

        public void Add(PrawoJazdy prawoJazdy)
        {
            entities.prawaJazdy.Add(prawoJazdy);
        }

        public void Delete(PrawoJazdy prawoJazdy)
        {
            entities.prawaJazdy.Remove(prawoJazdy);
        }

        public void Save()
        {
            entities.SaveChanges();
        }
    }
}