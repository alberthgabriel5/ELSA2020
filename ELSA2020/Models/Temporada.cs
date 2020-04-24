using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ELSA2020.Models
{
    public class Temporada
    {
        private int Id;
        private String Nombre;
        private String FechaInicio;
        private String FechaFinal;
        private float VariacionPrecio;

        public Temporada(int id, string nombre, string fechaInicio, string fechaFinal, float variacionPrecio)
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
            FechaInicio = "";
            FechaFinal = "";
            VariacionPrecio = 0;
        }

        public int Id1 { get => Id; set => Id = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string FechaInicio1 { get => FechaInicio; set => FechaInicio = value; }
        public string FechaFinal1 { get => FechaFinal; set => FechaFinal = value; }
        public float VariacionPrecio1 { get => VariacionPrecio; set => VariacionPrecio = value; }
    }
}