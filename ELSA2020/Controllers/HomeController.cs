using ELSA2020.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ELSA2020.Controllers
{
    public class HomeController : Controller
    {
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
            ViewBag.Message = "Your application description page.";

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