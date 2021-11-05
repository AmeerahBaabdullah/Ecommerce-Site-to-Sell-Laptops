using System.Web;
using System.Web.Optimization;

namespace sell_laptop
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/js/jquery.min.js",
                         "~/Scripts/js/bootstrap.min.js",
                            "~/Scripts/js/slick.min.js",
                            "~/Scripts/js/nouislider.min.js",
                               "~/Scripts/js/jquery.zoom.min.js",
                                  "~/Scripts/js/main.js"

                      ));

            bundles.Add(new StyleBundle("~/Content/Css").Include(
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/slick.css", 
                      "~/ Content/css / slick-theme.css",
                      "~/Content/css/nouislider.min.css",
                      "~/ Content/css /font-awesome.min.css",
                      "~/Content/css/style.css" ));
        }
    }
}
