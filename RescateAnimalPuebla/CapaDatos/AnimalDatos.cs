using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class AnimalDatos
    {
        public void Crear(string nombreComun, string especieCientifica, string historiaRescate, string rutaFoto, int asociacionID, int estatusID)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.CadenaConexion()))
            {
                SqlCommand cmd = new SqlCommand("sp_Animales_Crear", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreComun", nombreComun);
                cmd.Parameters.AddWithValue("@EspecieCientifica", especieCientifica);
                cmd.Parameters.AddWithValue("@HistoriaRescate", historiaRescate);
                cmd.Parameters.AddWithValue("@RutaFoto", rutaFoto);
                cmd.Parameters.AddWithValue("@AsociacionID", asociacionID);
                cmd.Parameters.AddWithValue("@EstatusID", estatusID);

                conexion.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable ObtenerTodos()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conexion = new SqlConnection(Conexion.CadenaConexion()))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_Animales_ObtenerTodos", conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable ObtenerPorID(int animalID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conexion = new SqlConnection(Conexion.CadenaConexion()))
            {
                // Usamos una consulta directa con JOINs para obtener toda la info necesaria
                string query = @"
            SELECT 
                A.AnimalID, A.NombreComun, A.EspecieCientifica, A.HistoriaRescate, A.RutaFoto,
                Asoc.Nombre AS NombreAsociacion,
                Est.Nombre AS NombreEstatus
            FROM 
                Animales A
            INNER JOIN 
                Asociaciones Asoc ON A.AsociacionID = Asoc.AsociacionID
            INNER JOIN 
                EstatusAnimal Est ON A.EstatusID = Est.EstatusID
            WHERE 
                A.AnimalID = @AnimalID";

                SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                da.SelectCommand.Parameters.AddWithValue("@AnimalID", animalID);
                da.Fill(dt);
            }
            return dt;
        }

        public void Actualizar(int animalID, string nombreComun, string especieCientifica, string historiaRescate, string rutaFoto, int asociacionID, int estatusID)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.CadenaConexion()))
            {
                SqlCommand cmd = new SqlCommand("sp_Animales_Actualizar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AnimalID", animalID);
                cmd.Parameters.AddWithValue("@NombreComun", nombreComun);
                cmd.Parameters.AddWithValue("@EspecieCientifica", especieCientifica);
                cmd.Parameters.AddWithValue("@HistoriaRescate", historiaRescate);
                cmd.Parameters.AddWithValue("@RutaFoto", rutaFoto);
                cmd.Parameters.AddWithValue("@AsociacionID", asociacionID);
                cmd.Parameters.AddWithValue("@EstatusID", estatusID);

                conexion.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int animalID)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.CadenaConexion()))
            {
                SqlCommand cmd = new SqlCommand("sp_Animales_Eliminar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AnimalID", animalID);

                conexion.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public DataTable ObtenerDisponiblesParaAdopcion()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conexion = new SqlConnection(Conexion.CadenaConexion()))
            {
                // En lugar de un SP, llamamos directamente a la Vista
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM vw_AnimalesListosParaAdoptar", conexion);
                da.SelectCommand.CommandType = CommandType.Text; // Es texto, no un SP
                da.Fill(dt);
            }
            return dt;
        }
    }

}
