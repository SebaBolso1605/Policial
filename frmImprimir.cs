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
                                        dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre + " " + s.SocSegundoNombre, 
                                            s.SocPrimerApellido + " " + s.SocSegundoApellido, c.CuotaId, c.CuotaAAAAMM, "Impaga",true);                                
                                    else
                                        dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre + " " + s.SocSegundoNombre,
                                            s.SocPrimerApellido + " " + s.SocSegundoApellido, c.CuotaId, c.CuotaAAAAMM, "Impaga");
                                }
                            }
                        }
                        if (listaCuotas.Count > 0 && !soloCuotasImpagas)
                        {
                            foreach (Cuota c in listaCuotas)
                            {
                                string estado = c.CuotaPaga ? "Paga" : "Impaga";
                                if (imprimirTodo)
                                    dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre + " " + s.SocSegundoNombre,
                                            s.SocPrimerApellido + " " + s.SocSegundoApellido, c.CuotaId, c.CuotaAAAAMM, estado,true);
                                else
                                    dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre + " " + s.SocSegundoNombre,
                                            s.SocPrimerApellido + " " + s.SocSegundoApellido, c.CuotaId, c.CuotaAAAAMM,estado);
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
                var filaSeleccionada = dgvSocios.CurrentRow;
                SaveFileDialog guardar = new SaveFileDialog();

                //como está el código ahora solo vas a seleccionar una, porque no estas iterando, en caso de tenes varias seleccionadas tendrás una lista y habrá que iterar.
                //esto del nombre ves si lo usas, porque hay que iterar, sino de mientras comenta el if y ponele el nombre que quieras.
                string nombre = "";
                if (chkImprimir.Checked)
                {
                    nombre = "Todas las cuotas";
                }
                else
                {
                    nombre = "Cuota del Socio " + filaSeleccionada.Cells["SocPrimerNombre"].Value.ToString() + filaSeleccionada.Cells["SocPrimerApellido"].Value.ToString() + ".pdf";
                }
                 //DateTime.Now.ToString("ddMMyyyy") + ".pdf";
                guardar.FileName = nombre;               
                string plantillaHtlm = Properties.Resources.plantillaHTML.ToString();  //Properties.Resources.plantilla.ToString();

                //System.IO.FileStream fileStream = new FileStream(@"C:\Users\Admin\Desktop\prueba.pdf", FileMode.Create);
                plantillaHtlm = plantillaHtlm.Replace("@Socio", filaSeleccionada.Cells["SocId"].Value.ToString());
                plantillaHtlm = plantillaHtlm.Replace("@Nombre", filaSeleccionada.Cells["SocPrimerNombre"].Value.ToString() + filaSeleccionada.Cells["SocPrimerApellido"].Value.ToString());
                //plantillaHtlm = plantillaHtlm.Replace("@Direccion", filaSeleccionada.Cells["SocDireccion"].Value.ToString());
                plantillaHtlm = plantillaHtlm.Replace("@CuotaSocial", filaSeleccionada.Cells["SocId"].Value.ToString());
                plantillaHtlm = plantillaHtlm.Replace("@FechaDeEmision", filaSeleccionada.Cells["SocId"].Value.ToString());
                plantillaHtlm = plantillaHtlm.Replace("@Email", filaSeleccionada.Cells["SocId"].Value.ToString());
                plantillaHtlm = plantillaHtlm.Replace("@FechaDeIngreso", filaSeleccionada.Cells["SocId"].Value.ToString());
                plantillaHtlm = plantillaHtlm.Replace("@AnioMes", filaSeleccionada.Cells["CuotaAAAAMM"].Value.ToString());

                //Document doc = new Document(PageSize.A4);
                //PdfWriter writer = PdfWriter.GetInstance(doc, fileStream);

                //doc.Open();
                ////doc.Add(new Phrase(""));           

                //using (StreamReader reader = new StreamReader(@"C:\Users\Admin\Desktop\plantillaHTML.html"))
                // {
                //    XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, reader);
                // }

                //doc.Close();
                //fileStream.Close();

                if (guardar.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fileStream = new FileStream(guardar.FileName, FileMode.Create)) //, FileAccess.Write))
                    {
                        Document doc = new Document(PageSize.A4, 10, 10, 10, 10);
                        PdfWriter writer = PdfWriter.GetInstance(doc, fileStream);

                        doc.Open();
                        doc.Add(new Phrase(""));


                        using (StringReader reader = new StringReader(plantillaHtlm))
                        {
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, reader);
                        }

                        doc.Close();
                        fileStream.Close();
                    }
                }
                //else { }
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
