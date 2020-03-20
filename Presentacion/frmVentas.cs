using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades;
using Logica;
namespace Presentacion
{
    public partial class frmVentas : Form, IComunicacionClientes, IComunicacionVendedores,
                                        IComunicacionProducto
    {
        int ID = 0;
        ErrorProvider Error;

        private static frmVentas frmVentasS;

        public static frmVentas frmVentasR
        {
            get
            {
                if (frmVentasS == null || frmVentasS.IsDisposed == true)
                    frmVentasS = new frmVentas();
                return frmVentasS;
            }

            set
            {
                frmVentasS = value;
            }


        }
        public frmVentas()
        {
            InitializeComponent();
            Error = new ErrorProvider();
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }
        public void LlenarGrid()
        {
            VentasBL Obtener = new VentasBL();
            dgvVentas.DataSource = Obtener.ObtenerVentas();
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Ventas Entidad = new Ventas();
            VentasBL Insertar = new VentasBL();
            if (Validar())
            {
                Entidad.ID_Cliente = Convert.ToInt32(txtIDcli.Text);
                Entidad.ID_Vendedor = Convert.ToInt32(txtIDVend.Text);
                Entidad.ID_Producto = Convert.ToInt32(txtIDProd.Text);
                Entidad.Fecha = dtpFechas.Value;
                Entidad.Cantidad = Convert.ToInt32(txtCantidad.Text);
                Insertar.InsertarVentas(Entidad);
                dgvVentas.Update();
                LlenarGrid();
                MessageBox.Show("Registro agregado con exito", "Registro agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar(txtIDcli, txtIDProd, txtCantidad, txtIDVend);
            }
            else
            {
                MessageBox.Show("Hay campos que son obligatorios que se encuentran vacios.", "Error de validación", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public bool Validar()
        {
            bool valor = false;
            if (!string.IsNullOrWhiteSpace(txtIDcli.Text) && !string.IsNullOrWhiteSpace(txtIDProd.Text) && !string.IsNullOrWhiteSpace(txtIDVend.Text)
                && !string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                valor = true;
            }
            return valor;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Ventas Entidad = new Ventas();
            VentasBL Actualizar = new VentasBL();

            if (ID < 1)
            {
                MessageBox.Show("Debe seleccionar un registro valido antes de actualizar." +
                " Por favor seleccione un registro en la pestaña de busqueda que desea actualizar "
                  + "y vuelva a intentarlo.", "Error de eliminación",
                  MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                Entidad.ID_Cliente = Convert.ToInt32(txtIDcli.Text);
                Entidad.ID_Vendedor = Convert.ToInt32(txtIDVend.Text);
                Entidad.ID_Producto = Convert.ToInt32(txtIDProd.Text);
                Entidad.Fecha = dtpFechas.Value;
                Entidad.Cantidad = Convert.ToInt32(txtCantidad.Text);
                Actualizar.ActualizarVentas(Entidad,ID);
                MessageBox.Show("Registro Actualizado.", "Actualización", MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
                dgvVentas.Update();
                LlenarGrid();
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Ventas Entidad = new Ventas();
            VentasBL Eliminar = new VentasBL();
            if (ID < 1)
            {
                MessageBox.Show("Debe seleccionar un registro valido antes de eliminar." +
                " Por favor seleccione un registro en la pestaña de busqueda que desea eliminar "
                  + "y vuelva a intentarlo.", "Error de eliminación",
                  MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                DialogResult resultado = MessageBox.Show("¿Realmente deseas eliminar el registro de ID de cliente: " + txtIDcli.Text + "?",
                    "¿Desea eliminar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    Entidad.ID_Cliente = ID;
                    Eliminar.EliminarVentas(Entidad,ID);
                    MessageBox.Show("Registro eliminado con exito", "Información",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvVentas.Update();
                    LlenarGrid();
                    Limpiar(txtIDcli, txtIDProd, txtCantidad, txtIDVend);
                }
            }
        }

        private void dgvVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dgvVentas.CurrentRow.Index;

            ID = Convert.ToInt32(dgvVentas.Rows[fila].Cells["ID_CLIENTE"].Value);
            txtIDcli.Text = dgvVentas.Rows[fila].Cells["ID_CLIENTE"].Value.ToString();
            txtIDProd.Text = dgvVentas.Rows[fila].Cells["ID_PROD"].Value.ToString();
            txtIDVend.Text = dgvVentas.Rows[fila].Cells["ID_VENDEDOR"].Value.ToString();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            VentasBL Buscar = new VentasBL();
            if (rbIdCli.Checked)
            {
                dgvVentas.DataSource = Buscar.BuscarVentas(txtBusqueda.Text, "IDCli");
            }
            else if (rbIdProd.Checked)
            {
                dgvVentas.DataSource = Buscar.BuscarVentas(txtBusqueda.Text, "IDProd");
            }
            else if (rbIdVend.Checked)
            {
                dgvVentas.DataSource = Buscar.BuscarVentas(txtBusqueda.Text, "IDVend");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmClientes.frmClientesR.Show(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmVendedor.frmVendedorS.Show(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmProducto.frmProductoR.Show(this);
        }

        public void IDCliente(string id)
        {
            txtIDcli.Text = id;
        }    

        public void IdProducto(string id)
        {
            txtIDProd.Text = id;
        }

        public void IdVendedores(string id)
        {
            txtIDVend.Text = id;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            VentasBL ObtenerClientesVentas = new VentasBL();
            this.dgvVentas.DataSource = ObtenerClientesVentas.ObtenerVentasClientes();
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar)
                || char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Este campo solo puede aceptar números. Intente colocando algún valor", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtIDProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar)
             || char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Este campo solo puede aceptar números. Intente colocando algún valor", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtIDVend_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar)
             || char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Este campo solo puede aceptar números. Intente colocando algún valor", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtIDcli_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIDcli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar)
             || char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Este campo solo puede aceptar números. Intente colocando algún valor", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                e.Handled = false;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Limpiar(txtIDcli, txtIDProd, txtCantidad, txtIDVend);
        }

        public void Limpiar(params TextBox[] text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                text[i].Clear();

            }

        }
    }
}
