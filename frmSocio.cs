﻿using System;
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
    public partial class frmSocio : Form
    {
        #region Variables
        private string titulo = "Gestión de Socios";
        private string mensaje = "";
        public List<TipoCuota> listaTC;
        private Socio socio;
        private Cuota cuota;
        private List<Socio> listaSocios;
        #endregion
        public frmSocio()
        {
            InitializeComponent();
            ColorFrm();
            CargoTC();
            CargoGrillaSocios();
        }
        #region Eventos
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
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
                bool res = HayError();
                errorProvider.Clear();
                DialogResult resul = MessageBox.Show("¿Confirma guardar los cambios?", titulo, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (resul == DialogResult.OK)
                {
                    Usuario _usu = Program.usuarioLogueado;
                    bool resultado = false;
                    CreoSocio();

                    if (socio != null)
                        resultado = PersistirSocio(socio, cuota, _usu);

                    if (resultado)
                    {
                        mensaje = "La información del Socio se guardó exitosamente.";
                        MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPrimerApellido.Text = "";
                        txtSegundoApellido.Text = "";
                        txtPrimerNombre.Text = "";
                        txtSegundoNombre.Text = "";
                        txtCI.Text = "";
                        txtCelular.Text = "";
                        txtTel.Text = "";
                        txtDireccion.Text = "";
                        txtEmail.Text = "";
                        txtObservaciones.Text = "";
                        cmbTC.SelectedIndex = -1;
                    }
                    else
                    {
                        mensaje = "No se guardó la información del Socio.";
                        MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void cmbTC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void cmbTC_SelectedValueChanged(object sender, EventArgs e)
        {

        }
        private void txtCI_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtCI.Text.Trim().Length >= 10)
                {
                    throw new Exception("Largo maximo para el documento - 9 digitos.");
                }
                else if (txtCI.Text.Trim() != "")
                {
                    try
                    {
                        ulong.Parse(txtCI.Text.Trim());
                    }
                    catch (Exception)
                    {
                        throw new Exception("El documento debe ser numérico.");
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                ILogicaSocio FSocio = FabricaLogica.getLogicaSocio();
                listaSocios = FSocio.ListarSocios();

                if (txtParametro.Text != "")
                {

                }
                if (listaSocios.Count > 0)
                {
                    foreach (Socio s in listaSocios)
                    {
                        dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre + " " + s.SocSegundoNombre, s.SocPrimerApellido + " " + s.SocSegundoApellido,
                            s.SocTel);
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ILogicaSocio FSocio = FabricaLogica.getLogicaSocio();
                listaSocios = FSocio.ListarSocios();
                bool socioActivo = checkBox1.Checked ? true : false;
                var _resultado = (from unSocio in listaSocios
                                  where unSocio.SocId.ToString().ToUpper().Contains(txtParametro.Text.ToUpper()) ||
                                  unSocio.SocCI.ToString().ToUpper().Contains(txtParametro.Text.ToUpper()) ||
                                  unSocio.SocPrimerNombre.ToString().ToUpper().Contains(txtParametro.Text.ToUpper()) ||
                                  unSocio.SocPrimerApellido.ToString().ToUpper().Contains(txtParametro.Text.ToUpper()) ||
                                  unSocio.SocDireccion.ToString().ToUpper().Contains(txtParametro.Text.ToUpper()) ||
                                  unSocio.SocSegundoApellido.ToString().ToUpper().Contains(txtParametro.Text.ToUpper())
                                  select new Socio
                                  {
                                      //agragar comentario
                                      SocId = unSocio.SocId,
                                      //SocId = unSocio.SocId,
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
                                  }).ToList();

                dgvSocios.Rows.Clear();
                if (listaSocios != null)
                {
                    foreach (Socio s in _resultado)
                    {
                        string estado = s.SocAtivo ? "Activo" : "Inactivo";
                        dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre, s.SocPrimerApellido, s.SocDireccion, s.SocTel, s.SocCelular, estado,"Editar");
                    }
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void button1_Click_2(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                ILogicaSocio lSocio = FabricaLogica.getLogicaSocio();
                Socio soc = null;
                if (!string.IsNullOrEmpty(txtBuscarModif.Text))
                {
                    int ci = Convert.ToInt32(txtBuscarModif.Text);
                    soc = lSocio.BuscarSocioPorCI(ci);
                    if (soc != null)
                    {
                        txtPrimerApellidoModif.Text = soc.SocPrimerApellido;
                        txtPrimerNombreModif.Text = soc.SocPrimerNombre;
                        txtSegundoApellidoModif.Text = soc.SocSegundoApellido;
                        txtSegundoNombreModif.Text = soc.SocSegundoNombre;
                        txtCIModif.Text = soc.SocCI.ToString();
                        txtEmailModif.Text = soc.SocEmail;
                        txtDireccionModif.Text = soc.SocDireccion;
                        txtTelModif.Text = soc.SocTel;
                        txtCelularModif.Text = soc.SocCelular;
                        txtObservacionesModif.Text = soc.SocObservaciones;
                        cmbTPModif.SelectedItem = soc.SocTipoCuota;
                    }
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnModificarSocio_Click(object sender, EventArgs e)
        {
            try
            {
                ILogicaSocio lSocio = FabricaLogica.getLogicaSocio();
                Socio soc = new Socio();
                if (!string.IsNullOrEmpty(txtBuscarModif.Text))
                {
                    int ci = Convert.ToInt32(txtBuscarModif.Text);
                    bool ret = HayErrorModif();
                    if (ret == false)
                    {
                        soc.SocCI = ci;
                        soc.SocPrimerNombre = txtPrimerNombreModif.Text;
                        soc.SocPrimerApellido = txtPrimerApellidoModif.Text;
                        soc.SocSegundoApellido = txtSegundoApellidoModif.Text;

                        if (!string.IsNullOrEmpty(txtSegundoNombreModif.Text))
                            soc.SocSegundoNombre = txtSegundoNombreModif.Text;
                        else
                            soc.SocSegundoNombre = "";

                        if (!string.IsNullOrEmpty(txtEmailModif.Text))
                            soc.SocEmail = txtEmailModif.Text;
                        else
                            soc.SocEmail = "";

                        if (!string.IsNullOrEmpty(txtDireccionModif.Text))
                            soc.SocDireccion = txtDireccionModif.Text;
                        else
                            soc.SocDireccion = "";

                        if (!string.IsNullOrEmpty(txtCelularModif.Text))
                            soc.SocCelular = txtCelularModif.Text;
                        else
                            soc.SocCelular = "";

                        if (!string.IsNullOrEmpty(txtTelModif.Text))
                            soc.SocTel = txtTelModif.Text;
                        else
                            soc.SocTel = "";

                        if (!string.IsNullOrEmpty(txtObservacionesModif.Text))
                            soc.SocObservaciones = txtObservacionesModif.Text;
                        else
                            soc.SocObservaciones = "";

                        lSocio.ModificarSocio(soc, Program.usuarioLogueado);
                    }
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                ILogicaSocio lSocio = FabricaLogica.getLogicaSocio();
                Socio soc = null;
                if (!string.IsNullOrEmpty(txtBuscarEliminar.Text))
                {
                    int ci = Convert.ToInt32(txtBuscarEliminar.Text);
                    soc = lSocio.BuscarSocioPorCI(ci);
                    if (soc != null)
                    {
                        txtPrimerApellidoBaja.Text = soc.SocPrimerApellido;
                        txtPrimerNombreBaja.Text = soc.SocPrimerNombre;
                        txtSegundoApellidoBaja.Text = soc.SocSegundoApellido;
                        txtCiBaja.Text = soc.SocCI.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("No existe socio con esa cedula.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnEliminarSocio_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                bool resp = false;
                ILogicaSocio lSocio = FabricaLogica.getLogicaSocio();
                Socio soc = new Socio();

                if (!string.IsNullOrEmpty(txtBuscarEliminar.Text))
                {
                    int ci = Convert.ToInt32(txtBuscarEliminar.Text);
                    soc.SocCI = ci;
                    if (!string.IsNullOrEmpty(txtMotivoBaja.Text))
                        soc.SocMotivoEgreso = txtMotivoBaja.Text;
                    else
                        soc.SocMotivoEgreso = " ";

                    soc.SocFechaEgreso = dtpFechaBaja.Value;

                    resp = lSocio.BajaSocio(soc);
                    if (resp)
                    {
                        MessageBox.Show("Se dio de baja correctamente al socio.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPrimerApellidoBaja.Text = "";
                        txtPrimerNombreBaja.Text = "";
                        txtSegundoApellidoBaja.Text = "";
                        txtCiBaja.Text = "";
                        txtBuscarEliminar.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("No dio de baja correctamente al socio.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPrimerApellidoBaja.Text = "";
                        txtPrimerNombreBaja.Text = "";
                        txtSegundoApellidoBaja.Text = "";
                        txtCiBaja.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("No se econtro socio.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void txtBuscarModif_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtBuscarModif_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtCIModif.Text.Trim().Length >= 10)
                {
                    throw new Exception("Largo maximo para el documento - 9 digitos.");
                }
                else if (txtCIModif.Text.Trim() != "")
                {
                    try
                    {
                        ulong.Parse(txtCIModif.Text.Trim());
                    }
                    catch (Exception)
                    {
                        throw new Exception("El documento debe ser numérico.");
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            CargoGrillaSocios();
        }
        private void btnVolver_Click(object sender, EventArgs e)
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
        #endregion
        #region Metodos
        private bool HayError()
        {
            #region Controlo errores campos
            bool error = false;
            if (cmbTC.SelectedIndex == 0)
            {
                errorProvider.SetError(label20, "Seleccione categoria.");
                error = true;
            }
            if (string.IsNullOrEmpty(txtPrimerApellido.Text.Trim()))
            {
                errorProvider.SetError(label12, "Ingrese Primer Apellido.");
                error = true;
            }
            if (string.IsNullOrEmpty(txtSegundoApellido.Text.Trim()))
            {
                errorProvider.SetError(label11, "Ingrese Segundo Apellido.");
                error = true;
            }
            if (string.IsNullOrEmpty(txtPrimerNombre.Text.Trim()))
            {
                errorProvider.SetError(label9, "Ingrese Primer Nombre.");
                error = true;
            }
            if (string.IsNullOrEmpty(txtCI.Text.Trim()))
            {
                errorProvider.SetError(label19, "Ingrese cedula.");
                error = true;
            }
            if (dtpFechaNacimiento.Value.Date > DateTime.Now.Date)
            {
                errorProvider.SetError(label22, "Seleccione fecha de nacimiento.");
                error = true;
            }
            if (dtpFechaIngreso.Value.Date > DateTime.Now.Date)
            {
                errorProvider.SetError(label23, "Seleccione fecha de ingreso.");
                error = true;
            }
            if (dtpFechaCuotaDesde.Value.Date > DateTime.Now.Date)
            {
                errorProvider.SetError(label25, "Seleccione fecha comienzo cuota.");
                error = true;
            }
            return error;
            #endregion
        }
        private bool HayErrorModif()
        {
            #region Controlo errores campos
            bool error = false;

            if (cmbTPModif.SelectedIndex < 0)
            {
                errorProvider.SetError(label35, "Seleccione categoria.");
                error = true;
            }
            if (string.IsNullOrEmpty(txtPrimerApellidoModif.Text.Trim()))
            {
                errorProvider.SetError(label43, "Ingrese Primer Apellido.");
                error = true;
            }
            if (string.IsNullOrEmpty(txtSegundoApellidoModif.Text.Trim()))
            {
                errorProvider.SetError(label41, "Ingrese Segundo Apellido.");
                error = true;
            }
            if (string.IsNullOrEmpty(txtPrimerNombreModif.Text.Trim()))
            {
                errorProvider.SetError(label9, "Ingrese Primer Nombre.");
                error = true;
            }
            if (string.IsNullOrEmpty(txtCIModif.Text.Trim()))
            {
                errorProvider.SetError(label19, "Ingrese cedula.");
                error = true;
            }
            return error;
            #endregion
        }
        private void CreoSocio()
        {
            try
            {
                bool ret = HayError();
                if (ret==false)
                {
                    socio = new Socio();
                    cuota = new Cuota();
                    socio.SocCI = Convert.ToInt32(txtCI.Text.Trim());
                    socio.SocPrimerNombre = txtPrimerNombre.Text;
                    socio.SocPrimerApellido = txtPrimerApellido.Text;
                    socio.SocSegundoApellido = txtSegundoApellido.Text;
                    socio.SocSegundoApellido = txtSegundoApellido.Text;

                    if (!string.IsNullOrEmpty(txtSegundoNombre.Text))
                        socio.SocSegundoNombre = txtSegundoNombre.Text;
                    else
                        socio.SocSegundoNombre = "";

                    if (!string.IsNullOrEmpty(txtEmail.Text))
                        socio.SocEmail = txtEmail.Text;
                    else
                        socio.SocEmail = "";

                    if (!string.IsNullOrEmpty(txtDireccion.Text))
                        socio.SocDireccion = txtDireccion.Text;
                    else
                        socio.SocDireccion = "";

                    if (!string.IsNullOrEmpty(txtCelular.Text))
                        socio.SocCelular = txtCelular.Text;
                    else
                        socio.SocCelular = "";

                    if (!string.IsNullOrEmpty(txtTel.Text))
                        socio.SocTel = txtTel.Text;
                    else
                        socio.SocTel = "";

                    if (!string.IsNullOrEmpty(txtObservaciones.Text))
                        socio.SocObservaciones = txtObservaciones.Text;
                    else
                        socio.SocObservaciones = "";

                    socio.SocFechaNacimiento = dtpFechaNacimiento.Value;
                    socio.SocFechaIngreso = dtpFechaNacimiento.Value;
                    socio.SocTipoCuota = cmbTC.SelectedIndex;
                    //socio.SocTipoCuota = listaTC.FirstOrDefault(x => x.TCId == cmbTC.SelectedIndex);
                    socio.SocAtivo = true;
                    socio.FecAlta = DateTime.Now;
                    socio.FecModif = DateTime.Now;
                    socio.UsuIdAlta = Program.usuarioLogueado.UsuId;
                    socio.UsuIdModif = Program.usuarioLogueado.UsuId;

                    cuota.SocId = socio.SocId;
                    cuota.CuotaFechaDesde = dtpFechaCuotaDesde.Value;
                    cuota.CuotaFechaHasta = DateTime.Now;
                    cuota.CuotaTipo = socio.SocTipoCuota;
                    cuota.CuotaPaga = false;
                    cuota.FecAlta = socio.FecAlta;
                    cuota.FecModif = socio.FecModif;
                    cuota.UsuIdAlta = socio.UsuIdAlta;
                    cuota.UsuIdModif = socio.UsuIdModif;
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private bool PersistirSocio(Socio s, Cuota c, Usuario usu)
        {
            bool resp = false;
            try
            {
                ILogicaSocio FSocio = FabricaLogica.getLogicaSocio();
                resp = FSocio.AltaSocio(s, c,usu);

                return resp;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return resp;
        }
        public void ColorFrm()
        {
            btnCancelar.BackColor = RGBColors.color5;
            btnGuardar.BackColor = RGBColors.color5;
            btnVolver.BackColor = RGBColors.color5;
            lblTituloFormulario.ForeColor = RGBColors.color5;
            label1.ForeColor = RGBColors.color5;
            btnVolverAPrincipal.BackColor = RGBColors.color5;
            label52.ForeColor = RGBColors.color5;
            btnModificarSocio.BackColor = RGBColors.color5;
            btnCancelarModificarSocio.BackColor = RGBColors.color5;
            button3.BackColor = RGBColors.color5;
            label53.ForeColor = RGBColors.color5;
            button2.BackColor = RGBColors.color5;
            btnEliminarSocio.BackColor = RGBColors.color5;
            button6.BackColor = RGBColors.color5;
            button1.BackColor = RGBColors.color5;
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
        private void CargoGrillaSocios()
        {
            try
            {
                ILogicaSocio FSocio = FabricaLogica.getLogicaSocio();
                listaSocios = FSocio.ListarSocios();
                bool socioActivo = checkBox1.Checked ? true : false;
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
                                  }).ToList();
                    dgvSocios.Rows.Clear();
                    if (listaSocios != null)
                    {
                        foreach (Socio s in _resultado)
                        {
                            string estado = s.SocAtivo ? "Activo" : "Inactivo";
                            dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre, s.SocPrimerApellido, s.SocDireccion, s.SocTel, s.SocCelular, estado, "Editar");
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
                                      }).ToList();
                    dgvSocios.Rows.Clear();

                    if (listaSocios != null)
                    {
                        foreach (Socio s in _resultado)
                        {
                            string estado = s.SocAtivo ? "Activo" : "Inactivo";
                            dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre, s.SocPrimerApellido, s.SocDireccion, s.SocTel, s.SocCelular, estado, "Editar");
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
        private void CargoTC()
        {
            try
            {
                cmbTC.Items.Clear();
                ILogicaSocio tipoCuota = FabricaLogica.getLogicaSocio();
                listaTC = tipoCuota.ListarTC();
                cmbTC.Items.Add("Seleccionar");

                foreach (TipoCuota e in listaTC)
                {
                    cmbTC.Items.Add(e.TCDescripcion.Trim() + "   - Monto: $" + e.TCMonto);
                    cmbTPModif.Items.Add(e.TCDescripcion.Trim() + "   - Monto: $" + e.TCMonto);
                }

                cmbTC.SelectedIndex = 0;
                cmbTPModif.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion

        private void txtBuscarEliminar_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtBuscarEliminar.Text.Trim().Length >= 10)
                {
                    throw new Exception("Largo maximo para el documento - 9 digitos.");
                }
                else if (txtBuscarEliminar.Text.Trim() != "")
                {
                    try
                    {
                        ulong.Parse(txtBuscarEliminar.Text.Trim());
                    }
                    catch (Exception)
                    {
                        throw new Exception("El documento debe ser numérico.");
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgvSocios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int boton = int.Parse(e.ColumnIndex + "");
                switch (boton)
                {
                    case 8:
                        tabModifcar.Focus();
                        break;
                    default:
                        break;
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
