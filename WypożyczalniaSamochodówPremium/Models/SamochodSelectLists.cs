using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class SamochodSelectLists
    {
        static readonly List<string> Paliwa = new List<string>(new string[]
        {
            "Benzyna",
            "Diesel",
            "Benzyna + LPG",
            "CNG",
            "Hybryda",
            "Elektryczny"            
        });

        static readonly List<string> LiczbaDrzwi = new List<string>(new string[]
        {
            "Trzydrzwiowy",
            "Czterodrzwiowy",
            "Pięciodrzwiowy",
            "Wielodrzwiowy"
        });

        static readonly List<string> RodzajSkrzyni = new List<string>(new string[]
        {
            "Manualna",
            "Automatyczna"
        });

        public static List<string> PaliwaList
        {
            get { return Paliwa; }
        }
        public static List<string> LiczbaDrzwiList
        {
            get { return LiczbaDrzwi; }
        }
        public static List<string> RodzajSkrzyniList
        {
            get { return RodzajSkrzyni; }
        }

    }
}