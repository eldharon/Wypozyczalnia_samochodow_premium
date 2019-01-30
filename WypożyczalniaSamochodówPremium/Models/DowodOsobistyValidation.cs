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
        public int PESEL { get; set; }
        public string NrDowodu { get; set; }
        public DateTime TerminWaznosci { get; set; }
    }
}