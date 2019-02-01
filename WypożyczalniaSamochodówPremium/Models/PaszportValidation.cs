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
        public string NrPaszportu { get; set; }
        public DateTime TerminWaznosci { get; set; }
    }
}