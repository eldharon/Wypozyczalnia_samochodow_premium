using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WypożyczalniaSamochodówPremium.Models
{
    [MetadataType(typeof(UbezpieczenieValidation))]
    public partial class Ubezpieczenie
    {
    }

    public class UbezpieczenieValidation
    {
        [HiddenInput(DisplayValue = false), ScaffoldColumn(false)]
        public int UbezpieczenieId { get; set; }
        [DisplayName("Numer polisy")]
        public string NumerPolisy { get; set; }
        [Required(ErrorMessage = "Proszę podać datę od kiedy ubezpieczenie obowiązuje"), DataType(DataType.Date), DisplayName("Ważne od")]
        public System.DateTime WazneOd { get; set; }
        [Required(ErrorMessage = "Proszę podać datę do kiedy ubezpieczenie obowiązuje"), DataType(DataType.Date), DisplayName("Ważne do")]
        public System.DateTime WazneDo { get; set; }

    }
}