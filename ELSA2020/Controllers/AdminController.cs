using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ELSA2020.Models;

namespace ELSA2020.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        EstadoReservaDATA data = new EstadoReservaDATA();

        public ActionResult VerEstadoHotel()
        {
            List<EstadoReserva> lista = data.ListAll();
            ViewBag.datos = lista;
            return View();
        }
        public ActionResult Index()
        {
            /*ViewBag.NombreUnico = "Hotel de Montaña y Naturaleza";
            Hotel hotel = new Hotel();
            Hotel respuesta = hotel.obtenerHotel();*/

            //var hotelrespuesta = respuesta;

            //ViewBag.infoHotel = hotelrespuesta;

            return View();
        }

        public ActionResult InicioSesion()
        {
            ViewBag.data = "";
            return View();
        }

        [HttpPost]
        public ActionResult InicioSesion(string usuario, string contrasenna)
        {
            Models.Usuario usuarioAdmin = new Models.Usuario();
            bool respuesta = usuarioAdmin.iniciarSesion(usuario,contrasenna);
            if (respuesta)
            {
                return View("Index");
            }
            else
            {
                ViewBag.data = "Información incorrecta"; 
                return View("InicioSesion");
            }
            
        }
    }
}