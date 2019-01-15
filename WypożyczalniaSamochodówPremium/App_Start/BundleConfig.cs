using System.Web;
using System.Web.Optimization;

namespace WypożyczalniaSamochodówPremium
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                "~/Content/bootstrap.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.validate.unobtrusive*"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/ajax").Include(
                        "~/Scripts/jquery.unobtrusive-ajax.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/loginjs").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/umd/popper.min.js",
                "~/Scripts/bootstrap.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/popper").Include(
                        "~/Scripts/umd/popper.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/cleveradminJS").Include(
                "~/Scripts/pace.min.js",
                "~/Scripts/app.js"
                ));
            bundles.Add(new StyleBundle("~/Content/logincss").Include(
                "~/Content/CleverAdmin/css/style.css",
                "~/Content/font-awesome.min.css"
                ));
            

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/flag-icon.min.css",
                      "~/Content/simple-line-icons.min.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/custom-www.css"));

            bundles.Add(new StyleBundle("~/Content/cleveradminCSSstyle").Include(
                "~/Content/CleverAdmin/css/style.css",
                "~/Content/CleverAdmin/css/custom.css"));

            bundles.Add(new StyleBundle("~/Content/icons").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/simple-line-icons.min.css",
                "~/Content/font-awesome.min.css"
                ));
            bundles.Add(new StyleBundle("~/Content/toastrCSS").Include(
                "~/Content/CleverAdmin/toastr.css"
                ));
        }


    }
}
