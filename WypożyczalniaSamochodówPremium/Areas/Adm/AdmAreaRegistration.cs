using System.Web.Mvc;

namespace WypożyczalniaSamochodówPremium.Areas.Adm
{
    public class AdmAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Adm";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
            "adm_CarsForAjax", // Pages route
            "adm/Samochod/CarsForAjax/{from}/{to}", //URL with parameters
            new { controller = "Samochod", action = "CarsForAjax", from = "", to = "" }
            );

            context.MapRoute(
                "adm_default",
                "adm/{controller}/{action}/{id}",
                new { controller = "Panel", action = "Index", id = UrlParameter.Optional }
                );
        }
    }
}