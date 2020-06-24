using System.Web.Optimization;

namespace ELSA2020
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.min.js"));

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
                        "~/Scripts/estadoHabitacion.js",
                        "~/Scripts/AdministrarSobreNosotros.js",
                        "~/Scripts/EstadoHabitaciones.js",
                       "~/Scripts/modificacionDePaginas.js",
                       "~/Scripts/AdministrarFacilidades.js",
                       "~/Scripts/toastr.min.js"));

            bundles.Add(new StyleBundle("~/Content/map").Include(
                      "~/Content/style.css.map"));

            bundles.Add(new ScriptBundle("~/bundles/fecha").Include(
                        "~/Scripts/DisponibilidadHabitaciones.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                    "~/Scripts/datatables.js",
                    "~/Scripts/dataTables.bootstrap.js",
                    "~/Scripts/dataTables.bootstrap4.js",
                    "~/Scripts/dataTables.foundation.js",
                    "~/Scripts/dataTables.jqueryui.js",
                    "~/Scripts/dataTables.semanticui.js",
                    "~/Scripts/jquery.dataTables.js",
                    "~/Scripts/dataTables.buttons.min.js",
                    "~/Scripts/pdfmake.min.js",
                    "~/Scripts/buttons.print.min.js",
                    "~/Scripts/jszip.min.js",
                    "~/Scripts/buttons.html5.min.js",
                    "~/Scripts/vfs_fonts.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/datatables.css",
                    "~/Content/dataTables.bootstrap.css",
                    "~/Content/dataTables.bootstrap4.css",
                    "~/Content/dataTables.foundation.css",
                    "~/Content/dataTables.jqueryui.css",
                    "~/Content/dataTables.semanticui.css",
                    "~/Content/jquery.dataTables.css",
                      "~/Content/bootstrap.min.css",
                      "~/Content/elegant-icons.css",
                      "~/Content/flaticon.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/magnific-popup.css",
                      "~/Content/slicknav.min.css",
                      "~/Content/style.css",
                      "~/Content/AdministrarSobreNosotros.css",
                      "~/Content/toastr.css"));
        }
    }
}
