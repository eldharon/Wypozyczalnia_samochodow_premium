using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WypożyczalniaSamochodówPremium.Models
{
    [MetadataType(typeof(WypSamValidation))]
    public partial class WypSam
    {
    }

    public class WypSamValidation
    {
        [HiddenInput(DisplayValue = false), ScaffoldColumn(false)]
        public int WypSamId { get; set; }
    }
}