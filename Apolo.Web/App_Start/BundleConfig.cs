using System.Web;
using System.Web.Optimization;

namespace Apolo.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Assets/plugins/jquery/jquery-1.10.2.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Assets/plugins/jquery/jquery.validate.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Assets/plugins/bootstrap/js/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/admin").Include(
                      "~/Assets/plugins/node-waves/js/waves.js",
                      "~/Assets/js/admin.js",
                      "~/Assets/js/helper.js"));

            bundles.Add(new StyleBundle("~/Assets/css").Include(
                    "~/Assets/plugins/bootstrap/css/bootstrap.css",
                    "~/Assets/plugins/animate/css/animate.css",
                    "~/Assets/plugins/node-waves/css/waves.css",
                    "~/Assets/css/materialize.css",
                    "~/Assets/css/style.css",
                    "~/Assets/css/themes.css"));
        }
    }
}
