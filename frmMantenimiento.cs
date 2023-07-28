using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using EntidadesCompartidas;
//using Logica;
using System.Xml;
using System.IO;
using Policial.ServicePolicial;

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
            btnPagar.BackColor = RGBColors.color;
            btnCancelar.BackColor = RGBColors.color;
            button2.Text = "Agregar";
            label1.ForeColor = RGBColors.color;
            label10.ForeColor = RGBColors.color;
            button1.BackColor = RGBColors.color;
            button2.BackColor = RGBColors.color;
            ListarCuotasSocios();
            chkPagar.Checked = false;
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
                IServicePolicial tipoCuota = new ServicePolicialClient();
                listaTC = tipoCuota.ListarTC().ToList();
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
            if (txtDescripcion.Text.Trim() == "")
            {
                errorProvider.SetError(label28, "Ingrese categoria.");
                error = true;
            }
            if (string.IsNullOrEmpty(txtMonto.Text.Trim()))
            {
                errorProvider.SetError(label17, "Ingrese monto.");
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
                IServicePolicial FSocio = new ServicePolicialClient();
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
        public void ListarCuotasSocios()
        {
            try
            {
                IServicePolicial lc = new ServicePolicialClient();
                IServicePolicial ls = new ServicePolicialClient();
                List<Cuota> listaCuotas = new List<Cuota>();
                List<Socio> listaSocios = new List<Socio>();
                dgvSocios.Rows.Clear();
                listaSocios = ls.ListarSocios().ToList();
                bool soloCuotasImpagas = checkBox1.Checked ? true : false;
                bool imprimirTodo = chkPagar.Checked ? true : false;

                if (listaSocios.Count > 0)
                {
                    foreach (Socio s in listaSocios)
                    {
                        listaCuotas = lc.BuscarCuotasSocio(s.SocId).ToList();

                        if (listaCuotas.Count > 0 && soloCuotasImpagas)
                        {
                            foreach (Cuota c in listaCuotas)
                            {
                                if (!c.CuotaPaga)
                                {
                                    if (imprimirTodo)
                                        dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre + " " + s.SocSegundoNombre,
                                            s.SocPrimerApellido + " " + s.SocSegundoApellido, c.CuotaId, c.CuotaAAAAMM);
                                    else
                                        dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre + " " + s.SocSegundoNombre,
                                            s.SocPrimerApellido + " " + s.SocSegundoApellido, c.CuotaId, c.CuotaAAAAMM);
                                }
                            }
                        }
                        if (listaCuotas.Count > 0 && !soloCuotasImpagas)
                        {
                            foreach (Cuota c in listaCuotas)
                            {
                                if (imprimirTodo)
                                    dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre + " " + s.SocSegundoNombre,
                                            s.SocPrimerApellido + " " + s.SocSegundoApellido, c.CuotaId, c.CuotaAAAAMM);
                                else
                                    dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre + " " + s.SocSegundoNombre,
                                            s.SocPrimerApellido + " " + s.SocSegundoApellido, c.CuotaId, c.CuotaAAAAMM);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private string DevolverCategoria(int id)
        {
            try
            {
                string cat = "";
                List<TipoCuota> listaTC = new List<TipoCuota>();
                IServicePolicial tipoCuota = new ServicePolicialClient();
                listaTC = tipoCuota.ListarTC().ToList();

                TipoCuota c = new TipoCuota();
                c = listaTC.Where(x => x.TCId == id).FirstOrDefault();
                cat = c.TCDescripcion.ToString();
                return cat;
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                throw new Exception(mensaje, ex);
            }
        }
        private bool PersistirCuota(Cuota c, Usuario usu)
        {
            bool resp = false;
            try
            {
                IServicePolicial FSocio = new ServicePolicialClient();
                resp = FSocio.AltaCuentaSocio(c, usu);
                return resp;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return resp;
        }
        private bool PagarCuota(Cuota c, Usuario usu)
        {
            bool resp = false;
            try
            {
                IServicePolicial FSocio = new ServicePolicialClient();
                resp = FSocio.PagarCuotaSocio(c, usu);
                return resp;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return resp;
        }
        private int DevolverCategoriaDescrip(string desc)
        {
            try
            {
                int cat = 0;
                List<TipoCuota> listaTC = new List<TipoCuota>();
                IServicePolicial tipoCuota = new ServicePolicialClient();
                listaTC = tipoCuota.ListarTC().ToList();

                TipoCuota c = new TipoCuota();
                c = listaTC.Where(x => x.TCDescripcion == desc).FirstOrDefault();
                cat = c.TCId;
                return cat;
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                throw new Exception(mensaje, ex);
            }
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
                        textBox1.Text = filaSeleccionada.Cells["TCId"].Value.ToString().Trim();
                        txtDescripcion.Text = filaSeleccionada.Cells["TCDescripcion"].Value.ToString().Trim();
                        txtMonto.Text = filaSeleccionada.Cells["TCMonto"].Value.ToString().Trim();
                        btnPagar.Text = "Modificar";
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
                        btnPagar.Text = "Eliminar";
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
                IServicePolicial lNF = new ServicePolicialClient();
                TipoCuota tipoCuota = new TipoCuota();
                Usuario _usu = Program.usuarioLogueado;
                bool resultado = false;
                bool ret = HayError();
                if (btnPagar.Text == "Agregar")
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
                errorProvider.Clear();
                ret = HayError();
                if (btnPagar.Text == "Modificar")
                {
                    if (ret == false)
                    {
                        tipoCuota.TCId = Convert.ToInt32(textBox1.Text.Trim());
                        tipoCuota.TCDescripcion = txtDescripcion.Text.Trim();
                        tipoCuota.TCMonto = Convert.ToInt32(txtMonto.Text.Trim());

                        tipoCuota.FecModif = DateTime.Now;
                        tipoCuota.UsuIdModif = Program.usuarioLogueado.UsuId;

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
                                btnPagar.Text = "Agregar";
                            }
                            else
                            {
                                mensaje = "No se modifico la información.";
                                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                btnPagar.Text = "Agregar";
                            }
                        }
                    }
                }
                #endregion
                #region Eliminar
                if (btnPagar.Text == "Eliminar")
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
                            btnPagar.Text = "Agregar";
                        }
                        else
                        {
                            mensaje = "No se elimino la información.";
                            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            btnPagar.Text = "Agregar";
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
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                txtDescripcion.Text = "";
                txtMonto.Text = "";
                btnPagar.Text = "Agregar";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void chkPagar_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ListarCuotasSocios();
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ListarCuotasSocios();
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {

        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult drPagar = new DialogResult();
                IServicePolicial lNF = new ServicePolicialClient();
                bool hayErrores = false;

                if (!hayErrores)
                {
                    int totalSeleccion = dgvSocios.Rows.Cast<DataGridViewRow>().
                   Where(p => Convert.ToBoolean(p.Cells["Generar"].Value)).Count();
                    if (totalSeleccion > 0)
                    {
                        drPagar = MessageBox.Show("Confirma generar " + totalSeleccion + " cuotas seleccionadas?",
                             "Generar seleccion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    }

                    if (drPagar == DialogResult.OK)
                    {
                        foreach (DataGridViewRow row in dgvSocios.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells["Generar"].Value))
                            {
                                Usuario usuario = Program.usuarioLogueado;
                                Cuota cuota = new Cuota();
                                cuota.SocId = Convert.ToInt32(row.Cells["Socio"].Value);
                                //cuota.CuotaFechaDesde = Convert.ToDateTime(dtpEmision.Value);
                                //cuota.CuotaFechaHasta = Convert.ToDateTime(dtpVencimiento.Value);
                                int tipo = DevolverCategoriaDescrip(row.Cells["TipoCuota"].Value.ToString());
                                cuota.CuotaTipo = tipo;
                                cuota.CuotaPaga = true;
                                //cuota.CuotaAAAAMM = comboBox1.SelectedItem.ToString() + "/" + comboBox2.SelectedItem.ToString();

                                bool retorno = PersistirCuota(cuota, usuario);
                                if (retorno)
                                    MessageBox.Show("Se crearon " + totalSeleccion + " seleccionadas.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                    MessageBox.Show("No se pudo generar seleccion.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }
                    else
                        MessageBox.Show("Seleccione Socio para generar cuotas.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
