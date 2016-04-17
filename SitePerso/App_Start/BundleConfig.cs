using System.Web;
using System.Web.Optimization;

namespace SitePerso
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/coundown-timer.js",
                      "~/Scripts/bohtml5shivotstrap.js",
                      "~/Scripts/jquery.js",
                      "~/Scripts/jquery.nav.js",
                      "~/Scripts/jquery.parallax.js",
                      "~/Scripts/jquery.scrollTo.js",
                      "~/Scripts/main.js",
                      "~/Scripts/modernizr.custom.86080.js",
                      "~/Scripts/respond.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/animate.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/main.css",
                      "~/Content/responsive.css"));
        }
    }
}
