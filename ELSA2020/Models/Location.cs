using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ELSA2020.Models
{
    public class Location
    {
        public Location()
        {
            PaginaLocation = GetPage(4).First();
            Titulo = GetPageLocation().First();
            Resumen = GetPageLocationText().First();

        }
        public Pagina PaginaLocation { set; get; }
        public ContenidoTexto Titulo { set; get; }
        public ContenidoTexto Resumen { set; get; }
        public IEnumerable<ContenidoTexto> GetPageLocation()
        {
            using (var context = new entityFramework())
            {
                return context.ContenidoTexto.Where(ContenidoTexto => ContenidoTexto.idPagina == 4 && ContenidoTexto.id==6).ToList();

            }
        }
        public IEnumerable<ContenidoTexto> GetPageLocationText()
        {
            using (var context = new entityFramework())
            {
                return context.ContenidoTexto.Where(ContenidoTexto => ContenidoTexto.idPagina == 4 && ContenidoTexto.id == 7).ToList();

            }
        }
        public IEnumerable<Pagina> GetPage(int id)
        {
            using (var context = new entityFramework())
            {
                return context.Pagina.Where(Pagina => Pagina.id == id).ToList();

            }
        }

        public IEnumerable<ContenidoImagen> GetImagesContact()
        {
            using (var context = new entityFramework())
            {
                return context.getImagesAboutUs().ToList();
            }

        }

        
    }
}