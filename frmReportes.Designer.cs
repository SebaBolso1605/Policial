
namespace Policial
{
    partial class frmReportes
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
            this.btnListar = new System.Windows.Forms.Button();
            this.lblTituloFormulario = new System.Windows.Forms.Label();
            this.txtParametro = new System.Windows.Forms.TextBox();
            this.dgvReportes = new System.Windows.Forms.DataGridView();
            this.SocId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SocCI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SocPrimerNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SocPrimerApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SocDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefonos = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnListar
            // 
            this.btnListar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.btnListar.FlatAppearance.BorderSize = 0;
            this.btnListar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListar.ForeColor = System.Drawing.Color.White;
            this.btnListar.Location = new System.Drawing.Point(588, 68);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(201, 21);
            this.btnListar.TabIndex = 35;
            this.btnListar.Text = "Listar";
            this.btnListar.UseVisualStyleBackColor = false;
            // 
            // lblTituloFormulario
            // 
            this.lblTituloFormulario.AutoSize = true;
            this.lblTituloFormulario.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloFormulario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.lblTituloFormulario.Location = new System.Drawing.Point(12, 5);
            this.lblTituloFormulario.Name = "lblTituloFormulario";
            this.lblTituloFormulario.Size = new System.Drawing.Size(151, 38);
            this.lblTituloFormulario.TabIndex = 34;
            this.lblTituloFormulario.Text = "Reportes";
            // 
            // txtParametro
            // 
            this.txtParametro.Location = new System.Drawing.Point(19, 68);
            this.txtParametro.Name = "txtParametro";
            this.txtParametro.Size = new System.Drawing.Size(538, 20);
            this.txtParametro.TabIndex = 33;
            // 
            // dgvReportes
            // 
            this.dgvReportes.AllowUserToAddRows = false;
            this.dgvReportes.AllowUserToDeleteRows = false;
            this.dgvReportes.AllowUserToOrderColumns = true;
            this.dgvReportes.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvReportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReportes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SocId,
            this.SocCI,
            this.SocPrimerNombre,
            this.SocPrimerApellido,
            this.SocDireccion,
            this.Telefonos,
            this.Editar});
            this.dgvReportes.Location = new System.Drawing.Point(19, 100);
            this.dgvReportes.Name = "dgvReportes";
            this.dgvReportes.ReadOnly = true;
            this.dgvReportes.RowHeadersVisible = false;
            this.dgvReportes.RowHeadersWidth = 51;
            this.dgvReportes.Size = new System.Drawing.Size(770, 345);
            this.dgvReportes.TabIndex = 32;
            // 
            // SocId
            // 
            this.SocId.HeaderText = "Socio Nº";
            this.SocId.Name = "SocId";
            this.SocId.ReadOnly = true;
            this.SocId.Width = 80;
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
            // Telefonos
            // 
            this.Telefonos.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Telefonos.HeaderText = "Teléfonos";
            this.Telefonos.MinimumWidth = 6;
            this.Telefonos.Name = "Telefonos";
            this.Telefonos.ReadOnly = true;
            this.Telefonos.Width = 140;
            // 
            // Editar
            // 
            this.Editar.HeaderText = "Editar";
            this.Editar.MinimumWidth = 6;
            this.Editar.Name = "Editar";
            this.Editar.ReadOnly = true;
            this.Editar.Width = 80;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(284, 468);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(298, 28);
            this.button1.TabIndex = 36;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // frmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 552);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.lblTituloFormulario);
            this.Controls.Add(this.txtParametro);
            this.Controls.Add(this.dgvReportes);
            this.Name = "frmReportes";
            this.Text = "frmReportes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.Label lblTituloFormulario;
        private System.Windows.Forms.TextBox txtParametro;
        private System.Windows.Forms.DataGridView dgvReportes;
        private System.Windows.Forms.DataGridViewTextBoxColumn SocId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SocCI;
        private System.Windows.Forms.DataGridViewTextBoxColumn SocPrimerNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn SocPrimerApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn SocDireccion;
        private System.Windows.Forms.DataGridViewButtonColumn Telefonos;
        private System.Windows.Forms.DataGridViewButtonColumn Editar;
        private System.Windows.Forms.Button button1;
    }
}