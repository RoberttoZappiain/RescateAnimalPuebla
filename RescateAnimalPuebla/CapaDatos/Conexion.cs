using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CapaDatos
{
    public class Conexion
    {
        // Este método lee la cadena de conexión desde el archivo Web.config
        public static string CadenaConexion()
        {
            return ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
        }
    }
}
