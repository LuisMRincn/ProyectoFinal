using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Dominio.Conexiones
{
    public class ConexionDB
    {
        SqlConnection conexion = new SqlConnection("server  = (Local); database = Mercadito; integrated security = true");
        
        public void conexiones()
        {
            conexion.Open();

        }
        public void Open()
        {
            SqlConnection conexion1 = new SqlConnection("server  = (Local); database = Mercadito; integrated security = true");
        }

        public void Cerrar()
        {
            
            conexion.Close();

        }


    }
}
