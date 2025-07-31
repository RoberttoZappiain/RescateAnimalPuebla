using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos; //  acceso a la capa de datos
using System.Data; //  acceso a DataTable

namespace CapaNegocio
{
    public class AsociacionNegocio
    {
        // Creamos una instancia de nuestra clase de datos para poder usar sus métodos
        private readonly AsociacionDatos _asociacionDatos = new AsociacionDatos();

        public DataTable ListarAsociaciones()
        {
            return _asociacionDatos.ObtenerTodos();
        }

        public DataTable ObtenerAsociacionPorID(int id)
        {
            return _asociacionDatos.ObtenerPorID(id);
        }

        public void InsertarAsociacion(string nombre, string direccion, string mision, string tipo, string rutaLogo)
        {
            // Ejemplo de una regla de negocio simple: el nombre no puede estar vacío.
            if (string.IsNullOrEmpty(nombre))
            {
                throw new System.Exception("El nombre de la asociación no puede estar vacío.");
            }
            // Si todo está bien, llamamos al método de la capa de datos.
            _asociacionDatos.Crear(nombre, direccion, mision, tipo, rutaLogo);
        }

        public void EditarAsociacion(int id, string nombre, string direccion, string mision, string tipo, string rutaLogo)
        {
            // Aquí también podrías añadir validaciones antes de llamar a la capa de datos.
            _asociacionDatos.Actualizar(id, nombre, direccion, mision, tipo, rutaLogo);
        }

        public void EliminarAsociacion(int id)
        {
            _asociacionDatos.Eliminar(id);
        }
    }

}
