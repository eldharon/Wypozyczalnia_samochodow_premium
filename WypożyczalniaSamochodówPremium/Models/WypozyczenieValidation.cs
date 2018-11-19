using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WypożyczalniaSamochodówPremium.Models
{
    [MetadataType(typeof(WypozyczenieValidation))]
    public partial class Wypozyczenie
    {
    }

    public class WypozyczenieValidation
    {
        [HiddenInput(DisplayValue = false), ScaffoldColumn(false)]
        public int WypozyczenieId { get; set; }
        [Required(ErrorMessage = "Proszę podać datę wypożyczenia"), DataType(DataType.DateTime), DisplayName("Data wypożyczenia")]
        public System.DateTime DataWypozyczenia { get; set; }
        [Required(ErrorMessage = "Proszę podać datę zwrotu"), DataType(DataType.DateTime), DisplayName("Data zwrotu")]
        public System.DateTime DataZwrotu { get; set; }
        [Required(ErrorMessage = "Proszę wybrac czy samochod ma byc dostarczony")]
        public bool CzyDostarczany { get; set; }
        [Required(ErrorMessage = "Proszę wybrac czy potrzebny bedzie firmowy kierowca do prowadzenia samochodu")]
        public bool CzyKierowca { get; set; }
        [DisplayName("Adres dojazdu"), MaxLength(64)]
        public string AdresDojazdu { get; set; }
    }
}