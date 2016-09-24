using Cinemex.Cartelera.Business.Entity;
using Cinemex.Cartelera.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemex.Cartelera.Business
{
    public class BusCatalogos
    {
        public List<EntGenero> ObtenerGeneros()
        {
            DataTable dt = new DatCatalogos().ObtenerGenero();
            List<EntGenero> lst = new List<EntGenero>();
            foreach (DataRow dr in dt.Rows)
            {
                EntGenero ent = new EntGenero();
                ent.id = Convert.ToInt32(dr["GENE_ID"]);
                ent.nombre = dr["GENE_NOMB"].ToString();
                lst.Add(ent);
            }
            return lst;
        }

        public List<EntClasificacion> ObtenerClasi()
        {
            DataTable dt = new DatCatalogos().ObtenerClasi();
            List<EntClasificacion> lst = new List<EntClasificacion>();
            foreach (DataRow dr in dt.Rows)
            {
                EntClasificacion ent = new EntClasificacion();
                ent.id = Convert.ToInt32(dr["CLAS_ID"]);
                ent.nombre = dr["CLAS_NOMB"].ToString();
                lst.Add(ent);
            }
            return lst;
        }
    }
}
