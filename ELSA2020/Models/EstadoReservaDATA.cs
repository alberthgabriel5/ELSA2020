using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ELSA2020.Models
{
    public class EstadoReservaDATA
    {
        string connectionString = ConfigurationManager.ConnectionStrings["bdConn"].ConnectionString;

        //public List<SpEstHabitaciones_Result> ListAll()
        //{

        //    using (var context = new entityFramework())
        //    {

        //        return context.MYSpEstHabitaciones().ToList();
        //    }

        //}

        public List<EstadoReserva> ListAll()
        {
            List<EstadoReserva> reserva = new List<EstadoReserva>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("estadoH", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sqlDataReader = command.ExecuteReader();
                //this reads all the rows coming from DB
                while (sqlDataReader.Read())
                {
                    reserva.Add(new EstadoReserva
                    {
                        numeroHabitacion = Convert.ToInt32(sqlDataReader["numero"]),
                        tipo = sqlDataReader["nombre"].ToString(),
                        estado = sqlDataReader["Estado"].ToString()
                    }
                    );
                }
                connection.Close();
            }
            return reserva;
        }



    }
}