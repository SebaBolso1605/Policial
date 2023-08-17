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
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using iTextSharp.tool.xml;

namespace Policial
{
    public partial class frmImprimir : Form
    {
        #region Atributos/Propiedades
        string mensaje = "";
        string titulo = "";
        #endregion
        #region Metodos
        public frmImprimir()
        {
            InitializeComponent();
            btnImprimir.BackColor = RGBColors.color4;
            btnVolver.BackColor = RGBColors.color4;
            lblTituloFormulario.ForeColor = RGBColors.color4;
            btnBuscar.BackColor = RGBColors.color4;
            //btnPagarCuotas.BackColor = RGBColors.color4;
            ListarCuotasSocios();
            chkImprimir.Checked = false;
            //chkPagar.Checked = false;
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
        public void ImprimirCuotas()
        {
            try
            {

            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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
                bool imprimirTodo = chkImprimir.Checked ? true : false;

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
                                        dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre + " " + s.SocSegundoNombre, s.SocPrimerApellido + " " + s.SocSegundoApellido,
                                            c.CuotaId, c.CuotaAAAAMM, "Impaga", c.CuotaFechaDesde, true, s.SocDireccion, s.SocEmail);                                
                                    else
                                        dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre + " " + s.SocSegundoNombre, s.SocPrimerApellido + " " + s.SocSegundoApellido, 
                                            c.CuotaId, c.CuotaAAAAMM, "Impaga", c.CuotaFechaDesde, false, s.SocDireccion, s.SocEmail);
                                }
                            }
                        }
                        if (listaCuotas.Count > 0 && !soloCuotasImpagas)
                        {
                            foreach (Cuota c in listaCuotas)
                            {
                                string estado = c.CuotaPaga ? "Paga" : "Impaga";
                                if (imprimirTodo)
                                    dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre + " " + s.SocSegundoNombre, s.SocPrimerApellido + " " + s.SocSegundoApellido, 
                                        c.CuotaId, c.CuotaAAAAMM, estado, c.CuotaFechaDesde,true, s.SocDireccion, s.SocEmail);
                                else
                                    dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre + " " + s.SocSegundoNombre, s.SocPrimerApellido + " " + s.SocSegundoApellido, 
                                        c.CuotaId, c.CuotaAAAAMM, estado, c.CuotaFechaDesde, false, s.SocDireccion, s.SocEmail);
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
        #endregion
        #region Eventos
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                bool seleccionado = false;
                string cuotas = "";
                foreach (DataGridViewRow row in dgvSocios.Rows)
                {
                    if (row.Cells["imprimir"].Value != null)
                    {
                        if ((bool)row.Cells["imprimir"].Value)
                        {
                            seleccionado = true;
                            string nombre = "";
                            if (chkImprimir.Checked)
                                nombre = "Todas las cuotas";
                            else
                                nombre = "Cuota del Socio" + row.Cells["SocPrimerNombre"].Value.ToString() + row.Cells["SocPrimerNombre"].Value.ToString() + ".pdf";

                            string plantillaHtlm = Properties.Resources.plantillaHTML.ToString();
                            plantillaHtlm = plantillaHtlm.Replace("@Socio", row.Cells["SocId"].Value.ToString());
                            plantillaHtlm = plantillaHtlm.Replace("@Nombre", row.Cells["SocPrimerNombre"].Value.ToString() + row.Cells["SocPrimerApellido"].Value.ToString());
                            plantillaHtlm = plantillaHtlm.Replace("@Direccion", row.Cells["SocDireccion"].Value.ToString());
                            plantillaHtlm = plantillaHtlm.Replace("@CuotaSocial", row.Cells["CuotaId"].Value.ToString());
                            plantillaHtlm = plantillaHtlm.Replace("@FechaDeEmision", row.Cells["CuotaFechaDesde"].Value.ToString());
                            //if(!string.IsNullOrEmpty(filaSeleccionada.Cells["SocEmail"].Value.ToString()))
                            //    plantillaHtlm = plantillaHtlm.Replace("@Email", filaSeleccionada.Cells["SocEmail"].Value.ToString());
                            //else
                            //    plantillaHtlm = plantillaHtlm.Replace("@Email", "");
                            // plantillaHtlm = plantillaHtlm.Replace("@FechaDeIngreso", filaSeleccionada.Cells["SocId"].Value.ToString());
                            plantillaHtlm = plantillaHtlm.Replace("@AnioMes", row.Cells["CuotaAAAAMM"].Value.ToString());

                            cuotas = cuotas + plantillaHtlm;                            
                        }
                    }
                }
                if (!seleccionado)
                {
                    MessageBox.Show("Debe seleccionar al menos una cuota para imprimir.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else {
                    var filaSeleccionada = dgvSocios.CurrentRow;
                    SaveFileDialog guardar = new SaveFileDialog();
                    string plantillaFinal = Properties.Resources.plantillaFinal.ToString();

                    plantillaFinal = plantillaFinal.Replace("@Cuota", cuotas);

                    if (guardar.ShowDialog() == DialogResult.OK)
                    {
                        using (FileStream fileStream = new FileStream(guardar.FileName, FileMode.Create))
                        {
                            Document doc = new Document(PageSize.A4, 10, 10, 10, 10);
                            PdfWriter writer = PdfWriter.GetInstance(doc, fileStream);

                            doc.Open();
                            doc.Add(new Phrase(""));

                            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.logo, System.Drawing.Imaging.ImageFormat.Png);
                            img.ScaleToFit(80, 60);
                            img.Alignment = iTextSharp.text.Image.UNDERLYING;
                            img.SetAbsolutePosition(doc.LeftMargin, doc.Top - 60);

                            using (StringReader reader = new StringReader(plantillaFinal))
                            {
                                XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, reader);
                            }

                            doc.Close();
                            fileStream.Close();
                        }

                        MessageBox.Show("Se generaron cuotas marcadas para imprimir.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("Seleccione ubicación de destino.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            try
            {
                ListarCuotasSocios();
                cmbAño.SelectedIndex = -1;
                cmbMes.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }      
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //PagarCuotas();
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
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string año = cmbAño.SelectedIndex != -1 ? cmbAño.SelectedItem.ToString() : "";
                string mes = cmbMes.SelectedIndex != -1 ? cmbMes.SelectedItem.ToString() : "";
                dgvSocios.Rows.Clear();
                IServicePolicial lc = new ServicePolicialClient();
                IServicePolicial ls = new ServicePolicialClient();
                List<Cuota> listaCuotas = new List<Cuota>();
                List<Socio> listaSocios = new List<Socio>();
                listaSocios = ls.ListarSocios().ToList();
                bool soloCuotasImpagas = checkBox1.Checked ? true : false;

                if (listaSocios.Count > 0)
                {
                    foreach (Socio s in listaSocios)
                    {
                        listaCuotas = lc.BuscarCuotasSocio(s.SocId).ToList();

                        if (listaCuotas.Count > 0 && soloCuotasImpagas)
                        {
                            foreach (Cuota c in listaCuotas)
                            {
                                if (!c.CuotaPaga && c.CuotaAAAAMM == mes + "/" + año)
                                    dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre + " " + s.SocSegundoNombre,
                                            s.SocPrimerApellido + " " + s.SocSegundoApellido, c.CuotaId, c.CuotaAAAAMM,"Impaga");
                            }
                        }
                        if (listaCuotas.Count > 0 && !soloCuotasImpagas)
                        {
                            foreach (Cuota c in listaCuotas)
                            {
                                if (c.CuotaPaga && c.CuotaAAAAMM == mes + "/" + año)
                                    dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre + " " + s.SocSegundoNombre,
                                            s.SocPrimerApellido + " " + s.SocSegundoApellido, c.CuotaId, c.CuotaAAAAMM,"Paga");
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
        private void chkImprimir_CheckedChanged(object sender, EventArgs e)
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
                                if (!c.CuotaPaga )
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
