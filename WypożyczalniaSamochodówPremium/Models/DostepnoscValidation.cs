using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WypożyczalniaSamochodówPremium.Models
{
    [MetadataType(typeof(DostepnoscValidation))]
    public partial class Dostepnosc
    {
    }

    public class DostepnoscValidation
    {
        [HiddenInput(DisplayValue = false), ScaffoldColumn(false)]
        public int DostepnoscId { get; set; }
        [DataType(DataType.DateTime), DisplayName("Ważne od")]
        public Nullable<System.DateTime> NiedostepnyOd { get; set; }
        [Required(ErrorMessage = "Proszę podać datę do kiedy samochód jest niedostepny"), DataType(DataType.DateTime), DisplayName("Ważne od")]
        public System.DateTime NiedostepnyDo { get; set; }
    }
}