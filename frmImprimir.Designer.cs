﻿
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
            this.SocPrimerNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SocPrimerApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CuotaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CuotaAAAAMM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pagar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Imprimir = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cmbAño = new System.Windows.Forms.ComboBox();
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSocios)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTituloFormulario
            // 
            this.lblTituloFormulario.AutoSize = true;
            this.lblTituloFormulario.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloFormulario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.lblTituloFormulario.Location = new System.Drawing.Point(290, 22);
            this.lblTituloFormulario.Name = "lblTituloFormulario";
            this.lblTituloFormulario.Size = new System.Drawing.Size(370, 38);
            this.lblTituloFormulario.TabIndex = 137;
            this.lblTituloFormulario.Text = "Generar Cuotas Socios";
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.ForeColor = System.Drawing.Color.White;
            this.btnVolver.Location = new System.Drawing.Point(484, 516);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(176, 29);
            this.btnVolver.TabIndex = 136;
            this.btnVolver.Text = "Limpiar";
            this.btnVolver.UseVisualStyleBackColor = false;
            // 
            // dgvSocios
            // 
            this.dgvSocios.AllowUserToAddRows = false;
            this.dgvSocios.AllowUserToDeleteRows = false;
            this.dgvSocios.AllowUserToOrderColumns = true;
            this.dgvSocios.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvSocios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSocios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SocId,
            this.SocCI,
            this.SocPrimerNombre,
            this.SocPrimerApellido,
            this.CuotaId,
            this.CuotaAAAAMM,
            this.Pagar,
            this.Imprimir});
            this.dgvSocios.Location = new System.Drawing.Point(38, 144);
            this.dgvSocios.Name = "dgvSocios";
            this.dgvSocios.ReadOnly = true;
            this.dgvSocios.RowHeadersVisible = false;
            this.dgvSocios.RowHeadersWidth = 51;
            this.dgvSocios.Size = new System.Drawing.Size(887, 345);
            this.dgvSocios.TabIndex = 135;
            // 
            // SocId
            // 
            this.SocId.HeaderText = "Socio";
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
            // CuotaId
            // 
            this.CuotaId.HeaderText = "Cuota";
            this.CuotaId.MinimumWidth = 6;
            this.CuotaId.Name = "CuotaId";
            this.CuotaId.ReadOnly = true;
            this.CuotaId.Width = 80;
            // 
            // CuotaAAAAMM
            // 
            this.CuotaAAAAMM.HeaderText = "Mes/Año";
            this.CuotaAAAAMM.MinimumWidth = 6;
            this.CuotaAAAAMM.Name = "CuotaAAAAMM";
            this.CuotaAAAAMM.ReadOnly = true;
            this.CuotaAAAAMM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CuotaAAAAMM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CuotaAAAAMM.Width = 140;
            // 
            // Pagar
            // 
            this.Pagar.HeaderText = "Pagar";
            this.Pagar.Name = "Pagar";
            this.Pagar.ReadOnly = true;
            this.Pagar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Imprimir
            // 
            this.Imprimir.HeaderText = "Imprimir";
            this.Imprimir.Name = "Imprimir";
            this.Imprimir.ReadOnly = true;
            // 
            // cmbAño
            // 
            this.cmbAño.FormattingEnabled = true;
            this.cmbAño.Items.AddRange(new object[] {
            "2022",
            "2023",
            "2024",
            "2025"});
            this.cmbAño.Location = new System.Drawing.Point(258, 92);
            this.cmbAño.Name = "cmbAño";
            this.cmbAño.Size = new System.Drawing.Size(103, 21);
            this.cmbAño.TabIndex = 191;
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
            this.cmbMes.Location = new System.Drawing.Point(179, 92);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(73, 21);
            this.cmbMes.TabIndex = 190;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(35, 92);
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
            this.btnImprimir.Location = new System.Drawing.Point(280, 516);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(176, 29);
            this.btnImprimir.TabIndex = 192;
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
            this.btnBuscar.Location = new System.Drawing.Point(388, 89);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(198, 24);
            this.btnBuscar.TabIndex = 193;
            this.btnBuscar.Text = "Filtrar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            // 
            // frmImprimir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 605);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.cmbAño);
            this.Controls.Add(this.cmbMes);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblTituloFormulario);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.dgvSocios);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn SocId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SocCI;
        private System.Windows.Forms.DataGridViewTextBoxColumn SocPrimerNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn SocPrimerApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn CuotaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CuotaAAAAMM;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Pagar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Imprimir;
        private System.Windows.Forms.Button btnBuscar;
    }
}