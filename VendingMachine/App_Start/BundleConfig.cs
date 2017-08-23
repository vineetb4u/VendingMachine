using System.Web;
using System.Web.Optimization;

namespace VendingMachine
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new Bundle("~/bundles/libraries")
               .Include(
                   "~/Scripts/jquery-{version}.js",
                   "~/Scripts/jquery.validate*",
                   "~/Scripts/underscore.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            ));

            bundles.Add(new Bundle("~/bundles/angular")
                .Include(
                    "~/Scripts/angular.js",
                    "~/Scripts/angular-cookies.js",
                    "~/Scripts/angular-route.js",
                    "~/Scripts/angular-resource.js",
                    "~/Scripts/angular-animate.js"));

            bundles.Add(new ScriptBundle("~/bundles/modules")
                .IncludeDirectory("~/Modules/UI", "*.js", true)
                .Include("~/Modules/application.js"));


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
