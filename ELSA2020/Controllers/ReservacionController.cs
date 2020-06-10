using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELSA2020.Models;
using System.Web.Mvc;
using System.Net.Mail;
using System.Configuration;

namespace ELSA2020.Controllers
{
    public class ReservacionController : Controller
    {
        public ActionResult ReservaEnLinea()
        {

            ViewBag.infoHotel ="HOla";

            return View();
        }

        public ActionResult ReservaPositiva()
        {

            ViewBag.infoHotel = "HOla";

            return View();
        }

        public ActionResult ReservaInformacion()
        {

            ViewBag.infoHotel = "HOla";

            return View();
        }

        public ActionResult ReservaNegativa()
        {

            ViewBag.infoReserva = "Lo sentimos!No tenemos en ese rango de fechas no tenemos habitaciones disponibles.";

            return View();
        }

        [HttpPost]
        public ActionResult ReservaEnLinea(DateTime fechaEntrada, DateTime fechaSalida, string tipoHabitacion)
        {

            TipoHabitacion tipoHab = new TipoHabitacion();
            Models.Reservacion reservar = new Models.Reservacion();
            String[] fe = (fechaEntrada.ToString()).Split(' ');
            reservar.FechaEntrada1 = fe[0];
            String[] fs = (fechaSalida.ToString()).Split(' ');
            reservar.FechaSalida1 = fs[0];
            reservar.Tipo1 = tipoHabitacion;

            tipoHab = tipoHab.ObtenerHabitacionReserva(reservar);
            if (tipoHab.Descripcion1.CompareTo("") == 0 || tipoHab.Imagen1.CompareTo("") == 0 || tipoHab.PrecioColones1.CompareTo("") == 0)
            {
                ViewBag.infoReserva = "Lo sentimos!No tenemos en ese rango de fechas no tenemos habitaciones disponibles.";
                return View("ReservaNegativa");
            }
            else
            {
                float precioColones = float.Parse(tipoHab.PrecioColones1);
                Temporada temp = new Temporada();
                float variacion = temp.VariacionPrecio1;
                float variacionColones = precioColones - (precioColones * variacion);
                tipoHab.PrecioColones1 = variacionColones.ToString();

                tipoHab.FechaEntrada1 = fechaEntrada.ToString();
                tipoHab.FechaSalida1 = fechaSalida.ToString();
                ViewBag.infoReserva = tipoHab;
                return View("ReservaPositiva");
            }
        }

        [HttpPost]
        public ActionResult ReservaPositiva(string idHabitacion, string precio, string nombre, string apellidos, string email, string tarjeta, string fechaEntrada, string fechaSalida)
        {

            Models.Reservacion reservacion = new Models.Reservacion();
            Models.Cliente cliente = new Models.Cliente();
            
            reservacion.IdCliente1 = cliente.registrarCliente(nombre, apellidos,email);
            reservacion.IdHabitacion1 = int.Parse(idHabitacion);

            string[] fes = (fechaEntrada.ToString()).Split(' ');
            string[] fss = (fechaSalida.ToString()).Split(' ');
            reservacion.FechaEntrada1 = fes[0];
            reservacion.FechaSalida1 = fss[0];

            DateTime fe = DateTime.Parse(fechaEntrada);
            DateTime fs = DateTime.Parse(fechaSalida);

            TimeSpan difFechas = fs - fe;
            int dias = difFechas.Days;

            reservacion.CantidadDias1 = dias+1;
            reservacion.CantidadNoches1 = dias;
            reservacion.Precio1 = float.Parse(precio);
            if (tarjeta.CompareTo(" ")==0)
            {
                reservacion.Estado1 = "Pendiente";
            }
            else
            {
                reservacion.Estado1 = "Pagado";
            }
            Temporada temporada = new Temporada();
            temporada = temporada.ObtenerTemporada(reservacion.FechaEntrada1, reservacion.FechaSalida1);
            reservacion.IdTemporada1 = temporada.Id1;
            reservacion.NumeroReservacion1 = reservacion.generarNumeroReservacion(nombre);
            string[] numeros = reservacion.reservarHabitacion(reservacion);
            string numReserva = numeros[0];
            //enviar correo
            String correoEnviar = email;
            String correo = ConfigurationManager.ConnectionStrings["Correo"].ConnectionString;
            String contrasenia = ConfigurationManager.ConnectionStrings["Contrasenia"].ConnectionString;

            String mensaje = "<p>Hola "+nombre+"!</p><br><p>Su reservacion fue exitosa</p><br><p>Numero de reservacion: "+numReserva+ "</p><br><p>Numero de habitacion: " + numeros[1] + "</p><br><p>Gracias por preferirnos. Te esperamos!</p>";
            MailMessage oMailMessage = new MailMessage();
            oMailMessage.To.Add(new MailAddress(correoEnviar));
            oMailMessage.From = new MailAddress(correo);
            oMailMessage.IsBodyHtml = true;
            oMailMessage.Priority = MailPriority.Normal;
            oMailMessage.Subject = "Asunto: Reservacion en Hotel Colibri";
            oMailMessage.Body = mensaje;

            SmtpClient oSmtpClient = new SmtpClient();
            oSmtpClient.Host = "smtp.gmail.com";
            oSmtpClient.Port = 587;
            oSmtpClient.EnableSsl = true;
            oSmtpClient.UseDefaultCredentials = false;
            oSmtpClient.Credentials = new System.Net.NetworkCredential(correo, contrasenia);

            oSmtpClient.Send(oMailMessage);
            oMailMessage.Dispose();


            //respuesta a la vista
            ViewBag.nombre = nombre;
            ViewBag.numReserva = numReserva;
            ViewBag.numHabitacion = numeros[1];
            ViewBag.email = email;
            return View("ReservaInformacion");
        }
    }
}