using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using Entidades;
using System.Data;
namespace Logica
{
    public class ProductosBL
    {
        public DataTable LlenarProductos()
        {
            ProductosDAL llenar = new ProductosDAL();
            return llenar.ObtenerProductos();
        }

        public void InsertarProductos(Productos entidad)
        {
            ProductosDAL RegistrarProductos = new ProductosDAL();
            RegistrarProductos.InsertarProductos(entidad);
        }

        public void ActualizarProductos(Productos entidad)
        {
            ProductosDAL ActualizarProductos = new ProductosDAL();
            ActualizarProductos.ActualizarProductos(entidad);
        }

        public void EliminarProductos(Productos entidad)
        {
            ProductosDAL EliminarProductos = new ProductosDAL();
            EliminarProductos.EliminarProductos(entidad);
        }

        public DataTable BuscarProductos(string param, string opcion)
        {
            ProductosDAL Buscar = new ProductosDAL();
            return Buscar.BuscarProductos(param, opcion);
        }

        public bool ComprobarForanea(int id_fabricante)
        {
            return new ProductosDAL().ComprobarForanea(id_fabricante);
        }
    }
}
