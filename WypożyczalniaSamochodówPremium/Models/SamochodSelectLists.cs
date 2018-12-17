using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class SamochodSelectLists
    {
        static readonly List<string> Marki = new List<string>(new string[]
        {
            "Abarth",
            "Alfa Romeo",
            "Aston Martin",
            "Audi",
            "Bentley",
            "BMW",
            "Bugatti",
            "Cadillac",
            "Chevrolet",
            "Chrysler",
            "Citroën",
            "Dacia",
            "Daewoo",
            "Daihatsu",
            "Dodge",
            "Donkervoort",
            "DS",
            "Ferrari",
            "Fiat",
            "Fisker",
            "Ford",
            "Honda",
            "Hummer",
            "Hyundai",
            "Infiniti",
            "Iveco",
            "Jaguar",
            "Jeep",
            "Kia",
            "KTM",
            "Lada",
            "Lamborghini",
            "Lancia",
            "Land Rover",
            "Landwind",
            "Lexus",
            "Lotus",
            "Maserati",
            "Maybach",
            "Mazda",
            "McLaren",
            "Mercedes-Benz",
            "MG",
            "Mini",
            "Mitsubishi",
            "Morgan",
            "Nissan",
            "Opel",
            "Peugeot",
            "Porsche",
            "Renault",
            "Rolls-Royce",
            "Rover",
            "Saab",
            "Seat",
            "Skoda",
            "Smart",
            "SsangYong",
            "Subaru",
            "Suzuki",
            "Tesla",
            "Toyota",
            "Volkswagen",
            "Volvo"
        });

        static readonly List<string> Paliwa = new List<string>(new string[]
        {
            "Benzyna",
            "Diesel",
            "LPG",
            "CNG",
            "Hybryda",
            "Elektryczny"            
        });

        static readonly List<string> LiczbaDrzwi = new List<string>(new string[]
        {
            "Trzydrzwiowy",
            "Pięciodrzwiowy",
            "Wielodrzwiowy"
        });

        static readonly List<string> RodzajSkrzyni = new List<string>(new string[]
        {
            "Manualna",
            "Automatyczna"
        });


        public static List<string> MarkiList
        {
            get { return Marki; }
        }
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