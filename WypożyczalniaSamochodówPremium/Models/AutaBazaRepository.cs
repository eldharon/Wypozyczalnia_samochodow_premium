using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class AutaBazaRepository
    {
        WypozyczenieEntities entities = new WypozyczenieEntities();

        public IQueryable<AutaBaza> GetAllRecords()
        {
            return entities.autaBaza;
        }
        public IQueryable<AutaBaza> GetModelsForMake(string make)
        {
            return from autaBaza in entities.autaBaza where autaBaza.Marka == make select autaBaza;
        }
        public List<string> GetAllMarki()
        {
            return (from autaBaza in entities.autaBaza select autaBaza.Marka).Distinct().OrderBy(a => a).ToList();
        }
        public List<string> GetModeleForView(string make)
        {
            return (from autaBaza in entities.autaBaza where autaBaza.Marka == make select autaBaza.Model).OrderBy(m => m).ToList();
        }
        public AutaBaza GetRecordById(int id)
        {
            return entities.autaBaza.SingleOrDefault(s => s.AutoId == id);
        }
        public IQueryable<AutaBaza> GetRecordByMakeModel(string make, string model)
        {
            return from autaBaza in entities.autaBaza where autaBaza.Marka == make && autaBaza.Model == model select autaBaza;
        }

        public void Add(AutaBaza samochod)
        {
            entities.autaBaza.Add(samochod);
        }

        public void Delete(AutaBaza samochod)
        {
            entities.autaBaza.Remove(samochod);
        }

        public void Save()
        {
            entities.SaveChanges();
        }
    }
}