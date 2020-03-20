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
    public partial class frmClientes : Form
    {
        private static frmClientes frmClientesS;

        public static frmClientes frmClientesR
        {
            get
            {
                if (frmClientesS == null || frmClientesS.IsDisposed == true)
                    frmClientesS = new frmClientes();
                return frmClientesS;
            }

            set
            {
                frmClientesS = value;
            }

        }
        public frmClientes()
        {
            InitializeComponent();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        public void LlenarGrid()
        {
            ClientesBL Obtener = new ClientesBL();
            dgvClientes.DataSource = Obtener.LlenarClientes();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ClientesBL Buscar = new ClientesBL();
            this.dgvClientes.DataSource = Buscar.BusquedaClientes(txtBusqueda.Text, "Nombre");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int fila = dgvClientes.CurrentRow.Index;
            string id = dgvClientes.Rows[fila].Cells["ID_CLIENTE"].Value.ToString();
            IComunicacionClientes comunicar = this.Owner as IComunicacionClientes;

            if (comunicar != null)
            {
                comunicar.IDCliente(id);
            }
        }
    }
}
