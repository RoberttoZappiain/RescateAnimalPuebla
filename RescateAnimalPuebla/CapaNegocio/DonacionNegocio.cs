using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class DonacionNegocio
    {
        private readonly DonacionDatos _donacionDatos = new DonacionDatos();

        public DataTable ListarDonaciones()
        {
            return _donacionDatos.ObtenerTodos();
        }

        public DataTable ObtenerDonacionPorID(int id)
        {
            return _donacionDatos.ObtenerPorID(id);
        }

        public void InsertarDonacion(int asociacionID, decimal monto, bool donanteAnonimo)
        {
            if (monto <= 0)
            {
                throw new System.Exception("El monto de la donación debe ser mayor a cero.");
            }
            _donacionDatos.Crear(asociacionID, monto, donanteAnonimo);
        }

        public void EditarDonacion(int id, int asociacionID, decimal monto, bool donanteAnonimo)
        {
            _donacionDatos.Actualizar(id, asociacionID, monto, donanteAnonimo);
        }

        public void EliminarDonacion(int id)
        {
            _donacionDatos.Eliminar(id);
        }
    }

}
