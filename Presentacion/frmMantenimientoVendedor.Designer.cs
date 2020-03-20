namespace Presentacion
{
    partial class frmMantenimientoVendedor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoVendedor));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIDJefe = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtComision = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOficina = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rbTdInfo = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnBuscarCom = new System.Windows.Forms.Button();
            this.txtBusquedaCo = new System.Windows.Forms.TextBox();
            this.rbMayor = new System.Windows.Forms.RadioButton();
            this.rbMenor = new System.Windows.Forms.RadioButton();
            this.GrpBusq = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBusquedaCtlr = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbOficina = new System.Windows.Forms.RadioButton();
            this.rbExOficina = new System.Windows.Forms.RadioButton();
            this.rbNombre = new System.Windows.Forms.RadioButton();
            this.rbID = new System.Windows.Forms.RadioButton();
            this.dgvVendedor = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.GrpBusq.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendedor)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(485, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::Presentacion.Properties.Resources.new_document16;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(60, 22);
            this.toolStripButton1.Text = "&Nuevo";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::Presentacion.Properties.Resources._200_add;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(70, 22);
            this.toolStripButton2.Text = "&Agregar";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = global::Presentacion.Properties.Resources.refresh16;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(82, 22);
            this.toolStripButton3.Text = "&Actualizar";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = global::Presentacion.Properties.Resources.delete_square16_h;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(70, 22);
            this.toolStripButton4.Text = "&Eliminar";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(485, 369);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Khaki;
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(477, 340);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Mantenimiento";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Peru;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(215, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 66);
            this.panel1.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(218, 49);
            this.label5.TabIndex = 0;
            this.label5.Text = "&Vendedores";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Presentacion.Properties.Resources._3_cliente_icono_8594_128;
            this.pictureBox1.Location = new System.Drawing.Point(280, 91);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 142);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtIDJefe);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtComision);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtOficina);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Location = new System.Drawing.Point(2, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 235);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "&Datos del vendedor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "&ID Del Jefe";
            // 
            // txtIDJefe
            // 
            this.txtIDJefe.Location = new System.Drawing.Point(6, 201);
            this.txtIDJefe.Name = "txtIDJefe";
            this.txtIDJefe.Size = new System.Drawing.Size(60, 23);
            this.txtIDJefe.TabIndex = 3;
            this.txtIDJefe.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIDJefe_KeyPress);
            this.txtIDJefe.Validating += new System.ComponentModel.CancelEventHandler(this.txtIDJefe_Validating);
            this.txtIDJefe.Validated += new System.EventHandler(this.txtIDJefe_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "&% Comisión ";
            // 
            // txtComision
            // 
            this.txtComision.Location = new System.Drawing.Point(6, 148);
            this.txtComision.Name = "txtComision";
            this.txtComision.Size = new System.Drawing.Size(117, 23);
            this.txtComision.TabIndex = 2;
            this.txtComision.TextChanged += new System.EventHandler(this.txtComision_TextChanged);
            this.txtComision.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtComision_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "&Oficina";
            // 
            // txtOficina
            // 
            this.txtOficina.Location = new System.Drawing.Point(6, 88);
            this.txtOficina.Name = "txtOficina";
            this.txtOficina.Size = new System.Drawing.Size(117, 23);
            this.txtOficina.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "&Nombre ";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(6, 40);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(196, 23);
            this.txtNombre.TabIndex = 0;
            this.txtNombre.Validating += new System.ComponentModel.CancelEventHandler(this.txtNombre_Validating);
            this.txtNombre.Validated += new System.EventHandler(this.txtNombre_Validated);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Khaki;
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.GrpBusq);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.dgvVendedor);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(477, 340);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Busqueda";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rbTdInfo);
            this.groupBox5.Location = new System.Drawing.Point(235, 71);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(242, 68);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "&Varios filtros del vendedor:";
            // 
            // rbTdInfo
            // 
            this.rbTdInfo.AutoSize = true;
            this.rbTdInfo.Location = new System.Drawing.Point(6, 28);
            this.rbTdInfo.Name = "rbTdInfo";
            this.rbTdInfo.Size = new System.Drawing.Size(133, 20);
            this.rbTdInfo.TabIndex = 0;
            this.rbTdInfo.TabStop = true;
            this.rbTdInfo.Text = "&Toda la información";
            this.rbTdInfo.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnBuscarCom);
            this.groupBox4.Controls.Add(this.txtBusquedaCo);
            this.groupBox4.Controls.Add(this.rbMayor);
            this.groupBox4.Controls.Add(this.rbMenor);
            this.groupBox4.Location = new System.Drawing.Point(3, 99);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(165, 93);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "&Filtro de comisión";
            // 
            // btnBuscarCom
            // 
            this.btnBuscarCom.BackgroundImage = global::Presentacion.Properties.Resources.xmag;
            this.btnBuscarCom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscarCom.Location = new System.Drawing.Point(98, 41);
            this.btnBuscarCom.Name = "btnBuscarCom";
            this.btnBuscarCom.Size = new System.Drawing.Size(35, 23);
            this.btnBuscarCom.TabIndex = 6;
            this.btnBuscarCom.UseVisualStyleBackColor = true;
            this.btnBuscarCom.Click += new System.EventHandler(this.btnBuscarCom_Click);
            // 
            // txtBusquedaCo
            // 
            this.txtBusquedaCo.Location = new System.Drawing.Point(6, 43);
            this.txtBusquedaCo.Name = "txtBusquedaCo";
            this.txtBusquedaCo.Size = new System.Drawing.Size(86, 23);
            this.txtBusquedaCo.TabIndex = 5;
            // 
            // rbMayor
            // 
            this.rbMayor.AutoSize = true;
            this.rbMayor.Location = new System.Drawing.Point(79, 20);
            this.rbMayor.Name = "rbMayor";
            this.rbMayor.Size = new System.Drawing.Size(76, 20);
            this.rbMayor.TabIndex = 3;
            this.rbMayor.TabStop = true;
            this.rbMayor.Text = "&Mayor a:";
            this.rbMayor.UseVisualStyleBackColor = true;
            // 
            // rbMenor
            // 
            this.rbMenor.AutoSize = true;
            this.rbMenor.Location = new System.Drawing.Point(6, 20);
            this.rbMenor.Name = "rbMenor";
            this.rbMenor.Size = new System.Drawing.Size(76, 20);
            this.rbMenor.TabIndex = 2;
            this.rbMenor.TabStop = true;
            this.rbMenor.Text = "&Menor a:";
            this.rbMenor.UseVisualStyleBackColor = true;
            // 
            // GrpBusq
            // 
            this.GrpBusq.Controls.Add(this.btnBuscar);
            this.GrpBusq.Controls.Add(this.txtBusquedaCtlr);
            this.GrpBusq.Location = new System.Drawing.Point(196, 6);
            this.GrpBusq.Name = "GrpBusq";
            this.GrpBusq.Size = new System.Drawing.Size(253, 46);
            this.GrpBusq.TabIndex = 2;
            this.GrpBusq.TabStop = false;
            this.GrpBusq.Text = "&Control de busqueda";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackgroundImage = global::Presentacion.Properties.Resources.xmag;
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscar.Location = new System.Drawing.Point(204, 16);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(35, 23);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBusquedaCtlr
            // 
            this.txtBusquedaCtlr.Location = new System.Drawing.Point(6, 16);
            this.txtBusquedaCtlr.Name = "txtBusquedaCtlr";
            this.txtBusquedaCtlr.Size = new System.Drawing.Size(192, 23);
            this.txtBusquedaCtlr.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbOficina);
            this.groupBox2.Controls.Add(this.rbExOficina);
            this.groupBox2.Controls.Add(this.rbNombre);
            this.groupBox2.Controls.Add(this.rbID);
            this.groupBox2.Location = new System.Drawing.Point(3, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(187, 86);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "&Filtro";
            // 
            // rbOficina
            // 
            this.rbOficina.AutoSize = true;
            this.rbOficina.Location = new System.Drawing.Point(79, 54);
            this.rbOficina.Name = "rbOficina";
            this.rbOficina.Size = new System.Drawing.Size(65, 20);
            this.rbOficina.TabIndex = 5;
            this.rbOficina.TabStop = true;
            this.rbOficina.Text = "&Oficina";
            this.rbOficina.UseVisualStyleBackColor = true;
            // 
            // rbExOficina
            // 
            this.rbExOficina.AutoSize = true;
            this.rbExOficina.Location = new System.Drawing.Point(79, 19);
            this.rbExOficina.Name = "rbExOficina";
            this.rbExOficina.Size = new System.Drawing.Size(102, 20);
            this.rbExOficina.TabIndex = 4;
            this.rbExOficina.TabStop = true;
            this.rbExOficina.Text = "&Ex-tal oficina";
            this.rbExOficina.UseVisualStyleBackColor = true;
            // 
            // rbNombre
            // 
            this.rbNombre.AutoSize = true;
            this.rbNombre.Location = new System.Drawing.Point(3, 54);
            this.rbNombre.Name = "rbNombre";
            this.rbNombre.Size = new System.Drawing.Size(68, 20);
            this.rbNombre.TabIndex = 3;
            this.rbNombre.TabStop = true;
            this.rbNombre.Text = "&Nombre";
            this.rbNombre.UseVisualStyleBackColor = true;
            // 
            // rbID
            // 
            this.rbID.AutoSize = true;
            this.rbID.Location = new System.Drawing.Point(3, 19);
            this.rbID.Name = "rbID";
            this.rbID.Size = new System.Drawing.Size(40, 20);
            this.rbID.TabIndex = 2;
            this.rbID.TabStop = true;
            this.rbID.Text = "&ID";
            this.rbID.UseVisualStyleBackColor = true;
            // 
            // dgvVendedor
            // 
            this.dgvVendedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendedor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvVendedor.Location = new System.Drawing.Point(3, 194);
            this.dgvVendedor.Name = "dgvVendedor";
            this.dgvVendedor.Size = new System.Drawing.Size(471, 143);
            this.dgvVendedor.TabIndex = 0;
            this.dgvVendedor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVendedor_CellClick);
            // 
            // frmMantenimientoVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 394);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(501, 432);
            this.MinimumSize = new System.Drawing.Size(501, 432);
            this.Name = "frmMantenimientoVendedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vendedores";
            this.Load += new System.EventHandler(this.frmVendedor_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.GrpBusq.ResumeLayout(false);
            this.GrpBusq.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendedor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIDJefe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtComision;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOficina;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvVendedor;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rbTdInfo;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtBusquedaCo;
        private System.Windows.Forms.RadioButton rbMayor;
        private System.Windows.Forms.RadioButton rbMenor;
        private System.Windows.Forms.GroupBox GrpBusq;
        private System.Windows.Forms.TextBox txtBusquedaCtlr;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbOficina;
        private System.Windows.Forms.RadioButton rbExOficina;
        private System.Windows.Forms.RadioButton rbNombre;
        private System.Windows.Forms.RadioButton rbID;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnBuscarCom;
    }
}