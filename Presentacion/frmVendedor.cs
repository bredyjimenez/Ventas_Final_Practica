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
    public partial class frmVendedor : Form
    {
        private static frmVendedor frmVendedorR;

        public static frmVendedor frmVendedorS
        {
            get
            {
                if (frmVendedorR == null || frmVendedorR.IsDisposed == true)
                    frmVendedorR = new frmVendedor();

                return frmVendedorR;
            }

            set
            {
                frmVendedorR = value;
            }
        }
            

        public frmVendedor()
        {
            InitializeComponent();
        }

        private void frmVendedor_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        public void LlenarGrid()
        {
            VendedoresBL Obtener = new VendedoresBL();

            dataGridView1.DataSource = Obtener.ObtenerVendedores();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            VendedoresBL Buscar = new VendedoresBL();
            this.dataGridView1.DataSource  = Buscar.BuscarVendedores(txtBusqueda.Text, "Nombre");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IComunicacionVendedores comunicacion = this.Owner as IComunicacionVendedores;
            int fila = dataGridView1.CurrentRow.Index;
            string id = dataGridView1.Rows[fila].Cells["ID_VENDEDOR"].Value.ToString();
            if (comunicacion != null)
            {
                comunicacion.IdVendedores(id);
            }
        }

    }
}
