using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Datos
{
    public class Acceso
    {
        // Clase de acceso a datos. - Claritza Presinal - Vielka

        #region "Variables (Clases) de Conexion"
        private SqlConnection Conexion;
        #endregion

        //Constructor
        public Acceso()
        {
            Conexion = new SqlConnection(CadenaConexion);
        }
        private string CadenaConexion
        {
            get
            {
                return  ConfigurationManager.ConnectionStrings["Conexion"].ToString();
                    //@"Data Source = .\SQLEXPRESS;Initial Catalog = BD_IPD; Integrated Security = true";
            }

        }

        public SqlConnection ObtenerConexion()
        {
            return Conexion;
        }



    }
}
