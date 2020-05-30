using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ELSA2020.Models
{
    public class ListaNombreHabitacionesDATA
    {
        public List<T_HabitacionDTO> ListaNombreHabitaciones()
        {
            using (var context = new entityFramework())
            {

                var habitaciones = (from tHabitacion in context.tipoHabitacion
                                 select  new T_HabitacionDTO
                                 {
                                     id = tHabitacion.id,
                                     nombre = tHabitacion.nombre
                                 }).ToList();

                return habitaciones;

            }
        }
    }
}