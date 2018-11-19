using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WypożyczalniaSamochodówPremium.Models
{
    [MetadataType(typeof(DowodRejestracyjnyValidation))]
    public partial class DowodRejestracyjny
    {
    }

    public class DowodRejestracyjnyValidation
    {
        [HiddenInput(DisplayValue = false), ScaffoldColumn(false)]
        public int DowodRejId { get; set; }
        [Required(ErrorMessage = "Proszę podać numer VIN"),MaxLength(32)]
        public string VIN { get; set; }
        [Required(ErrorMessage = "Proszę podać serię dowodu rejestracyjnego")]
        public int Seria { get; set; }
        [Required(ErrorMessage = "Proszę podać numer rejestracyjny"), DisplayName("Numer rejestracyjny"),MaxLength(32)]
        public string NrRejestracyjny { get; set; }
    }
}