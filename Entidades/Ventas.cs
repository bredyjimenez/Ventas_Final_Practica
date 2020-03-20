using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Ventas
    {
        public int ID_Cliente { get; set; }
        public int ID_Vendedor { get; set; }
        public int ID_Producto { get; set; }

        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }

    }
}
