using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio.Conexiones;
using Infraestrutura;
using System.Data;

namespace Infraestrutura
{
    class ListarProductos
    {
        SqlConnection conexion = new SqlConnection("server = GM-ZCD; database = Mercadito; integrated security = true");
        public string listarprecio( string CBProducto)
        {
            string Producto = CBProducto;
            SqlCommand CMD = new SqlCommand("Select Nombre_Producto,Precio from Producto where Nombre_Producto = @Nombre", conexion);
            CMD.Parameters.AddWithValue("@Nombre", Producto);
            SqlDataAdapter sda1 = new SqlDataAdapter(CMD);
            DataTable DT1 = new DataTable();
            sda1.Fill(DT1);

            double Precio = Convert.ToDouble(DT1.Rows[0][1].ToString());
            
             string Dato = Convert.ToString(Precio);
            return Dato;
        }

    }
}
