using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class EstatusAnimalDatos
    {
        public void Crear(string nombre, string descripcion)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.CadenaConexion()))
            {
                SqlCommand cmd = new SqlCommand("sp_EstatusAnimal_Crear", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Descripcion", descripcion);

                conexion.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable ObtenerTodos()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conexion = new SqlConnection(Conexion.CadenaConexion()))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_EstatusAnimal_ObtenerTodos", conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable ObtenerPorID(int estatusID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conexion = new SqlConnection(Conexion.CadenaConexion()))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_EstatusAnimal_ObtenerPorID", conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@EstatusID", estatusID);
                da.Fill(dt);
            }
            return dt;
        }

        public void Actualizar(int estatusID, string nombre, string descripcion)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.CadenaConexion()))
            {
                SqlCommand cmd = new SqlCommand("sp_EstatusAnimal_Actualizar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EstatusID", estatusID);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Descripcion", descripcion);

                conexion.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int estatusID)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.CadenaConexion()))
            {
                SqlCommand cmd = new SqlCommand("sp_EstatusAnimal_Eliminar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EstatusID", estatusID);

                conexion.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }

}
