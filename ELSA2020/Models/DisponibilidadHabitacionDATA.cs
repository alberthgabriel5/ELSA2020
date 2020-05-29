using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ELSA2020.Models
{
    public class DisponibilidadHabitacionDATA
    {
        string connectionString = ConfigurationManager.ConnectionStrings["bdConn"].ConnectionString;

        public List<DisponibilidadHabitacion> ListAll(string fechaCortaIinicio,
         string fechaCortaFin, int dias, int tipoHab)
        {
            List<DisponibilidadHabitacion> reserva = new List<DisponibilidadHabitacion>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SP_DisponibilidadHabitaciones", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@cantidadDias", dias);
                command.Parameters.AddWithValue("@fechaInicio", fechaCortaIinicio);
                command.Parameters.AddWithValue("@fechaFin",fechaCortaFin);
                command.Parameters.AddWithValue("@tipoHabitacion", tipoHab);

                SqlDataReader sqlDataReader = command.ExecuteReader();
                //this reads all the rows coming from DB
                while (sqlDataReader.Read())
                {
                    reserva.Add(new DisponibilidadHabitacion
                    {
                        id = Convert.ToInt32(sqlDataReader["id"]),
                        numero = Convert.ToInt32(sqlDataReader["numero"]),
                        nombre = sqlDataReader["nombre"].ToString(),
                        precioColones = Convert.ToInt32(sqlDataReader["precioColones"])
                    }
                    );
                }
                connection.Close();
            }
            return reserva;
        }

    }

}