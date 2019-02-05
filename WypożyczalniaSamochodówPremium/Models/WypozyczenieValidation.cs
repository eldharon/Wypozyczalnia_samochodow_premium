using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomDataAnnotations;

namespace WypożyczalniaSamochodówPremium.Models
{
    [MetadataType(typeof(WypozyczenieValidation))]
    public partial class Wypozyczenie
    {
        public virtual IEnumerable<WypSam> wypSamList { get; set; }
    }

    public class WypozyczenieValidation
    {
        [HiddenInput(DisplayValue = false), ScaffoldColumn(false)]
        public int WypozyczenieId { get; set; }
        [CurrentDate(ErrorMessage = "Proszę się nie bawić w doktora Emmetta Browna XD")]
        [Required(ErrorMessage = "Proszę podać datę wypożyczenia"), DataType(DataType.Date), DisplayName("Data wypożyczenia")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime DataWypozyczenia { get; set; }
        [CurrentDate(ErrorMessage = "Proszę się nie bawić w doktora Who XD")]
        [Required(ErrorMessage = "Proszę podać datę zwrotu"), DataType(DataType.Date), DisplayName("Data zwrotu")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime DataZwrotu { get; set; }
        [Required(ErrorMessage = "Proszę wybrac czy samochod ma byc dostarczony"), DisplayName("Czy samochód ma być dostarczony?")]
        public bool CzyDostarczany { get; set; }
        [Required(ErrorMessage = "Proszę wybrac czy potrzebny bedzie firmowy kierowca do prowadzenia samochodu")]
        public bool CzyKierowca { get; set; }
        [DisplayName("Adres dojazdu"), MaxLength(64)]
        public string AdresDojazdu { get; set; }
        [DisplayName("Wydarzenie")]
        public int WydarzenieId { get; set; }
    }
}