using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class VentasDAL
    {

        #region "Variables (Clases) de conexión"
        private SqlCommand ComandoSQL;
        private SqlDataAdapter AdaptadorSQL;
        private DataTable Dt;
        #endregion

        //Clase de Acceso a los datos
        private Acceso AccesoDatos;

        // Constructor
        public VentasDAL()
        {
            AccesoDatos = new Acceso();
        }

        public DataTable ObtenerVentas()
        {
            string query = "Select * From  Ventas";
            using (AdaptadorSQL = new SqlDataAdapter(query, AccesoDatos.ObtenerConexion()))
            {
                Dt = new DataTable();

                AdaptadorSQL.Fill(Dt);

            }
            return Dt;
        }

        public void InsertarVentas(Ventas ventas)
        {
            AccesoDatos.ObtenerConexion().Open();
            string Query = "INSERT INTO VENTAS VALUES (@FECH,@IDCLI,@IDVEND,@IDPROD,@CANTIDAD)";

            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                //ComandoSQL.CommandType = CommandType.StoredProcedure;
                ComandoSQL.CommandText = Query;
                try
                {
                    ComandoSQL.Parameters.AddWithValue("@FECH", Convert.ToDateTime(ventas.Fecha.ToShortDateString()));
                    ComandoSQL.Parameters.AddWithValue("@IDCLI", ventas.ID_Cliente);
                    ComandoSQL.Parameters.AddWithValue("@IDVEND", ventas.ID_Vendedor);
                    ComandoSQL.Parameters.AddWithValue("@IDPROD", ventas.ID_Producto);
                    ComandoSQL.Parameters.AddWithValue("@CANTIDAD", ventas.Cantidad);


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

        public void ActualizarVentas(Ventas ventas,int param)
        {
            AccesoDatos.ObtenerConexion().Open();
            string Query = "UPDATE VENTAS SET FECHA = @FECH, ID_CLIENTE=@IDCLI, ID_VENDEDOR=@IDVEND, ID_PROD = @IDPROD, CANTIDAD = @CANTIDAD "
                + "WHERE ID_CLIENTE = @ID";

            using (ComandoSQL = new SqlCommand()) 
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                //ComandoSQL.CommandType = CommandType.StoredProcedure;
                ComandoSQL.CommandText = Query;
                try
                {
                    ComandoSQL.Parameters.AddWithValue("@ID", param);
                    ComandoSQL.Parameters.AddWithValue("@FECH", ventas.Fecha.ToShortDateString());
                    ComandoSQL.Parameters.AddWithValue("@IDCLI", ventas.ID_Cliente);
                    ComandoSQL.Parameters.AddWithValue("@IDVEND", ventas.ID_Vendedor);
                    ComandoSQL.Parameters.AddWithValue("@IDPROD", ventas.ID_Producto);
                    ComandoSQL.Parameters.AddWithValue("@CANTIDAD", ventas.Cantidad);


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

        public void EliminarVentas(Ventas ventas)
        {
            AccesoDatos.ObtenerConexion().Open();

            string Query = "DELETE FROM VENTAS WHERE ID_CLIENTE = @ID";


            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.CommandText = Query;
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.Text;

                try
                {
                    ComandoSQL.Parameters.AddWithValue("@ID",ventas.ID_Cliente);
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

        public DataTable BuscarVentas(string param, string opcion)
        {
            AccesoDatos.ObtenerConexion().Open();
            string Query = string.Empty;

            if (opcion.Equals("IDCli"))
            {
                Query = "SELECT * FROM VENTAS WHERE ID_CLIENTE LIKE @PARAM";
            }
            else if (opcion.Equals("IDProd"))
            {
                Query = "SELECT * FROM VENTAS WHERE ID_PROD LIKE @PARAM";
            }
            else if (opcion.Equals("IDVend"))
            {
                Query = "SELECT * FROM VENTAS WHERE ID_VENDEDOR LIKE @PARAM";
            }

            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandText = Query;
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

                return Dt;

            }
        }
        public DataTable ObtenerVentasClientes()
        {
            string query = "Select FECHA,CANTIDAD,C.NOMB_CLIENTE,C.ID_CLIENTE,V.NOMB_VENDEDOR,V.ID_VENDEDOR,P.DESC_PRODUCTO,P.ID_PRODUCTO, " +
            "P.DESC_PRODUCTO FROM VENTAS INNER JOIN CLIENTES C " +
            "ON VENTAS.ID_CLIENTE = C.ID_CLIENTE INNER JOIN VENDEDOR V ON VENTAS.ID_VENDEDOR = V.ID_VENDEDOR " +
            "INNER JOIN PRODUCTOS P ON VENTAS.ID_PROD = P.ID_PRODUCTO";
            using (AdaptadorSQL = new SqlDataAdapter(query, AccesoDatos.ObtenerConexion()))
            {
                Dt = new DataTable();

                AdaptadorSQL.Fill(Dt);

            }
            return Dt;
        }

    }
}