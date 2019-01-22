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
        public IEnumerable<Samochod> FindCarsForTimeRange(DateTime from, DateTime to, int osobaId)
        {

            var temp = entities.wypozyczenia.Where(x => (x.DataWypozyczenia <= from && x.DataZwrotu >= to)
           || (x.DataWypozyczenia >= from && x.DataZwrotu <= to)
           || (x.DataWypozyczenia <= from && x.DataZwrotu <= to && x.DataZwrotu >= from)
           || (x.DataWypozyczenia >= from && x.DataZwrotu >= to && x.DataWypozyczenia <= to))
          .Join(entities.wypozyczeniaSamochody,
                wyp => wyp.WypozyczenieId,
                wypsam => wypsam.WypozyczenieId,
                (wyp, wypsam) => new { Wypozyczenie = wyp, WypSam = wypsam })
                .Select(x => x.WypSam)
          .Join(entities.samochody,
                wypsam => wypsam.SamochodId,
                sam => sam.SamochodId,
                (wypsam, sam) => new { WypSam = wypsam, Samochod = sam }).Select(x => x.Samochod);


            var wypTemp = (from samochod in entities.samochody
                           join wypozyczenieTemp in entities.wypozyczeniaTemp
                           on samochod.SamochodId equals wypozyczenieTemp.SamochodId
                           where wypozyczenieTemp.OsobaId == osobaId
                           select wypozyczenieTemp).Where(x => (x.DataWypozyczenia <= from && x.DataZwrotu >= to)
                           || (x.DataWypozyczenia >= from && x.DataZwrotu <= to)
                           || (x.DataWypozyczenia <= from && x.DataZwrotu <= to && x.DataZwrotu >= from)
                           || (x.DataWypozyczenia >= from && x.DataZwrotu >= to && x.DataWypozyczenia <= to)).Select(x => x.Samochod);


            var list1 = temp.Select(x => x.SamochodId);
            var list2 = wypTemp.Select(x => x.SamochodId);

            var result = entities.samochody.Where(x => !list1.Contains(x.SamochodId) && !list2.Contains(x.SamochodId));
            var check2 = result.ToList();

            return result;
        }
        public IEnumerable<SelectListItem> GetModelsForTimeRange(string marka, DateTime from, DateTime to, int osobaId)
        {

            var temp = entities.wypozyczenia.Where(x => (x.DataWypozyczenia <= from && x.DataZwrotu >= to)
           || (x.DataWypozyczenia >= from && x.DataZwrotu <= to)
           || (x.DataWypozyczenia <= from && x.DataZwrotu <= to && x.DataZwrotu >= from)
           || (x.DataWypozyczenia >= from && x.DataZwrotu >= to && x.DataWypozyczenia <= to))
          .Join(entities.wypozyczeniaSamochody,
                wyp => wyp.WypozyczenieId,
                wypsam => wypsam.WypozyczenieId,
                (wyp, wypsam) => new { Wypozyczenie = wyp, WypSam = wypsam })
                .Select(x => x.WypSam)
          .Join(entities.samochody,
                wypsam => wypsam.SamochodId,
                sam => sam.SamochodId,
                (wypsam, sam) => new { WypSam = wypsam, Samochod = sam }).Select(x => x.Samochod);


            var wypTemp = (from samochod in entities.samochody
                           join wypozyczenieTemp in entities.wypozyczeniaTemp
                           on samochod.SamochodId equals wypozyczenieTemp.SamochodId
                           where wypozyczenieTemp.OsobaId == osobaId
                           select wypozyczenieTemp).Where(x => (x.DataWypozyczenia <= from && x.DataZwrotu >= to)
                           || (x.DataWypozyczenia >= from && x.DataZwrotu <= to)
                           || (x.DataWypozyczenia <= from && x.DataZwrotu <= to && x.DataZwrotu >= from)
                           || (x.DataWypozyczenia >= from && x.DataZwrotu >= to && x.DataWypozyczenia <= to)).Select(x => x.Samochod);


            var list1 = temp.Select(x => x.SamochodId);
            var list2 = wypTemp.Select(x => x.SamochodId);

            var result = entities.samochody.Where(x => !list1.Contains(x.SamochodId) && !list2.Contains(x.SamochodId));
            var check2 = result.ToList();


            IEnumerable<SelectListItem> models = result
                .OrderBy(x => x.Model)
                .Where(x => x.Marka == marka)
                .Select(x =>
                new SelectListItem
                {
                    Value = x.SamochodId.ToString(),
                    Text = (x.Model + ", " + x.RokProdukcji.Year + ", " + x.Kolor),
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