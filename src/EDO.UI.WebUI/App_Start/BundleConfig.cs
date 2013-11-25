using System.Web;
using System.Web.Optimization;

namespace EDO.UI.WebUI
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/site").Include(
                        "~/Scripts/jquery/jquery-{version}.js"
                        , "~/Scripts/bootstrap.js"
                        ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-theme.css",
                "~/Content/style.css"
                ));


            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery/jquery-{version}.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery/jquery.unobtrusive*",
                        "~/Scripts/jquery/jquery.validate*"));

        }
    }
}