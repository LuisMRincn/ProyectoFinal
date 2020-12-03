using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Productos
    {
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public Productos(string name, int cantidad)
        {
            Nombre = name;
            Cantidad = cantidad;
        }
    }
}
