using System.Web.Optimization;

namespace ELSA2020
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryslicknav").Include(
                       "~/Scripts/jquery.slicknav.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquerymagnific").Include(
                        "~/Scripts/jquery.magnific-popup.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/main").Include(
                        "~/Scripts/main.js"));

            bundles.Add(new ScriptBundle("~/bundles/isotope").Include(
                        "~/Scripts/isotope.pkgd.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/masonry").Include(
                        "~/Scripts/masonry.pkgd.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/carousel").Include(
                        "~/Scripts/owl.carousel.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/Scripts").Include(
                        "~/Scripts/estadoHabitacion.js"));

            bundles.Add(new StyleBundle("~/Content/map").Include(
                      "~/Content/style.css.map"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/elegant-icons.css",
                      "~/Content/flaticon.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/magnific-popup.css",
                      "~/Content/slicknav.min.css",
                      "~/Content/style.css"));
        }
    }
}
