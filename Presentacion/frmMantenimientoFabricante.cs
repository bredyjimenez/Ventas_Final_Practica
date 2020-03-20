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
    public partial class frmMantenimientoFabricante : Form
    {
        int ID = 0;
        ErrorProvider error;

        private static frmMantenimientoFabricante frmFabricanteS;

        public static frmMantenimientoFabricante frmFabricanteR
        {
            get
            {
                if (frmFabricanteS == null || frmFabricanteS.IsDisposed == true)
                    frmFabricanteS = new frmMantenimientoFabricante();
                return frmFabricanteS;
            }
            set
            {
                frmFabricanteS = value;
            }

        }
        public frmMantenimientoFabricante()
        {
            InitializeComponent();
            error = new ErrorProvider();
        }

        private void frmMantenimientoFabricante_Load(object sender, EventArgs e)
        {
            LlenarGrid();  
        }

        public void LlenarGrid()
        {
            FabricantesBL Obtener = new FabricantesBL();
            dgvFabricantes.DataSource = Obtener.ObtenerFabricantes();
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                FabricantesBL Insertar = new FabricantesBL();
                Fabricante Entidad = new Fabricante();

                Entidad.Nombre = txtNombre.Text;
                Entidad.Direccion = txtDireccion.Text;
                Entidad.Pais = txtPais.Text;

                Insertar.InsertarFabricantes(Entidad);
                MessageBox.Show("Registro agregado con exito", "Registro agregado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvFabricantes.Update();
                LlenarGrid();
                Limpiar(txtNombre, txtPais, txtDireccion);
            }
            else
            {
                MessageBox.Show("Existen campos que son obligatorios y se encuentran vacios.",
                            "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            FabricantesBL Actualizar = new FabricantesBL();
            Fabricante Entidad = new Fabricante();

            if (ID < 1)
            {
                MessageBox.Show("Debe seleccionar un registro valido antes de actualizar." +
                " Por favor seleccione un registro en la pestaña de busqueda que desea actualizar "
                  + "y vuelva a intentarlo.", "Error de eliminación",
                  MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                Entidad.ID_Fabricante = ID;
                Entidad.Nombre = txtNombre.Text;
                Entidad.Direccion = txtDireccion.Text;
                Entidad.Pais = txtPais.Text;

                Actualizar.ActualizarFabricantes(Entidad);
                MessageBox.Show("Registro Actualizado.", "Actualización", MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
                dgvFabricantes.Update();
                LlenarGrid();
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            FabricantesBL Eliminar = new FabricantesBL();
            Fabricante Entidad = new Fabricante();
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
                    Entidad.ID_Fabricante = ID;

                    Eliminar.EliminarFabricantes(Entidad);
                    MessageBox.Show("Registro eliminado con exito", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvFabricantes.Update();
                    LlenarGrid();
                    Limpiar(txtNombre, txtPais, txtDireccion);
                }
            }
        }

        private void dgvFabricantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dgvFabricantes.CurrentRow.Index;
            ID = Convert.ToInt32(dgvFabricantes.Rows[fila].Cells["ID_FABRICANTE"].Value);
            txtNombre.Text  = dgvFabricantes.Rows[fila].Cells["NOMB_FABRICANTE"].Value.ToString();
            txtDireccion.Text = dgvFabricantes.Rows[fila].Cells["DIRECCION"].Value.ToString();
            txtPais.Text = dgvFabricantes.Rows[fila].Cells["PAIS"].Value.ToString();
            
        }

        public bool validar()
        {
            bool valor = false;

            if (!string.IsNullOrWhiteSpace(txtNombre.Text) && 
                !string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                valor = true;
            }

            return valor;
        }

        private void txtNombre_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = string.IsNullOrWhiteSpace(txtNombre.Text);
            error.SetError(txtNombre, "No puede dejarse ese campo vacio.");
        }

        private void txtNombre_Validated(object sender, EventArgs e)
        {
            error.SetError(txtNombre, string.Empty);
        }

        private void txtDireccion_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = string.IsNullOrWhiteSpace(txtDireccion.Text);
            error.SetError(txtDireccion, "No puede dejarse ese campo vacio.");
        }

        private void txtDireccion_Validated(object sender, EventArgs e)
        {
            error.SetError(txtDireccion, string.Empty);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FabricantesBL Buscar = new FabricantesBL();

            if (rbNombre.Checked == true)
            {
                dgvFabricantes.DataSource = Buscar.BuscarFabricantes(txtBusqueda.Text,"Nombre");
            }
            else if (rbPais.Checked == true)
            {
                dgvFabricantes.DataSource = Buscar.BuscarFabricantes(txtBusqueda.Text,"Pais");
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Limpiar(txtNombre, txtPais, txtDireccion);
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
