using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ELSA2020.Models
{
    public class Habitacion
    {
        private int Id;
        private int IdHotel;
        private int Numero;
        private int IdTipo;
        private String Descripcion;
        
        public Habitacion(int id, int idHotel, int numero, int idTipo, string descripcion)
        {
            Id = id;
            IdHotel = idHotel;
            Numero = numero;
            IdTipo = idTipo;
            Descripcion = descripcion;
        }

        public Habitacion()
        {
            Id = 0;
            IdHotel = 0;
            Numero = 0;
            IdTipo = 0;
            Descripcion = "";
        }

        public int Id1 { get => Id; set => Id = value; }
        public int IdHotel1 { get => IdHotel; set => IdHotel = value; }
        public int Numero1 { get => Numero; set => Numero = value; }
        public int IdTipo1 { get => IdTipo; set => IdTipo = value; }
        public string Descripcion1 { get => Descripcion; set => Descripcion = value; }
    }
}