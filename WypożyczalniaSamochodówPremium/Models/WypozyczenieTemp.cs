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
    
    public partial class WypozyczenieTemp
    {
        public int WypozyczenieTempId { get; set; }
        public int OsobaId { get; set; }
        public int SamochodId { get; set; }
        public System.DateTime DataWypozyczenia { get; set; }
        public System.DateTime DataZwrotu { get; set; }
    
        public virtual Osoba Osoba { get; set; }
        public virtual Samochod Samochod { get; set; }
    }
}
