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
    public partial class frmSocio : Form
    {
        #region Variables
        private string titulo = "Gestión de Socios";
        private string mensaje = "";
        public List<TipoCuota> listaTC;
        private Socio socio;
        private Cuota cuota;
        private List<Socio> listaSocios;
        private Usuario usuarioLogueado = Program.usuarioLogueado;
        private int cantidadSociosActivos;
        private int cantidadSociosInactivos;
        private int cantidadSocios;
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
                IServicePolicial FSocio = new ServicePolicialClient();
                listaSocios = FSocio.ListarSocios().ToList();

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
                IServicePolicial FSocio = new ServicePolicialClient();
                listaSocios = FSocio.ListarSocios().ToList();
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
                        if (estado == "Activo")
                            dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre + " " + s.SocSegundoNombre,
                                                s.SocPrimerApellido + " " + s.SocSegundoApellido, s.SocDireccion, s.SocTel, s.SocCelular, estado, "Editar");
                        else
                            dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre + " " + s.SocSegundoNombre,
                                                    s.SocPrimerApellido + " " + s.SocSegundoApellido, s.SocDireccion, s.SocTel, s.SocCelular, estado, "Editar", "Activar");
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
                IServicePolicial lSocio = new ServicePolicialClient();
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
                    else
                    {
                        MessageBox.Show("No se encontro socio para el documento ingresado", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtBuscarModif.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void button_Click_2(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                IServicePolicial lSocio = new ServicePolicialClient();
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
                    else
                    {
                        MessageBox.Show("No se encontro socio para el documento ingresado", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtBuscarModif.Text = "";
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
                IServicePolicial lSocio = new ServicePolicialClient();
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
                IServicePolicial lSocio = new ServicePolicialClient();
                Socio soc = null;
                if (!string.IsNullOrEmpty(txtBuscarEliminar.Text))
                {
                    int ci = Convert.ToInt32(txtBuscarEliminar.Text);
                    soc = lSocio.BuscarSocioPorCI(ci);
                    if (soc != null)
                    {
                        if (soc.SocAtivo)
                        {
                            txtPrimerApellidoBaja.Text = soc.SocPrimerApellido;
                            txtPrimerNombreBaja.Text = soc.SocPrimerNombre;
                            txtSegundoApellidoBaja.Text = soc.SocSegundoApellido;
                            txtCiBaja.Text = soc.SocCI.ToString();
                        }
                        else
                        {
                            MessageBox.Show("El socio con cédula: " + soc.SocCI + " , ya esta dado de baja.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Debe indicar un documento.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                IServicePolicial lSocio = new ServicePolicialClient();
                Socio soc = new Socio();

                if (!string.IsNullOrEmpty(txtCiBaja.Text))
                {
                    int ci = Convert.ToInt32(txtBuscarEliminar.Text);
                    soc.SocCI = ci;
                    if (!string.IsNullOrEmpty(txtMotivoBaja.Text))
                        soc.SocMotivoEgreso = txtMotivoBaja.Text;
                    else
                        soc.SocMotivoEgreso = " ";

                    soc.SocFechaEgreso = dtpFechaBaja.Value;


                    resp = lSocio.BajaSocio(soc, usuarioLogueado);
                    if (resp)
                    {
                        MessageBox.Show("Se dio de baja correctamente al socio.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarEliminar();
                    }
                    else
                    {
                        MessageBox.Show("No dio de baja correctamente al socio.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LimpiarEliminar();
                    }
                }
                else
                {
                    MessageBox.Show("Debe indicar un documento y buscar el socio a eliminar.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        private void txtPrimerNombre_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }
        private void txtPrimerApellido_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }
        private void txtSegundoApellido_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }
        private void dtpFechaNacimiento_ValueChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }
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
                string texto = "";
                int boton = int.Parse(e.ColumnIndex + "");
                if (!String.IsNullOrEmpty(dgvSocios.Rows[e.RowIndex].Cells[9].Value.ToString()))
                    texto = dgvSocios.Rows[e.RowIndex].Cells[9].Value.ToString();
                else
                    texto = "";
                int docum = Convert.ToInt32(dgvSocios.Rows[e.RowIndex].Cells[1].Value.ToString());

                //string SocApellido1 = dgvSocios.Rows[e.RowIndex].Cells[3].Value.ToString();
                Socio soc = new Socio();
                soc.SocId = Convert.ToInt32(dgvSocios.Rows[e.RowIndex].Cells[0].Value.ToString());
                soc.SocCI = docum;
                //soc.SocPrimerNombre = dgvSocios.Rows[e.RowIndex].Cells[2].Value.ToString();

                switch (boton)
                {
                    case 8:
                        this.tabModifcar.SelectedIndex = 2;
                        txtBuscarModif.Text = docum.ToString();
                        button1_Click_2(null, null);
                        break;
                    case 9:
                        if (texto == "Activar")
                        {
                            if (!String.IsNullOrEmpty(docum.ToString()))
                            {

                                bool resp = false;
                                resp = ActivarSocio(soc, Program.usuarioLogueado);
                                if (resp)
                                {
                                    MessageBox.Show("Se activo Socio seleccionado.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    CargoGrillaSocios();
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo activar Socio seleccionado.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    CargoGrillaSocios();
                                }
                            }
                        }
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
            if (dtpFechaNacimiento.Value.Date > DateTime.Now.Date.AddYears(-8))
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
                if (ret == false)
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
                IServicePolicial FSocio = new ServicePolicialClient();
                resp = FSocio.AltaSocio(s, c, usu);
                return resp;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return resp;
        }
        private bool ActivarSocio(Socio s, Usuario usu)
        {
            bool resp = false;
            try
            {
                IServicePolicial FSocio = new ServicePolicialClient();
                resp = FSocio.ActivarSocio(s, usu);
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
            label52.ForeColor = RGBColors.color5;
            btnModificarSocio.BackColor = RGBColors.color5;
            btnCancelarModificarSocio.BackColor = RGBColors.color5;
            label53.ForeColor = RGBColors.color5;
            button2.BackColor = RGBColors.color5;
            btnEliminarSocio.BackColor = RGBColors.color5;
            button1.BackColor = RGBColors.color5;
            button3.BackColor = RGBColors.color5;
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
                //ILogicaSocio FSocio = FabricaLogica.getLogicaSocio();
                IServicePolicial FSocio = new ServicePolicialClient();
                listaSocios = FSocio.ListarSocios().ToList();
                cantidadSocios = listaSocios.Count();
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
                            if (estado == "Activo")
                                dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre, s.SocPrimerApellido, s.SocDireccion, s.SocTel, s.SocCelular, estado, "Editar", "");
                            else
                                dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre, s.SocPrimerApellido, s.SocDireccion, s.SocTel, s.SocCelular, estado, "Editar", "Activar");
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
                            if (estado == "Activo")
                                dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre, s.SocPrimerApellido, s.SocDireccion, s.SocTel, s.SocCelular, estado, "Editar", "");
                            else
                                dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre, s.SocPrimerApellido, s.SocDireccion, s.SocTel, s.SocCelular, estado, "Editar", "Activar");
                        }
                    }
                }
                var _inactivos = (from soc in listaSocios where soc.SocAtivo == false select soc).Count();
                cantidadSociosInactivos = _inactivos;
                var _activos = (from soc in listaSocios where soc.SocAtivo == true select soc).Count();
                cantidadSociosActivos = _activos;
                lblCantSociosInactivos.Text = "Socios Inactivos: " + cantidadSociosInactivos.ToString();
                lblCantSociosActivos.Text = "Socios Activos: " + cantidadSociosActivos.ToString();
                lblCantSociosTotales.Text = "Socios en Total: " + cantidadSocios.ToString();
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
                //ILogicaSocio tipoCuota = FabricaLogica.getLogicaSocio();
                IServicePolicial tipoCuota = new ServicePolicialClient();
                listaTC = tipoCuota.ListarTC().ToList();
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

        private void button3_Click(object sender, EventArgs e)
        {
            LimpiarEliminar();
        }

        private void LimpiarEliminar()
        {
            txtBuscarEliminar.Text = "";
            txtPrimerNombreBaja.Text = "";
            txtPrimerApellidoBaja.Text = "";
            txtSegundoApellidoBaja.Text = "";
            txtCiBaja.Text = "";
            txtMotivoBaja.Text = "";
            dtpFechaBaja.Value = DateTime.Now;
        }

        private void LimpiarModificar()
        {
            txtBuscarModif.Text = "";
            txtPrimerNombreModif.Text = "";
            txtPrimerApellidoModif.Text = "";
            txtSegundoNombreModif.Text = "";
            txtCIModif.Text = "";
            txtCelularModif.Text = "";
            txtTelModif.Text = "";
            txtDireccionModif.Text = "";
            txtObservacionesModif.Text = "";
            txtEmailModif.Text = "";
            txtSegundoApellidoModif.Text = "";
            cmbTPModif.SelectedIndex = -1;
        }

        private void tabModifcar_Selected(object sender, TabControlEventArgs e)
        {
            string tab = tabModifcar.SelectedIndex.ToString();

            switch (tab)
            {
                case "0":
                    CargoGrillaSocios();
                    break;
                case "1":

                    break;
                case "2":

                    break;
                case "3":
                    LimpiarEliminar();
                    break;
                default:
                    break;
            }
        }

        private void btnCancelarModificarSocio_Click(object sender, EventArgs e)
        {
            LimpiarModificar();
        }
    }
}