using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntidadesCompartidas;
using Logica;

namespace Policial
{
    public partial class frmMantenimiento : Form
    {
        #region Variables/Pripiedades
        string mensaje = "";
        string titulo = "";
        #endregion
        #region Metodos
        public frmMantenimiento()
        {
            InitializeComponent();
            ListarTC();
            btnGuardar.BackColor = RGBColors.color;
            btnCancelar.BackColor = RGBColors.color;
            btnVolverAPrincipal.BackColor = RGBColors.color;
            btnGuardar.Text = "Agregar";
            label1.ForeColor = RGBColors.color;

        }
        public struct RGBColors
        {
            public static Color color = Color.FromArgb(172, 126, 241);
            public static Color color1 = Color.FromArgb(248, 118, 176);
            public static Color color2 = Color.FromArgb(253, 138, 114);
            public static Color color3 = Color.FromArgb(95, 77, 221);
            public static Color color4 = Color.FromArgb(249, 88, 155);
            public static Color color5 = Color.FromArgb(24, 161, 251);
        }
        public void ListarTC()
        {
            try
            {
                List<TipoCuota> listaTC = new List<TipoCuota>();
                ILogicaSocio tipoCuota = FabricaLogica.getLogicaSocio();
                listaTC = tipoCuota.ListarTC();
                dgvCategorias.Rows.Clear();

                foreach (TipoCuota e in listaTC)
                {
                    dgvCategorias.Rows.Add(e.TCId, e.TCDescripcion, e.TCMonto, "Editar", "Eliminar");
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private bool HayError()
        {
            #region Controlo errores campos
            bool error = false;
            if (txtDescripcion.Text == "")
            {
                errorProvider.SetError(label20, "Ingrese categoria.");
                error = true;
            }
            if (string.IsNullOrEmpty(txtMonto.Text.Trim()))
            {
                errorProvider.SetError(label25, "Ingrese monto.");
                error = true;
            }
            return error;
            #endregion
        }
        private bool PersistirTipoCuota(TipoCuota c, Usuario usu)
        {
            bool resp = false;
            try
            {
                ILogicaCuota FSocio = FabricaLogica.getLogicaCuota();
                resp = FSocio.AltaCuota(c, usu);
                return resp;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return resp;
        }
        #endregion
        #region Eventos
        private void dgvCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var filaSeleccionada = dgvCategorias.CurrentRow;
                if (e.ColumnIndex == 3) //editar
                {
                    if (dgvCategorias.SelectedRows != null)
                    {
                        int id = Convert.ToInt32(filaSeleccionada.Cells[0].Value);
                        textBox1.Text = filaSeleccionada.Cells["TCId"].Value.ToString();
                        txtDescripcion.Text = filaSeleccionada.Cells["TCDescripcion"].Value.ToString();
                        txtMonto.Text = filaSeleccionada.Cells["TCMonto"].Value.ToString();
                        btnGuardar.Text = "Modificar";
                    }
                    else
                        MessageBox.Show("Seleccione linea de la grilla.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (e.ColumnIndex == 4) //eliminar
                {
                    if (dgvCategorias.SelectedRows != null)
                    {
                        int id = Convert.ToInt32(filaSeleccionada.Cells[0].Value);
                        textBox1.Text = filaSeleccionada.Cells["TCId"].Value.ToString();
                        txtDescripcion.Text = filaSeleccionada.Cells["TCDescripcion"].Value.ToString();
                        txtMonto.Text = filaSeleccionada.Cells["TCMonto"].Value.ToString();
                        btnGuardar.Text = "Eliminar";
                    }
                    else
                        MessageBox.Show("Seleccione linea de la grilla.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                #region Aceptar
                errorProvider.Clear();
                ILogicaCuota lNF = FabricaLogica.getLogicaCuota();
                TipoCuota tipoCuota = new TipoCuota();
                Usuario _usu = Program.usuarioLogueado;
                bool resultado = false;
                bool ret = HayError();
                if (btnGuardar.Text == "Agregar")
                {
                    if (ret == false)
                    {
                        tipoCuota.TCDescripcion = txtDescripcion.Text.Trim();
                        tipoCuota.TCMonto = Convert.ToInt32(txtMonto.Text.Trim());

                        tipoCuota.FecAlta = DateTime.Now;
                        tipoCuota.UsuIdAlta = Program.usuarioLogueado.UsuId;

                        if (tipoCuota != null)
                        {
                            resultado = PersistirTipoCuota(tipoCuota, _usu);

                            if (resultado)
                            {
                                dgvCategorias.Rows.Add(tipoCuota.TCId, tipoCuota.TCDescripcion, tipoCuota.TCMonto, "Editar", "Eliminar");
                                txtDescripcion.Text = "";
                                txtMonto.Text = "";
                                ListarTC();
                                mensaje = "La información se guardó exitosamente.";
                                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                mensaje = "No se guardó la información.";
                                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }
                }
                #endregion
                #region Modificar
                if (btnGuardar.Text == "Modificar")
                {
                    if (ret == false)
                        tipoCuota.TCId = Convert.ToInt32(textBox1.Text.Trim());

                    if (tipoCuota != null)
                    {
                        resultado = lNF.ModificarCuota(tipoCuota, _usu);

                        if (resultado)
                        {
                            DateTime fecha = DateTime.Today;
                            dgvCategorias.Rows.Clear();
                            ListarTC();
                            txtMonto.Text = "";
                            txtDescripcion.Text = "";
                            mensaje = "La información se modifico correctamente.";
                            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnGuardar.Text = "Agregar";
                        }
                        else
                        {
                            mensaje = "No se modifico la información.";
                            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            btnGuardar.Text = "Agregar";
                        }
                    }
                }
                #endregion
                #region Eliminar
                if (btnGuardar.Text == "Eliminar")
                {
                    if (ret == false)
                    {
                        tipoCuota.TCId = Convert.ToInt32(textBox1.Text.Trim());
                        tipoCuota.TCDescripcion = txtDescripcion.Text.Trim();
                        tipoCuota.TCMonto = Convert.ToInt32(txtMonto.Text.Trim());

                        tipoCuota.FecAlta = DateTime.Now;
                        tipoCuota.UsuIdAlta = Program.usuarioLogueado.UsuId;
                    }

                    if (tipoCuota != null)
                    {
                        resultado = lNF.BajarCuota(tipoCuota.TCId,_usu);

                        if (resultado)
                        {
                            DateTime fecha = DateTime.Today;
                            dgvCategorias.Rows.Clear();
                            ListarTC();
                            txtMonto.Text = "";
                            txtDescripcion.Text = "";
                            mensaje = "La información se elimino correctamente.";
                            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnGuardar.Text = "Agregar";
                        }
                        else
                        {
                            mensaje = "No se elimino la información.";
                            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            btnGuardar.Text = "Agregar";
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }
        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }
        #endregion
    }
}
