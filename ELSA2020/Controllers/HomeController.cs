using ELSA2020.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ELSA2020.Controllers
{
    public class HomeController : Controller
    {
        About_UsEF aboutUs = new About_UsEF();
        public ActionResult Index()
        {
            Hotel hotel = new Hotel();
            Hotel respuesta = hotel.obtenerHotel();

            var hotelrespuesta = respuesta;
            
            ViewBag.infoHotel = hotelrespuesta;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.NombreUnico = aboutUs.getPageAboutUs().nombreUnico;
            ViewBag.valorTexto = aboutUs.getPageAboutUs().valorTexto;
            ViewBag.Imagenes = aboutUs.getImagesAboutUs().ToList();
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Ofert()
        {
            ViewBag.Message = "Time Limited";

            return View();
        }


        public ActionResult Tariff()
        {
            TipoHabitacion tipo = new TipoHabitacion();
            List<TipoHabitacion> tiposDeHabitacion = tipo.obtenerTiposDeHabitacion();

            var tipos = tiposDeHabitacion;

            ViewBag.Message = "Tarifas de habitaciones";
            ViewBag.tiposDeHabitacion = tipos;
            return View();

        }
        public ActionResult Location()
        {
            ViewBag.Message = "Como llegar";


            return View();
        }
    }
}