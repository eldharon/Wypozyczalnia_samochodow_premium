using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class AutaBazaDTO
    {
        public string brand { get; set; }
        public List<string> models { get; set; }
    }
}