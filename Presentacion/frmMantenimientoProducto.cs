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
    public partial class frmMantenimientoProducto : Form, IComunicacionFabricante
    {
        int ID = 0;
        ErrorProvider error;

        private static frmMantenimientoProducto frmProductoS;

        public static frmMantenimientoProducto frmProductosR
        {
            get
            {
                if (frmProductoS == null || frmProductoS.IsDisposed == true)
                    frmProductoS = new frmMantenimientoProducto();
                return frmProductoS;
            }

            set
            {
                frmProductoS = value;
            }
        }
        public frmMantenimientoProducto()
        {
            InitializeComponent();
            error = new ErrorProvider();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void frmMantenimientoProducto_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        public void LlenarGrid()
        {
            ProductosBL Cargar = new ProductosBL();
            dgvProductos.DataSource = Cargar.LlenarProductos();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                ProductosBL Insertar = new ProductosBL();
                Productos Entidad = new Productos();
                if (Insertar.ComprobarForanea(Convert.ToInt32(txtIdFab.Text)))
                {
                    Entidad.Descripcion = txtDesc.Text;
                    Entidad.ID_Fabricante = Convert.ToInt32(txtIdFab.Text);
                    Entidad.Costo = float.Parse(txtCosto.Text);
                    Entidad.Precio = float.Parse(txtPrecio.Text);
                    Insertar.InsertarProductos(Entidad);
                    MessageBox.Show("Registro agregado con exito.", "Agregado", MessageBoxButtons.OK,
                     MessageBoxIcon.Information);
                    dgvProductos.Update();
                    LlenarGrid();
                    Limpiar(txtDesc, txtIdFab, txtPrecio, txtCosto);
                }
                else
                {
                    MessageBox.Show("No existe tal fabricante. Por favor coloque un ID de fabricante valido.",
                        "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Existen campos que son obligatorios y se encuentran vacios.",
                            "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ProductosBL Actualizar = new ProductosBL();
            Productos Entidad = new Productos();

            if (ID < 1)
            {
                MessageBox.Show("Debe seleccionar un registro valido antes de actualizar." +
                " Por favor seleccione un registro en la pestaña de busqueda que desea actualizar "
                  + "y vuelva a intentarlo.", "Error de eliminación",
                  MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {

                Entidad.ID_Producto = ID;
                Entidad.Descripcion = txtDesc.Text;
                Entidad.ID_Fabricante = Convert.ToInt32(txtIdFab.Text);
                Entidad.Costo = float.Parse(txtCosto.Text);
                Entidad.Precio = float.Parse(txtPrecio.Text);
                Actualizar.ActualizarProductos(Entidad);
                MessageBox.Show("Registro Actualizado.", "Actualización", MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
                dgvProductos.Update();
                LlenarGrid();
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
                DialogResult resultado = MessageBox.Show("Realmente desea eliminar el registro de descripción: " + this.txtDesc.Text + "?",
                                  "¿Desea eliminar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    ProductosBL Eliminar = new ProductosBL();
                    Productos Entidad = new Productos();
                    Entidad.ID_Producto = ID;
                    Eliminar.EliminarProductos(Entidad);
                    MessageBox.Show("Registro eliminado con exito", "Información",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvProductos.Update();
                    LlenarGrid();
                    Limpiar(txtDesc, txtIdFab, txtPrecio, txtCosto);
                }
            }
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dgvProductos.CurrentRow.Index;
            ID = Convert.ToInt32(dgvProductos.Rows[fila].Cells["ID_PRODUCTO"].Value);
            txtDesc.Text = dgvProductos.Rows[fila].Cells["DESC_PRODUCTO"].Value.ToString();
            txtCosto.Text = dgvProductos.Rows[fila].Cells["COSTO"].Value.ToString();
            txtIdFab.Text = dgvProductos.Rows[fila].Cells["ID_FABRICANTE"].Value.ToString();
            txtPrecio.Text = dgvProductos.Rows[fila].Cells["PRECIO"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmSeleccionFabricantes.frmSelFabricantesS.Show(this);
            
        }

        public void IdFabricante(string id)
        {
            txtIdFab.Text = id;
           
        }

        public bool validar()
        {
            bool valor = false;

            if (!string.IsNullOrWhiteSpace(txtDesc.Text) && 
                !string.IsNullOrWhiteSpace(txtIdFab.Text))
            {
                valor = true;
            }

            return valor;
        }

        private void txtDesc_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = string.IsNullOrWhiteSpace(txtDesc.Text);
            error.SetError(txtDesc, "No se puede dejar este campo vacio.");
        }

        private void txtDesc_Validated(object sender, EventArgs e)
        {
            error.SetError(txtDesc, string.Empty);
        }

        private void txtIdFab_Validating(object sender, CancelEventArgs e)
        {
           
        }

        private void txtIdFab_Validated(object sender, EventArgs e)
        {
            //error.SetError(txtIdFab, string.Empty);
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            ProductosBL Buscar = new ProductosBL();

            if (rbDescripcion.Checked)
            {
                this.dgvProductos.DataSource = 
                    Buscar.BuscarProductos(txtBusqueda.Text, "Descripcion");
            }
            else if (rbIdFab.Checked)
            {
                this.dgvProductos.DataSource =
                    Buscar.BuscarProductos(txtBusqueda.Text, "IDFab");
            }

        }

        private void txtIdFab_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtIdFab_KeyPress(object sender, KeyPressEventArgs e)
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
            Limpiar(txtDesc, txtIdFab, txtPrecio, txtCosto);
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
