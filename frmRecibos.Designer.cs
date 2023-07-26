
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
            this.tabGenerales = new System.Windows.Forms.TabPage();
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
            this.tabindividual = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.cmbAño = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpFEchaCuotaPaga = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.rbtPaga = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSocCI = new System.Windows.Forms.TextBox();
            this.txtNFId = new System.Windows.Forms.TextBox();
            this.txtNombreSocNF = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSocIdNF = new System.Windows.Forms.TextBox();
            this.btnBuscarNF = new System.Windows.Forms.Button();
            this.txtBuscarCuota = new System.Windows.Forms.TextBox();
            this.dgvSociosNF = new System.Windows.Forms.DataGridView();
            this.SocId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CuotaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CuotaFechaDesde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MesAño = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaPaga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Imprimir = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label22 = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancelarNF = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuardarNF = new System.Windows.Forms.Button();
            this.tabModifcar = new System.Windows.Forms.TabControl();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.Socio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SocCI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SocPrimerNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SocPrimerApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SocDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SocTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SocCelular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SocActivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Generar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TipoCuota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.tabGenerales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSocios)).BeginInit();
            this.tabindividual.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSociosNF)).BeginInit();
            this.tabModifcar.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // tabGenerales
            // 
            this.tabGenerales.BackColor = System.Drawing.SystemColors.Control;
            this.tabGenerales.Controls.Add(this.label17);
            this.tabGenerales.Controls.Add(this.comboBox3);
            this.tabGenerales.Controls.Add(this.label14);
            this.tabGenerales.Controls.Add(this.btnGenerar);
            this.tabGenerales.Controls.Add(this.label12);
            this.tabGenerales.Controls.Add(this.dtpVencimiento);
            this.tabGenerales.Controls.Add(this.label13);
            this.tabGenerales.Controls.Add(this.label9);
            this.tabGenerales.Controls.Add(this.dtpEmision);
            this.tabGenerales.Controls.Add(this.label10);
            this.tabGenerales.Controls.Add(this.label8);
            this.tabGenerales.Controls.Add(this.comboBox1);
            this.tabGenerales.Controls.Add(this.comboBox2);
            this.tabGenerales.Controls.Add(this.label5);
            this.tabGenerales.Controls.Add(this.checkBox1);
            this.tabGenerales.Controls.Add(this.txtParametro);
            this.tabGenerales.Controls.Add(this.lblTituloFormulario);
            this.tabGenerales.Controls.Add(this.btnVolver);
            this.tabGenerales.Controls.Add(this.dgvSocios);
            this.tabGenerales.Location = new System.Drawing.Point(4, 25);
            this.tabGenerales.Name = "tabGenerales";
            this.tabGenerales.Padding = new System.Windows.Forms.Padding(3);
            this.tabGenerales.Size = new System.Drawing.Size(1043, 520);
            this.tabGenerales.TabIndex = 2;
            this.tabGenerales.Text = "Generar Cuotas Generales";
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.btnGenerar.FlatAppearance.BorderSize = 0;
            this.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.ForeColor = System.Drawing.Color.White;
            this.btnGenerar.Location = new System.Drawing.Point(280, 483);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(176, 29);
            this.btnGenerar.TabIndex = 226;
            this.btnGenerar.Text = "Generar Cuotas";
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(821, 129);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(16, 21);
            this.label12.TabIndex = 225;
            this.label12.Text = "*";
            // 
            // dtpVencimiento
            // 
            this.dtpVencimiento.Location = new System.Drawing.Point(532, 126);
            this.dtpVencimiento.Name = "dtpVencimiento";
            this.dtpVencimiento.Size = new System.Drawing.Size(283, 21);
            this.dtpVencimiento.TabIndex = 224;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(428, 129);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 17);
            this.label13.TabIndex = 223;
            this.label13.Text = "Vencimiento";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(352, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(16, 21);
            this.label9.TabIndex = 222;
            this.label9.Text = "*";
            // 
            // dtpEmision
            // 
            this.dtpEmision.Location = new System.Drawing.Point(129, 126);
            this.dtpEmision.Name = "dtpEmision";
            this.dtpEmision.Size = new System.Drawing.Size(217, 21);
            this.dtpEmision.TabIndex = 221;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(25, 129);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 17);
            this.label10.TabIndex = 220;
            this.label10.Text = "Fecha Emisión";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(25, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 17);
            this.label8.TabIndex = 195;
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
            this.comboBox1.Location = new System.Drawing.Point(208, 92);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(138, 24);
            this.comboBox1.TabIndex = 194;
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
            this.comboBox2.Location = new System.Drawing.Point(129, 92);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(73, 24);
            this.comboBox2.TabIndex = 193;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(25, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 17);
            this.label5.TabIndex = 192;
            this.label5.Text = "Mes / Año";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.ForeColor = System.Drawing.Color.Black;
            this.checkBox1.Location = new System.Drawing.Point(431, 68);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(126, 20);
            this.checkBox1.TabIndex = 141;
            this.checkBox1.Text = "solo Socios activos";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // txtParametro
            // 
            this.txtParametro.Location = new System.Drawing.Point(129, 66);
            this.txtParametro.Name = "txtParametro";
            this.txtParametro.Size = new System.Drawing.Size(217, 21);
            this.txtParametro.TabIndex = 140;
            // 
            // lblTituloFormulario
            // 
            this.lblTituloFormulario.AutoSize = true;
            this.lblTituloFormulario.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloFormulario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.lblTituloFormulario.Location = new System.Drawing.Point(21, 16);
            this.lblTituloFormulario.Name = "lblTituloFormulario";
            this.lblTituloFormulario.Size = new System.Drawing.Size(409, 38);
            this.lblTituloFormulario.TabIndex = 138;
            this.lblTituloFormulario.Text = "Generar Cuota Individual";
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.ForeColor = System.Drawing.Color.White;
            this.btnVolver.Location = new System.Drawing.Point(509, 483);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(176, 29);
            this.btnVolver.TabIndex = 137;
            this.btnVolver.Text = "Limpiar";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click_2);
            // 
            // dgvSocios
            // 
            this.dgvSocios.AllowUserToAddRows = false;
            this.dgvSocios.AllowUserToDeleteRows = false;
            this.dgvSocios.AllowUserToOrderColumns = true;
            this.dgvSocios.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvSocios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSocios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Socio,
            this.SocCI,
            this.SocPrimerNombre,
            this.SocPrimerApellido,
            this.SocDireccion,
            this.SocTel,
            this.SocCelular,
            this.SocActivo,
            this.Generar,
            this.TipoCuota});
            this.dgvSocios.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dgvSocios.Location = new System.Drawing.Point(28, 177);
            this.dgvSocios.Name = "dgvSocios";
            this.dgvSocios.RowHeadersVisible = false;
            this.dgvSocios.RowHeadersWidth = 51;
            this.dgvSocios.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvSocios.Size = new System.Drawing.Size(987, 283);
            this.dgvSocios.TabIndex = 136;
            // 
            // tabindividual
            // 
            this.tabindividual.BackColor = System.Drawing.SystemColors.Control;
            this.tabindividual.Controls.Add(this.label7);
            this.tabindividual.Controls.Add(this.cmbCategoria);
            this.tabindividual.Controls.Add(this.cmbAño);
            this.tabindividual.Controls.Add(this.groupBox1);
            this.tabindividual.Controls.Add(this.cmbMes);
            this.tabindividual.Controls.Add(this.rbtPaga);
            this.tabindividual.Controls.Add(this.label6);
            this.tabindividual.Controls.Add(this.txtSocCI);
            this.tabindividual.Controls.Add(this.txtNFId);
            this.tabindividual.Controls.Add(this.txtNombreSocNF);
            this.tabindividual.Controls.Add(this.label2);
            this.tabindividual.Controls.Add(this.txtSocIdNF);
            this.tabindividual.Controls.Add(this.btnBuscarNF);
            this.tabindividual.Controls.Add(this.txtBuscarCuota);
            this.tabindividual.Controls.Add(this.dgvSociosNF);
            this.tabindividual.Controls.Add(this.label22);
            this.tabindividual.Controls.Add(this.dtpDesde);
            this.tabindividual.Controls.Add(this.label16);
            this.tabindividual.Controls.Add(this.label15);
            this.tabindividual.Controls.Add(this.label3);
            this.tabindividual.Controls.Add(this.btnCancelarNF);
            this.tabindividual.Controls.Add(this.label1);
            this.tabindividual.Controls.Add(this.btnGuardarNF);
            this.tabindividual.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabindividual.Location = new System.Drawing.Point(4, 25);
            this.tabindividual.Name = "tabindividual";
            this.tabindividual.Padding = new System.Windows.Forms.Padding(3);
            this.tabindividual.Size = new System.Drawing.Size(1043, 520);
            this.tabindividual.TabIndex = 1;
            this.tabindividual.Text = "Generar Cuota Individual";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(381, 247);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 21);
            this.label7.TabIndex = 234;
            this.label7.Text = "*";
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.Enabled = false;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(175, 180);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(283, 25);
            this.cmbCategoria.TabIndex = 232;
            // 
            // cmbAño
            // 
            this.cmbAño.FormattingEnabled = true;
            this.cmbAño.Items.AddRange(new object[] {
            "2022",
            "2023",
            "2024",
            "2025"});
            this.cmbAño.Location = new System.Drawing.Point(254, 247);
            this.cmbAño.Name = "cmbAño";
            this.cmbAño.Size = new System.Drawing.Size(121, 25);
            this.cmbAño.TabIndex = 233;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpFEchaCuotaPaga);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(500, 213);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 62);
            this.groupBox1.TabIndex = 230;
            this.groupBox1.TabStop = false;
            // 
            // dtpFEchaCuotaPaga
            // 
            this.dtpFEchaCuotaPaga.Location = new System.Drawing.Point(109, 19);
            this.dtpFEchaCuotaPaga.Name = "dtpFEchaCuotaPaga";
            this.dtpFEchaCuotaPaga.Size = new System.Drawing.Size(200, 23);
            this.dtpFEchaCuotaPaga.TabIndex = 183;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(17, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 17);
            this.label4.TabIndex = 184;
            this.label4.Text = "Fecha Pago";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(315, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 21);
            this.label11.TabIndex = 159;
            this.label11.Text = "*";
            // 
            // cmbMes
            // 
            this.cmbMes.FormattingEnabled = true;
            this.cmbMes.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cmbMes.Location = new System.Drawing.Point(175, 247);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(73, 25);
            this.cmbMes.TabIndex = 231;
            // 
            // rbtPaga
            // 
            this.rbtPaga.AutoSize = true;
            this.rbtPaga.Location = new System.Drawing.Point(500, 184);
            this.rbtPaga.Name = "rbtPaga";
            this.rbtPaga.Size = new System.Drawing.Size(107, 21);
            this.rbtPaga.TabIndex = 228;
            this.rbtPaga.TabStop = true;
            this.rbtPaga.Text = "Cuota Paga";
            this.rbtPaga.UseVisualStyleBackColor = true;
            this.rbtPaga.CheckedChanged += new System.EventHandler(this.rbtPaga_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(31, 247);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 17);
            this.label6.TabIndex = 229;
            this.label6.Text = "Mes / Año";
            // 
            // txtSocCI
            // 
            this.txtSocCI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSocCI.Enabled = false;
            this.txtSocCI.Location = new System.Drawing.Point(653, 29);
            this.txtSocCI.Name = "txtSocCI";
            this.txtSocCI.Size = new System.Drawing.Size(28, 23);
            this.txtSocCI.TabIndex = 227;
            this.txtSocCI.Visible = false;
            // 
            // txtNFId
            // 
            this.txtNFId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNFId.Enabled = false;
            this.txtNFId.Location = new System.Drawing.Point(585, 30);
            this.txtNFId.Name = "txtNFId";
            this.txtNFId.Size = new System.Drawing.Size(28, 23);
            this.txtNFId.TabIndex = 226;
            this.txtNFId.Visible = false;
            // 
            // txtNombreSocNF
            // 
            this.txtNombreSocNF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombreSocNF.Enabled = false;
            this.txtNombreSocNF.Location = new System.Drawing.Point(252, 131);
            this.txtNombreSocNF.Name = "txtNombreSocNF";
            this.txtNombreSocNF.Size = new System.Drawing.Size(206, 23);
            this.txtNombreSocNF.TabIndex = 225;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(28, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 224;
            this.label2.Text = "Datos Socio";
            // 
            // txtSocIdNF
            // 
            this.txtSocIdNF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSocIdNF.Enabled = false;
            this.txtSocIdNF.Location = new System.Drawing.Point(175, 131);
            this.txtSocIdNF.Name = "txtSocIdNF";
            this.txtSocIdNF.Size = new System.Drawing.Size(62, 23);
            this.txtSocIdNF.TabIndex = 223;
            // 
            // btnBuscarNF
            // 
            this.btnBuscarNF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.btnBuscarNF.FlatAppearance.BorderSize = 0;
            this.btnBuscarNF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarNF.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarNF.ForeColor = System.Drawing.Color.White;
            this.btnBuscarNF.Location = new System.Drawing.Point(175, 84);
            this.btnBuscarNF.Name = "btnBuscarNF";
            this.btnBuscarNF.Size = new System.Drawing.Size(198, 21);
            this.btnBuscarNF.TabIndex = 222;
            this.btnBuscarNF.Text = "Buscar Documento";
            this.btnBuscarNF.UseVisualStyleBackColor = false;
            this.btnBuscarNF.Click += new System.EventHandler(this.btnBuscarNF_Click);
            // 
            // txtBuscarCuota
            // 
            this.txtBuscarCuota.Location = new System.Drawing.Point(31, 84);
            this.txtBuscarCuota.Name = "txtBuscarCuota";
            this.txtBuscarCuota.Size = new System.Drawing.Size(119, 23);
            this.txtBuscarCuota.TabIndex = 221;
            this.txtBuscarCuota.TextChanged += new System.EventHandler(this.txtBuscarCuota_TextChanged);
            // 
            // dgvSociosNF
            // 
            this.dgvSociosNF.AllowUserToAddRows = false;
            this.dgvSociosNF.AllowUserToDeleteRows = false;
            this.dgvSociosNF.AllowUserToOrderColumns = true;
            this.dgvSociosNF.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvSociosNF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSociosNF.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SocId,
            this.CuotaId,
            this.CuotaFechaDesde,
            this.TipoCuenta,
            this.Estado,
            this.MesAño,
            this.FechaPaga,
            this.Imprimir});
            this.dgvSociosNF.Location = new System.Drawing.Point(31, 348);
            this.dgvSociosNF.Name = "dgvSociosNF";
            this.dgvSociosNF.ReadOnly = true;
            this.dgvSociosNF.RowHeadersVisible = false;
            this.dgvSociosNF.RowHeadersWidth = 51;
            this.dgvSociosNF.Size = new System.Drawing.Size(811, 116);
            this.dgvSociosNF.TabIndex = 220;
            this.dgvSociosNF.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSociosNF_CellContentClick);
            // 
            // SocId
            // 
            this.SocId.HeaderText = "Socio";
            this.SocId.Name = "SocId";
            this.SocId.ReadOnly = true;
            this.SocId.Width = 60;
            // 
            // CuotaId
            // 
            this.CuotaId.HeaderText = "Cuota";
            this.CuotaId.MinimumWidth = 6;
            this.CuotaId.Name = "CuotaId";
            this.CuotaId.ReadOnly = true;
            this.CuotaId.Width = 60;
            // 
            // CuotaFechaDesde
            // 
            this.CuotaFechaDesde.FillWeight = 120F;
            this.CuotaFechaDesde.HeaderText = "Emision";
            this.CuotaFechaDesde.MinimumWidth = 6;
            this.CuotaFechaDesde.Name = "CuotaFechaDesde";
            this.CuotaFechaDesde.ReadOnly = true;
            // 
            // TipoCuenta
            // 
            this.TipoCuenta.HeaderText = "Categoria";
            this.TipoCuenta.MinimumWidth = 6;
            this.TipoCuenta.Name = "TipoCuenta";
            this.TipoCuenta.ReadOnly = true;
            this.TipoCuenta.Width = 120;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.MinimumWidth = 6;
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Estado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MesAño
            // 
            this.MesAño.HeaderText = "Mes/Año";
            this.MesAño.Name = "MesAño";
            this.MesAño.ReadOnly = true;
            // 
            // FechaPaga
            // 
            this.FechaPaga.HeaderText = "Fecha pago";
            this.FechaPaga.Name = "FechaPaga";
            this.FechaPaga.ReadOnly = true;
            // 
            // Imprimir
            // 
            this.Imprimir.HeaderText = "Pagar";
            this.Imprimir.Name = "Imprimir";
            this.Imprimir.ReadOnly = true;
            this.Imprimir.Width = 90;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(381, 213);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(16, 21);
            this.label22.TabIndex = 219;
            this.label22.Text = "*";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(175, 213);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(200, 23);
            this.dtpDesde.TabIndex = 218;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(28, 213);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(99, 17);
            this.label16.TabIndex = 217;
            this.label16.Text = "Fecha Emisión";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(28, 292);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(84, 17);
            this.label15.TabIndex = 216;
            this.label15.Text = "* Requerido";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(28, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 17);
            this.label3.TabIndex = 215;
            this.label3.Text = "Categoria";
            // 
            // btnCancelarNF
            // 
            this.btnCancelarNF.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelarNF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.btnCancelarNF.FlatAppearance.BorderSize = 0;
            this.btnCancelarNF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarNF.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarNF.ForeColor = System.Drawing.Color.White;
            this.btnCancelarNF.Location = new System.Drawing.Point(446, 524);
            this.btnCancelarNF.Name = "btnCancelarNF";
            this.btnCancelarNF.Size = new System.Drawing.Size(176, 25);
            this.btnCancelarNF.TabIndex = 214;
            this.btnCancelarNF.Text = "Cancelar";
            this.btnCancelarNF.UseVisualStyleBackColor = false;
            this.btnCancelarNF.Click += new System.EventHandler(this.btnCancelarNF_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.label1.Location = new System.Drawing.Point(27, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 38);
            this.label1.TabIndex = 212;
            this.label1.Text = "Cuotas Socios";
            // 
            // btnGuardarNF
            // 
            this.btnGuardarNF.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGuardarNF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.btnGuardarNF.FlatAppearance.BorderSize = 0;
            this.btnGuardarNF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarNF.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarNF.ForeColor = System.Drawing.Color.White;
            this.btnGuardarNF.Location = new System.Drawing.Point(156, 524);
            this.btnGuardarNF.Name = "btnGuardarNF";
            this.btnGuardarNF.Size = new System.Drawing.Size(176, 25);
            this.btnGuardarNF.TabIndex = 213;
            this.btnGuardarNF.Text = "Agregar";
            this.btnGuardarNF.UseVisualStyleBackColor = false;
            this.btnGuardarNF.Click += new System.EventHandler(this.btnGuardarNF_Click);
            // 
            // tabModifcar
            // 
            this.tabModifcar.Controls.Add(this.tabindividual);
            this.tabModifcar.Controls.Add(this.tabGenerales);
            this.tabModifcar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabModifcar.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabModifcar.Location = new System.Drawing.Point(0, 0);
            this.tabModifcar.Name = "tabModifcar";
            this.tabModifcar.SelectedIndex = 0;
            this.tabModifcar.Size = new System.Drawing.Size(1051, 549);
            this.tabModifcar.TabIndex = 2;
            // 
            // comboBox3
            // 
            this.comboBox3.Enabled = false;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(532, 97);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(283, 24);
            this.comboBox3.TabIndex = 234;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(428, 99);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 17);
            this.label14.TabIndex = 233;
            this.label14.Text = "Categoria";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(352, 92);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(16, 21);
            this.label17.TabIndex = 235;
            this.label17.Text = "*";
            // 
            // Socio
            // 
            this.Socio.HeaderText = "Socio";
            this.Socio.Name = "Socio";
            this.Socio.ReadOnly = true;
            this.Socio.Width = 80;
            // 
            // SocCI
            // 
            this.SocCI.HeaderText = "Cédula";
            this.SocCI.MinimumWidth = 6;
            this.SocCI.Name = "SocCI";
            this.SocCI.ReadOnly = true;
            this.SocCI.Width = 80;
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
            // SocDireccion
            // 
            this.SocDireccion.HeaderText = "Dirección";
            this.SocDireccion.MinimumWidth = 6;
            this.SocDireccion.Name = "SocDireccion";
            this.SocDireccion.ReadOnly = true;
            this.SocDireccion.Width = 180;
            // 
            // SocTel
            // 
            this.SocTel.HeaderText = "Teléfono";
            this.SocTel.MinimumWidth = 6;
            this.SocTel.Name = "SocTel";
            this.SocTel.ReadOnly = true;
            this.SocTel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SocTel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SocTel.Width = 140;
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
            // TipoCuota
            // 
            this.TipoCuota.HeaderText = "TipoCuota";
            this.TipoCuota.Name = "TipoCuota";
            this.TipoCuota.Visible = false;
            // 
            // frmRecibos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 549);
            this.Controls.Add(this.tabModifcar);
            this.Name = "frmRecibos";
            this.Text = "Cuotas Socios";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.tabGenerales.ResumeLayout(false);
            this.tabGenerales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSocios)).EndInit();
            this.tabindividual.ResumeLayout(false);
            this.tabindividual.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSociosNF)).EndInit();
            this.tabModifcar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TabControl tabModifcar;
        private System.Windows.Forms.TabPage tabindividual;
        private System.Windows.Forms.TabPage tabGenerales;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.ComboBox cmbAño;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpFEchaCuotaPaga;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbMes;
        private System.Windows.Forms.RadioButton rbtPaga;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSocCI;
        private System.Windows.Forms.TextBox txtNFId;
        private System.Windows.Forms.TextBox txtNombreSocNF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSocIdNF;
        private System.Windows.Forms.Button btnBuscarNF;
        private System.Windows.Forms.TextBox txtBuscarCuota;
        private System.Windows.Forms.DataGridView dgvSociosNF;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancelarNF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuardarNF;
        private System.Windows.Forms.DataGridViewTextBoxColumn SocId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CuotaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CuotaFechaDesde;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn MesAño;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaPaga;
        private System.Windows.Forms.DataGridViewButtonColumn Imprimir;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox txtParametro;
        private System.Windows.Forms.Label lblTituloFormulario;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.DataGridView dgvSocios;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtpVencimiento;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpEmision;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Socio;
        private System.Windows.Forms.DataGridViewTextBoxColumn SocCI;
        private System.Windows.Forms.DataGridViewTextBoxColumn SocPrimerNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn SocPrimerApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn SocDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn SocTel;
        private System.Windows.Forms.DataGridViewTextBoxColumn SocCelular;
        private System.Windows.Forms.DataGridViewTextBoxColumn SocActivo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Generar;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoCuota;
    }
}