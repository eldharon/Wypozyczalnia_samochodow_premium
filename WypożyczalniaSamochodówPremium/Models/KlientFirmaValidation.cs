using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WypożyczalniaSamochodówPremium.Models
{
    [MetadataType(typeof(KlientFirmaValidation))]
    public partial class KlientFirma
    {
    }

    public class KlientFirmaValidation
    {
        [HiddenInput(DisplayValue = false), ScaffoldColumn(false)]
        public int KlientFirmaId { get; set; }
        [Required(ErrorMessage = "Proszę podać nazwę firmy"), DisplayName("Nazwa firmy"), MaxLength(32)]
        public string NazwaFrimy { get; set; }
        [Required(ErrorMessage = "Proszę podać nazwę firmy"), MaxLength(64)]
        public string NIP { get; set; }
        [DisplayName("Rabat firmy"), DataType(DataType.Currency)]
        public Nullable<int> RabatFirma { get; set; }
        [DisplayName("Adres firmy"), MaxLength(64)]
        public string AdresFirmy { get; set; }
        [DisplayName("Kod pocztowy"), MaxLength(16)]
        public string KodPocztowy { get; set; }
        [MaxLength(16)]
        public string Miasto { get; set; }
    }
}