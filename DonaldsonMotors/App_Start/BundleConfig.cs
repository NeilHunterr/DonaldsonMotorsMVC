using System.Web;
using System.Web.Optimization;

namespace DonaldsonMotors
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/daypilot-all.min.js",
                        "~/Scripts/main.js",
                        "~/vendor/jquery/jquery.min.js",
                        "~/vendor/bootstrap/js/bootstrap.bundle.min.js",
                        "~/vendor/jquery.easing/jquery.easing.min.js",
                        "~/vendor/php-email-form/validate.js",
                        "~/vendor/counterup/counterup.min.js",
                        "~/vendor/tether/js/tether.min.js",
                        "~/vendor/jquery-sticky/jquery.sticky.js",
                        "~/vendor/venobox/venobox.min.js",
                        "~/vendor/lockfixed/jquery.lockfixed.min.js",
                        "~/vendor/waypoints/jquery.waypoints.min.js",
                        "~/vendor/superfish/superfish.min.js",
                        "~/vendor/hoverIntent/hoverIntent.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/vendor/bootstrap/css/bootstrap.min.css",
                      "~/vendor/venobox/venobox.css",
                      "~/vendor/font-awesome/css/font-awesome.min.css",
                      "~/Content/style.css"));
        }
    }
}
