using ELSA2020.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ELSA2020.Controllers
{
    public class HomeController : Controller
    {
        About_UsEF aboutUs = new About_UsEF();
        private Contact contact = new Contact();
        public ActionResult Index()
        {
            ViewBag.NombreUnico = "Bienvenidos a Hotel Colibrí";
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

            ViewBag.NombreUnico = "Contactenos";
            ViewBag.valorTexto = this.contact.getPageContact().ToList();
            ViewBag.Imagenes = this.contact.getImagesContact().ToList();
            
            
            return View();
        }
        public ActionResult Ofert()
        {
            ViewBag.NombreUnico = "Ofertas";
            ViewBag.Message = "Time Limited";

            return View();
        }


        public ActionResult Tariff()
        {
            ViewBag.NombreUnico = "Facilidades";
            TipoHabitacion tipo = new TipoHabitacion();
            List<TipoHabitacion> tiposDeHabitacion = tipo.obtenerTiposDeHabitacion();

            var tipos = tiposDeHabitacion;

            ViewBag.Message = "Tarifas de habitaciones";
            ViewBag.tiposDeHabitacion = tipos;
            return View();

        }
        public ActionResult Location()
        {
            ViewBag.NombreUnico = "Como llegar";
            ViewBag.Message = "Como llegar";


            return View();
        }
    }
}