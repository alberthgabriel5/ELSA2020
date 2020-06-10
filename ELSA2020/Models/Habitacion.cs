using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ELSA2020.Models
{
    public class Habitacion
    {
        private int Id;
        private int IdHotel;
        private int Numero;
        private int IdTipo;
        private String Descripcion;
        private int Estado;

        public Habitacion(int id, int idHotel, int numero, int idTipo, string descripcion, int estado)
        {
            Id = id;
            IdHotel = idHotel;
            Numero = numero;
            IdTipo = idTipo;
            Descripcion = descripcion;
            Estado = estado;
        }

        public Habitacion()
        {
            Id = 0;
            IdHotel = 0;
            Numero = 0;
            IdTipo = 0;
            Descripcion = "";
            Estado = 0;
        }

        public int Id1 { get => Id; set => Id = value; }
        public int IdHotel1 { get => IdHotel; set => IdHotel = value; }
        public int Numero1 { get => Numero; set => Numero = value; }
        public int IdTipo1 { get => IdTipo; set => IdTipo = value; }
        public string Descripcion1 { get => Descripcion; set => Descripcion = value; }
        public int Estado1 { get => Estado; set => Estado = value; }

        public List<Habitacion> ObtenerHabitaciones()
        {
            string connStr = ConfigurationManager.ConnectionStrings["bdConn"].ConnectionString;

            SqlConnection connection = new SqlConnection(connStr);
            String sqlSelect = "sp_obtenerHabitacion";
            SqlDataAdapter sqlDataAdapterClient = new SqlDataAdapter();
            sqlDataAdapterClient.SelectCommand = new SqlCommand();
            sqlDataAdapterClient.SelectCommand.CommandText = sqlSelect;
            sqlDataAdapterClient.SelectCommand.Connection = connection;
            sqlDataAdapterClient.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            DataSet dataSetHabitacion = new DataSet();
            sqlDataAdapterClient.Fill(dataSetHabitacion, "bdELSA.habitacion");
            sqlDataAdapterClient.SelectCommand.Connection.Close();
            DataRowCollection dataRowCollection = dataSetHabitacion.Tables["bdELSA.habitacion"].Rows;

            List<Habitacion> habitaciones = new List<Habitacion>();

            foreach (DataRow currentRow in dataRowCollection)
            {
                //id,idHotel,numero,idTipo,descripcion,estado
                Habitacion actual = new Habitacion();
                actual.Id1 = (int)currentRow["id"];
                actual.IdHotel1 = (int)currentRow["idHotel"];
                actual.Numero1 = (int)currentRow["numero"];
                actual.IdTipo1 = (int)currentRow["idTipo"];
                actual.Descripcion1 = currentRow["descripcion"].ToString();
                actual.Estado1 = (int)currentRow["estado"];

                habitaciones.Add(actual);
            }//Fin del foreach.

            return habitaciones;
        }

        public void actualizarEstadoHabitacion(String estado, String idHabitacion)
        {
            string connStr = ConfigurationManager.ConnectionStrings["bdConn"].ConnectionString;
            SqlConnection connection = new SqlConnection(connStr);
            String sqlSelect = "sp_actualizarEstadoHabitacion";
            SqlDataAdapter sqlDataAdapterClient = new SqlDataAdapter();
            sqlDataAdapterClient.SelectCommand = new SqlCommand();
            sqlDataAdapterClient.SelectCommand.CommandText = sqlSelect;
            sqlDataAdapterClient.SelectCommand.Connection = connection;
            sqlDataAdapterClient.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;

            sqlDataAdapterClient.SelectCommand.Parameters.Add(new SqlParameter("@estado", estado));
            sqlDataAdapterClient.SelectCommand.Parameters.Add(new SqlParameter("@idHabitacion", idHabitacion));
            DataSet dataSetActualizar = new DataSet();
            sqlDataAdapterClient.Fill(dataSetActualizar, "bdELSA.Habitacion");
            sqlDataAdapterClient.SelectCommand.Connection.Close();
        }

    }
}