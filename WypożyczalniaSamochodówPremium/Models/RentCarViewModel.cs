using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [DisplayName("Czy mamy dostarczyć samochód?")]
        public bool CzyDostarczany { get; set; }

        [DisplayName("Czy chcesz wynająć kierowcę?")]
        public bool CzyKierowca { get; set; }

        [DisplayName("Adres dostarczenia")]
        public string AdresDojazdu { get; set; }

        public string Uwagi { get; set; }

        public int WydarzenieId { get; set; }
        public int OsobaId { get; set; }
        //public IEnumerable<Pracownik> KierowcyList { get; set; }
        public string PaymentMethod { get; set; }
        public virtual double TotalPrice { get; set; }



    }
}