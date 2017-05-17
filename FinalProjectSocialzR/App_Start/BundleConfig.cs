using System.Web;
using System.Web.Optimization;

namespace FinalProjectSocialzR
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                 "~/Scripts/sidebar.js", "~/Scripts/slider.js", "~/Scripts/commentpanel.js", 
                 "~/Scripts/BootSideMenu.js", "~/Scripts/sortablelist.js",
                        "~/Scripts/jquery-{version}.js", "~/Scripts/jquery-ui.js",
                 "~/Scripts/BootSideMenuServices.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css", "~/Content/sidebar.css", 
                       "~/Content/slider.css", "~/Content/commentpanel.css", "~/Content/font-awesome.css",
                       "~/Content/BootSideMenu.css", "~/Content/sortablelist.css", "~/Content/jquery-ui.css",
                        "~/Content/navbar.css",
                      "~/Content/site.css"));
        }
    }
}
