using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WypożyczalniaSamochodówPremium.Models
{
    [MetadataType(typeof(PracownikWypozyczenieValidation))]
    public partial class PracownikWypozyczenie
    {
    }

    public class PracownikWypozyczenieValidation
    {
        [HiddenInput(DisplayValue = false), ScaffoldColumn(false)]
        public int PracownikWypozyczenieId { get; set; }
    }
}