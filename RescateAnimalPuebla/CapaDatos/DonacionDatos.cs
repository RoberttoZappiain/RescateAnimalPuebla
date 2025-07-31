using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DonacionDatos
    {
        public void Crear(int asociacionID, decimal monto, bool donanteAnonimo)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.CadenaConexion()))
            {
                SqlCommand cmd = new SqlCommand("sp_Donaciones_Crear", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AsociacionID", asociacionID);
                cmd.Parameters.AddWithValue("@Monto", monto);
                cmd.Parameters.AddWithValue("@DonanteAnonimo", donanteAnonimo);

                conexion.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable ObtenerTodos()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conexion = new SqlConnection(Conexion.CadenaConexion()))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_Donaciones_ObtenerTodos", conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable ObtenerPorID(int donacionID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conexion = new SqlConnection(Conexion.CadenaConexion()))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_Donaciones_ObtenerPorID", conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@DonacionID", donacionID);
                da.Fill(dt);
            }
            return dt;
        }

        public void Actualizar(int donacionID, int asociacionID, decimal monto, bool donanteAnonimo)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.CadenaConexion()))
            {
                SqlCommand cmd = new SqlCommand("sp_Donaciones_Actualizar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DonacionID", donacionID);
                cmd.Parameters.AddWithValue("@AsociacionID", asociacionID);
                cmd.Parameters.AddWithValue("@Monto", monto);
                cmd.Parameters.AddWithValue("@DonanteAnonimo", donanteAnonimo);

                conexion.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int donacionID)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.CadenaConexion()))
            {
                SqlCommand cmd = new SqlCommand("sp_Donaciones_Eliminar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DonacionID", donacionID);

                conexion.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }

}
