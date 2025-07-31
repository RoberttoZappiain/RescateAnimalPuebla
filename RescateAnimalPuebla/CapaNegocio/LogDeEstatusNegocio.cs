using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class LogDeEstatusNegocio
    {
        private readonly LogDeEstatusDatos _logDeEstatusDatos = new LogDeEstatusDatos();

        public DataTable ListarLogs()
        {
            return _logDeEstatusDatos.ObtenerTodos();
        }

        // Nota: Generalmente, los logs no se editan ni se eliminan desde la aplicación, 
        // solo se crean (a menudo por triggers) y se leen. 
        // Por eso, solo incluimos el método para listarlos.
    }

}
