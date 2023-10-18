//using EntidadesCompartidas;
//using Logica;
using Policial.ServicePolicial;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

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
            btnAgregar.Text = "Agregar";
            label1.ForeColor = RGBColors.color;
            label10.ForeColor = RGBColors.color;
            button1.BackColor = RGBColors.color;
            btnAgregar.BackColor = RGBColors.color;
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
                                    string estado = c.CuotaPaga ? "Paga" : "Impaga";
                                    string tipoCuota = DevolverCategoria(Convert.ToInt32(c.CuotaTipo));
                                    if (imprimirTodo)
                                        dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre + " " + s.SocSegundoNombre,
                                            s.SocPrimerApellido + " " + s.SocSegundoApellido, c.CuotaId, tipoCuota, c.CuotaAAAAMM, estado, true);
                                    else
                                        dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre + " " + s.SocSegundoNombre,
                                            s.SocPrimerApellido + " " + s.SocSegundoApellido, c.CuotaId, tipoCuota, c.CuotaAAAAMM,estado);
                                }
                            }
                        }
                        if (listaCuotas.Count > 0 && !soloCuotasImpagas)
                        {
                            foreach (Cuota c in listaCuotas)
                            {
                                string estado = c.CuotaPaga ? "Paga" : "Impaga";
                                string tipoCuota = DevolverCategoria(Convert.ToInt32(c.CuotaTipo));
                                if (imprimirTodo)
                                    dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre + " " + s.SocSegundoNombre,
                                            tipoCuota, c.CuotaId, tipoCuota,c.CuotaAAAAMM, estado);
                                else
                                    dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre + " " + s.SocSegundoNombre,
                                            s.SocPrimerApellido + " " + s.SocSegundoApellido, c.CuotaId, tipoCuota, c.CuotaAAAAMM, estado);
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
                        btnAgregar.Text = "Modificar";
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
                        btnAgregar.Text = "Eliminar";
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
                if (btnAgregar.Text == "Agregar")
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
                if (btnAgregar.Text == "Modificar")
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
                                btnAgregar.Text = "Agregar";
                            }
                            else
                            {
                                mensaje = "No se modifico la información.";
                                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                btnAgregar.Text = "Agregar";
                            }
                        }
                    }
                }
                #endregion
                #region Eliminar
                if (btnAgregar.Text == "Eliminar")
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
                            btnAgregar.Text = "Agregar";
                        }
                        else
                        {
                            mensaje = "No se elimino la información.";
                            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            btnAgregar.Text = "Agregar";
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
                   Where(p => Convert.ToBoolean(p.Cells["Pagar"].Value)).Count();
                    if (totalSeleccion > 0)
                    {
                        drPagar = MessageBox.Show("Confirma pagar " + totalSeleccion + " cuotas seleccionadas?",
                             "Generar seleccion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    }

                    if (drPagar == DialogResult.OK)
                    {
                        bool retorno = false;

                        foreach (DataGridViewRow row in dgvSocios.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells["Pagar"].Value))
                            {
                                Usuario usuario = Program.usuarioLogueado;
                                Cuota cuota = new Cuota();
                                cuota.SocId = Convert.ToInt32(row.Cells["SocId"].Value);
                                cuota.CuotaId = Convert.ToInt32(row.Cells["CuotaId"].Value);
                                int tipo = DevolverCategoriaDescrip(row.Cells["TipoCuota"].Value.ToString());
                                cuota.CuotaTipo = tipo;
                                cuota.CuotaPaga = true;
                                cuota.CuotaAAAAMM = row.Cells["CuotaAAAAMM"].Value.ToString();

                                retorno = PagarCuota(cuota, usuario);
                                if (retorno == false)
                                    MessageBox.Show("No se pudo pagar cuota: " + cuota.CuotaId + " del Socio " + cuota.SocId, titulo, 
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                        if (retorno)
                        {
                            MessageBox.Show("Se marcaron " + totalSeleccion + " cuotas pagas.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ListarCuotasSocios();
                        }
                        else
                            MessageBox.Show("No se pudo pagar seleccion.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                        MessageBox.Show("Seleccione cuotas para pagar.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtParametro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                IServicePolicial lc = new ServicePolicialClient();
                IServicePolicial ls = new ServicePolicialClient();
                List<Cuota> listaCuotas = new List<Cuota>();
                List<Socio> listaSocios = new List<Socio>();
                listaSocios = ls.ListarSocios().ToList();
                bool soloCuotasImpagas = checkBox1.Checked ? true : false;

                var _resultado = (from unSocio in listaSocios
                                  where unSocio.SocId.ToString().ToUpper().Contains(txtParametro.Text.ToUpper()) ||
                                  unSocio.SocCI.ToString().ToUpper().Contains(txtParametro.Text.ToUpper()) ||
                                  unSocio.SocPrimerNombre.ToString().ToUpper().Contains(txtParametro.Text.ToUpper()) ||
                                  unSocio.SocPrimerApellido.ToString().ToUpper().Contains(txtParametro.Text.ToUpper()) ||
                                  unSocio.SocDireccion.ToString().ToUpper().Contains(txtParametro.Text.ToUpper()) ||
                                  unSocio.SocTipoCuota.ToString().ToUpper().Contains(txtParametro.Text.ToUpper()) ||
                                  unSocio.SocSegundoApellido.ToString().ToUpper().Contains(txtParametro.Text.ToUpper())
                                  select new Socio
                                  {
                                      SocId = unSocio.SocId,
                                      SocCI = unSocio.SocCI,
                                      SocPrimerNombre = unSocio.SocPrimerNombre,
                                      SocPrimerApellido = unSocio.SocPrimerApellido,
                                      SocSegundoNombre = unSocio.SocSegundoNombre,
                                      SocSegundoApellido = unSocio.SocSegundoApellido,
                                      SocFechaNacimiento = unSocio.SocFechaNacimiento,
                                      SocFechaIngreso = unSocio.SocFechaIngreso,
                                      SocDireccion = unSocio.SocDireccion,
                                      SocEmail = unSocio.SocEmail,
                                      SocTel = unSocio.SocTel,
                                      SocCelular = unSocio.SocCelular,
                                      SocAtivo = unSocio.SocAtivo,
                                      SocTipoCuota = unSocio.SocTipoCuota,
                                  }).ToList();

                dgvSocios.Rows.Clear();

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
                                    dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre + " " + s.SocSegundoNombre,
                                            s.SocPrimerApellido + " " + s.SocSegundoApellido, c.CuotaId, c.CuotaAAAAMM, "Impaga");
                                if (c.CuotaPaga)
                                    dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre + " " + s.SocSegundoNombre,
                                            s.SocPrimerApellido + " " + s.SocSegundoApellido, c.CuotaId, c.CuotaAAAAMM, "Paga");
                            }
                        }
                    }
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
