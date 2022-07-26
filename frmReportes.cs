using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Policial
{
    public partial class frmReportes : Form
    {
        public frmReportes()
        {
            InitializeComponent();
            lblTituloFormulario.ForeColor = RGBColors.color1;
            btnListar.BackColor = RGBColors.color1;
            btnListar.BackColor = RGBColors.color1;
            button1.BackColor = RGBColors.color1;
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
    }
}
