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


            // For ExtJS
            bundles.Add(new ScriptBundle("~/bundles/sencha").Include(
                        "~/scripts/extjs421/ext-all-dev.js"
                        , "~/scripts/config/environment.js"
                        , "~/scripts/config/development.js"
                        , "~/scripts/config/router.js"
                        , "~/scripts/app.js"
                        ));

            bundles.Add(new StyleBundle("~/bundles/senchacss").Include(
                "~/scripts/extjs421/resources/css/ext-all.css",
                "~/Content/style.css"
                ));
        }
    }
}