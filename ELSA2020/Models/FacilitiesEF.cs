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
    }
}