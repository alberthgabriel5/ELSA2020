//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ELSA2020
{
    using System;
    using System.Collections.Generic;
    
    public partial class ContenidoImagen
    {
        public int id { get; set; }
        public string nombreUnico { get; set; }
        public byte[] valorImagen { get; set; }
        public Nullable<System.DateTime> fechaCreacion { get; set; }
        public Nullable<System.DateTime> fechaActualizacion { get; set; }
        public Nullable<int> idHotel { get; set; }
        public Nullable<int> idPagina { get; set; }
    
        public virtual hotel hotel { get; set; }
        public virtual Pagina Pagina { get; set; }
    }
}
