using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ELSA2020.Models
{
    public class Hotel
    {
        private int Id;
        private String Nombre;
        private String Descripcion;
        private String Imagen;

        public Hotel(int id, string nombre, string descripcion, string imagen)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Imagen = imagen;
        }

        public Hotel()
        {
            Id = 0;
            Nombre = "";
            Descripcion = "";
            Imagen = "";
        }

        public int Id1 { get => Id; set => Id = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string Descripcion1 { get => Descripcion; set => Descripcion = value; }
        public string Imagen1 { get => Imagen; set => Imagen = value; }

        public Hotel obtenerHotel()
        {
            string connStr = ConfigurationManager.ConnectionStrings["bdConn"].ConnectionString;
            SqlConnection connection = new SqlConnection(connStr);
            String sqlSelect = "sp_obtenerHotel";
            SqlDataAdapter sqlDataAdapterClient = new SqlDataAdapter();
            sqlDataAdapterClient.SelectCommand = new SqlCommand();
            sqlDataAdapterClient.SelectCommand.CommandText = sqlSelect;
            sqlDataAdapterClient.SelectCommand.Connection = connection;
            sqlDataAdapterClient.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            DataSet dataSetHotel = new DataSet();
            sqlDataAdapterClient.Fill(dataSetHotel, "bdELSA.hotel");
            sqlDataAdapterClient.SelectCommand.Connection.Close();
            DataRowCollection dataRowCollection = dataSetHotel.Tables["bdELSA.hotel"].Rows;

            Hotel hotelResultado = new Hotel();

            foreach (DataRow currentRow in dataRowCollection)
            {
                hotelResultado.Nombre1 = currentRow["nombre"].ToString();
                hotelResultado.Descripcion1 = currentRow["descripcion"].ToString();
                hotelResultado.Imagen1 = currentRow["imagen"].ToString();
                
            }//Fin del foreach.

            return hotelResultado;
        }

        public Hotel actualizarHotel(Hotel hotel)
        {
            string connStr = ConfigurationManager.ConnectionStrings["bdConn"].ConnectionString;
            SqlConnection connection = new SqlConnection(connStr);
            String sqlSelect = "sp_actualizarHotel";
            SqlDataAdapter sqlDataAdapterClient = new SqlDataAdapter();
            sqlDataAdapterClient.SelectCommand = new SqlCommand();
            sqlDataAdapterClient.SelectCommand.CommandText = sqlSelect;
            sqlDataAdapterClient.SelectCommand.Connection = connection;
            sqlDataAdapterClient.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlDataAdapterClient.SelectCommand.Parameters.Add(new SqlParameter("@descripcion", hotel.Descripcion1));
            sqlDataAdapterClient.SelectCommand.Parameters.Add(new SqlParameter("@imagen", hotel.Imagen1));
            sqlDataAdapterClient.SelectCommand.Parameters.Add(new SqlParameter("@id", hotel.Id1));
            DataSet dataSetHotel = new DataSet();
            sqlDataAdapterClient.Fill(dataSetHotel, "bdELSA.hotel");
            sqlDataAdapterClient.SelectCommand.Connection.Close();

            return hotel;
        }
    }
}