using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class EstatusAnimalNegocio
    {
        private readonly EstatusAnimalDatos _estatusAnimalDatos = new EstatusAnimalDatos();

        public DataTable ListarEstatus()
        {
            return _estatusAnimalDatos.ObtenerTodos();
        }

        public DataTable ObtenerEstatusPorID(int id)
        {
            return _estatusAnimalDatos.ObtenerPorID(id);
        }

        public void InsertarEstatus(string nombre, string descripcion)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                throw new System.Exception("El nombre del estatus no puede estar vacío.");
            }
            _estatusAnimalDatos.Crear(nombre, descripcion);
        }

        public void EditarEstatus(int id, string nombre, string descripcion)
        {
            _estatusAnimalDatos.Actualizar(id, nombre, descripcion);
        }

        public void EliminarEstatus(int id)
        {
            _estatusAnimalDatos.Eliminar(id);
        }
    }

}
