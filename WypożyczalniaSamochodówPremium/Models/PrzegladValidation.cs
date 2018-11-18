using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WypożyczalniaSamochodówPremium.Models
{
    [MetadataType(typeof(PrzegladValidation))]
    public partial class Przeglad
    {
    }

    public class PrzegladValidation
    {
        [HiddenInput(DisplayValue = false), ScaffoldColumn(false)]
        public int PrzegladId { get; set; }
        [Required(ErrorMessage = "Proszę podać datę przeglądu"), DataType(DataType.Date), DisplayName("Data przeglądu")]
        public System.DateTime DataPrzegladu { get; set; }
        [Required(ErrorMessage = "Proszę podać datę kolejnego przeglądu"), DataType(DataType.Date), DisplayName("Data kolejnego przeglądu")]
        public System.DateTime DataKolejnegoPrzegladu { get; set; }
        public string Uwagi { get; set; }
    }
}