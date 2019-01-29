using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WypożyczalniaSamochodówPremium.Models
{
    [MetadataType(typeof(OsobaValidation))]
    public partial class Osoba
    {
    }

    public class OsobaValidation
    {
        [HiddenInput(DisplayValue = false), ScaffoldColumn(false)]
        public int OsobaId { get; set; }
        [Required(ErrorMessage = "Proszę podać imie"), MaxLength(64)]
        public string Imie { get; set; }
        [Required(ErrorMessage = "Proszę podać nazwisko"), MaxLength(64)]
        public string Nazwisko { get; set; }
        [Required(ErrorMessage = "Proszę podać datę urodzenia"), DataType(DataType.Date), DisplayName("Data urodzenia")]
        public System.DateTime DataUrodzenia { get; set; }
        //[Required(ErrorMessage = "Proszę podać adres"), MaxLength(64)]
        public string Adres { get; set; }
        //[Required(ErrorMessage = "Proszę podać kod pocztowy"), MaxLength(32)]
        public string KodPocztowy { get; set; }
        //[Required(ErrorMessage = "Proszę podać kraj"), MaxLength(64)]
        public string Kraj { get; set; }
        //[Required(ErrorMessage = "Proszę podać numer telefonu"), MaxLength(32), DisplayName("Numer telefonu")]
        public string NrTelefonu { get; set; }
        //[Required(ErrorMessage = "Proszę podać miasto"), MaxLength(64)]
        public string Miasto { get; set; }
    }
}