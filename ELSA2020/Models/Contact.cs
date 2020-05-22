using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ELSA2020.Models
{
    public class Contact
    {
        public IEnumerable< ContenidoTexto> getPageContact()
        {
            using (var context = new entityFramework())
            {
                return context.ContenidoTexto.Where(ContenidoTexto => ContenidoTexto.idPagina == 2).ToList();               
                
            }
        }

        public IEnumerable<ContenidoImagen> getImagesContact()
        {
            using (var context = new entityFramework())
            {
                return context.getImagesAboutUs().ToList();
            }

        }
    }
}