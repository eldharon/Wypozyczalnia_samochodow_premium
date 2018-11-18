using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WypożyczalniaSamochodówPremium.Models
{
    [MetadataType(typeof(SerwisValidation))]
    public partial class Serwis
    {
    }

    public class SerwisValidation
    {
        [HiddenInput(DisplayValue = false), ScaffoldColumn(false)]
        public int SerwisId { get; set; }
        [Required(ErrorMessage = "Proszę podać datę oddania samochodu na serwis"), DataType(DataType.Date), DisplayName("Data oddania")]
        public System.DateTime DataOddania { get; set; }
        [Required(ErrorMessage = "Proszę podać datę odbioru samochodu z serwisu"), DataType(DataType.Date), DisplayName("Data odbioru")]
        public System.DateTime DataOdbioru { get; set; }
        [Required(ErrorMessage = "Proszę podać koszt serwisu"), DataType(DataType.Currency)]
        public double Koszt { get; set; }       
        public string Uwagi { get; set; }
    }
}