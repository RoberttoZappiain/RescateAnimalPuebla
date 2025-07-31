using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class AsociacionDatos
    {
        // Método para CREAR una nueva asociación
        public void Crear(string nombre, string direccion, string mision, string tipo, string rutaLogo)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.CadenaConexion()))
            {
                SqlCommand cmd = new SqlCommand("sp_Asociaciones_Crear", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Direccion", direccion);
                cmd.Parameters.AddWithValue("@Mision", mision);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@RutaLogo", rutaLogo);

                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
        }

        // Método para OBTENER TODAS las asociaciones
        public DataTable ObtenerTodos()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conexion = new SqlConnection(Conexion.CadenaConexion()))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_Asociaciones_ObtenerTodos", conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                conexion.Open();
                da.Fill(dt);
                conexion.Close();
            }
            return dt;
        }

        // Método para OBTENER UNA asociación por su ID
        public DataTable ObtenerPorID(int asociacionID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conexion = new SqlConnection(Conexion.CadenaConexion()))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_Asociaciones_ObtenerPorID", conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@AsociacionID", asociacionID);

                conexion.Open();
                da.Fill(dt);
                conexion.Close();
            }
            return dt;
        }

        // Método para ACTUALIZAR una asociación
        public void Actualizar(int asociacionID, string nombre, string direccion, string mision, string tipo, string rutaLogo)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.CadenaConexion()))
            {
                SqlCommand cmd = new SqlCommand("sp_Asociaciones_Actualizar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AsociacionID", asociacionID);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Direccion", direccion);
                cmd.Parameters.AddWithValue("@Mision", mision);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@RutaLogo", rutaLogo);

                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
        }

        // Método para ELIMINAR una asociación
        public void Eliminar(int asociacionID)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.CadenaConexion()))
            {
                SqlCommand cmd = new SqlCommand("sp_Asociaciones_Eliminar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AsociacionID", asociacionID);

                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
        }
    }
}
