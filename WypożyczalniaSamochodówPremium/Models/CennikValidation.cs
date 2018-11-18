using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WypożyczalniaSamochodówPremium.Models
{
    [MetadataType(typeof(CennikValidation))]
    public partial class Cennik
    {
    }

    public class CennikValidation
    {
        [HiddenInput(DisplayValue = false), ScaffoldColumn(false)]
        public int CennikId { get; set; }
        [DisplayName("Opis"), MaxLength(64)]
        public string Opis { get; set; }
        [Required(ErrorMessage = "Proszę wprowadzić cenę"), DisplayName("Cena")]
        public double Cena { get; set; }
    }
}