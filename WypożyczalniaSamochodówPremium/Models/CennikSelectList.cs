using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class CennikSelectList
    {
        static readonly IDictionary<string, string> Opis = new Dictionary<string, string>
        {
            {"dzień","dzień" },
            {"tydzień","tydzień" },
            {"miesiąc","miesiąc" },
        };

        public static IDictionary<string, string> OpisList
        {
            get { return Opis; }
        }
    }
}
