using System.Web;
using System.Web.Optimization;

namespace HMS
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery.js",
                        "~/Scripts/moment*",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/jquery.stellar.js",
                        "~/Scripts/jquery-ui-1.10.3.custom.js",
                        "~/Scripts/owl.carousel.js",
                        "~/Scripts/counter.js",
                        "~/Scripts/waypoints.js",
                        "~/Scripts/jquery.uniform.js",
                        "~/Scripts/easyResponsiveTabs.js",
                        "~/Scripts/jquery.fancybox.pack.js",
                        "~/Scripts/jquery.fancybox-media.js",
                        "~/Scripts/jquery.mixitup.js",
                        "~/Scripts/forms-validation.js",
                        "~/Scripts/jquery.jcarousel.min.js",
                        "~/Scripts/jquery.easypiechart.min.js",
                        "~/Scripts/scripts.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/adminlib").Include(
                "~/admn-lte/jquery/jquery.js",
                "~/admn-lte/moment/moment.js",                
                "~/Scripts/respond.js",
                "~/Scripts/DataTables/jquery.datatables.js",
                "~/Scripts/DataTables/datatables.bootstrap.js",
                "~/Scripts/owl.carousel.js",
                "~/Scripts/plugins.js",
                "~/Content/SBAdminPanel/js/jquery.js",
                "~/Content/SBAdminPanel/js/bootstrap.min.js",
                "~/Content/SBAdminPanel/js/jquery.js"
            ));
            //            "~/Content/SBAdminPanel/js/jquery.js"
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            //jQuery fullcalendar plugin css
            bundles.Add(new StyleBundle("~/Content/fullcalendar").Include(
                "~/Content/fullcalendar.css"));

            //jQuery fullcalendar plugin js
            bundles.Add(new ScriptBundle("~/bundles/fullcalendar").Include(
                "~/Scripts/moment.js",  //Include the moment.js
                "~/Scripts/fullcalendar.js"));
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include());

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/blue.css",
                      "~/Content/medicom.css",
                      "~/Content/revolution_style.css",
                      "~/Content/settings.css"
                      ));
            bundles.Add(new StyleBundle("~/Content/admincss").Include(
                "~/Content/SBAdminPanel/css/bootstrap.min.css",
                "~/Content/DataTables/css/datatables.bootstrap.css",
                "~/Content/owl.carousel.css",
                "~/Content/owl.theme.default.css",
                "~/Content/animate.css",
                "~/Content/font-awesome.min.css",
                "~/Content/jquery-ui.css",
                "~/Content/responsive.css",
                "~/Content/slider.css",
                "~/Content/SBAdminPanel/css/sb-admin.css",
                "~/Content/font-awesome/css/font-awesome.min.css"
            ));
        }
    }
}
