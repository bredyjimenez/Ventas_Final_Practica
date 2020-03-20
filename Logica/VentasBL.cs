using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using System.Data;
using Entidades;

namespace Logica
{
    public class VentasBL
    {
        public DataTable ObtenerVentas()
        {
            VentasDAL Obtener = new VentasDAL();
            return Obtener.ObtenerVentas();
        }

        public void InsertarVentas(Ventas entidad)
        {
            VentasDAL Insertar = new VentasDAL();
            Insertar.InsertarVentas(entidad);
        }

        public void ActualizarVentas(Ventas entidad,int param)
        {
            VentasDAL Actualizar = new VentasDAL();
            Actualizar.ActualizarVentas(entidad, param);
        }

        public void EliminarVentas(Ventas entidad, int param)
        {
            VentasDAL Eliminar = new VentasDAL();
            Eliminar.EliminarVentas(entidad);
        }

        public DataTable BuscarVentas(string param, string opcion)
        {
            VentasDAL Buscar = new VentasDAL();

            return Buscar.BuscarVentas(param, opcion);
        }

        public DataTable ObtenerVentasClientes()
        {
            return new VentasDAL().ObtenerVentasClientes();
        }
    }
}
