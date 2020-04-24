using System;
using System.Collections.Generic;
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

        public TipoHabitacion(int id, string nombre, string precioColones, string precioDolares)
        {
            Id = id;
            Nombre = nombre;
            PrecioColones = precioColones;
            PrecioDolares = precioDolares;
        }

        public TipoHabitacion()
        {
            Id = 0;
            Nombre = "";
            PrecioColones = "";
            PrecioDolares = "";
        }

        public int Id1 { get => Id; set => Id = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string PrecioColones1 { get => PrecioColones; set => PrecioColones = value; }
        public string PrecioDolares1 { get => PrecioDolares; set => PrecioDolares = value; }
    }
}