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
    
    public partial class DowodRejestracyjny
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DowodRejestracyjny()
        {
            this.ImageDowodRejestracyjny = new HashSet<ImageDowodRejestracyjny>();
        }
    
        public int DowodRejId { get; set; }
        public string VIN { get; set; }
        public int Seria { get; set; }
        public string NrRejestracyjny { get; set; }
        public int SamochodId { get; set; }
    
        public virtual Samochod Samochod { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImageDowodRejestracyjny> ImageDowodRejestracyjny { get; set; }
    }
}
