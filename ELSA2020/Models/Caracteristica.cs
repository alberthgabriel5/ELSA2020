using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ELSA2020.Models
{
    public class Caracteristica
    {
        private int Id;
        private String Nombre;
        private String Descripcion;
        private String Imagen;
        private String FechaCreacion;
        private int IdCaracteriticaHabitacion;
        private int IdHabitacion;
        private int IdCaracteristica;

        public Caracteristica(int id,string nombre, string descripcion, string imagen, string fechaCreacion, int idCaracteristucaHabitacion, int idHabitacion, int idCaracteristica)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Imagen = imagen;
            FechaCreacion = fechaCreacion;
            IdCaracteriticaHabitacion = idCaracteristucaHabitacion;
            IdHabitacion = idHabitacion;
            IdCaracteristica = idCaracteristica;
        }

        public Caracteristica()
        {
            Id = 0;
            Nombre = "";
            Descripcion = "";
            Imagen = "";
            FechaCreacion = "";
            IdCaracteriticaHabitacion = 0;
            IdHabitacion = 0;
            IdCaracteristica = 0;
        }

        public int Id1 { get => Id; set => Id = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string Descripcion1 { get => Descripcion; set => Descripcion = value; }
        public string Imagen1 { get => Imagen; set => Imagen = value; }
        public string FechaCreacion1 { get => FechaCreacion; set => FechaCreacion = value; }
        public int IdCaracteriticaHabitacion1 { get => IdCaracteriticaHabitacion; set => IdCaracteriticaHabitacion = value; }
        public int IdHabitacion1 { get => IdHabitacion; set => IdHabitacion = value; }
        public int IdCaracteristica1 { get => IdCaracteristica; set => IdCaracteristica = value; }
    }
}