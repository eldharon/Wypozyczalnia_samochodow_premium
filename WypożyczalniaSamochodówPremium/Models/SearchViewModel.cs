using CustomDataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class SearchViewModel
    {
        [CurrentDate(ErrorMessage = "Proszę podać poprawną datę")]
        [Required(ErrorMessage="Proszę podać datę wypożyczenia"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime dataWyp { get; set; }

        [CurrentDate(ErrorMessage = "Proszę podać poprawną datę")]
        [Required(ErrorMessage = "Proszę podać datę zwrotu"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime dataZwr { get; set; }

        public IEnumerable<Samochod> samochodyList { get; set; }

        public IEnumerable<WypozyczenieTemp> wypTemp { get; set; }

        public int osobaId { get; set; }
    }
}