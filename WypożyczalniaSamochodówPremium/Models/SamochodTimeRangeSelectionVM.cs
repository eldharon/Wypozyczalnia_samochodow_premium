using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class SamochodTimeRangeSelectionVM
    {
        public IEnumerable<Samochod> Samochod { get; set; }
        public SelectList ListaMarki { get; set; }
        public SelectList ListaModele { get; set; }
    }
}