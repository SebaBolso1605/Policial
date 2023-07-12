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
    public partial class frmNucleoFamiliar : Form
    {
        private string titulo = "Nucleo Familiar";
        NucleoFamiliar nucleoFamiliar;
        private string mensaje = "";
        
        public frmNucleoFamiliar()
        {
            InitializeComponent();
            label1.ForeColor = RGBColors.color2;
            btnBuscarNF.BackColor = RGBColors.color2;
            btnCancelarNF.BackColor = RGBColors.color2;
            btnGuardarNF.BackColor = RGBColors.color2;
            btnVolverAPrincipal.BackColor = RGBColors.color2;
            btnGuardarNF.Text = "Guardar";
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
                ILogicaNucleoFamiliar lSocioNF = FabricaLogica.getLogicaNucleoFamiliar();
                ILogicaSocio lSocio = FabricaLogica.getLogicaSocio();
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
                        socListaNF = lSocioNF.BuscarNucleoFamiliarPorCI(soc.SocId);                      
                        DateTime fecha = DateTime.Today;
                        
                        if (socListaNF.Count > 0)
                        {
                            foreach(NucleoFamiliar c in socListaNF)
                            {
                                int edad1 = fecha.Year - c.NFFechaNacimiento.Year;

                                if (DateTime.Today < c.NFFechaNacimiento.AddYears(edad1)) edad1--;
                                dgvSociosNF.Rows.Add(c.SocId, c.NFCI, c.NFPrimerNombre, c.NFPrimerApellido, edad1 + " años" ,c.NFTel, c.NFCelular, 
                                    "Editar", "Eliminar",c.NFFechaNacimiento,c.NFSegundoNombre,c.NFSegundoApellido, c.NFobservaciones,c.NFId);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se encontro socio para la cedula ingresada.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            if (dtpFechaNacimientoNF.Value.Date > DateTime.Now.Date.AddYears(-8))
            {
                errorProvider.SetError(label22, "Seleccione fecha de nacimiento.");
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
                ILogicaNucleoFamiliar lNF = FabricaLogica.getLogicaNucleoFamiliar();
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
                        socNF.NFId = Convert.ToInt32(txtNFId.Text);

                        if (!string.IsNullOrEmpty(txtSegundoNombreNF.Text))
                            socNF.NFSegundoNombre = txtSegundoNombreNF.Text;
                        else
                            socNF.NFSegundoNombre = "";
                        if ((int)cmbTipoVinculo.SelectedIndex <= 0)
                            socNF.NTipoPersona = cmbTipoVinculo.SelectedItem.ToString();

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
                                dgvSociosNF.Rows.Add(socNF.SocId, socNF.NFCI, socNF.NFPrimerNombre, socNF.NFPrimerApellido, socNF.NFTel, socNF.NFCelular, "Editar", "Eliminar");
                                LimpioFrmNF();
                                txtSocIdNF.Text = "";
                                txtNombreSocNF.Text = "";
                            }
                            else
                            {
                                mensaje = "No se guardó la información.";
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
                        socNF.NFId = Convert.ToInt32(txtNFId.Text);

                        if (!string.IsNullOrEmpty(txtSegundoNombreNF.Text))
                            socNF.NFSegundoNombre = txtSegundoNombreNF.Text;
                        else
                            socNF.NFSegundoNombre = "";

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
                            socListaNF = lNF.BuscarNucleoFamiliarPorCI(socNF.SocId);
                            dgvSociosNF.Rows.Clear();
                            if (socListaNF.Count > 0)
                            {
                                foreach(NucleoFamiliar c in socListaNF)
                                {
                                    int edad1 = fecha.Year - c.NFFechaNacimiento.Year;
                                    if (DateTime.Today < c.NFFechaNacimiento.AddYears(edad1)) edad1--;
                                    dgvSociosNF.Rows.Add(c.SocId, c.NFCI, c.NFPrimerNombre, c.NFPrimerApellido, edad1 + " años", c.NFTel, c.NFCelular,
                                                        "Editar", "Eliminar", c.NFFechaNacimiento, c.NFSegundoNombre, c.NFSegundoApellido, c.NFobservaciones, c.NFId);
                                }
                            }
                            LimpioFrmNF();
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
                        socNF.NFId = Convert.ToInt32(txtNFId.Text);

                        if (!string.IsNullOrEmpty(txtSegundoNombreNF.Text))
                            socNF.NFSegundoNombre = txtSegundoNombreNF.Text;
                        else
                            socNF.NFSegundoNombre = "";

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
                            socListaNF = lNF.BuscarNucleoFamiliarPorCI(socNF.SocId);
                            dgvSociosNF.Rows.Clear();
                            if (socListaNF.Count > 0)
                            {
                                foreach (NucleoFamiliar c in socListaNF)
                                {
                                    int edad1 = fecha.Year - c.NFFechaNacimiento.Year;
                                    if (DateTime.Today < c.NFFechaNacimiento.AddYears(edad1)) edad1--;
                                    dgvSociosNF.Rows.Add(c.SocId, c.NFCI, c.NFPrimerNombre, c.NFPrimerApellido, edad1 + " años", c.NFTel, c.NFCelular,
                                                        "Editar", "Eliminar", c.NFFechaNacimiento, c.NFSegundoNombre, c.NFSegundoApellido, c.NFobservaciones, c.NFId);
                                }
                            }
                            LimpioFrmNF();
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
            txtPrimerApellidoNF.Text = "";
            txtPrimerNombreNF.Text = "";
            txtSegundoNombreNF.Text = "";
            txtSegundoApellidoNF.Text = "";
            txtCINF.Text = "";
            txtTelNF.Text = "";
            txtCelularNF.Text = "";
            txtObservacionesNF.Text = "";
            dtpFechaNacimientoNF.Value = DateTime.Now;
        }
        private bool PersistirNucleoFamiliar(NucleoFamiliar c, Usuario usu)
        {
            bool resp = false;
            try
            {
                ILogicaNucleoFamiliar FSocio = FabricaLogica.getLogicaNucleoFamiliar();
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
                ILogicaNucleoFamiliar FSocio = FabricaLogica.getLogicaNucleoFamiliar();
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
                if(e.ColumnIndex == 7) //editar
                {
                    var filaSeleccionada = dgvSociosNF.CurrentRow;
                    if (dgvSociosNF.SelectedRows != null)
                    {
                        int id = Convert.ToInt32(filaSeleccionada.Cells[0].Value);
                        txtSocIdNF.Text = filaSeleccionada.Cells["SocId"].Value.ToString();
                        txtCINF.Text = filaSeleccionada.Cells["SocCI"].Value.ToString();
                        txtPrimerNombreNF.Text = filaSeleccionada.Cells["SocPrimerNombre"].Value.ToString();
                        txtPrimerApellidoNF.Text = filaSeleccionada.Cells["SocPrimerApellido"].Value.ToString();
                        string edad = filaSeleccionada.Cells["SocDireccion"].Value.ToString();
                        txtTelNF.Text = filaSeleccionada.Cells["SocTel"].Value.ToString();
                        txtCelularNF.Text = filaSeleccionada.Cells["SocCelular"].Value.ToString();
                        string a = filaSeleccionada.Cells["SocCelular"].Value.ToString();
                        string b = filaSeleccionada.Cells["SocCelular"].Value.ToString();
                        dtpFechaNacimientoNF.Value = Convert.ToDateTime(filaSeleccionada.Cells["SocFN"].Value);
                        txtObservacionesNF.Text = filaSeleccionada.Cells["SocObser"].Value.ToString();
                        string c = filaSeleccionada.Cells["SocCelular"].Value.ToString();
                        string d = filaSeleccionada.Cells["SocCelular"].Value.ToString();
                        txtSegundoApellidoNF.Text = filaSeleccionada.Cells["NFId"].Value.ToString();
                        txtNFId.Text = filaSeleccionada.Cells["SocSegundoNombre"].Value.ToString();
                        txtSegundoNombreNF.Text = filaSeleccionada.Cells["SocSegundoApellido"].Value.ToString();

                        btnGuardarNF.Text = "Modificar";   
                    }
                    else
                    {
                        MessageBox.Show("Seleccione linea de la grilla.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtBuscarNF.Focus();
                    }
                }
                else if (e.ColumnIndex == 8) //eliminar
                {
                    var filaSeleccionada = dgvSociosNF.CurrentRow;
                    if (dgvSociosNF.SelectedRows != null)
                    {
                        int id = Convert.ToInt32(filaSeleccionada.Cells[0].Value);

                        txtSocIdNF.Text = filaSeleccionada.Cells["SocId"].Value.ToString();
                        txtCINF.Text = filaSeleccionada.Cells["SocCI"].Value.ToString();
                        txtPrimerNombreNF.Text = filaSeleccionada.Cells["SocPrimerNombre"].Value.ToString();
                        txtPrimerApellidoNF.Text = filaSeleccionada.Cells["SocPrimerApellido"].Value.ToString();
                        string edad = filaSeleccionada.Cells["SocDireccion"].Value.ToString();
                        string j = filaSeleccionada.Cells["SocTel"].Value.ToString();
                        string f = filaSeleccionada.Cells["SocCelular"].Value.ToString();
                        string a = filaSeleccionada.Cells["SocCelular"].Value.ToString();
                        string b = filaSeleccionada.Cells["SocCelular"].Value.ToString();
                        string g = filaSeleccionada.Cells["SocFN"].Value.ToString();
                        string h = filaSeleccionada.Cells["SocObser"].Value.ToString();
                        string c = filaSeleccionada.Cells["SocCelular"].Value.ToString();
                        string d = filaSeleccionada.Cells["SocCelular"].Value.ToString();
                        txtSegundoApellidoNF.Text = filaSeleccionada.Cells["NFId"].Value.ToString();
                        txtNFId.Text = filaSeleccionada.Cells["SocSegundoNombre"].Value.ToString();
                        txtSegundoNombreNF.Text = filaSeleccionada.Cells["SocSegundoApellido"].Value.ToString();

                        txtCelularNF.Enabled = false;
                        txtObservacionesNF.Enabled = false;
                        txtTelNF.Enabled = false;
                        dtpFechaNacimientoNF.Enabled = false;
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
    }
}
