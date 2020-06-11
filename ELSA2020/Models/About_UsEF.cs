using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ELSA2020.Models
{
    public class About_UsEF
    {
        

        public ContenidoTexto getPageAboutUs()
        {
            using (var context = new entityFramework())
            {
                return context.GetDataAboutUsPage().Single();
            }
        }


        public int ActualizaTextoPaginaSobreNosotros(int id,string texto)
        {
            int resultToReturn = 0;
            using (var context = new entityFramework())
            {
                resultToReturn= context.SP_ActualizaTextoSobreNosotros(id,texto);
            }

            return resultToReturn;
        }

        public IEnumerable<ContenidoImagen> getImagesAboutUs()
        {
            using (var context = new entityFramework())
            {
                return context.getImagesAboutUs().ToList();
            }
        }


    }
}