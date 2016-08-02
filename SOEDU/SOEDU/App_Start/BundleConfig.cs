using System.Web;
using System.Web.Optimization;

namespace SOEDU
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/css/so-course.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/js/jquery-1.10.2.min.js",
                        "~/Content/Plugins/bootstrap/dist/js/bootstrap.min.js",
                        "~/Content/js/main.js",
                        "~/Content/js/jquery.scrollUp.min.js",
                         "~/Scripts/angular.js",
                         "~/app/app.js",
                         "~/app/controllers/Teacher.controller.js",
                         "~/app/services/Teacher.service.js",
                         "~/app/controllers/Course.controller.js",
                         "~/app/services/Course.service.js",
                        "~/Content/js/owl.carousel.min.js"
                        ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/Plugins/bootstrap/dist/css/bootstrap.min.css",
                "~/Content/css/Style.css",
                "~/Content/Plugins/font-awesome-4.5.0/css/font-awesome.min.css",
                "~/Content/Plugins/bootstrap-social-gh-pages/bootstrap-social.css",
                "~/Content/css/owl.carousel.css"
                ));
        }
    }
}
