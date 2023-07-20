
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.Paga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MesAño = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaPaga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Imprimir = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancelarNF = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuardarNF = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label22 = new System.Windows.Forms.Label();
            this.rbtPaga = new System.Windows.Forms.RadioButton();
            this.dtpFEchaCuotaPaga = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbAño = new System.Windows.Forms.ComboBox();
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSociosNF)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSocCI
            // 
            this.txtSocCI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSocCI.Enabled = false;
            this.txtSocCI.Location = new System.Drawing.Point(658, 27);
            this.txtSocCI.Name = "txtSocCI";
            this.txtSocCI.Size = new System.Drawing.Size(28, 20);
            this.txtSocCI.TabIndex = 177;
            this.txtSocCI.Visible = false;
            // 
            // txtNFId
            // 
            this.txtNFId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNFId.Enabled = false;
            this.txtNFId.Location = new System.Drawing.Point(590, 28);
            this.txtNFId.Name = "txtNFId";
            this.txtNFId.Size = new System.Drawing.Size(28, 20);
            this.txtNFId.TabIndex = 176;
            this.txtNFId.Visible = false;
            // 
            // txtNombreSocNF
            // 
            this.txtNombreSocNF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombreSocNF.Enabled = false;
            this.txtNombreSocNF.Location = new System.Drawing.Point(257, 129);
            this.txtNombreSocNF.Name = "txtNombreSocNF";
            this.txtNombreSocNF.Size = new System.Drawing.Size(206, 20);
            this.txtNombreSocNF.TabIndex = 175;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(33, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 174;
            this.label2.Text = "Datos Socio";
            // 
            // txtSocIdNF
            // 
            this.txtSocIdNF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSocIdNF.Enabled = false;
            this.txtSocIdNF.Location = new System.Drawing.Point(180, 129);
            this.txtSocIdNF.Name = "txtSocIdNF";
            this.txtSocIdNF.Size = new System.Drawing.Size(62, 20);
            this.txtSocIdNF.TabIndex = 173;
            // 
            // btnBuscarNF
            // 
            this.btnBuscarNF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.btnBuscarNF.FlatAppearance.BorderSize = 0;
            this.btnBuscarNF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarNF.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarNF.ForeColor = System.Drawing.Color.White;
            this.btnBuscarNF.Location = new System.Drawing.Point(180, 82);
            this.btnBuscarNF.Name = "btnBuscarNF";
            this.btnBuscarNF.Size = new System.Drawing.Size(198, 21);
            this.btnBuscarNF.TabIndex = 172;
            this.btnBuscarNF.Text = "Buscar Documento";
            this.btnBuscarNF.UseVisualStyleBackColor = false;
            this.btnBuscarNF.Click += new System.EventHandler(this.btnBuscarNF_Click);
            // 
            // txtBuscarCuota
            // 
            this.txtBuscarCuota.Location = new System.Drawing.Point(36, 82);
            this.txtBuscarCuota.Name = "txtBuscarCuota";
            this.txtBuscarCuota.Size = new System.Drawing.Size(119, 20);
            this.txtBuscarCuota.TabIndex = 171;
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
            this.Paga,
            this.MesAño,
            this.FechaPaga,
            this.Imprimir});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSociosNF.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSociosNF.Location = new System.Drawing.Point(36, 346);
            this.dgvSociosNF.Name = "dgvSociosNF";
            this.dgvSociosNF.ReadOnly = true;
            this.dgvSociosNF.RowHeadersVisible = false;
            this.dgvSociosNF.RowHeadersWidth = 51;
            this.dgvSociosNF.Size = new System.Drawing.Size(811, 116);
            this.dgvSociosNF.TabIndex = 170;
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
            // Paga
            // 
            this.Paga.HeaderText = "Paga";
            this.Paga.MinimumWidth = 6;
            this.Paga.Name = "Paga";
            this.Paga.ReadOnly = true;
            this.Paga.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Paga.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            this.Imprimir.HeaderText = "Imprimir";
            this.Imprimir.Name = "Imprimir";
            this.Imprimir.ReadOnly = true;
            this.Imprimir.Width = 90;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(33, 290);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(84, 17);
            this.label15.TabIndex = 163;
            this.label15.Text = "* Requerido";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(33, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 17);
            this.label3.TabIndex = 149;
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
            this.btnCancelarNF.Location = new System.Drawing.Point(451, 522);
            this.btnCancelarNF.Name = "btnCancelarNF";
            this.btnCancelarNF.Size = new System.Drawing.Size(176, 25);
            this.btnCancelarNF.TabIndex = 144;
            this.btnCancelarNF.Text = "Cancelar";
            this.btnCancelarNF.UseVisualStyleBackColor = false;
            this.btnCancelarNF.Click += new System.EventHandler(this.btnCancelarNF_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.label1.Location = new System.Drawing.Point(32, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 38);
            this.label1.TabIndex = 142;
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
            this.btnGuardarNF.Location = new System.Drawing.Point(161, 522);
            this.btnGuardarNF.Name = "btnGuardarNF";
            this.btnGuardarNF.Size = new System.Drawing.Size(176, 25);
            this.btnGuardarNF.TabIndex = 143;
            this.btnGuardarNF.Text = "Agregar";
            this.btnGuardarNF.UseVisualStyleBackColor = false;
            this.btnGuardarNF.Click += new System.EventHandler(this.btnGuardarNF_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(33, 211);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(99, 17);
            this.label16.TabIndex = 164;
            this.label16.Text = "Fecha Emisión";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(180, 211);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(200, 20);
            this.dtpDesde.TabIndex = 165;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(386, 211);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(16, 21);
            this.label22.TabIndex = 168;
            this.label22.Text = "*";
            // 
            // rbtPaga
            // 
            this.rbtPaga.AutoSize = true;
            this.rbtPaga.Location = new System.Drawing.Point(505, 182);
            this.rbtPaga.Name = "rbtPaga";
            this.rbtPaga.Size = new System.Drawing.Size(81, 17);
            this.rbtPaga.TabIndex = 182;
            this.rbtPaga.TabStop = true;
            this.rbtPaga.Text = "Cuota Paga";
            this.rbtPaga.UseVisualStyleBackColor = true;
            this.rbtPaga.CheckedChanged += new System.EventHandler(this.rbtPaga_CheckedChanged);
            // 
            // dtpFEchaCuotaPaga
            // 
            this.dtpFEchaCuotaPaga.Location = new System.Drawing.Point(109, 19);
            this.dtpFEchaCuotaPaga.Name = "dtpFEchaCuotaPaga";
            this.dtpFEchaCuotaPaga.Size = new System.Drawing.Size(200, 20);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpFEchaCuotaPaga);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(505, 211);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 62);
            this.groupBox1.TabIndex = 185;
            this.groupBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(386, 245);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 21);
            this.label7.TabIndex = 188;
            this.label7.Text = "*";
            // 
            // cmbAño
            // 
            this.cmbAño.FormattingEnabled = true;
            this.cmbAño.Items.AddRange(new object[] {
            "2022",
            "2023",
            "2024",
            "2025"});
            this.cmbAño.Location = new System.Drawing.Point(259, 245);
            this.cmbAño.Name = "cmbAño";
            this.cmbAño.Size = new System.Drawing.Size(121, 21);
            this.cmbAño.TabIndex = 187;
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
            this.cmbMes.Location = new System.Drawing.Point(180, 245);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(73, 21);
            this.cmbMes.TabIndex = 186;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(36, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 17);
            this.label6.TabIndex = 185;
            this.label6.Text = "Mes / Año";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.Enabled = false;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(180, 178);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(283, 21);
            this.cmbCategoria.TabIndex = 186;
            // 
            // frmRecibos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 608);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.cmbAño);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbMes);
            this.Controls.Add(this.rbtPaga);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSocCI);
            this.Controls.Add(this.txtNFId);
            this.Controls.Add(this.txtNombreSocNF);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSocIdNF);
            this.Controls.Add(this.btnBuscarNF);
            this.Controls.Add(this.txtBuscarCuota);
            this.Controls.Add(this.dgvSociosNF);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancelarNF);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGuardarNF);
            this.Name = "frmRecibos";
            this.Text = "Cuotas Socios";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSociosNF)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSocCI;
        private System.Windows.Forms.TextBox txtNFId;
        private System.Windows.Forms.TextBox txtNombreSocNF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSocIdNF;
        private System.Windows.Forms.Button btnBuscarNF;
        private System.Windows.Forms.TextBox txtBuscarCuota;
        private System.Windows.Forms.DataGridView dgvSociosNF;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancelarNF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuardarNF;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.RadioButton rbtPaga;
        private System.Windows.Forms.DateTimePicker dtpFEchaCuotaPaga;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbAño;
        private System.Windows.Forms.ComboBox cmbMes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn SocId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CuotaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CuotaFechaDesde;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Paga;
        private System.Windows.Forms.DataGridViewTextBoxColumn MesAño;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaPaga;
        private System.Windows.Forms.DataGridViewButtonColumn Imprimir;
    }
}