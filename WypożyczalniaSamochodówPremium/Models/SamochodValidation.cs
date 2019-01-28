using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WypożyczalniaSamochodówPremium.Models
{

    [MetadataType(typeof(SamochodValidation))]
    public partial class Samochod
    {
        public virtual int PhotoId { get; set; }
        public IEnumerable<Opis> opisy { get; set; }
        public IEnumerable<ImageSamochod> photos { get; set; }
    }

    public class SamochodValidation
    {
        [HiddenInput(DisplayValue = false), ScaffoldColumn(false)]
        public int SamochodId { get; set; }
        [Required(ErrorMessage = "Proszę podać markę"),MaxLength(32)]
        public string Marka { get; set; }
        
        [Required(ErrorMessage = "Proszę podać model"), MaxLength(32)]
        public string Model { get; set; }
        
        [Required(ErrorMessage = "Proszę podać wersję"), MaxLength(64)]
        public string Wersja { get; set; }
        [Required(ErrorMessage = "Proszę podać rok produkcji"), DataType(DataType.Date), DisplayName("Rok produkcji")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime RokProdukcji { get; set; }
        [Required(ErrorMessage = "Proszę podać rodzaj silnika"), MaxLength(16), DisplayName("Rodzaj silnika")]
        public string RodzajSilnika { get; set; }
        [Required(ErrorMessage = "Proszę podać pojemność silnika"), MaxLength(16), DisplayName("Pojemność silnika")]
        public string PojemnoscSilnika { get; set; }
        [Required(ErrorMessage = "Proszę podać rodzaj skrzyni biegów"), MaxLength(16), DisplayName("Skrzynia biegów")]
        public string SkrzyniaBiegow { get; set; }
        [Required(ErrorMessage = "Proszę podać liczbe drzwi"), MaxLength(32), DisplayName("Liczba drzwi")]
        public string LiczbaDrzwi { get; set; }
        [Required(ErrorMessage = "Proszę podać kolor"), MaxLength(16)]
        public string Kolor { get; set; }
        [Required]
        public int Przebieg { get; set; }
        public string Status { get; set; }

    }
}