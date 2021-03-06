﻿using System.Web;
using System.Web.Optimization;

namespace WypożyczalniaSamochodówPremium
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //START ADM
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

            bundles.Add(new StyleBundle("~/Content/Unify/jquery-ui").Include(
               "~/Content/Unify/jquery-ui/themes/base/jquery-ui.min.css"
               ));
            //END ADM



            ////START UNIFY
            ////CSS
            //bundles.Add(new StyleBundle("BootstrapUNIFY").Include(
            //    "~/Content/bootstrap.min.css"               
            //    ));
            //bundles.Add(new StyleBundle("IconsUNIFY").Include(
            //    "~/Content/font-awesome.min.css"
            //    ));
            ////END CSS

            ////JS
            //bundles.Add(new ScriptBundle("JQueryUNIFY").Include(
            //    "~/Scripts/jquery-{version}.js"
            //    ));

            ////END JS



            ////END UNIFY





            //END---------------------------------------------------------------

            bundles.Add(new StyleBundle("~/Content/UnifyCSS").Include(
                 "~/Content/bootstrap.min.css",
                 "~/Content/font-awesome.min.css",
                 "~/Content/simple-line-icons.min.css",
                 "~/Content/Unify/icon-etlinefont/style.css",
                 "~/Content/Unify/icon-line-pro/style.css",
                 "~/Content/Unify/icon-hs/style.css",
                 "~/Content/Unify/dzsparallaxer/dzsparallaxer.css",
                 "~/Content/Unify/dzsparallaxer/dzsscroller/scroller.css",
                 "~/Content/Unify/dzsparallaxer/advancedscroller/plugin.css",
                 "~/Content/Unify/jquery-ui/themes/base/jquery-ui.min.css",
                 "~/Content/Unify/slick-carousel/slick/slick.css",
                 "~/Content/Unify/customcss/animate.css",
                 "~/Content/Unify/hs-megamenu/src/hs.megamenu.css",
                 "~/Content/Unify/hamburgers/hamburgers.min.css",
                 "~/Content/Unify/customcss/unify-core.css",
                 "~/Content/Unify/customcss/unify-components.css",
                 "~/Content/Unify/customcss/unify-globals.css",
            "~/Content/Unify/customcss/custom.css"
            ));

            bundles.Add(new StyleBundle("~/Content/UnifyCustomCSS").Include(
                "~/Content/Unify/customcss/custom.css"
                ));
            bundles.Add(new ScriptBundle("~/bundles/UnifyJS").Include(
                "~/Content/Unify/hs-megamenu/src/hs.megamenu.js",
                "~/Content/Unify/dzsparallaxer/dzsparallaxer.js",
                "~/Content/Unify/dzsparallaxer/dzsscroller/scroller.js",
                "~/Content/Unify/dzsparallaxer/advancedscroller/plugin.js",
                "~/Content/Unify/chosen/chosen.jquery.js",
                "~/Content/Unify/image-select/src/ImageSelect.jquery.js",
                "~/Content/Unify/masonry/dist/masonry.pkgd.min.js",
                "~/Content/Unify/imagesloaded/imagesloaded.js",
                "~/Content/Unify/slick-carousel/slick/slick.js",
                "~/Content/Unify/components/hs.header.js",
                "~/Content/Unify/helpers/hs.hamburgers.js",
                "~/Content/Unify/components/hs.scroll-nav.js",
                "~/Content/Unify/components/hs.go-to.js",
                "~/Content/Unify/components/hs.sticky-block.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/WWW_js_global_compulsory").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery-migrate-{version}.js",
                "~/Scripts/umd/popper.min.js",
                "~/Scripts/bootstrap.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/WWW_js_implementing_plugins_home").Include(
                "~/Content/Unify/appear.js",
                "~/Content/Unify/slick-carousel/slick/slick.js",
                "~/Content/Unify/hs-megamenu/src/hs.megamenu.js",
                "~/Content/Unify/dzsparallaxer/dzsparallaxer.js",
                "~/Content/Unify/dzsparallaxer/dzsscroller/scroller.js",
                "~/Content/Unify/dzsparallaxer/advancedscroller/plugin.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/WWW_js_implementing_plugins_min").Include(
                "~/Content/Unify/appear.js",
                "~/Content/Unify/slick-carousel/slick/slick.js",
                "~/Content/Unify/hs-megamenu/src/hs.megamenu.js",
                "~/Content/Unify/dzsparallaxer/dzsparallaxer.js",
                "~/Content/Unify/dzsparallaxer/dzsscroller/scroller.js",
                "~/Content/Unify/dzsparallaxer/advancedscroller/plugin.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/WWW_js_unify").Include(
                "~/Content/Unify/hs.core.js",
                "~/Content/Unify/components/hs.carousel.js",
                "~/Content/Unify/components/hs.header.js",
                "~/Content/Unify/helpers/hs.hamburgers.js",
                "~/Content/Unify/components/hs.tabs.js",
                "~/Content/Unify/components/hs.onscroll-animation.js",
                "~/Content/Unify/components/hs.sticky-block.js",
                "~/Content/Unify/components/hs.go-to.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/WWW_js_custom").Include(
                "~/Content/Unify/customjs/custom.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/Unify/jquery-ui").Include(
                "~/Content/Unify/jquery-ui/ui/widget.js",
                "~/Content/Unify/jquery-ui/ui/version.js",
                "~/Content/Unify/jquery-ui/ui/keycode.js",
                "~/Content/Unify/jquery-ui/ui/position.js",
                "~/Content/Unify/jquery-ui/ui/unique-id.js",
                "~/Content/Unify/jquery-ui/ui/safe-active-element.js",
                "~/Content/Unify/jquery-ui/ui/widgets/menu.js",
                "~/Content/Unify/jquery-ui/ui/widgets/mouse.js",
                "~/Content/Unify/jquery-ui/ui/widgets/datepicker.js",
                "~/Content/Unify/jquery-ui/js/components/hs.datepicker.js"
                ));
        }


    }
}
