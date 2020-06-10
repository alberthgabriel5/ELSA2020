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
        private String FechaEntrada;
        private String FechaSalida;

        public TipoHabitacion(int id, string nombre, string precioColones, string precioDolares, List<Caracteristica> caracteristicas, string descripcion, string imagen, string fechaEntrada, string fechaSalida)
        {
            Id = id;
            Nombre = nombre;
            PrecioColones = precioColones;
            PrecioDolares = precioDolares;
            Caracteristicas = caracteristicas;
            Descripcion = descripcion;
            Imagen = imagen;
            FechaEntrada = fechaEntrada;
            FechaSalida = fechaSalida;
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
            FechaEntrada = "";
            FechaSalida = "";
        }

        public int Id1 { get => Id; set => Id = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string PrecioColones1 { get => PrecioColones; set => PrecioColones = value; }
        public string PrecioDolares1 { get => PrecioDolares; set => PrecioDolares = value; }
        public List<Caracteristica> Caracteristicas1 { get => Caracteristicas; set => Caracteristicas = value; }
        public string Descripcion1 { get => Descripcion; set => Descripcion = value; }
        public string Imagen1 { get => Imagen; set => Imagen = value; }
        public string FechaEntrada1 { get => FechaEntrada; set => FechaEntrada = value; }
        public string FechaSalida1 { get => FechaSalida; set => FechaSalida = value; }

        public List<TipoHabitacion> ObtenerTiposDeHabitacion()
        {
            string connStr = ConfigurationManager.ConnectionStrings["bdConn"].ConnectionString;

            SqlConnection connection1 = new SqlConnection(connStr);
            String sqlSelect1 = "sp_obtenerTemporada";
            SqlDataAdapter sqlDataAdapterClient1 = new SqlDataAdapter();
            sqlDataAdapterClient1.SelectCommand = new SqlCommand();
            sqlDataAdapterClient1.SelectCommand.CommandText = sqlSelect1;
            sqlDataAdapterClient1.SelectCommand.Connection = connection1;
            sqlDataAdapterClient1.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            DataSet dataSetTemporada = new DataSet();
            sqlDataAdapterClient1.Fill(dataSetTemporada, "bdELSA.temporada");
            sqlDataAdapterClient1.SelectCommand.Connection.Close();
            DataRowCollection dataRowCollection1 = dataSetTemporada.Tables["bdELSA.temporada"].Rows;

            float variacion = 0;

            foreach (DataRow currentRow in dataRowCollection1)
            {
                variacion = float.Parse(currentRow["variacionPrecio"].ToString());
                break;
            }//Fin del foreach.


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

                float precioColones = float.Parse(currentRow["precioColones"].ToString());
                float variacionColones = precioColones - (precioColones*variacion);
                tipoActual.PrecioColones1 = variacionColones.ToString();

                float precioDolares = float.Parse(currentRow["precioDolares"].ToString());
                float variacionDolares = precioDolares - (precioDolares * variacion);
                tipoActual.PrecioDolares1 = variacionDolares.ToString();

                tipoActual.Descripcion1 = currentRow["descripcion"].ToString();
                tipoActual.Imagen1 = currentRow["imagen"].ToString();

                Caracteristica caracteristica = new Caracteristica();
                tipoActual.Caracteristicas1 = caracteristica.obtenerCaracteristicas(tipoActual.Id1);

                tiposDeHabitacion.Add(tipoActual);
            }//Fin del foreach.

            return tiposDeHabitacion;
        }

        public TipoHabitacion ObtenerHabitacionReserva(Reservacion reserva)
        {
            string connStr = ConfigurationManager.ConnectionStrings["bdConn"].ConnectionString;
            SqlConnection connection = new SqlConnection(connStr);
            String sqlSelect = "sp_buscarHabitacionDisponibleParaReserva";
            SqlDataAdapter sqlDataAdapterClient = new SqlDataAdapter();
            sqlDataAdapterClient.SelectCommand = new SqlCommand();
            sqlDataAdapterClient.SelectCommand.CommandText = sqlSelect;
            sqlDataAdapterClient.SelectCommand.Connection = connection;
            sqlDataAdapterClient.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlDataAdapterClient.SelectCommand.Parameters.Add(new SqlParameter("@fechaInicio", reserva.FechaEntrada1));
            sqlDataAdapterClient.SelectCommand.Parameters.Add(new SqlParameter("@fechaFin", reserva.FechaSalida1));
            sqlDataAdapterClient.SelectCommand.Parameters.Add(new SqlParameter("@tipoHabitacion", reserva.Tipo1));
            DataSet dataSetTipoHabitacion = new DataSet();
            sqlDataAdapterClient.Fill(dataSetTipoHabitacion, "bdELSA.tipoHabitacion");
            sqlDataAdapterClient.SelectCommand.Connection.Close();

            DataTable table = new DataTable();
            DataRowCollection dataRowCollection = table.Rows;
            int n = 0;
            try
            {
                dataRowCollection = dataSetTipoHabitacion.Tables["bdELSA.tipoHabitacion"].Rows;
            }
            catch (Exception e)
            {
                n = 1;
            }

            TipoHabitacion tipo = new TipoHabitacion();
            tipo.Id1 = 0;
            tipo.Descripcion1 = "";
            tipo.Imagen1 = "";
            tipo.PrecioColones1 = "";
            if (n == 0)
            {
                foreach (DataRow currentRow in dataRowCollection)
                {
                    tipo.Id1 = int.Parse(currentRow["id"].ToString());
                    tipo.Descripcion1 = currentRow["descripcion"].ToString();
                    tipo.Imagen1 = currentRow["imagen"].ToString();
                    tipo.PrecioColones1 = currentRow["precioColones"].ToString();
                    tipo.PrecioDolares1 = currentRow["numero"].ToString();

                }//Fin del foreach.
            }
            return tipo;
        }

        public List<TipoHabitacion> ObtenerTiposHabitacionSinVariacion() 
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

                float precioColones = float.Parse(currentRow["precioColones"].ToString());
                float variacionColones = precioColones;
                tipoActual.PrecioColones1 = variacionColones.ToString();

                float precioDolares = float.Parse(currentRow["precioDolares"].ToString());
                float variacionDolares = precioDolares;
                tipoActual.PrecioDolares1 = variacionDolares.ToString();

                tipoActual.Descripcion1 = currentRow["descripcion"].ToString();
                tipoActual.Imagen1 = currentRow["imagen"].ToString();

                Caracteristica caracteristica = new Caracteristica();
                tipoActual.Caracteristicas1 = caracteristica.obtenerCaracteristicas(tipoActual.Id1);

                tiposDeHabitacion.Add(tipoActual);
            }//Fin del foreach.

            return tiposDeHabitacion;
        }

        public TipoHabitacion ObtenerTipoHabitacionPorID(int idTipoHabitacion) 
        {
            string connStr = ConfigurationManager.ConnectionStrings["bdConn"].ConnectionString;

            SqlConnection connection = new SqlConnection(connStr);
            String sqlSelect = "sp_obtenerTipoHabitacion";
            SqlDataAdapter sqlDataAdapterClient = new SqlDataAdapter();
            sqlDataAdapterClient.SelectCommand = new SqlCommand();
            sqlDataAdapterClient.SelectCommand.CommandText = sqlSelect;
            sqlDataAdapterClient.SelectCommand.Connection = connection;
            sqlDataAdapterClient.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlDataAdapterClient.SelectCommand.Parameters.Add(new SqlParameter("@id", idTipoHabitacion));
            DataSet dataSetTiposHabitacion = new DataSet();
            sqlDataAdapterClient.Fill(dataSetTiposHabitacion, "bdELSA.tipoHabitacion");
            sqlDataAdapterClient.SelectCommand.Connection.Close();
            DataRowCollection dataRowCollection = dataSetTiposHabitacion.Tables["bdELSA.tipoHabitacion"].Rows;

            TipoHabitacion tipoActual = new TipoHabitacion();
            foreach (DataRow currentRow in dataRowCollection)
            {
                
                tipoActual.Id1 = (int)currentRow["id"];
                tipoActual.Nombre1 = currentRow["nombre"].ToString();

                float precioColones = float.Parse(currentRow["precioColones"].ToString());
                float variacionColones = precioColones;
                tipoActual.PrecioColones1 = variacionColones.ToString();

                float precioDolares = float.Parse(currentRow["precioDolares"].ToString());
                float variacionDolares = precioDolares;
                tipoActual.PrecioDolares1 = variacionDolares.ToString();

                tipoActual.Descripcion1 = currentRow["descripcion"].ToString();
                tipoActual.Imagen1 = currentRow["imagen"].ToString();

                Caracteristica caracteristica = new Caracteristica();
                tipoActual.Caracteristicas1 = caracteristica.obtenerCaracteristicas(tipoActual.Id1);

            }//Fin del foreach.

            return tipoActual;
        }

        public String ActualizarInformacionHabitacion(int tipoHabitacion, int precioColones, float precioDolares, String descripcion)
        {
            string connStr = ConfigurationManager.ConnectionStrings["bdConn"].ConnectionString;

            SqlConnection connection = new SqlConnection(connStr);
            String sqlSelect = "sp_actualizarInformacionHabitacion";
            SqlDataAdapter sqlDataAdapterClient = new SqlDataAdapter();
            sqlDataAdapterClient.SelectCommand = new SqlCommand();
            sqlDataAdapterClient.SelectCommand.CommandText = sqlSelect;
            sqlDataAdapterClient.SelectCommand.Connection = connection;
            sqlDataAdapterClient.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlDataAdapterClient.SelectCommand.Parameters.Add(new SqlParameter("@id", tipoHabitacion));
            sqlDataAdapterClient.SelectCommand.Parameters.Add(new SqlParameter("@precioColones", precioColones));
            sqlDataAdapterClient.SelectCommand.Parameters.Add(new SqlParameter("@precioDolares", precioDolares));
            sqlDataAdapterClient.SelectCommand.Parameters.Add(new SqlParameter("@descripcion", descripcion));
            DataSet dataSetTiposHabitacion = new DataSet();
            sqlDataAdapterClient.Fill(dataSetTiposHabitacion, "bdELSA.tipoHabitacion");
            sqlDataAdapterClient.SelectCommand.Connection.Close();

            return "Correcto";
        }
    }
}