
namespace Policial
{
    partial class frmRecibos
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
            this.components = new System.ComponentModel.Container();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label17 = new System.Windows.Forms.Label();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpVencimiento = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpEmision = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtParametro = new System.Windows.Forms.TextBox();
            this.lblTituloFormulario = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.dgvSocios = new System.Windows.Forms.DataGridView();
            this.Socio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SocCI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SocPrimerNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SocPrimerApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoCuota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SocDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SocTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SocCelular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SocActivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Generar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chkTodos = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSocios)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(314, 119);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(16, 21);
            this.label17.TabIndex = 273;
            this.label17.Text = "*";
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.btnGenerar.FlatAppearance.BorderSize = 0;
            this.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.ForeColor = System.Drawing.Color.White;
            this.btnGenerar.Location = new System.Drawing.Point(225, 567);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(176, 29);
            this.btnGenerar.TabIndex = 270;
            this.btnGenerar.Text = "Generar Cuotas";
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(960, 123);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(16, 21);
            this.label12.TabIndex = 269;
            this.label12.Text = "*";
            // 
            // dtpVencimiento
            // 
            this.dtpVencimiento.Location = new System.Drawing.Point(760, 121);
            this.dtpVencimiento.Name = "dtpVencimiento";
            this.dtpVencimiento.Size = new System.Drawing.Size(194, 20);
            this.dtpVencimiento.TabIndex = 268;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(673, 123);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 17);
            this.label13.TabIndex = 267;
            this.label13.Text = "Vencimiento";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(632, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(16, 21);
            this.label9.TabIndex = 266;
            this.label9.Text = "*";
            // 
            // dtpEmision
            // 
            this.dtpEmision.Location = new System.Drawing.Point(432, 120);
            this.dtpEmision.Name = "dtpEmision";
            this.dtpEmision.Size = new System.Drawing.Size(194, 20);
            this.dtpEmision.TabIndex = 265;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(336, 123);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 17);
            this.label10.TabIndex = 264;
            this.label10.Text = "Fecha Emisión";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(35, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 17);
            this.label8.TabIndex = 263;
            this.label8.Text = "Filtrar Socio";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "2022",
            "2023",
            "2024",
            "2025"});
            this.comboBox1.Location = new System.Drawing.Point(192, 120);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(116, 21);
            this.comboBox1.TabIndex = 262;
            this.comboBox1.Click += new System.EventHandler(this.comboBox1_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
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
            this.comboBox2.Location = new System.Drawing.Point(113, 120);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(73, 21);
            this.comboBox2.TabIndex = 261;
            this.comboBox2.Click += new System.EventHandler(this.comboBox2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(35, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 17);
            this.label5.TabIndex = 260;
            this.label5.Text = "Mes / Año";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.ForeColor = System.Drawing.Color.Black;
            this.checkBox1.Location = new System.Drawing.Point(352, 81);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(117, 17);
            this.checkBox1.TabIndex = 259;
            this.checkBox1.Text = "solo Socios activos";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // txtParametro
            // 
            this.txtParametro.Location = new System.Drawing.Point(113, 78);
            this.txtParametro.Name = "txtParametro";
            this.txtParametro.Size = new System.Drawing.Size(217, 20);
            this.txtParametro.TabIndex = 258;
            this.txtParametro.TextChanged += new System.EventHandler(this.txtParametro_TextChanged);
            // 
            // lblTituloFormulario
            // 
            this.lblTituloFormulario.AutoSize = true;
            this.lblTituloFormulario.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloFormulario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.lblTituloFormulario.Location = new System.Drawing.Point(29, 20);
            this.lblTituloFormulario.Name = "lblTituloFormulario";
            this.lblTituloFormulario.Size = new System.Drawing.Size(262, 38);
            this.lblTituloFormulario.TabIndex = 257;
            this.lblTituloFormulario.Text = "Generar Cuotas";
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.ForeColor = System.Drawing.Color.White;
            this.btnVolver.Location = new System.Drawing.Point(536, 567);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(176, 29);
            this.btnVolver.TabIndex = 256;
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
            this.Socio,
            this.SocCI,
            this.SocPrimerNombre,
            this.SocPrimerApellido,
            this.TipoCuota,
            this.SocDireccion,
            this.SocTel,
            this.SocCelular,
            this.SocActivo,
            this.Generar});
            this.dgvSocios.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dgvSocios.Location = new System.Drawing.Point(12, 186);
            this.dgvSocios.Name = "dgvSocios";
            this.dgvSocios.RowHeadersVisible = false;
            this.dgvSocios.RowHeadersWidth = 51;
            this.dgvSocios.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvSocios.Size = new System.Drawing.Size(1021, 360);
            this.dgvSocios.TabIndex = 255;
            // 
            // Socio
            // 
            this.Socio.HeaderText = "Socio";
            this.Socio.Name = "Socio";
            this.Socio.ReadOnly = true;
            // 
            // SocCI
            // 
            this.SocCI.HeaderText = "Cédula";
            this.SocCI.MinimumWidth = 6;
            this.SocCI.Name = "SocCI";
            this.SocCI.ReadOnly = true;
            // 
            // SocPrimerNombre
            // 
            this.SocPrimerNombre.HeaderText = "Nombre";
            this.SocPrimerNombre.MinimumWidth = 6;
            this.SocPrimerNombre.Name = "SocPrimerNombre";
            this.SocPrimerNombre.ReadOnly = true;
            // 
            // SocPrimerApellido
            // 
            this.SocPrimerApellido.HeaderText = "Apellido";
            this.SocPrimerApellido.Name = "SocPrimerApellido";
            this.SocPrimerApellido.ReadOnly = true;
            // 
            // TipoCuota
            // 
            this.TipoCuota.HeaderText = "Tipo de Cuota";
            this.TipoCuota.Name = "TipoCuota";
            // 
            // SocDireccion
            // 
            this.SocDireccion.HeaderText = "Dirección";
            this.SocDireccion.MinimumWidth = 6;
            this.SocDireccion.Name = "SocDireccion";
            this.SocDireccion.ReadOnly = true;
            // 
            // SocTel
            // 
            this.SocTel.HeaderText = "Teléfono";
            this.SocTel.MinimumWidth = 6;
            this.SocTel.Name = "SocTel";
            this.SocTel.ReadOnly = true;
            this.SocTel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SocTel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SocCelular
            // 
            this.SocCelular.HeaderText = "Celular";
            this.SocCelular.Name = "SocCelular";
            this.SocCelular.ReadOnly = true;
            // 
            // SocActivo
            // 
            this.SocActivo.HeaderText = "Estado";
            this.SocActivo.Name = "SocActivo";
            this.SocActivo.ReadOnly = true;
            // 
            // Generar
            // 
            this.Generar.HeaderText = "Generar";
            this.Generar.Name = "Generar";
            this.Generar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // chkTodos
            // 
            this.chkTodos.AutoSize = true;
            this.chkTodos.Checked = true;
            this.chkTodos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTodos.ForeColor = System.Drawing.Color.Black;
            this.chkTodos.Location = new System.Drawing.Point(932, 163);
            this.chkTodos.Name = "chkTodos";
            this.chkTodos.Size = new System.Drawing.Size(99, 17);
            this.chkTodos.TabIndex = 274;
            this.chkTodos.Text = "marcar todos";
            this.chkTodos.UseVisualStyleBackColor = true;
            this.chkTodos.CheckedChanged += new System.EventHandler(this.chkTodos_CheckedChanged);
            // 
            // frmRecibos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 656);
            this.Controls.Add(this.chkTodos);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dtpVencimiento);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtpEmision);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.txtParametro);
            this.Controls.Add(this.lblTituloFormulario);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.dgvSocios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRecibos";
            this.Text = "Cuotas Socios";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSocios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtpVencimiento;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpEmision;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox txtParametro;
        private System.Windows.Forms.Label lblTituloFormulario;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.DataGridView dgvSocios;
        private System.Windows.Forms.DataGridViewTextBoxColumn Socio;
        private System.Windows.Forms.DataGridViewTextBoxColumn SocCI;
        private System.Windows.Forms.DataGridViewTextBoxColumn SocPrimerNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn SocPrimerApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoCuota;
        private System.Windows.Forms.DataGridViewTextBoxColumn SocDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn SocTel;
        private System.Windows.Forms.DataGridViewTextBoxColumn SocCelular;
        private System.Windows.Forms.DataGridViewTextBoxColumn SocActivo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Generar;
        private System.Windows.Forms.CheckBox chkTodos;
    }
}