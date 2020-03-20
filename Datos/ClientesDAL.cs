using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class ClientesDAL
    {
        #region "Variables (Clases) de conexión"
        private SqlCommand ComandoSQL;
        private SqlDataAdapter AdaptadorSQL;
        private DataTable Dt;
        #endregion

        //Clase de Acceso a los datos
        private Acceso AccesoDatos;

        // Constructor
        public ClientesDAL()
        {
            AccesoDatos = new Acceso();
        }

        public DataTable ObtenerClientes()
        {
            string query = "Select * From Clientes";
            using (AdaptadorSQL = new SqlDataAdapter(query, AccesoDatos.ObtenerConexion()))
            {
                Dt = new DataTable();

                AdaptadorSQL.Fill(Dt);

            }
            return Dt;
        }

        public void InsertarClientes(Clientes Clientes)
        {
            AccesoDatos.ObtenerConexion().Open();
            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.StoredProcedure;
                ComandoSQL.CommandText = "INSERTARCLIENTES";
                try
                {
                    ComandoSQL.Parameters.AddWithValue("@Nombre", Clientes.Nombre);
                    ComandoSQL.Parameters.AddWithValue("@Direccion", Clientes.Direccion);
                    ComandoSQL.Parameters.AddWithValue("@Pais", Clientes.Pais);
                    ComandoSQL.Parameters.AddWithValue("@SaldoInicial", Clientes.SaldoInicial);
                    ComandoSQL.Parameters.AddWithValue("@SaldoActual", Clientes.SaldoActual);

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

        public void EliminarClientes(Clientes Clientes)
        {
            AccesoDatos.ObtenerConexion().Open();


            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
               // ComandoSQL.CommandType = CommandType.StoredProcedure;
                ComandoSQL.CommandText = "DELETE FROM CLIENTES WHERE ID_CLIENTE = @ID";
                try
                {
                    ComandoSQL.Parameters.AddWithValue("@ID", Clientes.ID);
                  

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

        public void ActualizarClientes(Clientes Clientes)
        {
            string query = "UPDATE CLIENTES SET NOMB_CLIENTE = @NOMBRE," +
                           "DIRECCION = @DIRECCION, PAIS = @PAIS," +
                           "SALDO_INIC = @SALDO_IN," +
                           "SALDO_ACT = @SALDO_ACT WHERE ID_CLIENTE = @ID";

            AccesoDatos.ObtenerConexion().Open();


            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                // ComandoSQL.CommandType = CommandType.StoredProcedure;
                ComandoSQL.CommandText = query;
                try
                {
                    ComandoSQL.Parameters.AddWithValue("@ID", Clientes.ID);
                    ComandoSQL.Parameters.AddWithValue("@NOMBRE", Clientes.Nombre);
                    ComandoSQL.Parameters.AddWithValue("@DIRECCION", Clientes.Direccion);
                    ComandoSQL.Parameters.AddWithValue("@PAIS", Clientes.Pais);
                    ComandoSQL.Parameters.AddWithValue("@SALDO_IN", Clientes.SaldoInicial);
                    ComandoSQL.Parameters.AddWithValue("@SALDO_ACT", Clientes.SaldoActual);

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

        public DataTable BusquedaClientes(string parametro, string opcion)
        {
            AccesoDatos.ObtenerConexion().Open();
            string query = string.Empty;

            if (opcion.Equals("Nombre"))
            {
                query = "SELECT * FROM CLIENTES WHERE NOMB_CLIENTE LIKE @param";
            }
            else if (opcion.Equals("Pais"))
            {
                query = "SELECT * FROM CLIENTES WHERE PAIS LIKE @param";
            }

            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandText = query;
                ComandoSQL.CommandType = CommandType.Text;
                
                try
                {
                    ComandoSQL.Parameters.AddWithValue("@param", "%" + parametro + "%");
                   

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
