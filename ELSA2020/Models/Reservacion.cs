using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ELSA2020.Models
{
    public class Reservacion
    {
        private int Id;
        private String NumeroReservacion;
        private int IdCliente;
        private int IdHabitacion;
        private String FechaEntrada;
        private String FechaSalida;
        private int CantidadDias;
        private int CantidadNoches;
        private float Precio;
        private String FechaCreacion;
        private String Estado;
        private int IdTemporada;
        private String Tipo;

        public Reservacion(int id, int idCliente, int idHabitacion, string fechaEntrada, string fechaSalida, int cantidadDias, int cantidadNoches, float precio, string fechaCreacion, string estado, int idTemporada, string tipo, string numeroReservacion)
        {
            Id = id;
            IdCliente = idCliente;
            IdHabitacion = idHabitacion;
            FechaEntrada = fechaEntrada;
            FechaSalida = fechaSalida;
            CantidadDias = cantidadDias;
            CantidadNoches = cantidadNoches;
            Precio = precio;
            FechaCreacion = fechaCreacion;
            Estado = estado;
            IdTemporada = idTemporada;
            Tipo = tipo;
            NumeroReservacion = numeroReservacion;
        }

        public Reservacion()
        {
            Id = 0;
            IdCliente = 0;
            IdHabitacion = 0;
            FechaEntrada = "";
            FechaSalida = "";
            CantidadDias = 0;
            CantidadNoches = 0;
            Precio = 0;
            FechaCreacion = "";
            Estado = "";
            IdTemporada = 0;
            Tipo = "";
            NumeroReservacion = "";
        }

        public int Id1 { get => Id; set => Id = value; }
        public int IdCliente1 { get => IdCliente; set => IdCliente = value; }
        public int IdHabitacion1 { get => IdHabitacion; set => IdHabitacion = value; }
        public string FechaEntrada1 { get => FechaEntrada; set => FechaEntrada = value; }
        public string FechaSalida1 { get => FechaSalida; set => FechaSalida = value; }
        public int CantidadDias1 { get => CantidadDias; set => CantidadDias = value; }
        public int CantidadNoches1 { get => CantidadNoches; set => CantidadNoches = value; }
        public float Precio1 { get => Precio; set => Precio = value; }
        public string FechaCreacion1 { get => FechaCreacion; set => FechaCreacion = value; }
        public string Estado1 { get => Estado; set => Estado = value; }
        public int IdTemporada1 { get => IdTemporada; set => IdTemporada = value; }
        public string Tipo1 { get => Tipo; set => Tipo = value; }
        public string NumeroReservacion1 { get => NumeroReservacion; set => NumeroReservacion = value; }


        public string[] reservarHabitacion(Reservacion reserva)
        {
            string connStr = ConfigurationManager.ConnectionStrings["bdConn"].ConnectionString;
            SqlConnection connection = new SqlConnection(connStr);
            String sqlSelect = "sp_registrarReservacion";
            SqlDataAdapter sqlDataAdapterClient = new SqlDataAdapter();
            sqlDataAdapterClient.SelectCommand = new SqlCommand();
            sqlDataAdapterClient.SelectCommand.CommandText = sqlSelect;
            sqlDataAdapterClient.SelectCommand.Connection = connection;
            sqlDataAdapterClient.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;

            sqlDataAdapterClient.SelectCommand.Parameters.Add(new SqlParameter("@numeroReservacion", reserva.NumeroReservacion1));
            sqlDataAdapterClient.SelectCommand.Parameters.Add(new SqlParameter("@idCliente", reserva.IdCliente1));
            sqlDataAdapterClient.SelectCommand.Parameters.Add(new SqlParameter("@idHabitacion", reserva.IdHabitacion1));
            sqlDataAdapterClient.SelectCommand.Parameters.Add(new SqlParameter("@fechaEntrada", reserva.FechaEntrada1));
            sqlDataAdapterClient.SelectCommand.Parameters.Add(new SqlParameter("@fechaSalida", reserva.FechaSalida1));
            sqlDataAdapterClient.SelectCommand.Parameters.Add(new SqlParameter("@cantidadDias", reserva.CantidadDias1));
            sqlDataAdapterClient.SelectCommand.Parameters.Add(new SqlParameter("@cantidadNoches", reserva.CantidadNoches1));
            sqlDataAdapterClient.SelectCommand.Parameters.Add(new SqlParameter("@precio", reserva.Precio1));
            sqlDataAdapterClient.SelectCommand.Parameters.Add(new SqlParameter("@estado", reserva.Estado1));
            sqlDataAdapterClient.SelectCommand.Parameters.Add(new SqlParameter("@idTemporada", reserva.IdTemporada1));
            DataSet dataSetReservar = new DataSet();
            sqlDataAdapterClient.Fill(dataSetReservar, "bdELSA.Reservacion");
            sqlDataAdapterClient.SelectCommand.Connection.Close();
            DataRowCollection dataRowCollection = dataSetReservar.Tables["bdELSA.Reservacion"].Rows;

            string[] num = new string[2];
            foreach (DataRow currentRow in dataRowCollection)
            {
                num[0] = currentRow["numeroReserva"].ToString();
                num[1] = reserva.IdHabitacion1.ToString();


            }//Fin del foreach.

            return num;
        }

        public string generarNumeroReservacion(string nombre)
        {
            string numero = "HC-";
            string parteNombre = nombre.Substring(0,1);
            numero = numero + parteNombre;
            var random = new Random();
            var value = random.Next(1,10000);
            numero = numero + value;

            string connStr = ConfigurationManager.ConnectionStrings["bdConn"].ConnectionString;
            SqlConnection connection = new SqlConnection(connStr);
            String sqlSelect = "sp_comprobarNumeroReserva ";
            SqlDataAdapter sqlDataAdapterClient = new SqlDataAdapter();
            sqlDataAdapterClient.SelectCommand = new SqlCommand();
            sqlDataAdapterClient.SelectCommand.CommandText = sqlSelect;
            sqlDataAdapterClient.SelectCommand.Connection = connection;
            sqlDataAdapterClient.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;

            sqlDataAdapterClient.SelectCommand.Parameters.Add(new SqlParameter("@numeroReserva", numero));
            DataSet dataSetReservar = new DataSet();
            sqlDataAdapterClient.Fill(dataSetReservar, "bdELSA.hotel");
            sqlDataAdapterClient.SelectCommand.Connection.Close();
            DataRowCollection dataRowCollection = dataSetReservar.Tables["bdELSA.hotel"].Rows;

            string num = "";
            foreach (DataRow currentRow in dataRowCollection)
            {
                num = currentRow["Respuesta"].ToString();

            }//Fin del foreach.

            if (num.CompareTo("System") == 0)
            {
                generarNumeroReservacion(nombre);
            }
            return numero;
            
        }
    }
}