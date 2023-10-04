﻿using System;
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
    public partial class frmNucleoFamiliar : Form
    {
        private string titulo = "Nucleo Familiar";
        NucleoFamiliar nucleoFamiliar;
        private string mensaje = "";
        private int IdNFSeleccionado = -1;
        
        public frmNucleoFamiliar()
        {
            InitializeComponent();
            label1.ForeColor = RGBColors.color2;
            btnBuscarNF.BackColor = RGBColors.color2;
            btnCancelarNF.BackColor = RGBColors.color2;
            btnGuardarNF.BackColor = RGBColors.color2;
            btnGuardarNF.Text = "Guardar";
            cmbTipoVinculo.SelectedIndex = 0;
            txtBuscarNF.Focus();
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
        private void btnBuscarNF_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                dgvSociosNF.Rows.Clear();
                //ILogicaNucleoFamiliar lSocioNF = FabricaLogica.getLogicaNucleoFamiliar();
                //ILogicaSocio lSocio = FabricaLogica.getLogicaSocio();
                IServicePolicial lSocioNF = new ServicePolicialClient();
                IServicePolicial lSocio = new ServicePolicialClient();
                List<NucleoFamiliar> socListaNF = new List<NucleoFamiliar>();
                NucleoFamiliar nf = new NucleoFamiliar();
                Socio soc = new Socio();
                if (!string.IsNullOrEmpty(txtBuscarNF.Text))
                {
                    int ci = Convert.ToInt32(txtBuscarNF.Text);
                    soc = lSocio.BuscarSocioPorCI(ci);
                    if (soc != null)
                    {
                        txtSocIdNF.Text = Convert.ToString(soc.SocId);
                        txtNombreSocNF.Text = soc.SocPrimerNombre + " " + soc.SocPrimerApellido;
                        socListaNF = lSocioNF.BuscarNucleoFamiliarPorCI(soc.SocId).ToList();                     
                        DateTime fecha = DateTime.Today;
                        
                        if (socListaNF.Count > 0)
                        {
                            foreach (NucleoFamiliar c in socListaNF)
                            {
                                int edad1 = fecha.Year - c.NFFechaNacimiento.Year;
                                txtNFId.Text = Convert.ToString(c.NFId);
                                if (DateTime.Today < c.NFFechaNacimiento.AddYears(edad1)) edad1--;
                                dgvSociosNF.Rows.Add(c.SocId, c.NFCI, c.NFPrimerNombre, c.NFPrimerApellido, edad1 + " años", c.NfTipoVinculo, c.NFTel, c.NFCelular,
                                    "Editar", "Eliminar", c.NFFechaNacimiento, c.NFobservaciones, c.NFId, c.NFSegundoApellido, c.NFSegundoNombre);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontro socio para la cédula ingresada.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtBuscarNF.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Debe indicar una cédula.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtBuscarNF.Focus();
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
       
        private bool HayError()
        {
            #region Controlo errores campos
            bool error = false;
            if (string.IsNullOrEmpty(txtPrimerApellidoNF.Text.Trim()))
            {
                errorProvider.SetError(label12, "Ingrese Primer Apellido.");
                error = true;
            }
            if (string.IsNullOrEmpty(txtSegundoApellidoNF.Text.Trim()))
            {
                errorProvider.SetError(label11, "Ingrese Segundo Apellido.");
                error = true;
            }
            if (string.IsNullOrEmpty(txtPrimerNombreNF.Text.Trim()))
            {
                errorProvider.SetError(label9, "Ingrese Primer Nombre.");
                error = true;
            }
            if (string.IsNullOrEmpty(txtCINF.Text.Trim()))
            {
                errorProvider.SetError(label19, "Ingrese cedula.");
                error = true;
            }
            if((int)cmbTipoVinculo.SelectedIndex <= 0)
            {
                errorProvider.SetError(label10, "Selecciones vinculo.");
                error = true;
            }

            return error;
            #endregion
        }
        private void btnGuardarNF_Click(object sender, EventArgs e)
        {
            try
            {
                #region Aceptar
                errorProvider.Clear();
                //ILogicaNucleoFamiliar lNF = FabricaLogica.getLogicaNucleoFamiliar();
                IServicePolicial lNF = new ServicePolicialClient();
                NucleoFamiliar socNF = new NucleoFamiliar();
                Usuario _usu = Program.usuarioLogueado;
                bool resultado = false;
                bool ret = HayError();
                if(btnGuardarNF.Text == "Guardar")
                {
                    if (ret == false)
                    {
                        socNF.SocId = Convert.ToInt32(txtSocIdNF.Text.Trim());
                        socNF.NFCI = Convert.ToInt32(txtCINF.Text.Trim());
                        socNF.NFPrimerNombre = txtPrimerNombreNF.Text;
                        socNF.NFPrimerApellido = txtPrimerApellidoNF.Text;
                        socNF.NFSegundoApellido = txtSegundoApellidoNF.Text;
                        //socNF.NFId = Convert.ToInt32(txtNFId.Text);

                        if (!string.IsNullOrEmpty(txtSegundoNombreNF.Text))
                            socNF.NFSegundoNombre = txtSegundoNombreNF.Text;
                        else
                            socNF.NFSegundoNombre = "";

                        if ((int)cmbTipoVinculo.SelectedIndex >= 0)
                            socNF.NfTipoVinculo = cmbTipoVinculo.SelectedItem.ToString();

                        if (!string.IsNullOrEmpty(txtCelularNF.Text))
                            socNF.NFCelular = txtCelularNF.Text;
                        else
                            socNF.NFCelular = "";

                        if (!string.IsNullOrEmpty(txtTelNF.Text))
                            socNF.NFTel = txtTelNF.Text;
                        else
                            socNF.NFTel = "";

                        if (!string.IsNullOrEmpty(txtObservacionesNF.Text))
                            socNF.NFobservaciones = txtObservacionesNF.Text;
                        else
                            socNF.NFobservaciones = "";

                        socNF.NFFechaNacimiento = dtpFechaNacimientoNF.Value;
                        socNF.NFActivo = true;
                        socNF.FecAlta = DateTime.Now;
                        socNF.FecModif = DateTime.Now;
                        socNF.UsuIdAlta = Program.usuarioLogueado.UsuId;
                        socNF.UsuIdModif = Program.usuarioLogueado.UsuId;

                        if (socNF != null)
                        {
                            resultado = PersistirNucleoFamiliar(socNF, _usu);

                            if (resultado)
                            {
                                mensaje = "La información se guardó exitosamente.";
                                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DateTime fecha = DateTime.Today;
                                int edad1 = fecha.Year - socNF.NFFechaNacimiento.Year;
                                dgvSociosNF.Rows.Add(socNF.SocId, socNF.NFCI, socNF.NFPrimerNombre, socNF.NFPrimerApellido, edad1 + " años" , socNF.NfTipoVinculo ,socNF.NFTel,
                                    socNF.NFCelular, "Editar", "Eliminar");
                                LimpioFrmNF();                                
                                //txtSocIdNF.Text = "";
                                //txtNombreSocNF.Text = "";
                                btnBuscarNF_Click(null, null);
                            }
                            else
                            {
                                mensaje = "No se guardó la información.";
                                LimpiarTextos();
                                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }
                    else
                    {
                        mensaje = "Faltan completar datos requeridos.";
                        MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                #endregion
                #region Modificar
                if(btnGuardarNF.Text == "Modificar")
                {
                    if (ret == false)
                    {
                        socNF.SocId = Convert.ToInt32(txtSocIdNF.Text.Trim());
                        socNF.NFCI = Convert.ToInt32(txtCINF.Text.Trim());
                        socNF.NFPrimerNombre = txtPrimerNombreNF.Text;
                        socNF.NFPrimerApellido = txtPrimerApellidoNF.Text;
                        socNF.NFSegundoApellido = txtSegundoApellidoNF.Text;
                        socNF.NFId = IdNFSeleccionado;

                        if (!string.IsNullOrEmpty(txtSegundoNombreNF.Text))
                            socNF.NFSegundoNombre = txtSegundoNombreNF.Text;
                        else
                            socNF.NFSegundoNombre = "";

                        if ((int)cmbTipoVinculo.SelectedIndex >= 0)
                            socNF.NfTipoVinculo = cmbTipoVinculo.SelectedItem.ToString();

                        if (!string.IsNullOrEmpty(txtCelularNF.Text))
                            socNF.NFCelular = txtCelularNF.Text;
                        else
                            socNF.NFCelular = "";

                        if (!string.IsNullOrEmpty(txtTelNF.Text))
                            socNF.NFTel = txtTelNF.Text;
                        else
                            socNF.NFTel = "";

                        if (!string.IsNullOrEmpty(txtObservacionesNF.Text))
                            socNF.NFobservaciones = txtObservacionesNF.Text;
                        else
                            socNF.NFobservaciones = "";

                        socNF.NFFechaNacimiento = dtpFechaNacimientoNF.Value;
                        socNF.FecModif = DateTime.Now;
                        socNF.UsuIdModif = Program.usuarioLogueado.UsuId;
                    }

                    if (socNF != null)
                    {
                        resultado =lNF.ModificarNF(socNF, _usu);

                        if (resultado)
                        {
                            mensaje = "La información se modifico correctamente.";
                            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DateTime fecha = DateTime.Today;
                            List<NucleoFamiliar> socListaNF = new List<NucleoFamiliar>();
                            socListaNF = lNF.BuscarNucleoFamiliarPorCI(socNF.SocId).ToList();
                            LimpioFrmNF();
                            if (socListaNF.Count > 0)
                            {
                                foreach(NucleoFamiliar c in socListaNF)
                                {
                                    int edad1 = fecha.Year - c.NFFechaNacimiento.Year;
                                    if (DateTime.Today < c.NFFechaNacimiento.AddYears(edad1)) edad1--;
                                    dgvSociosNF.Rows.Add(c.SocId, c.NFCI, c.NFPrimerNombre, c.NFPrimerApellido, edad1 + " años", c.NfTipoVinculo, c.NFTel, c.NFCelular,
                                                        "Editar", "Eliminar", c.NFFechaNacimiento, c.NFobservaciones, c.NFId, c.NFSegundoApellido, c.NFSegundoNombre);
                                }
                            }                            
                            txtBuscarNF.Focus();
                        }
                        else
                        {
                            mensaje = "No se modifico la información.";
                            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                #endregion
                #region Eliminar
                if (btnGuardarNF.Text == "Eliminar")
                {
                    if (ret == false)
                    {
                        socNF.SocId = Convert.ToInt32(txtSocIdNF.Text.Trim());
                        socNF.NFCI = Convert.ToInt32(txtCINF.Text.Trim());
                        socNF.NFPrimerNombre = txtPrimerNombreNF.Text;
                        socNF.NFPrimerApellido = txtPrimerApellidoNF.Text;
                        socNF.NFSegundoApellido = txtSegundoApellidoNF.Text;
                        socNF.NFId = IdNFSeleccionado;

                        if (!string.IsNullOrEmpty(txtSegundoNombreNF.Text))
                            socNF.NFSegundoNombre = txtSegundoNombreNF.Text;
                        else
                            socNF.NFSegundoNombre = "";

                        if ((int)cmbTipoVinculo.SelectedIndex >= 0)
                            socNF.NfTipoVinculo = cmbTipoVinculo.SelectedItem.ToString();

                        if (!string.IsNullOrEmpty(txtCelularNF.Text))
                            socNF.NFCelular = txtCelularNF.Text;
                        else
                            socNF.NFCelular = "";

                        if (!string.IsNullOrEmpty(txtTelNF.Text))
                            socNF.NFTel = txtTelNF.Text;
                        else
                            socNF.NFTel = "";

                        if (!string.IsNullOrEmpty(txtObservacionesNF.Text))
                            socNF.NFobservaciones = txtObservacionesNF.Text;
                        else
                            socNF.NFobservaciones = "";

                        socNF.NFFechaNacimiento = dtpFechaNacimientoNF.Value;
                        socNF.FecModif = DateTime.Now;
                        socNF.UsuIdModif = Program.usuarioLogueado.UsuId;
                   }

                    if (socNF != null)
                    {
                        resultado = lNF.BajaNF(socNF.NFId);

                        if (resultado)
                        {
                            mensaje = "La información se modifico correctamente.";
                            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DateTime fecha = DateTime.Today;
                            List<NucleoFamiliar> socListaNF = new List<NucleoFamiliar>();
                            socListaNF = lNF.BuscarNucleoFamiliarPorCI(socNF.SocId).ToList();
                            //dgvSociosNF.Rows.Clear();
                            LimpioFrmNF();
                            if (socListaNF.Count > 0)
                            {
                                foreach (NucleoFamiliar c in socListaNF)
                                {
                                    int edad1 = fecha.Year - c.NFFechaNacimiento.Year;
                                    if (DateTime.Today < c.NFFechaNacimiento.AddYears(edad1)) edad1--;
                                    dgvSociosNF.Rows.Add(c.SocId, c.NFCI, c.NFPrimerNombre, c.NFPrimerApellido, edad1 + " años", c.NfTipoVinculo, c.NFTel, c.NFCelular,
                                                        "Editar", "Eliminar", c.NFFechaNacimiento, c.NFobservaciones, c.NFId, c.NFSegundoApellido, c.NFSegundoNombre );
                                }
                            }                            
                        }
                        else
                        {
                            mensaje = "No se modifico la información.";
                            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        public void LimpioFrmNF()
        {
            //txtBuscarNF.Text = "";
            //txtSocIdNF.Text = "";
            //txtNombreSocNF.Text = "";
            txtPrimerApellidoNF.Text = "";
            txtPrimerNombreNF.Text = "";
            txtSegundoNombreNF.Text = "";
            txtSegundoApellidoNF.Text = "";
            txtCINF.Text = "";
            txtTelNF.Text = "";
            txtCelularNF.Text = "";
            txtObservacionesNF.Text = "";
            dtpFechaNacimientoNF.Value = DateTime.Now;
            cmbTipoVinculo.SelectedIndex = 0;
            //txtSocCI.Text = "";
            //txtNFId.Text = "";
            dgvSociosNF.Rows.Clear();
            btnGuardarNF.Text = "Guardar";
        }
        private bool PersistirNucleoFamiliar(NucleoFamiliar c, Usuario usu)
        {
            bool resp = false;
            try
            {
                //ILogicaNucleoFamiliar FSocio = FabricaLogica.getLogicaNucleoFamiliar();
                IServicePolicial FSocio = new ServicePolicialClient();
                resp = FSocio.AltaNucleoFamiliar(c, usu);
                return resp;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return resp;
        }
        private bool ModficarNucleoFamiliar(NucleoFamiliar c, Usuario usu)
        {
            bool resp = false;
            try
            {
                //ILogicaNucleoFamiliar FSocio = FabricaLogica.getLogicaNucleoFamiliar();
                IServicePolicial FSocio = new ServicePolicialClient();
                resp = FSocio.ModificarNF(c, usu);
                return resp;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return resp;
        }
        private void dgvSociosNF_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(e.ColumnIndex == 8) //editar
                {
                    var filaSeleccionada = dgvSociosNF.CurrentRow;
                    if (dgvSociosNF.SelectedRows != null)
                    {
                        IdNFSeleccionado = -1;
                        int id = Convert.ToInt32(filaSeleccionada.Cells[0].Value);
                        IdNFSeleccionado = Convert.ToInt32(filaSeleccionada.Cells["NFId"].Value);
                        txtPrimerNombreNF.Text = filaSeleccionada.Cells["SocPrimerNombre"].Value.ToString();
                        txtSegundoNombreNF.Text = filaSeleccionada.Cells["SocSegundoNombre"].Value.ToString();
                        txtPrimerApellidoNF.Text = filaSeleccionada.Cells["SocPrimerApellido"].Value.ToString();
                        txtSegundoApellidoNF.Text = filaSeleccionada.Cells["SocSegundoApellido"].Value.ToString();
                        txtCINF.Text = filaSeleccionada.Cells["SocCI"].Value.ToString();
                        dtpFechaNacimientoNF.Value = Convert.ToDateTime(filaSeleccionada.Cells["SocFN"].Value);
                        cmbTipoVinculo.SelectedItem = filaSeleccionada.Cells["NFTipoVinculo"].Value;
                        txtTelNF.Text = filaSeleccionada.Cells["SocTel"].Value.ToString();
                        txtCelularNF.Text = filaSeleccionada.Cells["SocCelular"].Value.ToString();
                        txtObservacionesNF.Text = filaSeleccionada.Cells["SocObser"].Value.ToString();                                              

                        btnGuardarNF.Text = "Modificar";   
                    }
                    else
                    {
                        MessageBox.Show("Seleccione linea de la grilla.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtBuscarNF.Focus();
                    }
                }
                else if (e.ColumnIndex == 9) //eliminar
                {
                    var filaSeleccionada = dgvSociosNF.CurrentRow;
                    if (dgvSociosNF.SelectedRows != null)
                    {
                        IdNFSeleccionado = -1;
                        int id = Convert.ToInt32(filaSeleccionada.Cells[0].Value);
                        IdNFSeleccionado = Convert.ToInt32(filaSeleccionada.Cells["NFId"].Value);
                        txtPrimerNombreNF.Text = filaSeleccionada.Cells["SocPrimerNombre"].Value.ToString();
                        txtSegundoNombreNF.Text = filaSeleccionada.Cells["SocSegundoNombre"].Value.ToString();
                        txtPrimerApellidoNF.Text = filaSeleccionada.Cells["SocPrimerApellido"].Value.ToString();
                        txtSegundoApellidoNF.Text = filaSeleccionada.Cells["SocSegundoApellido"].Value.ToString();
                        txtCINF.Text = filaSeleccionada.Cells["SocCI"].Value.ToString();
                        dtpFechaNacimientoNF.Value = Convert.ToDateTime(filaSeleccionada.Cells["SocFN"].Value);
                        cmbTipoVinculo.SelectedItem = filaSeleccionada.Cells["NFTipoVinculo"].Value;
                        txtTelNF.Text = filaSeleccionada.Cells["SocTel"].Value.ToString();
                        txtCelularNF.Text = filaSeleccionada.Cells["SocCelular"].Value.ToString();
                        txtObservacionesNF.Text = filaSeleccionada.Cells["SocObser"].Value.ToString();

                        btnGuardarNF.Text = "Eliminar";
                    }
                    else
                    {
                        MessageBox.Show("Seleccione linea de la grilla.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtBuscarNF.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtBuscarNF_Validated(object sender, EventArgs e)
        {
            try
            {
                if (txtBuscarNF.Text.Trim().Length >= 10)
                {
                    throw new Exception("Largo maximo para el documento - 9 digitos.");
                }
                else if (txtBuscarNF.Text.Trim() != "")
                {
                    try
                    {
                        ulong.Parse(txtBuscarNF.Text.Trim());
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

        private void txtPrimerNombreNF_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void txtSegundoNombreNF_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void btnCancelarNF_Click(object sender, EventArgs e)
        {
            LimpiarTextos();
        }
        public void LimpiarTextos()
        {
            txtBuscarNF.Text = "";
            txtNombreSocNF.Text = "";
            txtPrimerApellidoNF.Text = "";
            txtPrimerNombreNF.Text = "";
            txtCelularNF.Text = "";
            txtCINF.Text = "";
            txtNFId.Text = "";
            txtSegundoApellidoNF.Text = "";
            txtSegundoNombreNF.Text = "";
            txtSocIdNF.Text = "";
            txtTelNF.Text = "";
            txtSocCI.Text = "";
            cmbTipoVinculo.SelectedIndex = 0;
            txtObservacionesNF.Text = "";
            txtNombreSocNF.Text = "";
            btnGuardarNF.Text = "Guardar";
            dgvSociosNF.Rows.Clear();
            dtpFechaNacimientoNF.Value = Convert.ToDateTime(DateTime.Today);
        }

        private void txtCINF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
