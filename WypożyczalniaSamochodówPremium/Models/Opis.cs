//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WypożyczalniaSamochodówPremium.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Opis
    {
        public int idOpis { get; set; }
        public string OpisOgolny { get; set; }
        public string Wyposazenie { get; set; }
        public int Samochod_IdSamochodu { get; set; }
    
        public virtual Samochod Samochod { get; set; }
    }
}
