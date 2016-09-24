using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemex.Cartelera.Business.Entity
{
    public class EntPelicula
    {
        public EntPelicula() { }
        public int id { get; set; }
        public string nombre { get; set; }
        public string sinopsis { get; set; }
        public int generoId { get; set; }
        public int clasificacionId { get; set; }
        public string fotoMini { get; set; }
        public string fotoPortada { get; set; }
        public int anio { get; set; }
        public DateTime fechaAlta { get; set; }
        public bool estatus { get; set; }
        public string video { get; set; }
        public string productor { get; set; }

        private EntGenero genero;
        public EntGenero Genero
        {
            get
            {
                if (genero == null)
                    genero = new EntGenero();
                return genero;
            }
            set
            {
                if (genero == null)
                    genero = new EntGenero();
                genero = value;
            }
        }

        private EntClasificacion clasificacion;
        public EntClasificacion Clasificacion
        {
            get { return clasificacion; }
            set { clasificacion = value; }
        }


    }
}
