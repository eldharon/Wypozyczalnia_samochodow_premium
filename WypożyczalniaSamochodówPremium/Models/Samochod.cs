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
    
    public partial class Samochod
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Samochod()
        {
            this.Cennik = new HashSet<Cennik>();
            this.Dostepnosc = new HashSet<Dostepnosc>();
            this.DowodRejestracyjny = new HashSet<DowodRejestracyjny>();
            this.Opis = new HashSet<Opis>();
            this.Przeglad = new HashSet<Przeglad>();
            this.Serwis = new HashSet<Serwis>();
            this.Ubezpieczenie = new HashSet<Ubezpieczenie>();
            this.WypSam = new HashSet<WypSam>();
        }
    
        public int SamochodId { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Wersja { get; set; }
        public System.DateTime RokProdukcji { get; set; }
        public string RodzajSilnika { get; set; }
        public string PojemnoscSilnika { get; set; }
        public string SkrzyniaBiegow { get; set; }
        public string LiczbaDrzwi { get; set; }
        public string Kolor { get; set; }
        public int Przebieg { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cennik> Cennik { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dostepnosc> Dostepnosc { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DowodRejestracyjny> DowodRejestracyjny { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Opis> Opis { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Przeglad> Przeglad { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Serwis> Serwis { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ubezpieczenie> Ubezpieczenie { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WypSam> WypSam { get; set; }
    }
}
