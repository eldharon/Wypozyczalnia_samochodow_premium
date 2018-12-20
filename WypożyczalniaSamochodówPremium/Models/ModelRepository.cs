using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class ModelRepository
    {
        public IEnumerable<SelectListItem> GetModels()
        {
            List<SelectListItem> models = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Value = null,
                    Text = " "
                }
            };
            return models;
        }

        public IEnumerable<SelectListItem> GetModels(string make)
        {
            if (!String.IsNullOrWhiteSpace(make))
            {
                using (var context = new WypozyczenieEntities())
                {
                    IEnumerable<SelectListItem> models = context.autaBaza.AsNoTracking()
                        .OrderBy(n => n.Model)
                        .Where(n => n.Marka == make)
                        .Select(n =>
                           new SelectListItem
                           {
                               Value = n.Model,
                               Text = n.Model
                           }).ToList();
                    return new SelectList(models, "Value", "Text");
                }
            }
            return null;
        }
    }
}