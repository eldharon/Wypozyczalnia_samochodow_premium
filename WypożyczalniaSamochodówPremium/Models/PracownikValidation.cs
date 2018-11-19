using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WypożyczalniaSamochodówPremium.Models
{
    [MetadataType(typeof(PracownikValidation))]
    public partial class Pracownik
    {
    }

    public class PracownikValidation
    {
        [HiddenInput(DisplayValue = false), ScaffoldColumn(false)]
        public int PracownikId { get; set; }
        [Required(ErrorMessage = "Proszę podać datę zatrudnienia"), DisplayName("Data zatrudnienia"), DataType(DataType.Date)]
        public System.DateTime DataZatrudnienia { get; set; }
        [DisplayName("Data zwolnienia"), DataType(DataType.Date)]
        public Nullable<System.DateTime> DataZwolnienia { get; set; }
        [Required(ErrorMessage = "Proszę podać wysokość pensji"), DataType(DataType.Currency)]
        public double Pensja { get; set; }
        [DataType(DataType.Currency)]
        public Nullable<double> Premia { get; set; }
        [Required(ErrorMessage = "Proszę podać stanowisko")]
        public string Stanowisko { get; set; }
    }
}