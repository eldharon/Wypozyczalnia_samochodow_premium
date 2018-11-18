using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WypożyczalniaSamochodówPremium.Models
{
    [MetadataType(typeof(RozliczenieValidation))]
    public partial class Rozliczenie
    {
    }

    public class RozliczenieValidation
    {
        [HiddenInput(DisplayValue = false), ScaffoldColumn(false)]
        public int RozliczenieId { get; set; }
        [DataType(DataType.Currency), DisplayName("Dodatkowe opłaty")]
        public Nullable<double> DodatkoweOplaty { get; set; }
        [Required(ErrorMessage = "Proszę podać wartość zaliczki"), DataType(DataType.Currency)]
        public double Zaliczka { get; set; }
        [DisplayName("Dodatkowy rabat")]
        public Nullable<double> DodatkowyRabat { get; set; }
        public double CalkowityKoszt { get; set; }
    }
}