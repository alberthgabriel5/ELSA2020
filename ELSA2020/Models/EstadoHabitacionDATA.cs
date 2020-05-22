using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ELSA2020.Models
{
    public class EstadoHabitacionDATA
    {

        string connectionString = ConfigurationManager.ConnectionStrings["bdConn"].ConnectionString;

        //public List<SP_FECHA_Result> ListAll()
        //{

        //    using (var context = new entityFramework())
        //    {

        //        return context.SP_FECHA().ToList();
        //    }

        //}

        public List<EstadoHabitacion> ListAll()
        {
            List<EstadoHabitacion> reserva = new List<EstadoHabitacion>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SP_FECHA", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sqlDataReader = command.ExecuteReader();
                //this reads all the rows coming from DB
                while (sqlDataReader.Read())
                {
                    reserva.Add(new EstadoHabitacion
                    {
                        numero = Convert.ToInt32(sqlDataReader["numero"]),
                        estado = Convert.ToInt32(sqlDataReader["estado"]),
                        tipo = sqlDataReader["nombre"].ToString()
                    }
                    );
                }
                connection.Close();
            }
            return reserva;
        }



    }

}