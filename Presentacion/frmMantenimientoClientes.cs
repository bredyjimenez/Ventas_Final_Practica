using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Logica;
using Entidades;

namespace Presentacion
{
    public partial class frmMantenimientoClientes : Form
    {
        int ID = 0;
        ErrorProvider error;
        // Patrón Singlenton
        private static frmMantenimientoClientes frmClientesS;

        public static frmMantenimientoClientes frmClientesR
        {
            get
            {
                if (frmClientesS == null || frmClientesS.IsDisposed == true)
                    frmClientesS = new frmMantenimientoClientes();
                return frmClientesS;
            }
            set
            {
                frmClientesS = value;
            }
        }
        public frmMantenimientoClientes()
        {
            InitializeComponent();
            error = new ErrorProvider();
        }

        private void frmMantenimientoClientes_Load(object sender, EventArgs e)
        {
            LlenarGrid();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void LlenarGrid()
        {
            ClientesBL cli = new ClientesBL();

            dgvClientes.DataSource = cli.LlenarClientes();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                ClientesBL cli = new ClientesBL();
                Clientes entidades = new Clientes();

              
                if (txtPais.Text == string.Empty)
                    txtPais.Text = null;
                if (txtSaldoActual.Text == string.Empty)
                    txtSaldoActual.Text = "0.0";

                float SaldoIn = float.Parse(txtSaldoInicial.Text);
                float SaldoAct = float.Parse(txtSaldoActual.Text);

                entidades.Nombre = txtNombre.Text;
                entidades.Direccion = txtDireccion.Text;
                entidades.Pais = txtPais.Text;
                entidades.SaldoActual = SaldoAct;
                entidades.SaldoInicial = SaldoIn;

                cli.RegClientes(entidades);
                dgvClientes.Update();
                LlenarGrid();
                MessageBox.Show("Registro agregado con exito.", "Agregado", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Limpiar(txtNombre, txtPais, txtDireccion, txtSaldoInicial, txtSaldoActual);
            }
            else
            {
                MessageBox.Show("Hay campos que son obligatorios que se encuentran vacios." , "Error de validación", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (ID < 1)
            {
                MessageBox.Show("Debe seleccionar un registro valido antes de eliminar." +
                " Por favor seleccione un registro en la pestaña de busqueda que desea eliminar "
                  + "y vuelva a intentarlo.", "Error de eliminación",
                  MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
              DialogResult resultado = MessageBox.Show("Realmente desea eliminar el registro de nombre: " + txtNombre.Text + "?",
                                "¿Desea eliminar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

              if (resultado == DialogResult.Yes)
              {

                  Clientes entidad = new Clientes();
                  entidad.ID = ID;
                  ClientesBL eliminar = new ClientesBL();

                  eliminar.EliminarClientes(entidad);
                  dgvClientes.Update();
                  LlenarGrid();
                  MessageBox.Show("Registro Eliminado.", "Eliminación", MessageBoxButtons.OK,
               MessageBoxIcon.Information);
                  Limpiar(txtNombre, txtPais, txtDireccion);
              }
            }
           
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Clientes entidad = new Clientes();
            ClientesBL actualizar = new ClientesBL();

            if (ID < 1)
            {
                MessageBox.Show("Debe seleccionar un registro valido antes de actualizar." +
                " Por favor seleccione un registro en la pestaña de busqueda que desea actualizar "
                  + "y vuelva a intentarlo.", "Error de eliminación",
                  MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {

                entidad.ID = ID;
                entidad.Nombre = txtNombre.Text;
                entidad.Direccion = txtDireccion.Text;
                entidad.Pais = txtPais.Text;

                entidad.SaldoActual = float.Parse(txtSaldoActual.Text);
                entidad.SaldoInicial = float.Parse(txtSaldoInicial.Text);

                actualizar.ActualizarClientes(entidad);
                dgvClientes.Update();
                LlenarGrid();
                MessageBox.Show("Registro Actualizado.", "Actualización", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }


        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            ClientesBL busqueda = new ClientesBL();

            if (rbNombre.Checked == true)
            {
                dgvClientes.DataSource = busqueda.BusquedaClientes(txtBusqueda.Text, "Nombre");
            }
            else if (rbPais.Checked == true)
            {
                dgvClientes.DataSource = busqueda.BusquedaClientes(txtBusqueda.Text, "Pais");
            }
        }

        public void PaginarClientes()
        {
            int fila = dgvClientes.CurrentRow.Index;
            try
            {
                ID = Convert.ToInt32(dgvClientes.Rows[fila].Cells["ID_CLIENTE"].Value);
                txtNombre.Text = dgvClientes.Rows[fila].Cells["NOMB_CLIENTE"].Value.ToString();
                txtPais.Text = dgvClientes.Rows[fila].Cells["PAIS"].Value.ToString();
                txtDireccion.Text = dgvClientes.Rows[fila].Cells["DIRECCION"].Value.ToString();
                txtSaldoInicial.Text = dgvClientes.Rows[fila].Cells["SALDO_INIC"].Value.ToString();
                txtSaldoActual.Text = dgvClientes.Rows[fila].Cells["SALDO_ACT"].Value.ToString();
            }

            catch (Exception) { }
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PaginarClientes();
        }

        private void txtSaldoInicial_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtSaldoActual_TextChanged(object sender, EventArgs e)
        {
           
        }

        public bool validar()
        {
            bool valor = false;

            if (!string.IsNullOrWhiteSpace(txtNombre.Text) && !string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                valor = true;
            }
            return valor;
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            
            

        }

        private void txtDireccion_Leave(object sender, EventArgs e)
        {
           
        }

        private void txtNombre_Validating(object sender, CancelEventArgs e)
        {
              e.Cancel = string.IsNullOrWhiteSpace(txtNombre.Text);
           
              error.SetError(txtNombre, "Este campo no puede quedar vacio"); 
        }

        private void txtNombre_Validated(object sender, EventArgs e)
        {
            error.SetError(txtNombre, string.Empty);
        }

        private void txtDireccion_Validated(object sender, EventArgs e)
        {
            error.SetError(txtDireccion, string.Empty);
        }

        private void txtDireccion_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = string.IsNullOrWhiteSpace(txtDireccion.Text);
            error.SetError(txtDireccion, "No puede dejar este campo vacio.");
        }

        private void txtSaldoInicial_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Limpiar(txtNombre, txtPais, txtDireccion, txtSaldoInicial, txtSaldoActual);
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
