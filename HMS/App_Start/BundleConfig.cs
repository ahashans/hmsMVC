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
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/moment*",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/respond.js",
                        "~/Scripts/DataTables/jquery.datatables.js",
                        "~/Scripts/DataTables/datatables.bootstrap.js",
                        "~/Scripts/owl.carousel.js",
                        "~/Scripts/plugins.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include());

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-flatly.css",
                      "~/Content/DataTables/css/datatables.bootstrap.css",
                      "~/Content/owl.carousel.css",
                      "~/Content/owl.theme.default.css",
                      "~/Content/animate.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/jquery-ui.css",
                      "~/Content/responsive.css",
                      "~/Content/slider.css",
                      "~/Content/site.css"));
        }
    }
}
