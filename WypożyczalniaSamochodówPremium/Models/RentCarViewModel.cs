using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class RentCarViewModel
    {
        public IEnumerable<WypozyczenieTemp> CarInCartList { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataWypozyczenia { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataZwrotu { get; set; }
        public bool CzyDostarczany { get; set; }
        public bool CzyKierowca { get; set; }
        public string AdresDojazdu { get; set; }
        public int WydarzenieId { get; set; }
        public Osoba Osoba { get; set; }
        public IEnumerable<Pracownik> KierowcyList { get; set; }

    }
}