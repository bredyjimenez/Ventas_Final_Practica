using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Clientes
    {
        //Llave primaria
        public int ID { get; set; }

        //Datos del cliente
        public string Nombre { get; set; }
        public  string Direccion { get; set; }
        public string Pais { get; set; }

        // Saldos
        public float SaldoInicial { get; set; }
        public  float SaldoActual { get; set; }


    }
}
