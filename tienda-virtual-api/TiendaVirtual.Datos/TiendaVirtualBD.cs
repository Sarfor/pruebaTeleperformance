using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaVirtual.Datos
{
    public static  class TiendaVirtualBD
    {
        private static string CadenaConexion = "Server=localhost;Database=TiendaVirtual;Trusted_Connection=True;";

        public static SqlConnection CrearConexion()
        {
            return new SqlConnection(CadenaConexion);
        }

    }
        
}
