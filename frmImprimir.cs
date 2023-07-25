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
            btnBuscar.BackColor = RGBColors.color4;
            btnPagarCuotas.BackColor = RGBColors.color4;
            ListarCuotasSocios();
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
                //SaveFileDialog guardar = new SaveFileDialog();
                //guardar.FileName = DateTime.Now.ToString("ddMMyyyy") + ".pdf";
                string nombre = DateTime.Now.ToString("ddMMyyyy") + ".pdf";
                string plantillaHtlm = Properties.Resources.plantillaHTML.ToString();



                System.IO.FileStream fileStream = new FileStream(nombre, FileMode.Create);

                    Document doc = new Document(iTextSharp.text.PageSize.A4, 10, 10, 10, 10);
                    PdfWriter writer = PdfWriter.GetInstance(doc, fileStream);

                    doc.Open();
                    doc.Add(new Phrase(""));

                    using (StreamReader reader = new StreamReader(plantillaHtlm))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, reader);
                    }

                    doc.Close();
                    fileStream.Close();


                //plantillaHtlm = plantillaHtlm.Replace("@Socio", filaSeleccionada.Cells["SocId"].Value.ToString());
                //plantillaHtlm = plantillaHtlm.Replace("@Nombre", filaSeleccionada.Cells["SocPrimerNombre"].Value.ToString() + filaSeleccionada.Cells["SocPrimerApellido"].Value.ToString());
                //plantillaHtlm = plantillaHtlm.Replace("@Direccion", filaSeleccionada.Cells["SocDireccion"].Value.ToString());
                //plantillaHtlm = plantillaHtlm.Replace("@CuotaSocial", filaSeleccionada.Cells["SocId"].Value.ToString());
                //plantillaHtlm = plantillaHtlm.Replace("@FechaDeEmision", filaSeleccionada.Cells["SocId"].Value.ToString());
                //plantillaHtlm = plantillaHtlm.Replace("@Email", filaSeleccionada.Cells["SocId"].Value.ToString());
                //plantillaHtlm = plantillaHtlm.Replace("@FechaDeIngreso", filaSeleccionada.Cells["SocId"].Value.ToString());
                //plantillaHtlm = plantillaHtlm.Replace("@AnioMes", filaSeleccionada.Cells["CuotaAAAAMM"].Value.ToString());

                //if (guardar.ShowDialog() == DialogResult.OK)
                //{
                //    using (FileStream fileStream = new FileStream(guardar.FileName, FileMode.Create, FileAccess.Write))
                //    {
                //        Document doc = new Document(iTextSharp.text.PageSize.A4,10,10,10,10);
                //        PdfWriter writer = PdfWriter.GetInstance(doc,fileStream);

                //        doc.Open();
                //        doc.Add(new Phrase(""));

                //        using(StreamReader reader = new StreamReader(plantillaHtlm))
                //        {
                //            XMLWorkerHelper.GetInstance().ParseXHtml(writer,doc,reader); 
                //        }

                //        doc.Close();
                //        fileStream.Close();
                //    }
                //}
                //else { }
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

                if (listaSocios.Count > 0)
                {
                    foreach (Socio s in listaSocios)
                    {
                        listaCuotas = lc.BuscarCuotasSocio(s.SocId).ToList();

                        if (listaCuotas.Count > 0 && soloCuotasImpagas)    
                        {
                            foreach (Cuota c in listaCuotas)
                            {
                                //dgvSocios.Rows.Cast<DataGridViewRow>().
                                //Where(p => Convert.ToBoolean(p.Cells["Pagar"].Value) == false);
                                if (!c.CuotaPaga)
                                    dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre, s.SocPrimerApellido, c.CuotaId, c.CuotaAAAAMM, c.CuotaPaga);
                            }
                        }
                        if (listaCuotas.Count > 0 && !soloCuotasImpagas)
                        {
                            foreach (Cuota c in listaCuotas)
                            {
                                dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre, s.SocPrimerApellido, c.CuotaId, c.CuotaAAAAMM, c.CuotaPaga);
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
        public void PagarCuotas() 
        {
            try
            {
                IServicePolicial ls = new ServicePolicialClient();
                Cuota cuota = new Cuota();
                DataTable dtRetorno = new DataTable();
                var filaSeleccionada = dgvSocios.CurrentRow;
                DialogResult drPagar;
                DialogResult drImprimir;

                int totalSeleccion = dgvSocios.Rows.Cast<DataGridViewRow>().
                    Where(p => Convert.ToBoolean(p.Cells["Pagar"].Value)).Count();
                if(totalSeleccion > 0)
                {
                    drPagar = MessageBox.Show("Confirma pagar " + totalSeleccion + " cuotas seleccionadas?",
                         "Pagar seleccion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }

                foreach (DataGridViewRow row in dgvSocios.Rows)
                {
                    if(Convert.ToBoolean(row.Cells["Pagar"].Value))
                    {
                        Usuario usuario = new Usuario();
                        //cmd.Parameters.AddWithValue("@IdSocio", c.SocId);
                        //cmd.Parameters.AddWithValue("@IdCuota", c.CuotaId);
                        //cmd.Parameters.AddWithValue("@CuotaFechaPaga", c.CuotaFechaPaga);
                        cuota.SocId = Convert.ToInt32(row.Cells["SocId"].Value);
                        cuota.CuotaId = Convert.ToInt32(row.Cells["CuotaId"].Value);
                        cuota.CuotaFechaPaga = DateTime.Now;
                        ls.PagarCuotaSocio(cuota, usuario);
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                PagarCuotas();
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

                IServicePolicial lc = new ServicePolicialClient();
                IServicePolicial ls = new ServicePolicialClient();
                List<Cuota> listaCuotas = new List<Cuota>();
                List<Socio> listaSocios = new List<Socio>();
                dgvSocios.Rows.Clear();
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
                                //dgvSocios.Rows.Cast<DataGridViewRow>().
                                //Where(p => p.Cells["CuotaAAAAMM"].Value.ToString() == mes + "/" + año);
                                if (!c.CuotaPaga && c.CuotaAAAAMM == mes + "/" + año)
                                    dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre, s.SocPrimerApellido, c.CuotaId, c.CuotaAAAAMM, c.CuotaPaga);
                            }
                        }
                        if (listaCuotas.Count > 0 && !soloCuotasImpagas)
                        {
                            foreach (Cuota c in listaCuotas)
                            {
                                //dgvSocios.Rows.Cast<DataGridViewRow>().
                                //Where(p => p.Cells["CuotaAAAAMM"].Value.ToString() == mes + "/" + año);
                                //if (c.CuotaPaga && c.CuotaAAAAMM == mes + "/" + año)
                                    dgvSocios.Rows.Add(s.SocId, s.SocCI, s.SocPrimerNombre, s.SocPrimerApellido, c.CuotaId, c.CuotaAAAAMM, c.CuotaPaga);
                            }
                        }
                    }
                }




                //DataTable dataTable = new DataTable();
                //dataTable.Columns.Add("Socio");
                //dataTable.Columns.Add("Cédula");
                //dataTable.Columns.Add("Nombre");
                //dataTable.Columns.Add("Apellido");
                //dataTable.Columns.Add("Cuota");
                //dataTable.Columns.Add("Mes/Año");
                //dataTable.Columns.Add("Pagar");
                //dataTable.Columns.Add("Imprimir");
                //dataTable.Columns.Add("SocDireccion");

                ////Recorrer filas
                //foreach (DataGridViewRow fila in this.dgvSocios.Rows)
                //{
                //    DataRow dr = dataTable.NewRow();
                //    dr[0] = fila.Cells[0].Value.ToString();
                //    dr[1] = fila.Cells[1].Value.ToString();
                //    dr[2] = fila.Cells[2].Value.ToString();
                //    dr[3] = fila.Cells[3].Value.ToString();
                //    dr[4] = fila.Cells[4].Value.ToString();
                //    dr[5] = fila.Cells[5].Value.ToString();
                //    dr[6] = fila.Cells[6].Value;
                //    dr[7] = fila.Cells[7].Value;
                //    dataTable.Rows.Add(dr);
                //}

                //dgvSocios.Rows.Clear();
                //if (dataTable.Rows.Count > 0)
                //{
                //    foreach (DataRow c in dataTable.Rows)
                //    {
                //        dgvSocios.Rows.Add(c[0].ToString);
                //    }
                //}
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
