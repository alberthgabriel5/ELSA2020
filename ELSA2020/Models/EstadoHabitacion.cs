using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ELSA2020.Models
{
    public class EstadoHabitacion
    {
        public int numero { get; set; }
        public string tipo { get; set; }
        public int estado { get; set; }//0 ocupado 1 disponible
    }
}