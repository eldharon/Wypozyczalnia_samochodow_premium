using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WypożyczalniaSamochodówPremium.Models
{
    [MetadataType(typeof(AkcesoriaValidation))]
    public partial class Akcesoria
    {
    }
        public class AkcesoriaValidation
    {
        [HiddenInput(DisplayValue = false), ScaffoldColumn(false)]
        public int AkcesoriaId { get; set; }
        [Required(ErrorMessage = "Proszę wpisać nazwę"), DisplayName("Nazwa akcesorium")]
        public string Nazwa { get; set; }
        [Required(ErrorMessage = "Proszę wprowadzić opis"), DisplayName("Opis akcesorium")]
        public string Opis { get; set; }
        [Required(ErrorMessage = "Proszę wprowadzić cenę"), DataType(DataType.Currency), DisplayName("Cena akcesorium")]
        public double Cena { get; set; }
    }
}