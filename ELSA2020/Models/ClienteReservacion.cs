using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ELSA2020.Models
{
    public class ClienteReservacion
    {
        private String NombreCliente;
        private String ApellidosCliente;
        private String CorreoCliente;
        private int IdReservacion;
        private String NumeroReservacion;
        private String FechaEntrada;
        private String FechaSalida;
        private String FechaCreacion;
        private String Tipo;

        public ClienteReservacion()
        {
            NombreCliente1 = "";
            ApellidosCliente1 = "";
            CorreoCliente1 = "";
            IdReservacion1 = 0;
            NumeroReservacion1 = "";
            FechaEntrada1 = "";
            FechaSalida1 = "";
            FechaCreacion1 = "";
            Tipo1 = "";
        }

        public ClienteReservacion(string nombreCliente, string apellidosCliente, string correoCliente, int idReservacion, string numeroReservacion, string fechaEntrada, string fechaSalida, string fechaCreacion, string tipo)
        {
            NombreCliente1 = nombreCliente;
            ApellidosCliente1 = apellidosCliente;
            CorreoCliente1 = correoCliente;
            IdReservacion1 = idReservacion;
            NumeroReservacion1 = numeroReservacion;
            FechaEntrada1 = fechaEntrada;
            FechaSalida1 = fechaSalida;
            FechaCreacion1 = fechaCreacion;
            Tipo1 = tipo;
        }

        public string NombreCliente1 { get => NombreCliente; set => NombreCliente = value; }
        public string ApellidosCliente1 { get => ApellidosCliente; set => ApellidosCliente = value; }
        public string CorreoCliente1 { get => CorreoCliente; set => CorreoCliente = value; }
        public int IdReservacion1 { get => IdReservacion; set => IdReservacion = value; }
        public string NumeroReservacion1 { get => NumeroReservacion; set => NumeroReservacion = value; }
        public string FechaEntrada1 { get => FechaEntrada; set => FechaEntrada = value; }
        public string FechaSalida1 { get => FechaSalida; set => FechaSalida = value; }
        public string FechaCreacion1 { get => FechaCreacion; set => FechaCreacion = value; }
        public string Tipo1 { get => Tipo; set => Tipo = value; }


        public List<ClienteReservacion> obtenerListaDeReservaciones() 
        {
            string connStr = ConfigurationManager.ConnectionStrings["bdConn"].ConnectionString;
            SqlConnection connection = new SqlConnection(connStr);

            String sqlSelect = "sp_obtenerListaDeReservaciones";
            SqlDataAdapter sqlDataAdapterClient = new SqlDataAdapter();
            sqlDataAdapterClient.SelectCommand = new SqlCommand();
            sqlDataAdapterClient.SelectCommand.CommandText = sqlSelect;
            sqlDataAdapterClient.SelectCommand.Connection = connection;
            sqlDataAdapterClient.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            DataSet dataSet = new DataSet();
            sqlDataAdapterClient.Fill(dataSet, "bdELSA.Reservacion");
            sqlDataAdapterClient.SelectCommand.Connection.Close();
            DataRowCollection dataRowCollection = dataSet.Tables["bdELSA.Reservacion"].Rows;
            List<ClienteReservacion> listaReservaciones = new List<ClienteReservacion>();

            foreach (DataRow currentRow in dataRowCollection)
            {
                ClienteReservacion reservaActual = new ClienteReservacion();
                reservaActual.NombreCliente1 = currentRow["nombre"].ToString();
                reservaActual.ApellidosCliente1 = currentRow["apellidos"].ToString();
                reservaActual.CorreoCliente1 = currentRow["email"].ToString();
                reservaActual.IdReservacion1 = Int32.Parse(currentRow["id"].ToString());
                reservaActual.NumeroReservacion1 = currentRow["numeroReserva"].ToString();
                reservaActual.FechaEntrada1 = currentRow["fechaEntrada"].ToString();
                reservaActual.FechaSalida1 = currentRow["fechaSalida"].ToString();
                reservaActual.FechaCreacion1 = currentRow["fechaCreacion"].ToString();
                reservaActual.Tipo1 = currentRow["tipoHabitacion"].ToString();
                listaReservaciones.Add(reservaActual);
            }

            return listaReservaciones;
        }

        public ClienteReservacion obtenerReservacionPorNumero(String numeroReserva)
        {
            string connStr = ConfigurationManager.ConnectionStrings["bdConn"].ConnectionString;
            SqlConnection connection = new SqlConnection(connStr);

            String sqlSelect = "sp_obtenerReservacionPorNumero";
            SqlDataAdapter sqlDataAdapterClient = new SqlDataAdapter();
            sqlDataAdapterClient.SelectCommand = new SqlCommand();
            sqlDataAdapterClient.SelectCommand.CommandText = sqlSelect;
            sqlDataAdapterClient.SelectCommand.Connection = connection;
            sqlDataAdapterClient.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlDataAdapterClient.SelectCommand.Parameters.Add(new SqlParameter("@numeroReservacion", numeroReserva));
            DataSet dataSet = new DataSet();
            sqlDataAdapterClient.Fill(dataSet, "bdELSA.Reservacion");
            sqlDataAdapterClient.SelectCommand.Connection.Close();
            DataRowCollection dataRowCollection = dataSet.Tables["bdELSA.Reservacion"].Rows;
            ClienteReservacion reservacion = new ClienteReservacion();

            foreach (DataRow currentRow in dataRowCollection)
            {
                reservacion.NombreCliente1 = currentRow["nombre"].ToString();
                reservacion.ApellidosCliente1 = currentRow["apellidos"].ToString();
                reservacion.CorreoCliente1 = currentRow["email"].ToString();
                reservacion.IdReservacion1 = Int32.Parse(currentRow["id"].ToString());
                reservacion.NumeroReservacion1 = currentRow["numeroReserva"].ToString();
                reservacion.FechaEntrada1 = currentRow["fechaEntrada"].ToString();
                reservacion.FechaSalida1 = currentRow["fechaSalida"].ToString();
                reservacion.FechaCreacion1 = currentRow["fechaCreacion"].ToString();
                reservacion.Tipo1 = currentRow["tipoHabitacion"].ToString();
            }

            return reservacion;
        }
    }
}