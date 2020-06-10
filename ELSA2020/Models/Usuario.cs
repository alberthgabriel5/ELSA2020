using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ELSA2020.Models
{
    public class Usuario
    {
        private int Id;
        private String Nombre;
        private String Apellidos;
        private String Usuario1;
        private String Contrasenia;
        private String Tipo;
        private int IdHotel;

        public Usuario(int id, string nombre, string apellidos, string usuario1, string contrasenia, string tipo, int idHotel)
        {
            Id = id;
            Nombre = nombre;
            Apellidos = apellidos;
            Usuario1 = usuario1;
            Contrasenia = contrasenia;
            Tipo = tipo;
            IdHotel = idHotel;
        }

        public Usuario()
        {
            Id = 0;
            Nombre = "";
            Apellidos = "";
            Usuario1 = "";
            Contrasenia = "";
            Tipo = "";
            IdHotel = 0;
        }

        public int Id1 { get => Id; set => Id = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string Apellidos1 { get => Apellidos; set => Apellidos = value; }
        public string Usuario11 { get => Usuario1; set => Usuario1 = value; }
        public string Contrasenia1 { get => Contrasenia; set => Contrasenia = value; }
        public string Tipo1 { get => Tipo; set => Tipo = value; }
        public int IdHotel1 { get => IdHotel; set => IdHotel = value; }

        public bool IniciarSesion(string usuario, string contrasenia)
        {
            string connStr = ConfigurationManager.ConnectionStrings["bdConn"].ConnectionString;
            SqlConnection connection = new SqlConnection(connStr);
            String sqlSelect = "sp_iniciosesionUsuario";
            SqlDataAdapter sqlDataAdapterClient = new SqlDataAdapter();
            sqlDataAdapterClient.SelectCommand = new SqlCommand();
            sqlDataAdapterClient.SelectCommand.CommandText = sqlSelect;
            sqlDataAdapterClient.SelectCommand.Connection = connection;
            sqlDataAdapterClient.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlDataAdapterClient.SelectCommand.Parameters.Add(new SqlParameter("@usuario", usuario));
            sqlDataAdapterClient.SelectCommand.Parameters.Add(new SqlParameter("@contrasenia", contrasenia));
            DataSet dataSetUsuario = new DataSet();
            sqlDataAdapterClient.Fill(dataSetUsuario, "bdELSA.Usuario");
            sqlDataAdapterClient.SelectCommand.Connection.Close();
            DataRowCollection dataRowCollection = dataSetUsuario.Tables["bdELSA.Usuario"].Rows;

            bool inicio = false;

            foreach (DataRow currentRow in dataRowCollection)
            {
                inicio = true;
            }//Fin del foreach.
            return inicio;
        }

        public string RegistrarUsuario(Usuario usuario)
        {
            string connStr = ConfigurationManager.ConnectionStrings["bdConn"].ConnectionString;
            SqlConnection connection = new SqlConnection(connStr);
            String sqlSelect = "sp_registrarUsuario";
            SqlDataAdapter sqlDataAdapterClient = new SqlDataAdapter();
            sqlDataAdapterClient.SelectCommand = new SqlCommand();
            sqlDataAdapterClient.SelectCommand.CommandText = sqlSelect;
            sqlDataAdapterClient.SelectCommand.Connection = connection;
            sqlDataAdapterClient.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;

            sqlDataAdapterClient.SelectCommand.Parameters.Add(new SqlParameter("@nombre", usuario.Nombre1));
            sqlDataAdapterClient.SelectCommand.Parameters.Add(new SqlParameter("@apellidos", usuario.Apellidos1));
            sqlDataAdapterClient.SelectCommand.Parameters.Add(new SqlParameter("@usuario", usuario.Usuario11));
            sqlDataAdapterClient.SelectCommand.Parameters.Add(new SqlParameter("@contrasenia", usuario.Contrasenia1));
            sqlDataAdapterClient.SelectCommand.Parameters.Add(new SqlParameter("@tipo", usuario.Tipo1));
            sqlDataAdapterClient.SelectCommand.Parameters.Add(new SqlParameter("@idHotel", usuario.IdHotel1));
  
            DataSet dataSetRegistrar = new DataSet();
            sqlDataAdapterClient.Fill(dataSetRegistrar, "bdELSA.Usuario");
            sqlDataAdapterClient.SelectCommand.Connection.Close();

            string num = "";
            return num;
        }

    }

}