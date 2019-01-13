using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class PhotoViewModel
    {
        public string Name { get; set; }
        public string AlternateText { get; set; }
        public string ContentType { get; set; }
        public byte[] Image { get; set; }
    }
}