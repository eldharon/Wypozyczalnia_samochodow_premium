using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class PracownikSelectList
    {
        static readonly IDictionary<string, string> Stanowisko = new Dictionary<string, string>
        {
            {"obsługa","obsługa" },
            {"kierowca","kierowca" },
            {"menadżer","menadżer" },
        };

        public static IDictionary<string, string> StanowikoList
        {
            get { return Stanowisko; }
        }
    }
}
