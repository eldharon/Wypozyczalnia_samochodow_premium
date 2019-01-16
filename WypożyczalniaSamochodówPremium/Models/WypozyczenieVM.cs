using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class WypozyczenieVM
    {
        public Wypozyczenie wypozyczenie { get; set; }
        public Samochod samochod { get; set; }
    }
}