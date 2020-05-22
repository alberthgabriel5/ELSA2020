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

        EstadoHabitacionDATA estDATA = new EstadoHabitacionDATA();
        public ActionResult estadoHabitacion()
        {
            //List<SP_FECHA_Result> lista = new List<SP_FECHA_Result>();
            ViewBag.datos = estDATA.ListAll();
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