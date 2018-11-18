using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WypożyczalniaSamochodówPremium.Models
{
    [MetadataType(typeof(KlientIndywidualnyValidation))]
    public partial class KlientIndywidualny
    {
    }

    public class KlientIndywidualnyValidation
    {
        [HiddenInput(DisplayValue = false), ScaffoldColumn(false)]
        public int KlientIndywidualnyId { get; set; }
        public Nullable<int> Rabat { get; set; }
    }
}