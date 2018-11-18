using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WypożyczalniaSamochodówPremium.Models
{
    [MetadataType(typeof(OpisValidation))]
    public partial class Opis
    {
    }

    public class OpisValidation
    {
        [HiddenInput(DisplayValue = false), ScaffoldColumn(false)]
        public int OpisId { get; set; }
        [Required(ErrorMessage = "Proszę wpisać opis"), DisplayName("Opis ogólny")]
        public string OpisOgolny { get; set; }
        [Required(ErrorMessage = "Proszę wpisać opis wyposażenia"), DisplayName("Opis wyposażenia")]
        public string Wyposazenie { get; set; }
    }
}