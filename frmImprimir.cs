using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntidadesCompartidas;
using EntidadesCompartidas.Enums;
using Logica;

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
                ILogicaCuota lc = LogicaCuota.GetInstancia();
                ILogicaSocio ls = LogicaSocio.GetInstancia();
                List<Cuota> listaCuotas = new List<Cuota>();
                List<Socio> listaSocios = new List<Socio>();

                  listaSocios = ls.ListarSocios();

                if(listaSocios.Count > 0)
                {
                    foreach (Socio s in listaSocios)
                    {
                        listaCuotas = lc.BuscarCuotasSocio(s.SocId);
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
