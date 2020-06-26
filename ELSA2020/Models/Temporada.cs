using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ELSA2020.Models
{
    public class Temporada
    {
        

        public Temporada(int id, string nombre, DateTime fechaInicio, DateTime fechaFinal, float variacionPrecio)
        {
            Id = id;
            Nombre = nombre;
            FechaInicio = fechaFinal;
            FechaFinal = fechaFinal;
            VariacionPrecio = variacionPrecio;
        }

        public Temporada()
        {
            Id = 0;
            Nombre = "";
            FechaInicio = DateTime.Now;
            FechaFinal = DateTime.Now;
            VariacionPrecio = 0;
        }
        
        [Required]
        [MinLength(6)]
        public int Id { get => Id; set => Id = value; }
        public string Nombre { get => Nombre; set => Nombre = value; }
        public DateTime FechaInicio { get => FechaInicio; set => FechaInicio = value; }
        public DateTime FechaFinal { get => FechaFinal; set => FechaFinal = value; }
        public float VariacionPrecio { get => VariacionPrecio; set => VariacionPrecio = value; }

        public Temporada ObtenerTemporada(string fechaI, string fechaf)
        {
            string connStr = ConfigurationManager.ConnectionStrings["bdConn"].ConnectionString;
            SqlConnection connection = new SqlConnection(connStr);
            String sqlSelect = "sp_obtenerTemporadaIntervalo";
            SqlDataAdapter sqlDataAdapterClient = new SqlDataAdapter();
            sqlDataAdapterClient.SelectCommand = new SqlCommand();
            sqlDataAdapterClient.SelectCommand.CommandText = sqlSelect;
            sqlDataAdapterClient.SelectCommand.Connection = connection;
            sqlDataAdapterClient.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlDataAdapterClient.SelectCommand.Parameters.Add(new SqlParameter("@fechaInicio", fechaI));
            DataSet dataSetTemporada = new DataSet();
            sqlDataAdapterClient.Fill(dataSetTemporada, "bdELSA.temporada");
            sqlDataAdapterClient.SelectCommand.Connection.Close();
            DataRowCollection dataRowCollection1 = dataSetTemporada.Tables["bdELSA.temporada"].Rows;
            
            Temporada tem = new Temporada();
            foreach (DataRow currentRow in dataRowCollection1)
            {

                tem.Id = int.Parse(currentRow["id"].ToString());
                ////tem.VariacionPrecio1 = float.Parse(currentRow["variaionPreio"].ToString());
                tem.VariacionPrecio = 1;

                break;
            }//Fin del foreach.

            return tem;
        }
    }
}