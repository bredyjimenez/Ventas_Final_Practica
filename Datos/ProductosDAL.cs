using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Entidades;

namespace Datos
{
    public class ProductosDAL
    {
        #region "Variables (Clases) de conexión"
        private SqlCommand ComandoSQL;
        private SqlDataAdapter AdaptadorSQL;
        private DataTable Dt;
        #endregion

        //Clase de Acceso a los datos
        private Acceso AccesoDatos;

        // Constructor
        public ProductosDAL()
        {
            AccesoDatos = new Acceso();
        }

        public DataTable ObtenerProductos()
        {
            string query = "Select * From Productos";
            using (AdaptadorSQL = new SqlDataAdapter(query, AccesoDatos.ObtenerConexion()))
            {
                Dt = new DataTable();

                AdaptadorSQL.Fill(Dt);

            }
            return Dt;
        }

        public void InsertarProductos(Productos productos)
        {
            AccesoDatos.ObtenerConexion().Open();
            string Query = "INSERT INTO PRODUCTOS VALUES(@DESCR,@ID_FAB,@COST,@PREC)";

            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                //ComandoSQL.CommandType = CommandType.StoredProcedure;
                ComandoSQL.CommandText = Query;
                try
                {
                    ComandoSQL.Parameters.AddWithValue("@DESCR", productos.Descripcion);
                    ComandoSQL.Parameters.AddWithValue("@ID_FAB", productos.ID_Fabricante);
                    ComandoSQL.Parameters.AddWithValue("@COST", productos.Costo);
                    ComandoSQL.Parameters.AddWithValue("@PREC", productos.Precio);
                    

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

        public void ActualizarProductos(Productos productos)
        {

            AccesoDatos.ObtenerConexion().Open();

            string Query = "UPDATE PRODUCTOS SET DESC_PRODUCTO = @DESCR," +
                            "ID_FABRICANTE = @ID_FAB," +
                            "COSTO = @COST," +
                            "PRECIO = @PREC " +
                            "WHERE ID_PRODUCTO = @ID";


            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.CommandText = Query;
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.Text;

                try
                {
                    ComandoSQL.Parameters.AddWithValue("@ID", productos.ID_Producto);
                    ComandoSQL.Parameters.AddWithValue("@DESCR", productos.Descripcion);
                    ComandoSQL.Parameters.AddWithValue("@ID_FAB", productos.ID_Fabricante);
                    ComandoSQL.Parameters.AddWithValue("@COST", productos.Costo);
                    ComandoSQL.Parameters.AddWithValue("@PREC", productos.Precio);

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

        public void EliminarProductos(Productos productos)
        {

            AccesoDatos.ObtenerConexion().Open();

            string Query = "DELETE FROM PRODUCTOS WHERE ID_PRODUCTO = @ID";


            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.CommandText = Query;
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.Text;

                try
                {
                    ComandoSQL.Parameters.AddWithValue("@ID", productos.ID_Producto);
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

        public DataTable BuscarProductos(string param, string opcion)
        {
            string query = string.Empty;

            if (opcion.Equals("Descripcion"))
            {
                query = "SELECT * FROM PRODUCTOS WHERE DESC_PRODUCTO LIKE @PARAM";
            }
            else
            {
                query = "SELECT * FROM PRODUCTOS WHERE ID_FABRICANTE LIKE @PARAM";
            }
            AccesoDatos.ObtenerConexion().Open();
            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection =  AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandText = query;
                ComandoSQL.Parameters.AddWithValue("@PARAM", "%" + param + "%");
                try
                {
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
            }
            return Dt;

        }

        public bool ComprobarForanea(int id_fabricante)
        {
            bool valor = false;
            AccesoDatos.ObtenerConexion().Open();

            string Query = "SELECT ID_FABRICANTE FROM FABRICANTES WHERE ID_FABRICANTE = @ID";


            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.CommandText = Query;
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.Text;

                try
                {
                    ComandoSQL.Parameters.AddWithValue("@ID", id_fabricante);

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
