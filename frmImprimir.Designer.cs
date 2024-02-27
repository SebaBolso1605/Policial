
namespace Policial
{
    partial class frmImprimir
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
            this.lblTituloFormulario = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.dgvSocios = new System.Windows.Forms.DataGridView();
            this.SocId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SocCI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SocNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SocApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CuotaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CuotaAAAAMM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CuotaFechaDesde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Imprimir = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CuotaFechaPaga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SocDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SocEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SocPrimerNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SocSegundoNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SocPrimerApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SocSegundoApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TCMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TCDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbAño = new System.Windows.Forms.ComboBox();
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.chkImprimir = new System.Windows.Forms.CheckBox();
            this.txtParametro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSocios)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTituloFormulario
            // 
            this.lblTituloFormulario.AutoSize = true;
            this.lblTituloFormulario.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloFormulario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.lblTituloFormulario.Location = new System.Drawing.Point(31, 9);
            this.lblTituloFormulario.Name = "lblTituloFormulario";
            this.lblTituloFormulario.Size = new System.Drawing.Size(261, 38);
            this.lblTituloFormulario.TabIndex = 137;
            this.lblTituloFormulario.Text = "Imprimir Cuotas";
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.ForeColor = System.Drawing.Color.White;
            this.btnVolver.Location = new System.Drawing.Point(503, 508);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(176, 29);
            this.btnVolver.TabIndex = 8;
            this.btnVolver.Text = "Limpiar";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // dgvSocios
            // 
            this.dgvSocios.AllowUserToAddRows = false;
            this.dgvSocios.AllowUserToDeleteRows = false;
            this.dgvSocios.AllowUserToOrderColumns = true;
            this.dgvSocios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSocios.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvSocios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSocios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SocId,
            this.SocCI,
            this.SocNombre,
            this.SocApellido,
            this.CuotaId,
            this.CuotaAAAAMM,
            this.Estado,
            this.CuotaFechaDesde,
            this.Imprimir,
            this.CuotaFechaPaga,
            this.SocDireccion,
            this.SocEmail,
            this.FechaIngreso,
            this.SocPrimerNombre,
            this.SocSegundoNombre,
            this.SocPrimerApellido,
            this.SocSegundoApellido,
            this.TCMonto,
            this.TCDescripcion});
            this.dgvSocios.Location = new System.Drawing.Point(33, 146);
            this.dgvSocios.Name = "dgvSocios";
            this.dgvSocios.RowHeadersVisible = false;
            this.dgvSocios.RowHeadersWidth = 51;
            this.dgvSocios.Size = new System.Drawing.Size(929, 343);
            this.dgvSocios.TabIndex = 6;
            // 
            // SocId
            // 
            this.SocId.HeaderText = "Socio";
            this.SocId.Name = "SocId";
            this.SocId.ReadOnly = true;
            // 
            // SocCI
            // 
            this.SocCI.HeaderText = "Cédula";
            this.SocCI.MinimumWidth = 6;
            this.SocCI.Name = "SocCI";
            this.SocCI.ReadOnly = true;
            // 
            // SocNombre
            // 
            this.SocNombre.HeaderText = "Nombre";
            this.SocNombre.MinimumWidth = 6;
            this.SocNombre.Name = "SocNombre";
            this.SocNombre.ReadOnly = true;
            // 
            // SocApellido
            // 
            this.SocApellido.HeaderText = "Apellido";
            this.SocApellido.Name = "SocApellido";
            this.SocApellido.ReadOnly = true;
            // 
            // CuotaId
            // 
            this.CuotaId.HeaderText = "Cuota";
            this.CuotaId.MinimumWidth = 6;
            this.CuotaId.Name = "CuotaId";
            this.CuotaId.ReadOnly = true;
            // 
            // CuotaAAAAMM
            // 
            this.CuotaAAAAMM.HeaderText = "Mes/Año";
            this.CuotaAAAAMM.MinimumWidth = 6;
            this.CuotaAAAAMM.Name = "CuotaAAAAMM";
            this.CuotaAAAAMM.ReadOnly = true;
            this.CuotaAAAAMM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CuotaAAAAMM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            // 
            // CuotaFechaDesde
            // 
            this.CuotaFechaDesde.HeaderText = "Fecha Emisión";
            this.CuotaFechaDesde.Name = "CuotaFechaDesde";
            // 
            // Imprimir
            // 
            this.Imprimir.HeaderText = "Imprimir";
            this.Imprimir.Name = "Imprimir";
            // 
            // CuotaFechaPaga
            // 
            this.CuotaFechaPaga.HeaderText = "CuotaFechaPaga";
            this.CuotaFechaPaga.Name = "CuotaFechaPaga";
            this.CuotaFechaPaga.Visible = false;
            // 
            // SocDireccion
            // 
            this.SocDireccion.HeaderText = "SocDireccion";
            this.SocDireccion.Name = "SocDireccion";
            this.SocDireccion.ReadOnly = true;
            this.SocDireccion.Visible = false;
            // 
            // SocEmail
            // 
            this.SocEmail.HeaderText = "Email";
            this.SocEmail.Name = "SocEmail";
            this.SocEmail.Visible = false;
            // 
            // FechaIngreso
            // 
            this.FechaIngreso.HeaderText = "Fecha de Ingreso";
            this.FechaIngreso.Name = "FechaIngreso";
            this.FechaIngreso.Visible = false;
            // 
            // SocPrimerNombre
            // 
            this.SocPrimerNombre.HeaderText = "SocPrimerNombre";
            this.SocPrimerNombre.Name = "SocPrimerNombre";
            this.SocPrimerNombre.Visible = false;
            // 
            // SocSegundoNombre
            // 
            this.SocSegundoNombre.HeaderText = "SocSegundoNombre";
            this.SocSegundoNombre.Name = "SocSegundoNombre";
            this.SocSegundoNombre.Visible = false;
            // 
            // SocPrimerApellido
            // 
            this.SocPrimerApellido.HeaderText = "SocPrimerApellido";
            this.SocPrimerApellido.Name = "SocPrimerApellido";
            this.SocPrimerApellido.Visible = false;
            // 
            // SocSegundoApellido
            // 
            this.SocSegundoApellido.HeaderText = "SocSegundoApellido";
            this.SocSegundoApellido.Name = "SocSegundoApellido";
            this.SocSegundoApellido.Visible = false;
            // 
            // TCMonto
            // 
            this.TCMonto.HeaderText = "TCMonto";
            this.TCMonto.Name = "TCMonto";
            this.TCMonto.Visible = false;
            // 
            // TCDescripcion
            // 
            this.TCDescripcion.HeaderText = "TCDescripcion";
            this.TCDescripcion.Name = "TCDescripcion";
            this.TCDescripcion.Visible = false;
            // 
            // cmbAño
            // 
            this.cmbAño.FormattingEnabled = true;
            this.cmbAño.Items.AddRange(new object[] {
            "2022",
            "2023",
            "2024",
            "2025"});
            this.cmbAño.Location = new System.Drawing.Point(212, 71);
            this.cmbAño.Name = "cmbAño";
            this.cmbAño.Size = new System.Drawing.Size(103, 21);
            this.cmbAño.TabIndex = 1;
            // 
            // cmbMes
            // 
            this.cmbMes.FormattingEnabled = true;
            this.cmbMes.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cmbMes.Location = new System.Drawing.Point(124, 71);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(73, 21);
            this.cmbMes.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(46, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 17);
            this.label6.TabIndex = 189;
            this.label6.Text = "Mes / Año";
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Location = new System.Drawing.Point(233, 508);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(176, 29);
            this.btnImprimir.TabIndex = 7;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(337, 68);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(198, 24);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Filtrar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.ForeColor = System.Drawing.Color.Black;
            this.checkBox1.Location = new System.Drawing.Point(555, 73);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(124, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "solo Cuotas Impagas";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // chkImprimir
            // 
            this.chkImprimir.AutoSize = true;
            this.chkImprimir.Checked = true;
            this.chkImprimir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkImprimir.ForeColor = System.Drawing.Color.Black;
            this.chkImprimir.Location = new System.Drawing.Point(843, 123);
            this.chkImprimir.Name = "chkImprimir";
            this.chkImprimir.Size = new System.Drawing.Size(85, 17);
            this.chkImprimir.TabIndex = 5;
            this.chkImprimir.Text = "Imprimir todo";
            this.chkImprimir.UseVisualStyleBackColor = true;
            this.chkImprimir.CheckedChanged += new System.EventHandler(this.chkImprimir_CheckedChanged);
            // 
            // txtParametro
            // 
            this.txtParametro.Location = new System.Drawing.Point(124, 109);
            this.txtParametro.Name = "txtParametro";
            this.txtParametro.Size = new System.Drawing.Size(191, 20);
            this.txtParametro.TabIndex = 2;
            this.txtParametro.TextChanged += new System.EventHandler(this.txtParametro_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(46, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 260;
            this.label1.Text = "Buscar";
            // 
            // frmImprimir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 605);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtParametro);
            this.Controls.Add(this.chkImprimir);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.cmbAño);
            this.Controls.Add(this.cmbMes);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblTituloFormulario);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.dgvSocios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmImprimir";
            this.Text = "frmImprimir";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSocios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTituloFormulario;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.DataGridView dgvSocios;
        private System.Windows.Forms.ComboBox cmbAño;
        private System.Windows.Forms.ComboBox cmbMes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox chkImprimir;
        private System.Windows.Forms.TextBox txtParametro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SocId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SocCI;
        private System.Windows.Forms.DataGridViewTextBoxColumn SocNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn SocApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn CuotaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CuotaAAAAMM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn CuotaFechaDesde;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Imprimir;
        private System.Windows.Forms.DataGridViewTextBoxColumn CuotaFechaPaga;
        private System.Windows.Forms.DataGridViewTextBoxColumn SocDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn SocEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn SocPrimerNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn SocSegundoNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn SocPrimerApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn SocSegundoApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn TCMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn TCDescripcion;
    }
}