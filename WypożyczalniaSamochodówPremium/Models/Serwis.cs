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
    
    public partial class Serwis
    {
        public int SerwisId { get; set; }
        public System.DateTime DataOddania { get; set; }
        public System.DateTime DataOdbioru { get; set; }
        public double Koszt { get; set; }
        public string Uwagi { get; set; }
        public int SamochodId { get; set; }
    
        public virtual Samochod Samochod { get; set; }
    }
}
