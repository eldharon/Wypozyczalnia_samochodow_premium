using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WypożyczalniaSamochodówPremium.Models
{
    [MetadataType(typeof(WypozyczenieTempValidation))]
    public partial class WypozyczenieTemp
    {
        public IEnumerable<WypozyczenieTemp> WypTempList { get; set; }
        public virtual double PricePerDay { get; set; }

    }

    public class WypozyczenieTempValidation
    {
        [HiddenInput(DisplayValue = false), ScaffoldColumn(false)]
        public int WypozyczenieTempId { get; set; }
        public int OsobaId { get; set; }
        public int SamochodId { get; set; }
        public DateTime DataWypozyczenia { get; set; }
        public DateTime DataZwrotu { get; set; }
    }
}