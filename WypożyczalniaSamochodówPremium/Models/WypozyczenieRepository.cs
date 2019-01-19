using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WypożyczalniaSamochodówPremium.Models;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class WypozyczenieRepository
    {
        WypozyczenieEntities entities = new WypozyczenieEntities();
        public IEnumerable<Samochod> FindCarsForTimeRange(DateTime from, DateTime to)
        {
            var temp = entities.wypozyczenia.Where(x => (x.DataWypozyczenia <= from && x.DataZwrotu >= to)
           || (x.DataWypozyczenia >= from && x.DataZwrotu <= to)
           || (x.DataWypozyczenia < from && x.DataZwrotu <= to && x.DataZwrotu > from)
           || (x.DataWypozyczenia >= from && x.DataZwrotu >= to && x.DataWypozyczenia <= from))
          .Join(entities.wypozyczeniaSamochody,
                wyp => wyp.WypozyczenieId,
                wypsam => wypsam.WypozyczenieId,
                (wyp, wypsam) => new { Wypozyczenie = wyp, WypSam = wypsam })
                .Select(x => x.WypSam)
          .Join(entities.samochody,
                wypsam => wypsam.SamochodId,
                sam => sam.SamochodId,
                (wypsam, sam) => new { WypSam = wypsam, Samochod = sam }).Select(x => x.Samochod);
            return entities.samochody.Except(temp);
        }
        public IEnumerable<SelectListItem> GetModelsForTimeRange(string marka, DateTime from, DateTime to)
        {

                var temp = entities.wypozyczenia.Where(x => (x.DataWypozyczenia <= from && x.DataZwrotu >= to)
           || (x.DataWypozyczenia >= from && x.DataZwrotu <= to)
           || (x.DataWypozyczenia < from && x.DataZwrotu <= to && x.DataZwrotu > from)
           || (x.DataWypozyczenia >= from && x.DataZwrotu >= to && x.DataWypozyczenia <= from))
                .Join(entities.wypozyczeniaSamochody,
                wyp => wyp.WypozyczenieId,
                wypsam => wypsam.WypozyczenieId,
                (wyp, wypsam) => new { Wypozyczenie = wyp, WypSam = wypsam })
                .Select(x => x.WypSam)
                .Join(entities.samochody,
                wypsam => wypsam.SamochodId,
                sam => sam.SamochodId,
                (wypsam, sam) => new { WypSam = wypsam, Samochod = sam }).Select(x => x.Samochod);
                IEnumerable<SelectListItem> models = entities.samochody.Except(temp)
                    .OrderBy(x => x.Model)
                    .Where(x => x.Marka == marka)
                    .Select(x =>
                    new SelectListItem
                    {
                        Value = x.Model,
                        Text = x.Model
                    }).ToList();
                return new SelectList(models, "Value", "Text");
            
        }
        public IQueryable<Wypozyczenie> FindAllWypozyczenia()
        {
            return entities.wypozyczenia;
        }

        public Wypozyczenie GetWypozyczenieById(int id)
        {
            return entities.wypozyczenia.SingleOrDefault(w => w.WypozyczenieId == id);
        }

        public void Add(Wypozyczenie wypozyczenie)
        {
            entities.wypozyczenia.Add(wypozyczenie);
        }

        public void Delete(Wypozyczenie wypozyczenie)
        {
            entities.wypozyczenia.Remove(wypozyczenie);
        }

        public void Save()
        {
            entities.SaveChanges();
        }
    }
}