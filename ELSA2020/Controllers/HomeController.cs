using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ELSA2020.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["texto"] = "Hotel colibri, es un lugar rodeado de montañas, hermosas vistas, arboles, vegetacion hermosa, aves y animales silvestres lo cuales se pueden apreciar en los recorrido atravez de los senderos de los alrededores del hotel, cuenta con varios servicios a los cuales podra accesar durante su estadia en nuestro hotel.";
            ViewData["imagen"] = "~/img/paginainicio/hotel.jpg";
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
    }
}