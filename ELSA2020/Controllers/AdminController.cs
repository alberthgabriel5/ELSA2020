using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ELSA2020.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            /*ViewBag.NombreUnico = "Hotel de Montaña y Naturaleza";
            Hotel hotel = new Hotel();
            Hotel respuesta = hotel.obtenerHotel();*/

            //var hotelrespuesta = respuesta;

            //ViewBag.infoHotel = hotelrespuesta;

            return View();
        }
    }
}