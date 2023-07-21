using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using EntidadesCompartidas;
//using EntidadesCompartidas.Enums;
//using Logica;
using System.Xml;
using System.IO;
using Policial.ServicePolicial;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

namespace Policial
{
    public partial class frmImprimir : Form
    {
        string mensaje = "";
        string titulo = "";

        public frmImprimir()
        {
            InitializeComponent();
            btnImprimir.BackColor = RGBColors.color4;
            btnVolver.BackColor = RGBColors.color4;
            lblTituloFormulario.ForeColor = RGBColors.color4;
            ListarCuotasSocios();
            
            //List<Enum> lstStatus = Enum.GetValues(typeof(Enum)).ToList();
            //cmbMes.Items
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                var filaSeleccionada = dgvSocios.CurrentRow;
                SaveFileDialog guardar = new SaveFileDialog();
                guardar.FileName = DateTime.Now.ToString("ddddMMyyyy" + ".pdf");
                string plantillaHtlm = Properties.Resources.plantillaHTML.ToString();


                plantillaHtlm = plantillaHtlm.Replace("@Socio", filaSeleccionada.Cells["SocId"].Value.ToString());
                plantillaHtlm = plantillaHtlm.Replace("@Nombre", filaSeleccionada.Cells["SocPrimerNombre"].Value.ToString() + filaSeleccionada.Cells["SocPrimerApellido"].Value.ToString());
                plantillaHtlm = plantillaHtlm.Replace("@Direccion", filaSeleccionada.Cells["SocDireccion"].Value.ToString());
                plantillaHtlm = plantillaHtlm.Replace("@CuotaSocial", filaSeleccionada.Cells["SocId"].Value.ToString());
                plantillaHtlm = plantillaHtlm.Replace("@FechaDeEmision", filaSeleccionada.Cells["SocId"].Value.ToString());
                plantillaHtlm = plantillaHtlm.Replace("@Email", filaSeleccionada.Cells["SocId"].Value.ToString());
                plantillaHtlm = plantillaHtlm.Replace("@FechaDeIngreso", filaSeleccionada.Cells["SocId"].Value.ToString());
                plantillaHtlm = plantillaHtlm.Replace("@AnioMes", filaSeleccionada.Cells["SocId"].Value.ToString());

                if (guardar.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fileStream = new FileStream(guardar.FileName, FileMode.Create))
                    {
                        Document pdfDoc = new Document(PageSize.A4, 10, 10, 10, 10);
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc,fileStream);

                        pdfDoc.Open();
                        pdfDoc.Add(new Phrase(""));

                        using(StreamReader reader = new StreamReader(plantillaHtlm))
                        {
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer,pdfDoc,reader); 
                        }

                        pdfDoc.Close();
                        fileStream.Close();
                    }



                    if (dgvSocios.SelectedRows != null)
                    {
                        int id = Convert.ToInt32(filaSeleccionada.Cells[0].Value);
                        //txtSocIdNF.Text = filaSeleccionada.Cells["SocId"].Value.ToString();
                        //txtCINF.Text = filaSeleccionada.Cells["SocCI"].Value.ToString();
                        //txtPrimerNombreNF.Text = filaSeleccionada.Cells["SocPrimerNombre"].Value.ToString();
                        //txtPrimerApellidoNF.Text = filaSeleccionada.Cells["SocPrimerApellido"].Value.ToString();
                        //string edad = filaSeleccionada.Cells["SocDireccion"].Value.ToString();
                        //txtTelNF.Text = filaSeleccionada.Cells["SocTel"].Value.ToString();
                        //txtCelularNF.Text = filaSeleccionada.Cells["SocCelular"].Value.ToString();
                        //string a = filaSeleccionada.Cells["SocCelular"].Value.ToString();
                        //string b = filaSeleccionada.Cells["SocCelular"].Value.ToString();
                        //dtpFechaNacimientoNF.Value = Convert.ToDateTime(filaSeleccionada.Cells["SocFN"].Value);
                        //txtObservacionesNF.Text = filaSeleccionada.Cells["SocObser"].Value.ToString();
                        //string c = filaSeleccionada.Cells["SocCelular"].Value.ToString();
                        //string d = filaSeleccionada.Cells["SocCelular"].Value.ToString();
                        //txtSegundoApellidoNF.Text = filaSeleccionada.Cells["NFId"].Value.ToString();
                        //txtNFId.Text = filaSeleccionada.Cells["SocSegundoNombre"].Value.ToString();
                        //txtSegundoNombreNF.Text = filaSeleccionada.Cells["SocSegundoApellido"].Value.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Seleccione linea de la grilla.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //txtBuscarNF.Focus();
                    }
                }
                else { }
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

                listaSocios = ls.ListarSocios().ToList();

                if(listaSocios.Count > 0)
                {
                    foreach (Socio s in listaSocios)
                    {
                        listaCuotas = lc.BuscarCuotasSocio(s.SocId).ToList();
                        if (listaCuotas != null)    
                        {
                            foreach (Cuota c in listaCuotas)
                            {
                                dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre, s.SocPrimerApellido, c.CuotaId, c.CuotaAAAAMM);
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
    }
}
