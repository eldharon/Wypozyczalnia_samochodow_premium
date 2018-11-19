using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;
using System.Threading;
using System.Globalization;
using WypożyczalniaSamochodówPremium.Models;

namespace WypożyczalniaSamochodówPremium.Helpers
{
    public class LangHelper
    {

        public static string lang_id()
        {
            if (HttpContext.Current.Request.RequestContext.RouteData.Values["lang"] != null && !string.IsNullOrWhiteSpace(HttpContext.Current.Request.RequestContext.RouteData.Values["lang"].ToString()) && HttpContext.Current.Request.RequestContext.RouteData.Values["culture"] != null && !string.IsNullOrWhiteSpace(HttpContext.Current.Request.RequestContext.RouteData.Values["culture"].ToString()))
            {   
                // set the lang from the route data (url)
                var lang = HttpContext.Current.Request.RequestContext.RouteData.Values["lang"].ToString();
                var culture = HttpContext.Current.Request.RequestContext.RouteData.Values["culture"].ToString();
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(lang+"-"+culture);
                HttpContext.Current.Session["Lang"] = lang + "-" + culture;

                return lang + "-" + culture;
            }   
            else  
            {

                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("pl-PL");
                HttpContext.Current.Session["Lang"] = "pl-PL";
                return "pl-PL";

            }

        }
    }
}
