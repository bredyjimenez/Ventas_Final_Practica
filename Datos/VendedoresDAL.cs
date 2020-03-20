using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class VendedoresDAL
    {
        #region "Variables (Clases) de conexión"
        private SqlCommand ComandoSQL;
        private SqlDataAdapter AdaptadorSQL;
        private DataTable Dt;
        #endregion

        //Clase de Acceso a los datos
        private Acceso AccesoDatos;

        // Constructor 
        public VendedoresDAL()
        {
            AccesoDatos = new Acceso();
        }

        public DataTable ObtenerVendedores()
        {
      

            using (AdaptadorSQL = new SqlDataAdapter("SELECT * FROM VENDEDOR",AccesoDatos.ObtenerConexion()))
            {
                Dt = new DataTable();
                AdaptadorSQL.Fill(Dt);
            }
            return Dt;
        }

        public void InsertarVendedores(Vendedores vendedor)
        {
         
            AccesoDatos.ObtenerConexion().Open();
            
            string Query = "INSERT INTO VENDEDOR VALUES (@NOMBRE,@IDJefe," +
                           "@Oficina, @Comision)"; 


            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.CommandText = Query;
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.Text;

                try
                {
                    ComandoSQL.Parameters.AddWithValue("@Nombre", vendedor.Nombre);
                    ComandoSQL.Parameters.AddWithValue("@IDJefe", vendedor.IDJefe);
                    ComandoSQL.Parameters.AddWithValue("@Oficina", vendedor.Oficina);
                    ComandoSQL.Parameters.AddWithValue("@Comision", vendedor.Comision);

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

        public void EliminarVendedores(Vendedores vendedor)
        {

            AccesoDatos.ObtenerConexion().Open();

            string Query = "DELETE FROM VENDEDOR WHERE ID_VENDEDOR = @ID";


            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.CommandText = Query;
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.Text;

                try
                {
                    ComandoSQL.Parameters.AddWithValue("@ID", vendedor.ID);
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

        public void ActualizarVendedores(Vendedores vendedor)
        {
           
            AccesoDatos.ObtenerConexion().Open();

            string Query = "UPDATE VENDEDOR SET NOMB_VENDEDOR = @NOMBRE," +
                            "ID_JEFE = @IDJEFE," +
                            "OFICINA = @OFICINA," +
                            "COMISION = @COMISION " +
                            "WHERE ID_VENDEDOR = @ID";


            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.CommandText = Query;
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.Text;

                try
                {
                    ComandoSQL.Parameters.AddWithValue("@ID", vendedor.ID);
                    ComandoSQL.Parameters.AddWithValue("@NOMBRE", vendedor.Nombre);
                    ComandoSQL.Parameters.AddWithValue("@IDJEFE", vendedor.IDJefe);
                    ComandoSQL.Parameters.AddWithValue("@OFICINA", vendedor.Oficina);
                    ComandoSQL.Parameters.AddWithValue("@COMISION", vendedor.Comision);

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

        public DataTable BuscarVendedores(string parametro, string opcion)
        {
          
            AccesoDatos.ObtenerConexion().Open();
            string Query = string.Empty;

            if (opcion.Equals("ID"))
            {
                Query = "SELECT * FROM VENDEDOR WHERE ID_VENDEDOR = @param";
            }
            else if (opcion.Equals("Nombre"))
            {
                Query = "SELECT * FROM VENDEDOR WHERE NOMB_VENDEDOR = @param";
            }
            else if (opcion.Equals("Oficina"))
            {
                Query = "SELECT * FROM VENDEDOR WHERE OFICINA = @param";
            }
            else if (opcion.Equals("Ex-Oficina"))
            {
                Query = "SELECT * FROM VENDEDOR WHERE OFICINA <> @param";
            }
            else if (opcion.Equals("Menor"))
            {
               Query = "SELECT * FROM VENDEDOR WHERE COMISION < @param";
            }
            else if (opcion.Equals("Mayor"))
            {
                Query = "SELECT * FROM VENDEDOR WHERE COMISION > @param";
            }
            else if (opcion.Equals("Td-Info"))
            {
                Query = "SELECT NOMB_VENDEDOR,ID_JEFE,OFICINA,COMISION, C.NOMB_CLIENTE,V.FECHA,V.CANTIDAD FROM VENDEDOR INNER JOIN VENTAS V "
                + "ON VENDEDOR.ID_VENDEDOR = V.ID_VENDEDOR " +
                "INNER JOIN CLIENTES C ON V.ID_CLIENTE = C.ID_CLIENTE WHERE NOMB_VENDEDOR = @param";
               
            
            }
          
           using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.CommandText = Query;
                ComandoSQL.CommandType = CommandType.Text;
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                try
                {
                    ComandoSQL.Parameters.AddWithValue("@param", parametro);

                    using (AdaptadorSQL = new SqlDataAdapter())
                    {
                        AdaptadorSQL.SelectCommand = ComandoSQL;
                        Dt = new DataTable();
                        AdaptadorSQL.Fill(Dt);
                    }
                }
                catch (Exception)
                {

                    throw;
                }

                finally
                {
                    AccesoDatos.ObtenerConexion().Close();
                }

                return Dt;
            }
        }

        public bool ComprobarForanea(int id_jefe)
        {
            bool valor = false;
            AccesoDatos.ObtenerConexion().Open();

            string Query = "SELECT ID_JEFE FROM VENDEDOR WHERE ID_JEFE = @ID";


            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.CommandText = Query;
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.Text;

                try
                {
                    ComandoSQL.Parameters.AddWithValue("@ID", id_jefe);

                    if (ComandoSQL.ExecuteScalar() != null)
                        valor = true;
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
            return valor;

        }
    }
}
