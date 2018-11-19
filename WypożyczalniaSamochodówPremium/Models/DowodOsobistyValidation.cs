using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WypożyczalniaSamochodówPremium.Models
{
    [MetadataType(typeof(DowodOsobistyValidation))]
    public partial class DowodOsobisty
    {
    }

    public class DowodOsobistyValidation
    {
        [HiddenInput(DisplayValue = false), ScaffoldColumn(false)]
        public int DowodOsobistyId { get; set; }
        [Required(ErrorMessage = "Proszę podać numer PESEL"), MaxLength(11)]
        public int PESEL { get; set; }
        [Required(ErrorMessage = "Proszę podać numer PESEL"), DisplayName("Numer dowodu")]
        public string NrDowodu { get; set; }
        [Required(ErrorMessage = "Proszę podać do kiedy dowód jest ważny"), DataType(DataType.Date), DisplayName("Termin ważności")]
        public System.DateTime TerminWaznosci { get; set; }
    }
}