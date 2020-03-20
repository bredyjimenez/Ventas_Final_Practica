using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Logica;

namespace Presentacion
{
    public partial class frmProducto : Form
    {
        private static frmProducto frmProductoS;
 
        public static frmProducto frmProductoR
        {
            get
            {
                if (frmProductoS == null || frmProductoS.IsDisposed == true)
                    frmProductoS = new frmProducto();

                return frmProductoS;
            }
            set
            {
                frmProductoS = value;
            }

        }
        public frmProducto()
        {
            InitializeComponent();
        }

        public void LlenarGrid()
        {
            ProductosBL Obtener = new ProductosBL();
            dataGridView1.DataSource = Obtener.LlenarProductos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IComunicacionProducto comunicar = this.Owner as IComunicacionProducto;
            int fila = dataGridView1.CurrentRow.Index;
            string id = dataGridView1.Rows[fila].Cells["ID_PRODUCTO"].Value.ToString();
            if (comunicar != null)
            
                comunicar.IdProducto(id);
            }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ProductosBL Buscar = new ProductosBL();

            dataGridView1.DataSource = Buscar.BuscarProductos(txtBusqueda.Text,"Descripcion");
        }
        }
    }
