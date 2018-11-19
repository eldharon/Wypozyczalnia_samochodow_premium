using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WypożyczalniaSamochodówPremium.Models
{

    [MetadataType(typeof(WydarzenieValidation))]
    public partial class Wydarzenie
    {
    }

    public class WydarzenieValidation
    {
        [HiddenInput(DisplayValue = false), ScaffoldColumn(false)]
        public int WydarzenieId { get; set; }
        [Required(ErrorMessage = "Proszę podać nazwę wydarzenia"), DisplayName("Nazwa wydarzenia"),MaxLength(32)]
        public string NazwaWydarzenia { get; set; }
        public string Opis { get; set; }
    }
}