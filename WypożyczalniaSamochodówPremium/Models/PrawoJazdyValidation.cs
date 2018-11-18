using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WypożyczalniaSamochodówPremium.Models
{
    [MetadataType(typeof(PrawoJazdyValidation))]
    public partial class PrawoJazdy
    {
    }

    public class PrawoJazdyValidation
    {
        [HiddenInput(DisplayValue = false), ScaffoldColumn(false)]
        public int PrawoJazdyId { get; set; }
        [Required(ErrorMessage = "Proszę podać numer prawa jazdy"), DisplayName("Numer prawa jazdy"), MaxLength(32)]
        public string NrPrawaJazdy { get; set; }
        [Required(ErrorMessage = "Proszę podać kraj wydania"), DisplayName("Kraj Wydania"), MaxLength(32)]
        public string KrajWydania { get; set; }
        public string Kategoria { get; set; }
    }
}