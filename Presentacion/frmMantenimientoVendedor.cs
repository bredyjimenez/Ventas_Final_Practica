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
    public partial class frmMantenimientoVendedor : Form
    {
        int ID = 0;
        ErrorProvider error;

        private static frmMantenimientoVendedor frmVendedorS;

        public static frmMantenimientoVendedor frmVendedorR
        {
            get
            {
                if (frmVendedorS == null || frmVendedorS.IsDisposed == true)
                    frmVendedorS = new frmMantenimientoVendedor();
                return frmVendedorS;
            }

            set
            {
                frmVendedorS = value;
            }

        }

        public frmMantenimientoVendedor()
        {
            InitializeComponent();
            error = new ErrorProvider();
        }

        private void frmVendedor_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        public void LlenarGrid()
        {
            VendedoresBL Obtener = new VendedoresBL();

            dgvVendedor.DataSource = Obtener.ObtenerVendedores();

        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            VendedoresBL Insertar = new VendedoresBL();

            Vendedores Entidad = new Vendedores();
            
            if (Validar())
            {
               if (Insertar.ComprobarForaneas(Convert.ToInt32(txtIDJefe.Text)))
               {
                Entidad.Nombre = txtNombre.Text;
                Entidad.Oficina = txtOficina.Text;
                Entidad.IDJefe = Convert.ToInt32(txtIDJefe.Text);
                Entidad.Comision = float.Parse(txtComision.Text);
                Insertar.InsertarVendedores(Entidad);
                dgvVendedor.Update();
                LlenarGrid();
                MessageBox.Show("Registro agregado con exito.", "Agregado", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Limpiar(txtNombre, txtOficina, txtComision, txtIDJefe);
               }
               else
               {
                    MessageBox.Show("El jefe indicado no existe.", "Error de validación", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
               }
            }
            else
            {
                MessageBox.Show("Hay campos que son obligatorios que se encuentran vacios.", "Error de validación", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            VendedoresBL Eliminar = new VendedoresBL();
            Vendedores Entidad = new Vendedores();
            if (ID < 1)
            {
                MessageBox.Show("Debe seleccionar un registro valido antes de eliminar." +
                " Por favor seleccione un registro en la pestaña de busqueda que desea eliminar "
                  + "y vuelva a intentarlo.", "Error de eliminación",
                  MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                DialogResult resultado = MessageBox.Show("¿Realmente desea eliminar el registro de nombre: " + txtNombre.Text + "?",
                                  "¿Desea eliminar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                 if (resultado == DialogResult.Yes)
                 {
                     Entidad.ID = ID;
                     Eliminar.EliminarVendedores(Entidad);
                     MessageBox.Show("Registro eliminado con exito", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                     dgvVendedor.Update();
                     LlenarGrid();
                     Limpiar(txtNombre, txtOficina, txtComision, txtIDJefe);
                 }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            VendedoresBL Actualizar = new VendedoresBL();

            Vendedores Entidad = new Vendedores();
            if (ID < 1)
            {
                MessageBox.Show("Debe seleccionar un registro valido antes de actualizar." +
                " Por favor seleccione un registro en la pestaña de busqueda que desea actualizar "
                  + "y vuelva a intentarlo.", "Error de eliminación",
                  MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                Entidad.ID = ID;
                Entidad.Nombre = txtNombre.Text;
                Entidad.Oficina = txtOficina.Text;
                Entidad.IDJefe = Convert.ToInt32(txtIDJefe.Text);
                Entidad.Comision = float.Parse(txtComision.Text);
                Actualizar.ActualizarVendedores(Entidad);
                MessageBox.Show("Registro Actualizado.", "Actualización", MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
                dgvVendedor.Update();
                LlenarGrid();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            VendedoresBL buscar = new VendedoresBL();

            if (rbID.Checked == true)
            {
                this.dgvVendedor.DataSource = 
                    buscar.BuscarVendedores(txtBusquedaCtlr.Text, "ID");
            }
            else if (rbNombre.Checked == true)
            {
                this.dgvVendedor.DataSource =
                    buscar.BuscarVendedores(txtBusquedaCtlr.Text, "Nombre");
            }
            else if (rbOficina.Checked == true)
            {
                this.dgvVendedor.DataSource = 
                    buscar.BuscarVendedores(txtBusquedaCtlr.Text, "Oficina");
            }
            else if (rbExOficina.Checked == true)
            {
               this.dgvVendedor.DataSource = 
                   buscar.BuscarVendedores( txtBusquedaCtlr.Text, "Ex-Oficina");
            }
            else if (rbTdInfo.Checked)
            {
                this.dgvVendedor.DataSource =
                  buscar.BuscarVendedores(txtBusquedaCtlr.Text, "Td-Info");
            }
        }

        private void btnBuscarCom_Click(object sender, EventArgs e)
        {
            VendedoresBL buscar = new VendedoresBL();

            if (rbMayor.Checked == true)
            {
                this.dgvVendedor.DataSource =
                    buscar.BuscarVendedores(txtBusquedaCo.Text, "Mayor");
            }
            else if (rbMenor.Checked == true)
            {
                this.dgvVendedor.DataSource =
                   buscar.BuscarVendedores(txtBusquedaCo.Text, "Menor");
            }
        }

        private void dgvVendedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dgvVendedor.CurrentRow.Index;

            ID = Convert.ToInt32(dgvVendedor.Rows[fila].Cells["ID_VENDEDOR"].Value);
            txtNombre.Text = dgvVendedor.Rows[fila].Cells["NOMB_VENDEDOR"].Value.ToString();
            txtOficina.Text = dgvVendedor.Rows[fila].Cells["OFICINA"].Value.ToString();
            txtComision.Text = dgvVendedor.Rows[fila].Cells["COMISION"].Value.ToString();
            txtIDJefe.Text = dgvVendedor.Rows[fila].Cells["ID_JEFE"].Value.ToString();
        }

        public bool Validar()
        {
            bool valor = false;

            if (!string.IsNullOrWhiteSpace(txtNombre.Text) && 
                !string.IsNullOrWhiteSpace(txtIDJefe.Text))
            {
                valor = true;
            }
            return valor;
        }

        private void txtNombre_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = string.IsNullOrWhiteSpace(txtNombre.Text);
            error.SetError(txtNombre, "Este campo no se puede quedar vacio");
        }

        private void txtNombre_Validated(object sender, EventArgs e)
        {
            error.SetError(txtNombre,string.Empty);
        }

        private void txtIDJefe_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = string.IsNullOrWhiteSpace(txtIDJefe.Text);
            error.SetError(txtIDJefe, "Este campo no se puede quedar vacio");
        }

        private void txtIDJefe_Validated(object sender, EventArgs e)
        {
            
            error.SetError(txtIDJefe, string.Empty);
        }

        private void txtComision_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtComision_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtIDJefe_KeyPress(object sender, KeyPressEventArgs e)
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
            Limpiar(txtNombre, txtOficina, txtComision, txtIDJefe);
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
