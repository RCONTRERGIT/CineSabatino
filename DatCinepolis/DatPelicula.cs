using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemex.Cartelera.Data
{
    public class DatPelicula : DatAbstracta
    {
        public DataTable Obtener()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT  PELI_ID ,PELI_NOMB ,PELI_SINO ,PELI_GENE_ID ,PELI_CLAS_ID ,PELI_FOTO_MINI ,PELI_FOTO_PORT ,PELI_ANIO ,PELI_FECH_ALTA ,PELI_ESTA ,PELI_VIDE ,PELI_PROD ,CLAS_ID ,CLAS_NOMB ,CLAS_DESC ,GENE_ID ,GENE_NOMB ,GENE_DESC FROM Pelicula INNER JOIN Clasificacion ON Clasificacion.CLAS_ID = Pelicula.PELI_CLAS_ID INNER JOIN dbo.Genero ON Genero.GENE_ID = Pelicula.PELI_GENE_ID", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public int Insertar(string nombre, string sinopsis, int generoId, int clasificacionId, string fotoMini, string fotoPortada, int anio, string fechaAlta, bool estatus, string video, string productor)
        {
            SqlCommand com = new SqlCommand("spInsertarPelicula", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = nombre, ParameterName = "@Nombre", });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = sinopsis, ParameterName = "@Sinopsis", });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Value = generoId, ParameterName = "@GeneroId", });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Value = clasificacionId, ParameterName = "@ClasificacionId", });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = fotoMini, ParameterName = "@FotoMini", });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = fotoPortada, ParameterName = "@FotoPort", });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Value = anio, ParameterName = "@Anio", });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = fechaAlta, ParameterName = "@Fecha", });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Bit, Value = estatus, ParameterName = "@Estatus", });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = video, ParameterName = "@Video", });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = productor, ParameterName = "@Productor", });
            try
            {
                con.Open();
                int filas = com.ExecuteNonQuery();
                con.Close();
                return filas;
            }
            catch (Exception ex)
            {
                con.Close();
                throw new ApplicationException("Error en capa de datos-" + ex.Message);
            }
        }

        public DataTable Obtener(int id)
        {
            SqlCommand com = new SqlCommand("spObtenerPelicula", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Value = id, ParameterName = "@Id", });
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public int Actualizar(string nombre, string sinopsis, int generoId, int clasificacionId, string fotoMini, string fotoPortada, int anio, string fechaAlta, bool estatus, string video, string productor, int id)
        {
            SqlCommand com = new SqlCommand("spActualizarPelicula", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = nombre, ParameterName = "@Nombre", });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = sinopsis, ParameterName = "@Sinopsis", });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Value = generoId, ParameterName = "@GeneroId", });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Value = clasificacionId, ParameterName = "@ClasificacionId", });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = fotoMini, ParameterName = "@FotoMini", });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = fotoPortada, ParameterName = "@FotoPort", });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Value = anio, ParameterName = "@Anio", });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = fechaAlta, ParameterName = "@Fecha", });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Bit, Value = estatus, ParameterName = "@Estatus", });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = video, ParameterName = "@Video", });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = productor, ParameterName = "@Productor", });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Value = id, ParameterName = "@ID", });
            try
            {
                con.Open();
                int filas = com.ExecuteNonQuery();
                con.Close();
                return filas;
            }
            catch (Exception ex)
            {
                con.Close();
                throw new ApplicationException("Error en capa de datos-" + ex.Message);
            }
        }
    }
}
