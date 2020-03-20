using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class FabricantesDAL
    {
        #region "Variables (Clases) de conexión"
        private SqlCommand ComandoSQL;
        private SqlDataAdapter AdaptadorSQL;
        private DataTable Dt;
        #endregion

        //Clase de Acceso a los datos
        private Acceso AccesoDatos;

        // Constructor
        public FabricantesDAL()
        {
            AccesoDatos = new Acceso();
        }

        public DataTable ObtenerFabricantes()
        {
            string query = "Select ID_FABRICANTE, NOMB_FABRICANTE,DIRECCION, PAIS  From Fabricantes";
            using (AdaptadorSQL = new SqlDataAdapter(query, AccesoDatos.ObtenerConexion()))
            {
                Dt = new DataTable();

                AdaptadorSQL.Fill(Dt);

            }
            return Dt;
        }

        public void InsertarFabricantes(Fabricante fabricantes)
        {
            AccesoDatos.ObtenerConexion().Open();
            string Query = "INSERT INTO FABRICANTES VALUES(@NOMB,@DIR,@PAIS)";

            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
               // ComandoSQL.CommandType = CommandType.StoredProcedure;
                ComandoSQL.CommandText = Query;
                try
                {
                    ComandoSQL.Parameters.AddWithValue("@NOMB",fabricantes.Nombre);
                    ComandoSQL.Parameters.AddWithValue("@DIR", fabricantes.Direccion);
                    ComandoSQL.Parameters.AddWithValue("@PAIS", fabricantes.Pais);
               


                    //Ejecutar Comando
                    ComandoSQL.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;

                }
                finally
                {
                    AccesoDatos.ObtenerConexion().Close();
                }
            }

        }

        public void ActualizarFabricantes(Fabricante fabricantes)
        {

            AccesoDatos.ObtenerConexion().Open();

            string Query = "UPDATE FABRICANTES SET NOMB_FABRICANTE= @NOMB," +
                            "DIRECCION = @DIR," +
                            "PAIS= @PAIS " +
                            "WHERE ID_FABRICANTE = @ID";


            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.CommandText = Query;
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.Text;

                try
                {
                    ComandoSQL.Parameters.AddWithValue("@ID", fabricantes.ID_Fabricante);
                    ComandoSQL.Parameters.AddWithValue("@NOMB", fabricantes.Nombre);
                    ComandoSQL.Parameters.AddWithValue("@DIR", fabricantes.Direccion);
                    ComandoSQL.Parameters.AddWithValue("@PAIS", fabricantes.Pais);

                    ComandoSQL.ExecuteNonQuery();
                }
                catch (Exception)
                {

                    throw;
                }

                finally
                {
                    AccesoDatos.ObtenerConexion().Close();
                }
            }
        }

        public void EliminarFabricantes(Fabricante fabricantes)
        {

            AccesoDatos.ObtenerConexion().Open();

            string Query = "DELETE FROM FABRICANTES WHERE ID_FABRICANTE = @ID";


            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.CommandText = Query;
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.Text;

                try
                {
                    ComandoSQL.Parameters.AddWithValue("@ID", fabricantes.ID_Fabricante);
                    ComandoSQL.ExecuteNonQuery();
                }
                catch (Exception)
                {

                    throw;
                }

                finally
                {
                    AccesoDatos.ObtenerConexion().Close();
                }
            }

        }

        public DataTable BuscarFabricantes(string param,string option)
        {
            string query = string.Empty;
            if (option.Equals("Nombre"))
            {
                query = "SELECT * FROM FABRICANTES WHERE NOMB_FABRICANTE LIKE @FAB";
            }
            else
            {
                query = "SELECT * FROM FABRICANTES WHERE PAIS LIKE @FAB";
            }
            AccesoDatos.ObtenerConexion().Open();
            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.CommandText = query;
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.Parameters.AddWithValue("@FAB", "%" + param + "%");
                try
                {
                    using (AdaptadorSQL = new SqlDataAdapter())
                    {
                        AdaptadorSQL.SelectCommand = ComandoSQL;
                        Dt = new DataTable();

                        AdaptadorSQL.Fill(Dt);

                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {

                    AccesoDatos.ObtenerConexion().Close();
                }
            }
            return Dt;

        }

    }

}
