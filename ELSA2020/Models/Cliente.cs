using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ELSA2020.Models
{
    public class Cliente
    {
        private int Id;
        private String Nombre;
        private String Apellidos;
        private String Correo;

        public Cliente(int id, string nombre, string apellidos, string correo)
        {
            Id = id;
            Nombre = nombre;
            Apellidos = apellidos;
            Correo = correo;
        }

        public Cliente()
        {
            Id = 0;
            Nombre = "";
            Apellidos = "";
            Correo = "";
        }

        public int Id1 { get => Id; set => Id = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string Apellidos1 { get => Apellidos; set => Apellidos = value; }
        public string Correo1 { get => Correo; set => Correo = value; }

        public int registrarCliente(string nombre, string apellidos, string correo)
        {
            string connStr = ConfigurationManager.ConnectionStrings["bdConn"].ConnectionString;
            SqlConnection connection = new SqlConnection(connStr);
            String sqlSelect = "sp_registrarCliente";
            SqlDataAdapter sqlDataAdapterClient = new SqlDataAdapter();
            sqlDataAdapterClient.SelectCommand = new SqlCommand();
            sqlDataAdapterClient.SelectCommand.CommandText = sqlSelect;
            sqlDataAdapterClient.SelectCommand.Connection = connection;
            sqlDataAdapterClient.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlDataAdapterClient.SelectCommand.Parameters.Add(new SqlParameter("@nombre", nombre));
            sqlDataAdapterClient.SelectCommand.Parameters.Add(new SqlParameter("@apellidos", apellidos));
            sqlDataAdapterClient.SelectCommand.Parameters.Add(new SqlParameter("@correo", correo));
            DataSet dataSetCliente = new DataSet();
            sqlDataAdapterClient.Fill(dataSetCliente, "bdELSA.hotel");
            sqlDataAdapterClient.SelectCommand.Connection.Close();
            DataRowCollection dataRowCollection = dataSetCliente.Tables["bdELSA.hotel"].Rows;

            int id = 0;

            foreach (DataRow currentRow in dataRowCollection)
            {
                id = int.Parse(currentRow["id"].ToString());

            }//Fin del foreach.
            return id;
        }
    }
}