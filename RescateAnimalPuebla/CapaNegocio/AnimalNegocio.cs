using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class AnimalNegocio
    {
        private readonly AnimalDatos _animalDatos = new AnimalDatos();

        public DataTable ListarAnimales()
        {
            return _animalDatos.ObtenerTodos();
        }

        public DataTable ObtenerAnimalPorID(int id)
        {
            return _animalDatos.ObtenerPorID(id);
        }

        public void InsertarAnimal(string nombreComun, string especieCientifica, string historiaRescate, string rutaFoto, int asociacionID, int estatusID)
        {
            // Aquí podrías validar que los IDs de asociación y estatus sean mayores a 0, por ejemplo.
            if (asociacionID <= 0 || estatusID <= 0)
            {
                throw new System.Exception("Debe seleccionar una asociación y un estatus válidos.");
            }
            _animalDatos.Crear(nombreComun, especieCientifica, historiaRescate, rutaFoto, asociacionID, estatusID);
        }

        public void EditarAnimal(int id, string nombreComun, string especieCientifica, string historiaRescate, string rutaFoto, int asociacionID, int estatusID)
        {
            _animalDatos.Actualizar(id, nombreComun, especieCientifica, historiaRescate, rutaFoto, asociacionID, estatusID);
        }

        public void EliminarAnimal(int id)
        {
            _animalDatos.Eliminar(id);
        }
    }
    
}
