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
            ///adm/Samochod/DeletePhoto/41
            context.MapRoute(
            "adm_DeletePhoto", // Pages route
            "adm/Samochod/DeletePhoto/{id}", //URL with parameters
            new { controller = "Samochod", action = "DeletePhoto", id = "" }
            );

            context.MapRoute(
            "adm_CarsForAjax", // Pages route
            "adm/Samochod/CarsForAjax/{from}/{to}/{osobaId}", //URL with parameters
            new { controller = "Samochod", action = "CarsForAjax", from = "", to = "", osobaId = "" }
            );

            context.MapRoute(
            "adm_GetPhoto", // Pages route
            "adm/Samochod/ShowPhoto/{id}", //URL with parameters
            new { controller = "Samochod", action = "ShowPhoto", id = "" }
            );

            context.MapRoute(
            "adm_hrefPhoto", // Pages route
            "adm/Samochod/Details/{samId}", //URL with parameters "/Adm/Samochod/Details/@item.ReferencedObjectId"
            new { controller = "Samochod", action = "Details", samId = "" }

            );
            context.MapRoute(
                "adm_default",
                "adm/{controller}/{action}/{id}",
                new { controller = "Panel", action = "Index", id = UrlParameter.Optional }
                );
        }
    }
}