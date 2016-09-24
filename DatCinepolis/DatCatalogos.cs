using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemex.Cartelera.Data
{
    public class DatCatalogos : DatAbstracta
    {

        public DataTable ObtenerClasi()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Clasificacion", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable ObtenerGenero()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Genero", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
