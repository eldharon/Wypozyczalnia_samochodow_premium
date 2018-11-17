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
    
    public partial class Pracownik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pracownik()
        {
            this.PracownikWypozyczenie = new HashSet<PracownikWypozyczenie>();
        }
    
        public int PracownikId { get; set; }
        public System.DateTime DataZatrudnienia { get; set; }
        public Nullable<System.DateTime> DataZwolnienia { get; set; }
        public double Pensja { get; set; }
        public Nullable<double> Premia { get; set; }
        public string Stanowisko { get; set; }
        public int OsobaId { get; set; }
    
        public virtual Osoba Osoba { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PracownikWypozyczenie> PracownikWypozyczenie { get; set; }
    }
}
