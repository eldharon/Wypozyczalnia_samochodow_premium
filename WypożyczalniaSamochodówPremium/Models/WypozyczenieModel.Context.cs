﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WypozyczenieEntities : DbContext
    {
        public WypozyczenieEntities()
            : base("name=WypozyczenieEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<Akcesoria> akcesoria { get; set; }
        public virtual DbSet<Cennik> cenniki { get; set; }
        public virtual DbSet<Dostepnosc> dostepnosci { get; set; }
        public virtual DbSet<DowodOsobisty> dowodyOsobiste { get; set; }
        public virtual DbSet<DowodRejestracyjny> dowodyRejestracyjne { get; set; }
        public virtual DbSet<KlientFirma> klienciFirmy { get; set; }
        public virtual DbSet<KlientIndywidualny> klienciIndywidualni { get; set; }
        public virtual DbSet<Opis> opisy { get; set; }
        public virtual DbSet<Osoba> osoby { get; set; }
        public virtual DbSet<Paszport> paszporty { get; set; }
        public virtual DbSet<Pracownik> pracownicy { get; set; }
        public virtual DbSet<PracownikWypozyczenie> pracownicyWypozyczenia { get; set; }
        public virtual DbSet<PrawoJazdy> prawaJazdy { get; set; }
        public virtual DbSet<Przeglad> przeglady { get; set; }
        public virtual DbSet<Rozliczenie> rozliczenia { get; set; }
        public virtual DbSet<Samochod> samochody { get; set; }
        public virtual DbSet<Serwis> serwisy { get; set; }
        public virtual DbSet<Ubezpieczenie> ubezpieczenia { get; set; }
        public virtual DbSet<Wydarzenie> wydarzenia { get; set; }
        public virtual DbSet<Wypozyczenie> wypozyczenia { get; set; }
        public virtual DbSet<WypSam> wypozyczeniaSamochody { get; set; }
    }
}
