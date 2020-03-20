using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Datos;
using System.Data;
namespace Logica
{
    public class FabricantesBL
    {
        public DataTable ObtenerFabricantes()
        {
            FabricantesDAL Obtener = new FabricantesDAL();

            return Obtener.ObtenerFabricantes();
        }

        public void InsertarFabricantes(Fabricante entidad)
        {
            FabricantesDAL Insertar = new FabricantesDAL();

            Insertar.InsertarFabricantes(entidad);
        }

        public void ActualizarFabricantes(Fabricante entidad)
        {
            FabricantesDAL Actualizar = new FabricantesDAL();

            Actualizar.ActualizarFabricantes(entidad);
        }

        public void EliminarFabricantes(Fabricante entidad)
        {
            FabricantesDAL Eliminar = new FabricantesDAL();

            Eliminar.EliminarFabricantes(entidad);
        }

        public DataTable BuscarFabricantes(string param,string option)
        {
            FabricantesDAL Buscar = new FabricantesDAL();

            return Buscar.BuscarFabricantes(param,option);
        }
    }
}
