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
using System.Diagnostics;
using System.Threading;
using Policial.Properties;

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
                                            c.CuotaId, c.CuotaAAAAMM, "Impaga", c.CuotaFechaDesde, true, c.CuotaFechaPaga, s.SocDireccion, s.SocEmail, s.SocFechaIngreso,
                                            s.SocPrimerNombre, s.SocSegundoNombre, s.SocPrimerApellido, s.SocSegundoApellido, c.TC.TCMonto, c.TC.TCDescripcion);
                                    else
                                        dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre + " " + s.SocSegundoNombre, s.SocPrimerApellido + " " + s.SocSegundoApellido,
                                            c.CuotaId, c.CuotaAAAAMM, "Impaga", c.CuotaFechaDesde, false, c.CuotaFechaPaga, s.SocDireccion, s.SocEmail, s.SocFechaIngreso,
                                            s.SocPrimerNombre, s.SocSegundoNombre, s.SocPrimerApellido, s.SocSegundoApellido, c.TC.TCMonto, c.TC.TCDescripcion);
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
                                        c.CuotaId, c.CuotaAAAAMM, estado, c.CuotaFechaDesde, true, c.CuotaFechaPaga, s.SocDireccion, s.SocEmail, s.SocFechaIngreso,
                                        s.SocPrimerNombre, s.SocSegundoNombre, s.SocPrimerApellido, s.SocSegundoApellido, c.TC.TCMonto, c.TC.TCDescripcion);
                                else
                                    dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre + " " + s.SocSegundoNombre, s.SocPrimerApellido + " " + s.SocSegundoApellido,
                                        c.CuotaId, c.CuotaAAAAMM, estado, c.CuotaFechaDesde, false, c.CuotaFechaPaga, s.SocDireccion, s.SocEmail, s.SocFechaIngreso,
                                        s.SocPrimerNombre, s.SocSegundoNombre, s.SocPrimerApellido, s.SocSegundoApellido, c.TC.TCMonto, c.TC.TCDescripcion);
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
                Document doc = new Document();
                List<Impresion> listaImpresion = new List<Impresion>();
                bool seleccionado = false;

                foreach (DataGridViewRow row in dgvSocios.Rows)
                {
                    if (row.Cells["imprimir"].Value != null)
                    {
                        if ((bool)row.Cells["imprimir"].Value)
                        {
                            seleccionado = true;
                            Impresion i = new Impresion();
                            Socio s = new Socio();
                            Cuota c = new Cuota();
                            TipoCuota tc = new TipoCuota();

                            i.SocioImp = s;
                            c.TC = tc;
                            i.CuotaImp = c;

                            s.SocId = Convert.ToInt32(row.Cells["SocId"].Value.ToString());
                            s.SocCI = Convert.ToInt32(row.Cells["SocCI"].Value.ToString());
                            s.SocPrimerNombre = row.Cells["SocPrimerNombre"].Value.ToString();
                            s.SocSegundoNombre = row.Cells["SocSegundoNombre"].Value.ToString();
                            s.SocPrimerApellido = row.Cells["SocPrimerApellido"].Value.ToString();
                            s.SocSegundoApellido = row.Cells["SocSegundoApellido"].Value.ToString();
                            s.SocFechaIngreso = Convert.ToDateTime(row.Cells["FechaIngreso"].Value.ToString());
                            s.SocDireccion = row.Cells["SocDireccion"].Value.ToString();

                            if (!string.IsNullOrEmpty(row.Cells["SocEmail"].Value.ToString()))
                                s.SocEmail = row.Cells["SocEmail"].Value.ToString();
                            else
                                s.SocEmail = "";
                            c.CuotaId = Convert.ToInt32(row.Cells["CuotaId"].Value.ToString());
                            c.CuotaFechaDesde = Convert.ToDateTime(row.Cells["CuotaFechaDesde"].Value.ToString());
                            c.CuotaAAAAMM = row.Cells["CuotaAAAAMM"].Value.ToString();
                            tc.TCMonto = Convert.ToInt32(row.Cells["TCMonto"].Value.ToString());
                            tc.TCDescripcion = row.Cells["TCDescripcion"].Value.ToString();


                            listaImpresion.Add(i);
                        }
                    }
                }
                //  ACA VA LA PARTE DE CREAR EL PDF
                if (!seleccionado)
                {
                    MessageBox.Show("Debe seleccionar al menos una cuota para imprimir.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    PDFImpresion(listaImpresion);
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
                                            s.SocPrimerApellido + " " + s.SocSegundoApellido, c.CuotaId, c.CuotaAAAAMM, "Impaga", c.CuotaFechaDesde, false, c.CuotaFechaPaga, 
                                            s.SocDireccion, s.SocEmail, s.SocFechaIngreso, s.SocPrimerNombre, s.SocSegundoNombre, s.SocPrimerApellido, s.SocSegundoApellido, c.TC.TCMonto, c.TC.TCDescripcion);
                            }
                        }
                        if (listaCuotas.Count > 0 && !soloCuotasImpagas)
                        {
                            foreach (Cuota c in listaCuotas)
                            {
                                if (c.CuotaPaga && c.CuotaAAAAMM == mes + "/" + año)
                                    dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre + " " + s.SocSegundoNombre,
                                            s.SocPrimerApellido + " " + s.SocSegundoApellido, c.CuotaId, c.CuotaAAAAMM, "Paga", c.CuotaFechaDesde, false, c.CuotaFechaPaga,
                                            s.SocDireccion, s.SocEmail, s.SocFechaIngreso, s.SocPrimerNombre, s.SocSegundoNombre, s.SocPrimerApellido, s.SocSegundoApellido, c.TC.TCMonto, c.TC.TCDescripcion);
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
                                if (!c.CuotaPaga)
                                    dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre + " " + s.SocSegundoNombre,
                                            s.SocPrimerApellido + " " + s.SocSegundoApellido, c.CuotaId, c.CuotaAAAAMM, "Impaga", c.CuotaFechaDesde, false, c.CuotaFechaPaga,
                                            s.SocDireccion, s.SocEmail, s.SocFechaIngreso, s.SocPrimerNombre, s.SocSegundoNombre, s.SocPrimerApellido, s.SocSegundoApellido, c.TC.TCMonto, c.TC.TCDescripcion);
                                if (c.CuotaPaga)
                                    dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre + " " + s.SocSegundoNombre,
                                            s.SocPrimerApellido + " " + s.SocSegundoApellido, c.CuotaId, c.CuotaAAAAMM, "Paga", c.CuotaFechaDesde, false, c.CuotaFechaPaga,
                                            s.SocDireccion, s.SocEmail, s.SocFechaIngreso, s.SocPrimerNombre, s.SocSegundoNombre, s.SocPrimerApellido, s.SocSegundoApellido, c.TC.TCMonto, c.TC.TCDescripcion);
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
        void PDFImpresion(List<Impresion> lista)
        {
            string path = "c:\\Reportes\\";
            try
            {
                if (lista != null)
                {
                    if (lista.Count > 0)
                    {
                        string nombreReporte = "Cuotas";
                        Document doc = new Document(PageSize.A4);
                        doc.SetMargins(28f, 28f, 70f, 85f);
                        string NombrePDF = nombreReporte + "-" + DateTime.Today.Day + "-" + DateTime.Today.Month + "-" + DateTime.Today.Year + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute;

                        // Se crea carpeta si no existe
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }

                        PdfWriter.GetInstance(doc, new FileStream(path + NombrePDF + ".pdf", FileMode.Create));
                        doc.Open();

                        BaseFont _textoGrande = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                        iTextSharp.text.Font textoGrande = new iTextSharp.text.Font(_textoGrande, 11f, iTextSharp.text.Font.BOLDITALIC, new BaseColor(0, 0, 0));

                        BaseFont _textoLeyenda = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                        iTextSharp.text.Font textoLeyenda = new iTextSharp.text.Font(_textoLeyenda, 6f, iTextSharp.text.Font.BOLDITALIC, new BaseColor(0, 0, 0));

                        BaseFont _textoLabel = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, true);
                        iTextSharp.text.Font textoLabel = new iTextSharp.text.Font(_textoLabel, 6f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));

                        BaseFont _textoInfo = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, true);
                        iTextSharp.text.Font textoInfo = new iTextSharp.text.Font(_textoInfo, 6f, iTextSharp.text.Font.BOLD, new BaseColor(0, 0, 0));

                        BaseFont _textoBlanco = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, true);
                        iTextSharp.text.Font textoBlanco = new iTextSharp.text.Font(_textoBlanco, 6f, iTextSharp.text.Font.BOLD, new BaseColor(Color.White));

                        iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(Resources.logo, System.Drawing.Imaging.ImageFormat.Png);
                        logo.ScaleAbsoluteWidth(40);
                        logo.ScaleAbsoluteHeight(26);
                        logo.Alignment = Element.ALIGN_RIGHT;

                        doc.Add(Chunk.NEWLINE);

                        int n = 0;
                        int nl = lista.Count();

                        foreach (Impresion i in lista)
                        {
                            n = n + 1;

                            var tbl = new PdfPTable(new float[] { 5f, 8f, 1f, 1f, 10f, 5f, 5f, 5f, 5f, 5f, }) { WidthPercentage = 100f };
                            tbl.AddCell(new PdfPCell(new Phrase("-", textoBlanco)) { Colspan = 2 });;
                            tbl.AddCell(new PdfPCell(new Phrase("", textoLabel)) { BorderWidthTop = 0, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderColor = BaseColor.CYAN });
                            tbl.AddCell(new PdfPCell(new Phrase("", textoLabel)) { Border = 0 });
                            tbl.AddCell(new PdfPCell(logo) { Rowspan = 3, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_CENTER, Padding = 2f });
                            tbl.AddCell(new PdfPCell(new Phrase("CLUB SPORTIVO POLICIAL Y CÍRCULO POLICIAL", textoGrande)) { Colspan = 5, Rowspan = 2 });
                            tbl.AddCell(new PdfPCell(new Phrase("Socio: ", textoLabel)) { Colspan = 1 });
                            tbl.AddCell(new PdfPCell(new Phrase(i.CuotaImp.TC.TCDescripcion.ToString().Trim() + "     Nº: " + i.SocioImp.SocId, textoInfo)) { Colspan = 1 });
                            tbl.AddCell(new PdfPCell(new Phrase("", textoLabel)) { BorderWidthTop = 0, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderColor = BaseColor.CYAN });
                            tbl.AddCell(new PdfPCell(new Phrase("", textoLabel)) { Border = 0 });                         
                            tbl.AddCell(new PdfPCell(new Phrase("Nombre: ", textoLabel)));
                            tbl.AddCell(new PdfPCell(new Phrase(i.SocioImp.SocPrimerNombre.ToString() + " " + i.SocioImp.SocSegundoNombre.ToString() + " "
                                                  + i.SocioImp.SocPrimerApellido.ToString() + " " + i.SocioImp.SocSegundoApellido.ToString(), textoInfo)));
                            tbl.AddCell(new PdfPCell(new Phrase("", textoLabel)) { BorderWidthTop = 0, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderColor = BaseColor.CYAN });
                            tbl.AddCell(new PdfPCell(new Phrase("", textoLabel)) { Border = 0 });
                            tbl.AddCell(new PdfPCell(new Phrase("Fundado el 27 de agosto de 1947 - Personería Jurídica desde el 12 de diciembre", textoLeyenda)) { Colspan = 5, });
                            //------
                            tbl.AddCell(new PdfPCell(new Phrase("Domicilio: ", textoLabel)));
                            tbl.AddCell(new PdfPCell(new Phrase(i.SocioImp.SocDireccion.ToString(), textoInfo)));
                            tbl.AddCell(new PdfPCell(new Phrase("", textoLabel)) { BorderWidthTop = 0, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderColor = BaseColor.CYAN });
                            tbl.AddCell(new PdfPCell(new Phrase("", textoLabel)) { Border = 0 });
                            tbl.AddCell(new PdfPCell(new Phrase("Cuota Social: ", textoLabel)));
                            tbl.AddCell(new PdfPCell(new Phrase("$ " + i.CuotaImp.TC.TCMonto.ToString(), textoInfo)));
                            tbl.AddCell(new PdfPCell(new Phrase("Email: ", textoLabel)));
                            tbl.AddCell(new PdfPCell(new Phrase(i.SocioImp.SocEmail.ToString().Trim(), textoLabel)) { Colspan = 3 });
                            //------
                            tbl.AddCell(new PdfPCell(new Phrase("Cuota Social: ", textoLabel)));
                            tbl.AddCell(new PdfPCell(new Phrase("$ " + i.CuotaImp.TC.TCMonto.ToString(), textoInfo)));
                            tbl.AddCell(new PdfPCell(new Phrase("", textoLabel)) { BorderWidthTop = 0, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderColor = BaseColor.CYAN });
                            tbl.AddCell(new PdfPCell(new Phrase("", textoLabel)) { Border = 0 });
                            tbl.AddCell(new PdfPCell(new Phrase("Nº de Socio: ", textoLabel)));
                            tbl.AddCell(new PdfPCell(new Phrase(i.SocioImp.SocId.ToString(), textoInfo)));
                            tbl.AddCell(new PdfPCell(new Phrase("Fecha de Ingreso: ", textoLabel)));
                            tbl.AddCell(new PdfPCell(new Phrase(i.SocioImp.SocFechaIngreso.ToString("dd/MM/yyyy"), textoInfo)) { Colspan = 3 });
                            //------
                            tbl.AddCell(new PdfPCell(new Phrase("Fecha de Emisión: ", textoLabel)));
                            tbl.AddCell(new PdfPCell(new Phrase(i.CuotaImp.CuotaFechaDesde.ToString("dd/MM/yyyy"), textoInfo)));
                            tbl.AddCell(new PdfPCell(new Phrase("", textoLabel)) { BorderWidthTop = 0, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderColor = BaseColor.CYAN });
                            tbl.AddCell(new PdfPCell(new Phrase("", textoLabel)) { Border = 0 });
                            tbl.AddCell(new PdfPCell(new Phrase("Nombre: ", textoLabel)));
                            tbl.AddCell(new PdfPCell(new Phrase(i.SocioImp.SocPrimerNombre.ToString() + " " + i.SocioImp.SocSegundoNombre.ToString() + " "
                                                  + i.SocioImp.SocPrimerApellido.ToString() + " " + i.SocioImp.SocSegundoApellido.ToString(), textoInfo))
                            { Colspan = 5 });
                            //------
                            tbl.AddCell(new PdfPCell(new Phrase("-", textoBlanco)) { Colspan = 2 });
                            tbl.AddCell(new PdfPCell(new Phrase("", textoLabel)) { BorderWidthTop = 0, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderColor = BaseColor.CYAN });
                            tbl.AddCell(new PdfPCell(new Phrase("", textoLabel)) { Border = 0 });
                            tbl.AddCell(new PdfPCell(new Phrase("Domicilio: ", textoLabel)));
                            tbl.AddCell(new PdfPCell(new Phrase(i.SocioImp.SocDireccion.ToString(), textoInfo)) { Colspan = 5 });
                            //------
                            tbl.AddCell(new PdfPCell(new Phrase("-", textoBlanco)) { Colspan = 2 });
                            tbl.AddCell(new PdfPCell(new Phrase("", textoLabel)) { BorderWidthTop = 0, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderColor = BaseColor.CYAN });
                            tbl.AddCell(new PdfPCell(new Phrase("", textoLabel)) { Border = 0 });
                            tbl.AddCell(new PdfPCell(new Phrase("Pago del Mes: ", textoLabel)));
                            tbl.AddCell(new PdfPCell(new Phrase(i.CuotaImp.CuotaFechaDesde.ToString("MM/yyyy"), textoInfo)) { Colspan = 2 });
                            tbl.AddCell(new PdfPCell(new Phrase("Fecha de Emisión: ", textoLabel)));
                            tbl.AddCell(new PdfPCell(new Phrase(i.CuotaImp.CuotaFechaDesde.ToString("dd/MM/yyyy"), textoInfo)) { Colspan = 3 });

                            if (n < nl)
                            {
                                //------
                                tbl.AddCell(new PdfPCell(new Phrase("-", textoBlanco)) { BorderWidthTop = 0, BorderWidthLeft = 0, BorderWidthRight = 0, BorderColor = BaseColor.CYAN });
                                tbl.AddCell(new PdfPCell(new Phrase("-", textoBlanco)) { BorderWidthTop = 0, BorderWidthLeft = 0, BorderWidthRight = 0, BorderColor = BaseColor.CYAN });
                                tbl.AddCell(new PdfPCell(new Phrase("-", textoBlanco)) { BorderWidthTop = 0, BorderWidthLeft = 0, BorderColor = BaseColor.CYAN });
                                tbl.AddCell(new PdfPCell(new Phrase("-", textoBlanco)) { BorderWidthTop = 0, BorderWidthRight = 0, BorderWidthLeft = 0, BorderColor = BaseColor.CYAN });
                                tbl.AddCell(new PdfPCell(new Phrase("-", textoBlanco)) { BorderWidthTop = 0, BorderWidthLeft = 0, BorderWidthRight = 0, BorderColor = BaseColor.CYAN });
                                tbl.AddCell(new PdfPCell(new Phrase("-", textoBlanco)) { Colspan = 5, BorderWidthTop = 0, BorderWidthLeft = 0, BorderWidthRight = 0, BorderColor = BaseColor.CYAN });
                                //------
                                tbl.AddCell(new PdfPCell(new Phrase("-", textoBlanco)) { Border = 0 });
                                tbl.AddCell(new PdfPCell(new Phrase("-", textoBlanco)) { Border = 0 });
                                tbl.AddCell(new PdfPCell(new Phrase("-", textoBlanco)) { BorderWidthTop = 0, BorderWidthLeft = 0, BorderWidthBottom = 0, BorderColor = BaseColor.CYAN });
                                tbl.AddCell(new PdfPCell(new Phrase("-", textoBlanco)) { Border = 0 });
                                tbl.AddCell(new PdfPCell(new Phrase("-", textoBlanco)) { Border = 0 });
                                tbl.AddCell(new PdfPCell(new Phrase("-", textoBlanco)) { Colspan = 5, Border = 0 });
                            }

                            doc.Add(tbl);

                        }


                        doc.Close();
                        Process.Start(path + NombrePDF + ".pdf");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
