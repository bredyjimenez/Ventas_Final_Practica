using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void mantenimientoDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantenimientoClientes.frmClientesR.Show();
            frmMantenimientoClientes.frmClientesR.MdiParent = this;
        }

        private void mantenimientoDeVendedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantenimientoVendedor.frmVendedorR.Show();
            frmMantenimientoVendedor.frmVendedorR.MdiParent = this;
        }



        private void mantenimientoDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantenimientoProducto.frmProductosR.Show();
          // frmMantenimientoProducto.frmProductosR.MdiParent = this;
        }

        private void mantenimientoDeFabricantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantenimientoFabricante.frmFabricanteR.Show();
            frmMantenimientoFabricante.frmFabricanteR.MdiParent = this;
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmMantenimientoClientes.frmClientesR.Show();
            frmMantenimientoClientes.frmClientesR.MdiParent = this;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmMantenimientoVendedor.frmVendedorR.Show();
            frmMantenimientoVendedor.frmVendedorR.MdiParent = this;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            frmVentas.frmVentasR.Show();
            frmVentas.frmVentasR.MdiParent = this;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            frmMantenimientoFabricante.frmFabricanteR.Show();
            frmMantenimientoFabricante.frmFabricanteR.MdiParent = this;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            frmMantenimientoProducto.frmProductosR.Show();
            frmMantenimientoProducto.frmProductosR.MdiParent = this;
        }

        private void mantenimientoDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVentas.frmVentasR.Show();
            //frmVentas.frmVentasR.MdiParent = this;
        }

        private void reporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.StartupPath + @"\Manual de usuario.pdf");
        }

        private void sustentantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAcercaDe acerca = new frmAcercaDe();
            acerca.Show();
        }
    }
}
