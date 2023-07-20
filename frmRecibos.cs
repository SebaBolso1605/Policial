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
        public string titulo = "Cuotas Socios";
        public string mensaje = "";
        public bool pagar = false;
        public frmRecibos()
        {
            InitializeComponent();
            btnBuscarNF.BackColor = RGBColors.color3;
            btnCancelarNF.BackColor = RGBColors.color3;
            btnGuardarNF.BackColor = RGBColors.color3;
            label1.ForeColor = RGBColors.color3;
            CargoTC();
            btnGuardarNF.Text = "Agregar";
            cmbMes.Enabled = true;
            cmbAño.Enabled = true;
            dtpDesde.Enabled = true;
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
        private void CargoTC()
        {
            try
            {
                List<TipoCuota> listaTC = new List<TipoCuota>();
                cmbCategoria.Items.Clear();
                //ILogicaSocio tipoCuota = FabricaLogica.getLogicaSocio();
                IServicePolicial tipoCuota = new ServicePolicialClient();
                listaTC = tipoCuota.ListarTC().ToList();
                cmbCategoria.Items.Add("Seleccionar");

                foreach (TipoCuota e in listaTC)
                {
                    cmbCategoria.Items.Add(e.TCDescripcion.Trim() + "   - Monto: $" + e.TCMonto);
                }

                cmbCategoria.SelectedIndex = 0;
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
                //ILogicaSocio tipoCuota = FabricaLogica.getLogicaSocio();
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
        private void btnBuscarNF_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                dgvSociosNF.Rows.Clear();
                //ILogicaCuota lSocioNF = FabricaLogica.getLogicaCuota();
                //ILogicaSocio lSocio = FabricaLogica.getLogicaSocio();
                IServicePolicial lSocioNF = new ServicePolicialClient();
                IServicePolicial lSocio = new ServicePolicialClient();
                List<Cuota> socListaNF = new List<Cuota>();
                Cuota nf = new Cuota();
                Socio soc = new Socio();
                cmbAño.SelectedIndex = -1;
                cmbMes.SelectedIndex = -1;
                btnGuardarNF.Text = "Agregar";
                cmbMes.Enabled = true;
                cmbAño.Enabled = true;
                dtpDesde.Enabled = true;
                if (!string.IsNullOrEmpty(txtBuscarCuota.Text))
                {
                    int ci = Convert.ToInt32(txtBuscarCuota.Text);
                    soc = lSocio.BuscarSocioPorCI(ci);
                    if (soc != null)
                    {
                        txtSocIdNF.Text = Convert.ToString(soc.SocId);
                        txtNombreSocNF.Text = soc.SocPrimerNombre + " " + soc.SocPrimerApellido;
                        cmbCategoria.SelectedIndex = soc.SocTipoCuota;
                        socListaNF = lSocioNF.BuscarCuotasSocio(soc.SocId).ToList();

                        if (socListaNF != null && socListaNF.Count > 0)
                        {
                            socListaNF.OrderBy(x => x.CuotaId).Reverse().ToList();
                            foreach (Cuota c in socListaNF)
                            {
                                string paga = c.CuotaPaga == true ? "Paga" : "Impaga";
                                string tipoCuota = "";
                                string fechaPago = "";

                                if (c.CuotaTipo > 0)
                                    tipoCuota = DevolverCategoria(c.CuotaTipo);

                                if (c.CuotaFechaPaga == DateTime.MinValue)
                                    fechaPago = "";
                                else
                                    fechaPago = c.CuotaFechaPaga.ToShortDateString();
                                dgvSociosNF.Rows.Add(c.SocId, c.CuotaId, c.CuotaFechaDesde.ToShortDateString(), tipoCuota.ToString(),
                                paga, c.CuotaAAAAMM.ToString(),fechaPago, "Pagar");
                                pagar = false;
                            } 
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se encontro socio para la cedula ingresada.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtBuscarCuota.Focus();
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void rbtPaga_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbtPaga.Checked)
                    groupBox1.Enabled = true;
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private bool PersistirCuota(Cuota c, Usuario usu)
        {
            bool resp = false;
            try
            {
                //ILogicaCuota FSocio = FabricaLogica.getLogicaCuota();
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
                //ILogicaCuota FSocio = FabricaLogica.getLogicaCuota();
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
        private bool HayError()
        {
            #region Controlo errores campos
            bool error = false;
            if (rbtPaga.Checked) 
            {
                if (dtpFEchaCuotaPaga.Value.Date > DateTime.Now.Date)  
                {
                    errorProvider.SetError(label11, "Seleccione fecha pago.");
                    error = true;
                }      
            }

            if (cmbAño.SelectedIndex == -1 || cmbMes.SelectedIndex == -1)
            {
                errorProvider.SetError(label7, "Seleccione mes/año para la cuota.");
                error = true;
            }   

            if (dtpDesde.Value.Date > DateTime.Now.Date)
             {
                errorProvider.SetError(label22, "Seleccione fecha de emisión .");
                error = true;
             }
            return error;
            #endregion
        }
        private void btnGuardarNF_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                //ILogicaCuota lNF = FabricaLogica.getLogicaCuota();
                IServicePolicial lNF = new ServicePolicialClient();
                Cuota cuota = new Cuota();
                Usuario _usu = Program.usuarioLogueado;
                bool resultado = false;
                bool ret = HayError();
                
                #region Agregar
                if (btnGuardarNF.Text == "Agregar")
                {
                    if (ret == false)
                    {
                        cuota.SocId = Convert.ToInt32(txtSocIdNF.Text.Trim());
                        cuota.CuotaFechaDesde = dtpDesde.Value;
                        cuota.CuotaPaga = true ? rbtPaga.Checked == true : rbtPaga.Checked == false;
                        if (rbtPaga.Checked)
                            cuota.CuotaFechaPaga = dtpFEchaCuotaPaga.Value;
                        cuota.CuotaAAAAMM = cmbMes.SelectedItem + "/" + cmbAño.SelectedItem;
                        cuota.CuotaTipo = cmbCategoria.SelectedIndex;
                        cuota.FecAlta = DateTime.Now;
                        cuota.FecModif = DateTime.Now;
                        cuota.UsuIdAlta = Program.usuarioLogueado.UsuId;
                        cuota.UsuIdModif = Program.usuarioLogueado.UsuId;
                    }

                    if (cuota != null)
                    {
                        resultado = PersistirCuota(cuota, _usu);

                        if (resultado)
                        {
                            mensaje = "La información se guardó correctamente.";
                            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            string paga = cuota.CuotaPaga == true ? "Paga" : "Impaga";
                            string tipoCuota = "";
                            string fechaPago = "";

                            if (cuota.CuotaFechaPaga.ToString() == "1/1/0001")
                                fechaPago = "";
                            else
                                fechaPago = cuota.CuotaFechaPaga.ToShortDateString();
                            tipoCuota = DevolverCategoria(cuota.CuotaTipo);

                            dgvSociosNF.Rows.Add(cuota.SocId, cuota.CuotaId, cuota.CuotaFechaDesde.ToShortDateString(), tipoCuota,
                            paga, cuota.CuotaAAAAMM.ToString(), fechaPago, "Pagar");

                            dtpDesde.Value = DateTime.Now;
                            rbtPaga.Checked = false;
                            txtSocIdNF.Text = "";
                            txtNombreSocNF.Text = "";
                            cmbCategoria.SelectedIndex = -1;
                            cmbAño.SelectedIndex = -1;
                            cmbMes.SelectedIndex = -1;
                        }
                        else
                        {
                            mensaje = "No se guardó la información.";
                            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                #endregion

                #region Pagar
                if (btnGuardarNF.Text == "Pagar")
                {
                    errorProvider.Clear();
                    cuota.CuotaId = Convert.ToInt32(txtNFId.Text);
                    cuota.SocId = Convert.ToInt32(txtSocIdNF.Text.Trim());
                    cuota.CuotaPaga = true ? rbtPaga.Checked == true : rbtPaga.Checked == false;
                    if (rbtPaga.Checked)
                        cuota.CuotaFechaPaga = dtpFEchaCuotaPaga.Value;
                    cuota.CuotaAAAAMM = cmbMes.SelectedItem + "/" + cmbAño.SelectedItem;                   
                    cuota.FecModif = DateTime.Now;
                    cuota.UsuIdModif = Program.usuarioLogueado.UsuId;

                    if (cuota != null)
                    {
                        resultado = PagarCuota(cuota, _usu);

                        if (resultado)
                        {
                            mensaje = "La información se guardó correctamente.";
                            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            List<Cuota> lSocioNF = new List<Cuota>();
                            lSocioNF = lNF.BuscarCuotasSocio(Convert.ToInt32(txtBuscarCuota.Text)).ToList();

                            if (lSocioNF != null && lSocioNF.Count > 0)
                            {
                                lSocioNF.OrderBy(x => x.CuotaId).Reverse().ToList();
                                foreach (Cuota c in lSocioNF)
                                {
                                    string paga = c.CuotaPaga == true ? "Paga" : "Impaga";
                                    string tipoCuota = "";
                                    string fechaPago = "";

                                    if (c.CuotaTipo > 0)
                                        tipoCuota = DevolverCategoria(c.CuotaTipo);

                                    if (c.CuotaFechaPaga == DateTime.MinValue)
                                        fechaPago = "";
                                    else
                                        fechaPago = c.CuotaFechaPaga.ToShortDateString();
                                    dgvSociosNF.Rows.Add(c.SocId, c.CuotaId, c.CuotaFechaDesde.ToShortDateString(), tipoCuota.ToString(),
                                    paga, c.CuotaAAAAMM.ToString(), fechaPago, "Pagar");
                                }
                            }

                            dtpDesde.Value = DateTime.Now;
                            rbtPaga.Checked = false;
                            txtSocIdNF.Text = "";
                            txtNombreSocNF.Text = "";
                            cmbCategoria.SelectedIndex = -1;
                            cmbAño.SelectedIndex = -1;
                            cmbMes.SelectedIndex = -1;
                            cmbMes.Enabled = true;
                            cmbAño.Enabled = true;
                            dtpDesde.Enabled = true;
                            errorProvider.Clear();
                        }
                        else
                        {
                            mensaje = "No se guardó la información.";
                            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            dtpDesde.Value = DateTime.Now;
                            rbtPaga.Checked = false;
                            txtSocIdNF.Text = "";
                            txtNombreSocNF.Text = "";
                            cmbCategoria.SelectedIndex = -1;
                            cmbAño.SelectedIndex = -1;
                            cmbMes.SelectedIndex = -1;
                            cmbMes.Enabled = true;
                            cmbAño.Enabled = true;
                            dtpDesde.Enabled = true;
                            errorProvider.Clear();
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            } 
        }
        private void dgvSociosNF_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 7) //pagar
                {
                    var filaSeleccionada = dgvSociosNF.CurrentRow;
                    if (dgvSociosNF.SelectedRows != null)
                    {
                        int id = Convert.ToInt32(filaSeleccionada.Cells[0].Value);
                        rbtPaga.Checked = true;
                        dtpFEchaCuotaPaga.Focus();
                        char delimitador = '/';

                        txtSocIdNF.Text = filaSeleccionada.Cells["SocId"].Value.ToString();
                        txtNFId.Text = filaSeleccionada.Cells["CuotaId"].Value.ToString();
                        dtpDesde.Value = Convert.ToDateTime(filaSeleccionada.Cells["CuotaFechaDesde"].Value);
                        cmbCategoria.SelectedText = filaSeleccionada.Cells["TipoCuenta"].Value.ToString().Trim();
                        string edad = filaSeleccionada.Cells["Paga"].Value.ToString();
                        string cadena = filaSeleccionada.Cells["MesAño"].Value.ToString();

                        string[] añomes = cadena.Split(delimitador);
                        string mes = añomes[0].ToString();
                        string año = añomes[1].ToString();
                        cmbAño.SelectedText = año.ToString();
                        cmbMes.SelectedText = mes.ToString();
                        cmbMes.Enabled = false;
                        cmbAño.Enabled = false;
                        dtpDesde.Enabled = false;
                        btnGuardarNF.Text = "Pagar";
                    }
                    else
                    {
                        MessageBox.Show("Seleccione linea de la grilla.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtBuscarCuota.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
