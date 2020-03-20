using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using System.Data;
using Entidades;

namespace Logica
{
    public class VendedoresBL
    {
        public DataTable ObtenerVendedores()
        {
            VendedoresDAL ObtenerVendedor = new VendedoresDAL();
            return ObtenerVendedor.ObtenerVendedores();
        }

        public void InsertarVendedores(Vendedores entidad)
        {
            VendedoresDAL Insertar = new VendedoresDAL();
            Insertar.InsertarVendedores(entidad);
        }

        public void EliminarVendedores(Vendedores entidad)
        {
            VendedoresDAL Eliminar = new VendedoresDAL();
            Eliminar.EliminarVendedores(entidad);
        }

        public void ActualizarVendedores(Vendedores entidad)
        {
            VendedoresDAL Actualizar = new VendedoresDAL();
            Actualizar.ActualizarVendedores(entidad);
        }

        public DataTable BuscarVendedores(string parametro, string opcion)
        {
            VendedoresDAL Buscar = new VendedoresDAL();
            return Buscar.BuscarVendedores(parametro, opcion);
        }

        public bool ComprobarForaneas(int id_jefe)
        {
            return new VendedoresBL().ComprobarForaneas(id_jefe);
        }
    }
}
