using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class SamochodTimeRangeSelectionVM
    {
        public int OsobaId { get; set; }
        public DateTime from { get; set; }
        public DateTime to { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public int SamochodId { get; set; }
        public IEnumerable<SelectListItem> ListaMarki { get; set; }
        public IEnumerable<SelectListItem> ListaModele { get; set; }
        public List<Samochod> ListaSamochodow { get; set; }
    }
}