using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ELSA2020;
using ELSA2020.Models;

namespace ELSA2020.Controllers
{
    public class AdminController : Controller
    {
        private entityFramework db = new entityFramework();

        public About_UsEF aboutUs = new About_UsEF();
        EstadoHabitacionDATA estDATA = new EstadoHabitacionDATA();
        ListaNombreHabitacionesDATA lnhDATA = new ListaNombreHabitacionesDATA();
        DisponibilidadHabitacionDATA dhDATA = new DisponibilidadHabitacionDATA();
        public ActionResult estadoHabitacion()
        {
            //List<SP_FECHA_Result> lista = new List<SP_FECHA_Result>();
            //ViewBag.datos = estDATA.ListAll();
            return View();
        }

        public JsonResult listarEstadoHabitaciones()
        {
            return Json(estDATA.ListAll(), JsonRequestBehavior.AllowGet);

        }


        public ActionResult AdministrarPaginaSobreNosotros()
        {
            ViewBag.valorTexto = aboutUs.getPageAboutUs().valorTexto;
            ViewBag.idPaginaSobreNosotros = aboutUs.getPageAboutUs().id;
            return View();
        }
        //cuando no se accede desde el llamado a la vista
        public JsonResult CargaPaginaSobreNosotros()
        {
            return Json(aboutUs.getPageAboutUs(), JsonRequestBehavior.AllowGet);
        }


        public JsonResult ActualizaTextoPaginaSobreNosotros(int id,string texto)
        {
            return Json(aboutUs.ActualizaTextoPaginaSobreNosotros(id,texto), JsonRequestBehavior.AllowGet);
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
        public ActionResult ActualizarInformacionHabitacion(int tipoHabitacion, int precioColones, float precioDolares, String descripcion) 
        {
            if (Session["UserID"] != null)
            {
                ViewBag.confirmacionActualizacion = "Nulo";
                TipoHabitacion tipo = new TipoHabitacion();
                String tipoDeHabitacion = tipo.ActualizarInformacionHabitacion(tipoHabitacion, precioColones, precioDolares, descripcion);
                TempData["message"] = "Cambios realizados exitosamente.";
                return RedirectToAction("Index");
            }
            else 
            {
                return RedirectToAction("LogIn");
            }
        }

        public ActionResult CancelarModificacionDescripcionTipoHabitacion(bool confirm) 
        {
            if (Session["UserID"] != null)
            {

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("LogIn");
            }
         }

        public JsonResult cambiarEstadoHabitacion(string estado, string id)
        {
            Habitacion habitacion = new Habitacion();
            habitacion.actualizarEstadoHabitacion(estado, id);
            return Json("Actualizado");
        }

        public ActionResult modificarPaginas()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LogIn");
            }
        }

        public ActionResult actualizarHome()
        {
            if (Session["UserID"] != null)
            {
                Hotel hotel = new Hotel();
                ViewBag.hotel = hotel.obtenerHotel();
                return View();
            }
            else
            {
                return RedirectToAction("LogIn");
            }
        }

        [HttpPost]
        public JsonResult actualizarHomePaginna(HttpPostedFileBase imagen, String imagenNombre, String estado, String descripcion)
        {
            if (estado.CompareTo("Si") == 0) {
                imagenNombre = Path.GetFileName(imagen.FileName);
                try
                {
                    string path = Server.MapPath("~/img/paginainicio/");

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    imagen.SaveAs(path + Path.GetFileName(imagen.FileName));
                }
                catch (Exception e) { }
            }

            Hotel hotel = new Hotel();
            hotel.Descripcion1 = descripcion;
            hotel.Imagen1 = imagenNombre;
            hotel.Id1 = 1;
            hotel.actualizarHotel(hotel);
            return Json("Actualizando home");
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

        public ActionResult ListarReservaciones()
        {
            if (Session["UserID"] != null)
            {

                return View("");
            }
            else
            {
                return RedirectToAction("LogIn");
            }
        }

        public ActionResult TraerListaReservas()
        {
            ClienteReservacion reservacion = new ClienteReservacion();
            return Json(new { data = reservacion.obtenerListaDeReservaciones() }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult EliminarReserva(String numeroReservacion)
        {
            if (Session["UserID"] != null)
            {
                Models.Reservacion reserva = new Models.Reservacion();
                reserva.EliminarReserva(numeroReservacion);

                return View("ListarReservaciones");
            }
            else
            {
                return RedirectToAction("LogIn");
            }
        }

        public ActionResult EliminarReservacion(String numeroReservacion)
        {
            if (Session["UserID"] != null)
            {
                Models.Reservacion reserva = new Models.Reservacion();
                reserva.EliminarReserva(numeroReservacion);

                return View("ListarReservaciones");
            }
            else
            {
                return RedirectToAction("LogIn");
            }
        }

        [HttpGet]
        public ActionResult VerReserva(String numeroReservacion)
        {
            if (Session["UserID"] != null)
            {
                ClienteReservacion reserva = new ClienteReservacion();
                var infoReserva = reserva.obtenerReservacionPorNumero(numeroReservacion);
                ViewBag.infoReserva = infoReserva;
                return View("InfoReserva");
            }
            else
            {
                return RedirectToAction("LogIn");
            }
        }

        public ActionResult RegistrarUsuario()
        {
            return View();
        }

        [HttpPost]
        public JsonResult RegistrarNuevoUsuario(string nombre, string apellidos, string nombreUsuario, string contrasenna)
        {
            Models.Usuario usuario = new Models.Usuario();
            string respuesta = "";
            if (usuario.ComprobarNombreUsuario(nombreUsuario))
            {
                respuesta = "No";
            }
            else
            {
                usuario.Nombre1 = nombre;
                usuario.Apellidos1 = apellidos;
                usuario.Usuario11 = nombreUsuario;
                usuario.Contrasenia1 = contrasenna;
                usuario.IdHotel1 = 1;
                respuesta = usuario.RegistrarUsuario(usuario);
            }
            return Json(respuesta);
        }
    }

}