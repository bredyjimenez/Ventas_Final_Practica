using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
   public class Productos
    {
       public int ID_Producto { get; set; }
       public string Descripcion { get; set; }
       public int ID_Fabricante { get; set; }
       public float Costo { get; set; }
       public float Precio { get; set; }

    }
}
