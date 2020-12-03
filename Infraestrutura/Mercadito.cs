using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Dominio.Conexiones;
using Aplicacion;
using Dominio;
using Infraestrutura;

namespace Infraestrutura
{
    public partial class Mercadito : Form
    {
        public Mercadito()
        {
            InitializeComponent();
        }
        SqlConnection conexion = new SqlConnection("server  = (Local); database = Mercadito; integrated security = true");
        private void Form1_Load(object sender, EventArgs e)
        {

            //Mostar producto en CB
            SqlCommand CMD2 = new SqlCommand("Select Nombre_Producto From Producto", conexion);
            conexion.Open();

            SqlDataReader Registro1 = CMD2.ExecuteReader();
            while (Registro1.Read())
            {
                CBProducto.Items.Add(Registro1["Nombre_Producto"]);
            }
            conexion.Close();


            //Mostar Cliente en CB
            SqlCommand CMD = new SqlCommand("Select ID,Nombre_Cliente From Cliente", conexion);
            conexion.Open();
            SqlDataReader Registro = CMD.ExecuteReader();
            while (Registro.Read())
            {
                comboBox1.Items.Add(Registro["Nombre_Cliente"]);
            }
            conexion.Close();
            // Mostrar datos en DGV
            //Para listar Ventas
            ListarVentas();

        }

        //Metodo de listar ventas en DGV
        public void ListarVentas()
        {
            conexion.Open();
            SqlCommand INS = new SqlCommand("Select * from Compra ORDER BY Nombre_Cliente", conexion);
            SqlDataAdapter SDA = new SqlDataAdapter();
            SDA.SelectCommand = INS;
            DataTable DT = new DataTable();
            SDA.Fill(DT);
            DGVC.DataSource = DT;
            conexion.Close();
        }

        private void CBProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Precio dato en label desde la BD, metodo hecho en una clase de infraestrutura
            ListarProductos LP = new ListarProductos();
            txtPrecio.Text = LP.listarprecio(CBProducto.Text);
            txtPrecio.ForeColor = Color.Black;
            txtPrecio.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Variable que luego paso por parametros
            try
            {
                int Precio = Convert.ToInt32(txtPrecio.Text);
                int Cant = Convert.ToInt32(txtCant.Text);
                string Client = comboBox1.Text;
                string Prod = CBProducto.Text;

                //Metodo comprar hecho en la capa Aplicacion

                Comprar CP = new Comprar();
                CP.ComprarProducto(Precio, Cant, Client, Prod);
                //Limpiar Campos
                txtPrecio.Text = "";
                txtCant.Text = "";
                comboBox1.Text = "";
                CBProducto.Text = "";
                //Actualizar DGV
                ListarVentas();
            }
            catch(Exception TiposdeDatosErroneos)
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
