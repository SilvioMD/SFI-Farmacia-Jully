using System.Web.Optimization;

namespace SFI_Farmacia_Jully
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //index
            bundles.Add(new ScriptBundle("~/assets/css").Include(
            "~/assets/css/app.css",
            "~/assets/css/bootstrap.css"));

            bundles.Add(new ScriptBundle("~/assets/vendors").Include(
            "~/assets/vendors/perfect-scrollbar/perfect-scrollbar.css",
            "~/assets/vendors/bootstrap-icons/bootstrap-icons.css",
            "~/assets/vendors/iconly/bold.css",
            "~/assets/images/favicon.svg"));

            bundles.Add(new ScriptBundle("~/assets/js").Include(
                "~/assets/js/bootstrap.bundle.min.js",
                "~/assets/js/main.js",
                "~/assets/js/pages/dashboard.js"));

            bundles.Add(new ScriptBundle("~/assets/settings").Include(
               "~/assets/js/settings.js"));

        }
    }
}
