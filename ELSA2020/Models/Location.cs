using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ELSA2020.Models
{
    public class Location
    {
       
        public Pagina PaginaLocation { set; get; }
        public ContenidoTexto Titulo { set; get; }
        public ContenidoTexto Resumen { set; get; }
        public IEnumerable<ContenidoTexto> GetPageLocation()
        {
            using (var context = new entityFramework())
            {
                return context.ContenidoTexto.Where(ContenidoTexto => ContenidoTexto.idPagina == 4 && ContenidoTexto.id == 6).ToList();

            }
        }
        public IEnumerable<ContenidoTexto> GetPageLocationText()
        {
            using (var context = new entityFramework())
            {
                return context.ContenidoTexto.Where(ContenidoTexto => ContenidoTexto.idPagina == 4 && ContenidoTexto.id == 7).ToList();

            }
        }

        public String getTitle()
        {
            return GetPageLocation().Select(Con => Con.valorTexto).First();
        }
        public String getText()
        {
            return GetPageLocationText().Select(Con => Con.valorTexto).First();
        }

    

        
    }
}