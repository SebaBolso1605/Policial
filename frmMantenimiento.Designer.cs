
namespace Policial
{
    partial class frmMantenimiento
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
            this.tabModifcar = new System.Windows.Forms.TabControl();
            this.tabPagarCuotas = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtParametro = new System.Windows.Forms.TextBox();
            this.chkPagar = new System.Windows.Forms.CheckBox();
            this.dgvSocios = new System.Windows.Forms.DataGridView();
            this.SocId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SocCI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SocPrimerNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SocPrimerApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CuotaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoCuota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CuotaAAAAMM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pagar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SocDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CuotaFechaPaga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPagar = new System.Windows.Forms.Button();
            this.tabModificarCuota = new System.Windows.Forms.TabPage();
            this.label39 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.dgvCategorias = new System.Windows.Forms.DataGridView();
            this.TCId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TCDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TCMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.tabModifcar.SuspendLayout();
            this.tabPagarCuotas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSocios)).BeginInit();
            this.tabModificarCuota.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // tabModifcar
            // 
            this.tabModifcar.Controls.Add(this.tabPagarCuotas);
            this.tabModifcar.Controls.Add(this.tabModificarCuota);
            this.tabModifcar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabModifcar.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabModifcar.Location = new System.Drawing.Point(0, 0);
            this.tabModifcar.Name = "tabModifcar";
            this.tabModifcar.SelectedIndex = 0;
            this.tabModifcar.Size = new System.Drawing.Size(1167, 622);
            this.tabModifcar.TabIndex = 2;
            // 
            // tabPagarCuotas
            // 
            this.tabPagarCuotas.BackColor = System.Drawing.SystemColors.Control;
            this.tabPagarCuotas.Controls.Add(this.checkBox1);
            this.tabPagarCuotas.Controls.Add(this.label2);
            this.tabPagarCuotas.Controls.Add(this.txtParametro);
            this.tabPagarCuotas.Controls.Add(this.chkPagar);
            this.tabPagarCuotas.Controls.Add(this.dgvSocios);
            this.tabPagarCuotas.Controls.Add(this.btnCancelar);
            this.tabPagarCuotas.Controls.Add(this.label1);
            this.tabPagarCuotas.Controls.Add(this.btnPagar);
            this.tabPagarCuotas.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPagarCuotas.Location = new System.Drawing.Point(4, 25);
            this.tabPagarCuotas.Name = "tabPagarCuotas";
            this.tabPagarCuotas.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagarCuotas.Size = new System.Drawing.Size(1159, 593);
            this.tabPagarCuotas.TabIndex = 0;
            this.tabPagarCuotas.Text = "Pagar Cuotas";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.ForeColor = System.Drawing.Color.Black;
            this.checkBox1.Location = new System.Drawing.Point(342, 86);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(139, 20);
            this.checkBox1.TabIndex = 263;
            this.checkBox1.Text = "solo Cuotas Impagas";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(63, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 262;
            this.label2.Text = "Buscar";
            // 
            // txtParametro
            // 
            this.txtParametro.Location = new System.Drawing.Point(134, 84);
            this.txtParametro.Name = "txtParametro";
            this.txtParametro.Size = new System.Drawing.Size(202, 21);
            this.txtParametro.TabIndex = 261;
            this.txtParametro.TextChanged += new System.EventHandler(this.txtParametro_TextChanged);
            // 
            // chkPagar
            // 
            this.chkPagar.AutoSize = true;
            this.chkPagar.Checked = true;
            this.chkPagar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPagar.ForeColor = System.Drawing.Color.Black;
            this.chkPagar.Location = new System.Drawing.Point(868, 98);
            this.chkPagar.Name = "chkPagar";
            this.chkPagar.Size = new System.Drawing.Size(88, 20);
            this.chkPagar.TabIndex = 199;
            this.chkPagar.Text = "Pagar todo";
            this.chkPagar.UseVisualStyleBackColor = true;
            this.chkPagar.CheckedChanged += new System.EventHandler(this.chkPagar_CheckedChanged);
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
            this.SocPrimerNombre,
            this.SocPrimerApellido,
            this.CuotaId,
            this.TipoCuota,
            this.CuotaAAAAMM,
            this.Estado,
            this.Pagar,
            this.SocDireccion,
            this.CuotaFechaPaga});
            this.dgvSocios.Location = new System.Drawing.Point(66, 124);
            this.dgvSocios.Name = "dgvSocios";
            this.dgvSocios.RowHeadersVisible = false;
            this.dgvSocios.RowHeadersWidth = 51;
            this.dgvSocios.Size = new System.Drawing.Size(929, 330);
            this.dgvSocios.TabIndex = 198;
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
            // CuotaId
            // 
            this.CuotaId.HeaderText = "Cuota";
            this.CuotaId.MinimumWidth = 6;
            this.CuotaId.Name = "CuotaId";
            this.CuotaId.ReadOnly = true;
            // 
            // TipoCuota
            // 
            this.TipoCuota.HeaderText = "Tipo Cuota";
            this.TipoCuota.Name = "TipoCuota";
            this.TipoCuota.ReadOnly = true;
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
            // Pagar
            // 
            this.Pagar.HeaderText = "Pagar";
            this.Pagar.Name = "Pagar";
            // 
            // SocDireccion
            // 
            this.SocDireccion.HeaderText = "SocDireccion";
            this.SocDireccion.Name = "SocDireccion";
            this.SocDireccion.ReadOnly = true;
            this.SocDireccion.Visible = false;
            // 
            // CuotaFechaPaga
            // 
            this.CuotaFechaPaga.HeaderText = "CuotaFechaPaga";
            this.CuotaFechaPaga.Name = "CuotaFechaPaga";
            this.CuotaFechaPaga.Visible = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(587, 470);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(176, 25);
            this.btnCancelar.TabIndex = 128;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.label1.Location = new System.Drawing.Point(46, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(372, 38);
            this.label1.TabIndex = 126;
            this.label1.Text = "Pagar Cuotas";
            // 
            // btnPagar
            // 
            this.btnPagar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPagar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.btnPagar.FlatAppearance.BorderSize = 0;
            this.btnPagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagar.ForeColor = System.Drawing.Color.White;
            this.btnPagar.Location = new System.Drawing.Point(318, 470);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(176, 25);
            this.btnPagar.TabIndex = 127;
            this.btnPagar.Text = "Pagar";
            this.btnPagar.UseVisualStyleBackColor = false;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // tabModificarCuota
            // 
            this.tabModificarCuota.BackColor = System.Drawing.SystemColors.Control;
            this.tabModificarCuota.Controls.Add(this.label39);
            this.tabModificarCuota.Controls.Add(this.textBox1);
            this.tabModificarCuota.Controls.Add(this.txtMonto);
            this.tabModificarCuota.Controls.Add(this.txtDescripcion);
            this.tabModificarCuota.Controls.Add(this.dgvCategorias);
            this.tabModificarCuota.Controls.Add(this.button1);
            this.tabModificarCuota.Controls.Add(this.btnAgregar);
            this.tabModificarCuota.Controls.Add(this.label10);
            this.tabModificarCuota.Controls.Add(this.label17);
            this.tabModificarCuota.Controls.Add(this.label27);
            this.tabModificarCuota.Controls.Add(this.label28);
            this.tabModificarCuota.Controls.Add(this.label29);
            this.tabModificarCuota.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabModificarCuota.Location = new System.Drawing.Point(4, 25);
            this.tabModificarCuota.Name = "tabModificarCuota";
            this.tabModificarCuota.Padding = new System.Windows.Forms.Padding(3);
            this.tabModificarCuota.Size = new System.Drawing.Size(1159, 593);
            this.tabModificarCuota.TabIndex = 1;
            this.tabModificarCuota.Text = "Actualizar Cuotas";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = System.Drawing.Color.Black;
            this.label39.Location = new System.Drawing.Point(436, 184);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(84, 17);
            this.label39.TabIndex = 209;
            this.label39.Text = "* Requerido";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(51, 95);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(47, 23);
            this.textBox1.TabIndex = 208;
            this.textBox1.Visible = false;
            // 
            // txtMonto
            // 
            this.txtMonto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMonto.Location = new System.Drawing.Point(238, 180);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(101, 23);
            this.txtMonto.TabIndex = 207;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.Location = new System.Drawing.Point(238, 142);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(282, 23);
            this.txtDescripcion.TabIndex = 206;
            // 
            // dgvCategorias
            // 
            this.dgvCategorias.AllowUserToAddRows = false;
            this.dgvCategorias.AllowUserToDeleteRows = false;
            this.dgvCategorias.AllowUserToOrderColumns = true;
            this.dgvCategorias.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategorias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TCId,
            this.TCDescripcion,
            this.TCMonto,
            this.Editar,
            this.Eliminar});
            this.dgvCategorias.Location = new System.Drawing.Point(98, 228);
            this.dgvCategorias.Name = "dgvCategorias";
            this.dgvCategorias.ReadOnly = true;
            this.dgvCategorias.RowHeadersVisible = false;
            this.dgvCategorias.RowHeadersWidth = 51;
            this.dgvCategorias.Size = new System.Drawing.Size(586, 149);
            this.dgvCategorias.TabIndex = 205;
            this.dgvCategorias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategorias_CellContentClick);
            // 
            // TCId
            // 
            this.TCId.HeaderText = "Categoria";
            this.TCId.Name = "TCId";
            this.TCId.ReadOnly = true;
            this.TCId.Width = 80;
            // 
            // TCDescripcion
            // 
            this.TCDescripcion.HeaderText = "Descripcion";
            this.TCDescripcion.MinimumWidth = 6;
            this.TCDescripcion.Name = "TCDescripcion";
            this.TCDescripcion.ReadOnly = true;
            this.TCDescripcion.Width = 200;
            // 
            // TCMonto
            // 
            this.TCMonto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TCMonto.HeaderText = "Monto";
            this.TCMonto.MinimumWidth = 6;
            this.TCMonto.Name = "TCMonto";
            this.TCMonto.ReadOnly = true;
            // 
            // Editar
            // 
            this.Editar.HeaderText = "Editar";
            this.Editar.Name = "Editar";
            this.Editar.ReadOnly = true;
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(439, 390);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(176, 25);
            this.button1.TabIndex = 204;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(185, 390);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(176, 25);
            this.btnAgregar.TabIndex = 203;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.label10.Location = new System.Drawing.Point(91, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(363, 38);
            this.label10.TabIndex = 202;
            this.label10.Text = "Mantenimiento cuotas";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(345, 180);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(16, 21);
            this.label17.TabIndex = 201;
            this.label17.Text = "*";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(130, 177);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(50, 17);
            this.label27.TabIndex = 200;
            this.label27.Text = "Monto";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.Black;
            this.label28.Location = new System.Drawing.Point(528, 141);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(16, 21);
            this.label28.TabIndex = 199;
            this.label28.Text = "*";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.Black;
            this.label29.Location = new System.Drawing.Point(130, 141);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(75, 17);
            this.label29.TabIndex = 198;
            this.label29.Text = "Categoria";
            // 
            // frmMantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 622);
            this.Controls.Add(this.tabModifcar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMantenimiento";
            this.Text = "Mantenimiento";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.tabModifcar.ResumeLayout(false);
            this.tabPagarCuotas.ResumeLayout(false);
            this.tabPagarCuotas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSocios)).EndInit();
            this.tabModificarCuota.ResumeLayout(false);
            this.tabModificarCuota.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TabControl tabModifcar;
        private System.Windows.Forms.TabPage tabPagarCuotas;
        private System.Windows.Forms.TabPage tabModificarCuota;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.DataGridView dgvCategorias;
        private System.Windows.Forms.DataGridViewTextBoxColumn TCId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TCDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn TCMonto;
        private System.Windows.Forms.DataGridViewButtonColumn Editar;
        private System.Windows.Forms.DataGridViewButtonColumn Eliminar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.CheckBox chkPagar;
        private System.Windows.Forms.DataGridView dgvSocios;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtParametro;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SocId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SocCI;
        private System.Windows.Forms.DataGridViewTextBoxColumn SocPrimerNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn SocPrimerApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn CuotaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoCuota;
        private System.Windows.Forms.DataGridViewTextBoxColumn CuotaAAAAMM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Pagar;
        private System.Windows.Forms.DataGridViewTextBoxColumn SocDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CuotaFechaPaga;
    }
}