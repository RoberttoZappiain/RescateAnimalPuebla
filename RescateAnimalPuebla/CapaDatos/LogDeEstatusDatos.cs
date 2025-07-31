using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class LogDeEstatusDatos
    {
        public void Crear(int animalID, int estatusAnteriorID, int estatusNuevoID)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.CadenaConexion()))
            {
                SqlCommand cmd = new SqlCommand("sp_LogDeEstatus_Crear", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AnimalID", animalID);
                cmd.Parameters.AddWithValue("@EstatusAnteriorID", estatusAnteriorID);
                cmd.Parameters.AddWithValue("@EstatusNuevoID", estatusNuevoID);

                conexion.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable ObtenerTodos()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conexion = new SqlConnection(Conexion.CadenaConexion()))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_LogDeEstatus_ObtenerTodos", conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable ObtenerPorID(int logID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conexion = new SqlConnection(Conexion.CadenaConexion()))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_LogDeEstatus_ObtenerPorID", conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@LogID", logID);
                da.Fill(dt);
            }
            return dt;
        }

        public void Actualizar(int logID, int animalID, int estatusAnteriorID, int estatusNuevoID)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.CadenaConexion()))
            {
                SqlCommand cmd = new SqlCommand("sp_LogDeEstatus_Actualizar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LogID", logID);
                cmd.Parameters.AddWithValue("@AnimalID", animalID);
                cmd.Parameters.AddWithValue("@EstatusAnteriorID", estatusAnteriorID);
                cmd.Parameters.AddWithValue("@EstatusNuevoID", estatusNuevoID);

                conexion.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int logID)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.CadenaConexion()))
            {
                SqlCommand cmd = new SqlCommand("sp_LogDeEstatus_Eliminar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LogID", logID);

                conexion.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }

}
