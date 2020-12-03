using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
   public class Ventas
    {
        public string Cliente { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public Ventas(string client, string produc, int cantid, int prec)
        {
            Cliente = client;
            Producto = produc;
            Cantidad = cantid;
            Precio = prec;

        }

    }
}
