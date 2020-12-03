using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio.Conexiones;
using Dominio;
using System.Windows.Forms;

namespace Aplicacion
{
    public class Comprar
    {
        SqlConnection conexion = new SqlConnection("server  = (Local); database = Mercadito; integrated security = true");
        public void ComprarProducto(int Precio, int Cantidad, string Nombre_cliente, string Nombre_productos)
        {
            try
            {
                //Conexiones -- Capa Dominio
                ConexionDB CDB = new ConexionDB();
                CDB.conexiones();
                conexion.Open();

                //Clases -- Capa Dominio
                Cliente cliente = new Cliente(Nombre_cliente);
                Productos productos = new Productos(Nombre_productos, Cantidad);

                ;
                //Precio Total
                int Total = Precio * Cantidad;

                //Ingresar datos a la Base de datos
                string InsertarC = "Insert into Compra (Nombre_Cliente ,Nombre_Producto ,Cantidad ,Precio, Total) Values(@NombreC,@NombreP, @cantidad, @precio, @total)";
                SqlCommand CMD4 = new SqlCommand(InsertarC, conexion);
                CMD4.Parameters.AddWithValue("@NombreC", cliente.Nombre);
                CMD4.Parameters.AddWithValue("@NombreP", productos.Nombre);
                CMD4.Parameters.AddWithValue("@cantidad", productos.Cantidad);
                CMD4.Parameters.AddWithValue("@precio", Precio);
                CMD4.Parameters.AddWithValue("@total", Total);
                CMD4.ExecuteNonQuery();
                MessageBox.Show("Compra realizda con exito");

            }
            catch (Exception TiposdeDatosErroneos)
            {
                MessageBox.Show($"{TiposdeDatosErroneos}\n\nComplete los campos de forma correcta");
            }
            finally
            {
                conexion.Close();
            }

        }
    }
}
