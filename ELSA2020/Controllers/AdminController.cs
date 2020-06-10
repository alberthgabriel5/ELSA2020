using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ELSA2020;
using ELSA2020.Models;

namespace ELSA2020.Controllers
{
    public class AdminController : Controller
    {
        private entityFramework db = new entityFramework();


        EstadoHabitacionDATA estDATA = new EstadoHabitacionDATA();
        ListaNombreHabitacionesDATA lnhDATA = new ListaNombreHabitacionesDATA();
        DisponibilidadHabitacionDATA dhDATA = new DisponibilidadHabitacionDATA();
        public ActionResult estadoHabitacion()
        {
            //List<SP_FECHA_Result> lista = new List<SP_FECHA_Result>();
            ViewBag.datos = estDATA.ListAll();
            return View();
        }

        public JsonResult ListaNombreHabitaciones()
        {
            return Json(lnhDATA.ListaNombreHabitaciones(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListaDisponibilidadHabitaciones(string fechaCortaIinicio,
         string fechaCortaFin,int dias,int tipoHab)
        {
            //ViewBag.datos = dhDATA.ListAll(fechaCortaIinicio, fechaCortaFin, dias, tipoHab);
            return Json(dhDATA.ListAll(fechaCortaIinicio,fechaCortaFin,dias,tipoHab), JsonRequestBehavior.AllowGet);
        }


        public ActionResult consultarDisponibilidadHabitaciones()
        {
            //List<SP_FECHA_Result> lista = new List<SP_FECHA_Result>();
            return View();
        }

        public ActionResult LogIn()
        {
            ViewBag.data = "";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(string nickname, string contrasenna)
        {
            if (ModelState.IsValid)
            {
                using (entityFramework db = new entityFramework())
                {
                    var obj = db.Usuario.Where(a => a.usuario1.Equals(nickname) && a.contrasenia.Equals(contrasenna)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.id.ToString();
                        Session["UserName"] = obj.nombre.ToString() + obj.apellidos.ToString();
                        Session["Nickname"] = obj.usuario1.ToString();
                        ViewBag.Usuario = Session["UserName"];
                        return RedirectToAction("index", "Admin");
                    }
                }


            }
            @ViewBag.Message = "Error Usuario y Contraseña";
            return View();
        }
        public ActionResult LogOut()
        {

            Session["UserID"] = null;
            Session["UserName"] = null;
            Session["Nickname"] = null;
            return RedirectToAction("LogIn");

        }

        
        public ActionResult AdministracionHabitaciones() 
        {
            if (Session["UserID"] != null)
            {
                ViewBag.NombreUnico = "Administrar Habitaciones";
                TipoHabitacion tipo = new TipoHabitacion();
                Habitacion habitacion = new Habitacion();
                List<TipoHabitacion> tiposDeHabitacion = tipo.ObtenerTiposHabitacionSinVariacion();
                List<Habitacion> listaHabitaciones = habitacion.ObtenerHabitaciones();

                var tipos = tiposDeHabitacion;
                var habitaciones = listaHabitaciones;

                ViewBag.tiposDeHabitacion = tipos;
                ViewBag.habitaciones = habitaciones;
                return View();
            }
            else
            {
                return RedirectToAction("LogIn");
            }
        }

        
        public ActionResult CambiarDescripcionHabitacion( int idTipoHabitacion )
        {
            if (Session["UserID"] != null)
            {
                ViewBag.NombreUnico = "Modificar Habitación";
                TipoHabitacion tipo = new TipoHabitacion();
                TipoHabitacion tipoDeHabitacion = tipo.ObtenerTipoHabitacionPorID(idTipoHabitacion);

                var tipoObtenido = tipoDeHabitacion;
                ViewBag.tipoDeHabitacion = tipoObtenido;
                return View();
            }
            else
            {
                return RedirectToAction("LogIn");
            }
        }

        [HttpPost]
        public JsonResult estadoHabitacion(string estado, string id)
        {
            Habitacion habitacion = new Habitacion();
            habitacion.actualizarEstadoHabitacion(estado,id);
            return Json("Actualizado");
        }


            // GET: Admin
            public ActionResult Index()
        {
            /* Todo lo que hagan en Admin le ponen este codigo al controlador*/



            if (Session["UserID"] != null)
            {



                var usuario = db.Usuario.Include(u => u.hotel);
                return View();
            }
            else
            {
                return RedirectToAction("LogIn");
            }
        }


        // GET: Admin/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["UserID"] != null)
            {

                /* Todo lo que hagan en Admin le ponen este codigo al controlador*/


                return View();
            }
            else
            {
                return RedirectToAction("LogIn");
            }
        }
    }

}