using ELSA2020.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ELSA2020.Controllers
{
    public class HomeController : Controller
    {
        public About_UsEF aboutUs = new About_UsEF();
        public Contact contact = new Contact();
        public Location location = new Location();
        public Pagina pagina = new Pagina();
        public ActionResult Index()
        {
            ViewBag.NombreUnico = "Hotel de Montaña y Naturaleza";
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
            ViewBag.valorTexto = this.contact.GetPageContact().ToList();
            ViewBag.Imagenes = this.contact.GetImagesContact().ToList();


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
            List<TipoHabitacion> tiposDeHabitacion = tipo.ObtenerTiposDeHabitacion();

            var tipos = tiposDeHabitacion;

            ViewBag.Message = "Tarifas de habitaciones";
            ViewBag.tiposDeHabitacion = tipos;
            return View();

        }
        public ActionResult Location()
        {
            ViewBag.NombreUnico = "¿Cómo llegar?";
            ViewBag.valorTexto = this.location.GetPageLocation().ToList();
            ViewBag.Message = this.location.GetPageLocationText().ToList();



            return View();
        }
    }
}