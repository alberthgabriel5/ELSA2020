using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ELSA2020.Models
{
    public class TipoHabitacion
    {
        private int Id;
        private String Nombre;
        private String PrecioColones;
        private String PrecioDolares;
        private List<Caracteristica> Caracteristicas;
        private String Descripcion;
        private String Imagen;

        public TipoHabitacion(int id, string nombre, string precioColones, string precioDolares, List<Caracteristica> caracteristicas, string descripcion, string imagen)
        {
            Id = id;
            Nombre = nombre;
            PrecioColones = precioColones;
            PrecioDolares = precioDolares;
            Caracteristicas = caracteristicas;
            Descripcion = descripcion;
            Imagen = imagen;
        }

        public TipoHabitacion()
        {
            Id = 0;
            Nombre = "";
            PrecioColones = "";
            PrecioDolares = "";
            Caracteristicas = new List<Caracteristica>();
            Descripcion = "";
            Imagen = "";
        }

        public int Id1 { get => Id; set => Id = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string PrecioColones1 { get => PrecioColones; set => PrecioColones = value; }
        public string PrecioDolares1 { get => PrecioDolares; set => PrecioDolares = value; }
        public List<Caracteristica> Caracteristicas1 { get => Caracteristicas; set => Caracteristicas = value; }
        public string Descripcion1 { get => Descripcion; set => Descripcion = value; }
        public string Imagen1 { get => Imagen; set => Imagen = value; }

        public List<TipoHabitacion> obtenerTiposDeHabitacion()
        {
            string connStr = ConfigurationManager.ConnectionStrings["bdConn"].ConnectionString;
            SqlConnection connection = new SqlConnection(connStr);
            String sqlSelect = "sp_obtenerTiposDeHabitacion";
            SqlDataAdapter sqlDataAdapterClient = new SqlDataAdapter();
            sqlDataAdapterClient.SelectCommand = new SqlCommand();
            sqlDataAdapterClient.SelectCommand.CommandText = sqlSelect;
            sqlDataAdapterClient.SelectCommand.Connection = connection;
            sqlDataAdapterClient.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            DataSet dataSetTiposHabitacion = new DataSet();
            sqlDataAdapterClient.Fill(dataSetTiposHabitacion, "bdELSA.tipoHabitacion");
            sqlDataAdapterClient.SelectCommand.Connection.Close();
            DataRowCollection dataRowCollection = dataSetTiposHabitacion.Tables["bdELSA.tipoHabitacion"].Rows;
            
            List<TipoHabitacion> tiposDeHabitacion = new List<TipoHabitacion>();

            foreach (DataRow currentRow in dataRowCollection)
            {
                TipoHabitacion tipoActual = new TipoHabitacion();
                tipoActual.Id1 = (int)currentRow["id"];
                tipoActual.Nombre1 = currentRow["nombre"].ToString();
                tipoActual.PrecioColones1 = currentRow["precioColones"].ToString();
                tipoActual.PrecioDolares1 = currentRow["precioDolares"].ToString();
                tipoActual.Descripcion1 = currentRow["descripcion"].ToString();
                tipoActual.Imagen1 = currentRow["imagen"].ToString();

                Caracteristica caracteristica = new Caracteristica();
                tipoActual.Caracteristicas1 = caracteristica.obtenerCaracteristicas(tipoActual.Id1);

                tiposDeHabitacion.Add(tipoActual);
            }//Fin del foreach.

            return tiposDeHabitacion;
        }
    }
}