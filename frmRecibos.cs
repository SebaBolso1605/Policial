//using EntidadesCompartidas;
using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using Policial.ServicePolicial;

namespace Policial
{
    public partial class frmRecibos : Form
    {
        #region Atributos/VAriables
        public string titulo = "Cuotas Socios";
        public string mensaje = "";
        public bool pagar = false;
        private List<Socio> listaSocios;
        #endregion
        #region Metodos
        public frmRecibos()
        {
            InitializeComponent();
            btnGenerar.BackColor = RGBColors.color3;
            btnVolver.BackColor = RGBColors.color3;
            lblTituloFormulario.ForeColor = RGBColors.color3;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            CargoGrillaSocios();
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
        private bool HayErrorGenerar()
        {
            #region Controlo errores campos
            bool error = false;

            if (dtpEmision.Value.Date > DateTime.Now.Date)
            {
                errorProvider.SetError(label9, "Seleccione de emisión.");
                error = true;
            }

            if (dtpVencimiento.Value.Date < DateTime.Now.Date && dtpVencimiento.Value.Date > dtpEmision.Value.Date)
            {
                errorProvider.SetError(label12, "Seleccione de vencimiento.");
                error = true;
            }

            if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
            {
                errorProvider.SetError(label17, "Seleccione mes/año para la cuota.");
                error = true;
            }
            return error;
            #endregion
        }
        private void CargoGrillaSocios()
        {
            try
            {
                IServicePolicial FSocio = new ServicePolicialClient();
                listaSocios = FSocio.ListarSocios().ToList();
                bool socioActivo = checkBox1.Checked ? true : false;
                bool marcarTodos = chkTodos.Checked ? true : false;
                if (socioActivo)
                {
                    var _resultado = (from unSocio in listaSocios
                                      where unSocio.SocAtivo == socioActivo
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

                    if (listaSocios != null)
                    {
                        foreach (Socio s in _resultado)
                        {
                            string tipoSocio = DevolverCategoria(s.SocTipoCuota);
                            string estado = s.SocAtivo ? "Activo" : "Inactivo";
                            if (marcarTodos)
                                dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre + " " + s.SocSegundoNombre, s.SocPrimerApellido + " " + s.SocSegundoApellido,
                                    tipoSocio, s.SocDireccion, s.SocTel, s.SocCelular, estado, true);
                            else
                                dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre + " " + s.SocSegundoNombre, s.SocPrimerApellido + " " + s.SocSegundoApellido,
                                    tipoSocio, s.SocDireccion, s.SocTel, s.SocCelular, estado, false);
                        }
                    }
                }
                else
                {
                    var _resultado = (from unSocio in listaSocios
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

                    if (listaSocios != null)
                    {
                        foreach (Socio s in _resultado)
                        {
                            string tipoSocio = DevolverCategoria(s.SocTipoCuota);
                            string estado = s.SocAtivo ? "Activo" : "Inactivo";
                            if (marcarTodos)
                                dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre + " " + s.SocSegundoNombre,
                                s.SocPrimerApellido + " " + s.SocSegundoApellido, tipoSocio, s.SocDireccion, s.SocTel, s.SocCelular, estado, true);
                            else
                                dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre + " " + s.SocSegundoNombre,
                                s.SocPrimerApellido + " " + s.SocSegundoApellido, tipoSocio, s.SocDireccion, s.SocTel, s.SocCelular, estado, false);
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
        #endregion
        #region Eventos
        private void btnVolver_Click(object sender, EventArgs e)
        {
            try
            {
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                CargoGrillaSocios();

            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnBuscarNF_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    errorProvider.Clear();
            //    dgvSociosNF.Rows.Clear();
            //    //ILogicaCuota lSocioNF = FabricaLogica.getLogicaCuota();
            //    //ILogicaSocio lSocio = FabricaLogica.getLogicaSocio();
            //    IServicePolicial lSocioNF = new ServicePolicialClient();
            //    IServicePolicial lSocio = new ServicePolicialClient();
            //    List<Cuota> socListaNF = new List<Cuota>();
            //    Cuota nf = new Cuota();
            //    Socio soc = new Socio();
            //    cmbAño.SelectedIndex = -1;
            //    cmbMes.SelectedIndex = -1;
            //    btnGuardarNF.Text = "Agregar";
            //    cmbMes.Enabled = true;
            //    cmbAño.Enabled = true;
            //    dtpDesde.Enabled = true;
            //    if (!string.IsNullOrEmpty(txtBuscarCuota.Text))
            //    {
            //        int ci = Convert.ToInt32(txtBuscarCuota.Text);
            //        soc = lSocio.BuscarSocioPorCI(ci);
            //        if (soc != null)
            //        {
            //            txtSocIdNF.Text = Convert.ToString(soc.SocId);
            //            txtNombreSocNF.Text = soc.SocPrimerNombre + " " + soc.SocPrimerApellido;
            //            cmbCategoria.SelectedIndex = soc.SocTipoCuota;
            //            socListaNF = lSocioNF.BuscarCuotasSocio(soc.SocId).ToList();

            //            if (socListaNF != null && socListaNF.Count > 0)
            //            {
            //                socListaNF.OrderBy(x => x.CuotaId).Reverse().ToList();
            //                foreach (Cuota c in socListaNF)
            //                {
            //                    string paga = c.CuotaPaga == true ? "Paga" : "Impaga";
            //                    string tipoCuota = "";
            //                    string fechaPago = "";

            //                    if (c.CuotaTipo > 0)
            //                        tipoCuota = DevolverCategoria(c.CuotaTipo);

            //                    if (c.CuotaFechaPaga == DateTime.MinValue)
            //                        fechaPago = "";
            //                    else
            //                        fechaPago = c.CuotaFechaPaga.ToShortDateString();
            //                    dgvSociosNF.Rows.Add(c.SocId, c.CuotaId, c.CuotaFechaDesde.ToShortDateString(), tipoCuota.ToString(),
            //                    paga, c.CuotaAAAAMM.ToString(),fechaPago, "Pagar");
            //                    pagar = false;
            //                } 
            //            }
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("No se encontro socio para la cedula ingresada.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        txtBuscarCuota.Focus();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    string mensaje = ex.Message;
            //    MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }
        private void btnGuardarNF_Click(object sender, EventArgs e)
        {}
        private void dgvSociosNF_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 7) //pagar
                {
                    //var filaSeleccionada = dgvSociosNF.CurrentRow;
                    //if (dgvSociosNF.SelectedRows != null)
                    //{
                    //    int id = Convert.ToInt32(filaSeleccionada.Cells[0].Value);
                    //    rbtPaga.Checked = true;
                    //    dtpFEchaCuotaPaga.Focus();
                    //    char delimitador = '/';

                    //    txtSocIdNF.Text = filaSeleccionada.Cells["SocId"].Value.ToString();
                    //    txtNFId.Text = filaSeleccionada.Cells["CuotaId"].Value.ToString();
                    //    dtpDesde.Value = Convert.ToDateTime(filaSeleccionada.Cells["CuotaFechaDesde"].Value);
                    //    cmbCategoria.SelectedText = filaSeleccionada.Cells["TipoCuenta"].Value.ToString().Trim();
                    //    string edad = filaSeleccionada.Cells["Paga"].Value.ToString();
                    //    string cadena = filaSeleccionada.Cells["MesAño"].Value.ToString();

                    //    string[] añomes = cadena.Split(delimitador);
                    //    string mes = añomes[0].ToString();
                    //    string año = añomes[1].ToString();
                    //    cmbAño.SelectedText = año.ToString();
                    //    cmbMes.SelectedText = mes.ToString();
                    //    cmbMes.Enabled = false;
                    //    cmbAño.Enabled = false;
                    //    dtpDesde.Enabled = false;
                    //    btnGuardarNF.Text = "Pagar";
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Seleccione linea de la grilla.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    txtBuscarCuota.Focus();
                    //}
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void txtParametro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                IServicePolicial FSocio = new ServicePolicialClient();
                listaSocios = FSocio.ListarSocios().ToList();
                bool socioActivo = checkBox1.Checked ? true : false;
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
                if (listaSocios != null)
                {
                    foreach (Socio s in _resultado)
                    {
                        string estado = s.SocAtivo ? "Activo" : "Inactivo";
                        string tipoSocio = DevolverCategoria(s.SocTipoCuota);
                        dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre + " " + s.SocSegundoNombre, s.SocPrimerApellido + " " + s.SocSegundoApellido,
                            tipoSocio, s.SocDireccion, s.SocTel, s.SocCelular, estado, true);
                    }
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void comboBox2_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void comboBox1_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult drPagar = new DialogResult();
                IServicePolicial lNF = new ServicePolicialClient();
                bool hayErrores = HayErrorGenerar();
                
                if(!hayErrores)
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
                                cuota.CuotaFechaDesde = Convert.ToDateTime(dtpEmision.Value);
                                cuota.CuotaFechaHasta = Convert.ToDateTime(dtpVencimiento.Value);
                                int tipo = DevolverCategoriaDescrip(row.Cells["TipoCuota"].Value.ToString());
                                cuota.CuotaTipo = tipo;    
                                cuota.CuotaPaga = false;
                                cuota.CuotaAAAAMM = comboBox2.SelectedItem.ToString() + "/" + comboBox1.SelectedItem.ToString();

                                bool retorno = PersistirCuota(cuota, usuario);
                                if(retorno)
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
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txtParametro.Text = "";
                CargoGrillaSocios();
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CargoGrillaSocios();
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
