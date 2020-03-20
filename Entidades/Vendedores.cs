using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Vendedores
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Oficina { get; set; }
        public float Comision { get; set; }
        public int IDJefe { get; set; }
    }
}
