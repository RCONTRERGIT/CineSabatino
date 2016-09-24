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
    public class BusPelicula
    {
        public List<EntPelicula> Obtener()
        {
            DataTable dt = new DatPelicula().Obtener();
            List<EntPelicula> lst = new List<EntPelicula>();
            foreach (DataRow dr in dt.Rows)
            {
                EntPelicula ent = new EntPelicula();
                ent.id = Convert.ToInt32(dr["PELI_ID"]);
                ent.nombre = dr["PELI_NOMB"].ToString();
                ent.sinopsis = dr["PELI_SINO"].ToString();
                ent.generoId = Convert.ToInt32(dr["PELI_GENE_ID"]);
                ent.clasificacionId = Convert.ToInt32(dr["PELI_CLAS_ID"]);
                ent.fotoMini = dr["PELI_FOTO_MINI"].ToString();
                ent.fotoPortada = dr["PELI_FOTO_PORT"].ToString();
                ent.anio = Convert.ToInt32(dr["PELI_ANIO"]);
                ent.fechaAlta = Convert.ToDateTime(dr["PELI_FECH_ALTA"]);
                ent.estatus = Convert.ToBoolean(dr["PELI_ESTA"]);
                ent.video = dr["PELI_VIDE"].ToString();
                ent.productor = dr["PELI_PROD"].ToString();
                ent.Genero.nombre = dr["GENE_NOMB"].ToString();
                ent.Clasificacion = new EntClasificacion();
                ent.Clasificacion.nombre = dr["CLAS_NOMB"].ToString();
                lst.Add(ent);

                
            }
            return lst;
        }

        public void Insertar(EntPelicula ent)
        {
            int filas = new DatPelicula().Insertar(ent.nombre, ent.sinopsis, ent.generoId, ent.clasificacionId, ent.fotoMini, ent.fotoPortada, ent.anio, ent.fechaAlta.ToString("MM/dd/yyyy"), ent.estatus, ent.video, ent.productor);

            if (filas != 1)
                throw new ApplicationException(string.Format("Error al insertar {0} de {1}", ent.nombre, ent.productor));
        }

        public EntPelicula Obtener(int id)
        {
            DataTable dt = new DatPelicula().Obtener(id);

            EntPelicula ent = new EntPelicula();
            ent.id = Convert.ToInt32(dt.Rows[0]["PELI_ID"]);
            ent.nombre = dt.Rows[0]["PELI_NOMB"].ToString();
            ent.sinopsis = dt.Rows[0]["PELI_SINO"].ToString();
            ent.generoId = Convert.ToInt32(dt.Rows[0]["PELI_GENE_ID"]);
            ent.clasificacionId = Convert.ToInt32(dt.Rows[0]["PELI_CLAS_ID"]);
            ent.fotoMini = dt.Rows[0]["PELI_FOTO_MINI"].ToString();
            ent.fotoPortada = dt.Rows[0]["PELI_FOTO_PORT"].ToString();
            ent.anio = Convert.ToInt32(dt.Rows[0]["PELI_ANIO"]);
            ent.fechaAlta = Convert.ToDateTime(dt.Rows[0]["PELI_FECH_ALTA"]);
            ent.estatus = Convert.ToBoolean(dt.Rows[0]["PELI_ESTA"]);
            ent.video = dt.Rows[0]["PELI_VIDE"].ToString();
            ent.productor = dt.Rows[0]["PELI_PROD"].ToString();
            return ent;
        }

        public void Actualizar(EntPelicula ent)
        {
            int filas = new DatPelicula().Actualizar(ent.nombre, ent.sinopsis, ent.generoId, ent.clasificacionId, ent.fotoMini, ent.fotoPortada, ent.anio, ent.fechaAlta.ToString("MM/dd/yyyy"), ent.estatus, ent.video, ent.productor, ent.id);

            if (filas != 1)
                throw new ApplicationException(string.Format("Error al actualizar {0} de {1}", ent.nombre, ent.productor));
        }
    }
}
