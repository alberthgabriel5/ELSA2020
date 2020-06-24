using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ELSA2020.Models
{
    public class FacilitiesEF
    {

        public ContenidoTexto getTitleParraphsFacilities()
        {
            using (var context = new entityFramework())
            {
                return context.sp_getDataFacilitiesPageContent().Single();
            }
        }
        public IEnumerable<Facilidades> getPageFacilities()
        {
            using (var context = new entityFramework())
            {
                return context.Sp_getFacilitiesInfo().ToList();
            }
        }

        public int ActualizaTextoPaginaFacilidades(int id, string texto)
        {
            int resultToReturn = 0;
            using (var context = new entityFramework())
            {
                resultToReturn = context.SP_ActualizaTextoFacilidades(id, texto);
            }

            return resultToReturn;
        }

        public obtenerDescripcionFacilidad_Result1 obtenerDescripcionFacilidad(int id)
        {
            using (var context = new entityFramework())
            {
                return context.obtenerDescripcionFacilidad(id).Single();
            }
        }
    }
}