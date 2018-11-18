using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WypożyczalniaSamochodówPremium.Models
{
    [MetadataType(typeof(PaszportValidation))]
    public partial class Paszport
    {
    }

    public class PaszportValidation
    {
        [HiddenInput(DisplayValue = false), ScaffoldColumn(false)]
        public int PaszportId { get; set; }
        [Required(ErrorMessage = "Proszę podać numer paszportu"), DisplayName("Numer paszportu")]
        public string NrPaszportu { get; set; }
        [DataType(DataType.Date), DisplayName("Termin ważności")]
        public Nullable<System.DateTime> TerminWaznosci { get; set; }
    }
}