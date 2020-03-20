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
    public partial class frmSeleccionFabricantes : Form
    {
        string id = " ";

        private static frmSeleccionFabricantes frmSelFabricantesR;

        public static frmSeleccionFabricantes frmSelFabricantesS
        {
            get
            {
                if (frmSelFabricantesR == null || frmSelFabricantesR.IsDisposed == true)
                    frmSelFabricantesR = new frmSeleccionFabricantes();
                return frmSelFabricantesR;
            }

            set
            {
                frmSelFabricantesR = value;
            }
        }
        public frmSeleccionFabricantes()
        {
            InitializeComponent();
        }

        private void frmSeleccionFabricantes_Load(object sender, EventArgs e)
        {
            FabricantesBL Obtener = new FabricantesBL();
            dgvFabricantes.DataSource = Obtener.ObtenerFabricantes();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FabricantesBL Buscar = new FabricantesBL();

            dgvFabricantes.DataSource = Buscar.BuscarFabricantes(txtBusqueda.Text,"Nombre");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IComunicacionFabricante IFabricantes = this.Owner as IComunicacionFabricante;

           
            if (IFabricantes != null)
            {
                IFabricantes.IdFabricante(id);
                
            }

        }

        private void dgvFabricantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dgvFabricantes.CurrentRow.Index;
           id = dgvFabricantes.Rows[fila].Cells["ID_FABRICANTE"].Value.ToString();
        }
    }
}
