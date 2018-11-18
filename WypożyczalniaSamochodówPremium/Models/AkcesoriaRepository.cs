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
            return entities.Akcesoria;
        }
        public Akcesoria
    }
}