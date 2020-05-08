using ELSA2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ELSA2020.Controllers
{
    public class FacilidadesController : Controller
    {
        // GET: Facilidades
        FacilitiesEF fef = new FacilitiesEF();

        public ActionResult Index()
        {
            ViewBag.Titulo = fef.getTitleParraphsFacilities().nombreUnico;
            ViewBag.ContenidoPagina = fef.getPageFacilities();
            return View();
        }
    }
}