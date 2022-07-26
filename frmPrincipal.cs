using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FontAwesome.Sharp;
using EntidadesCompartidas;
using System.Runtime.InteropServices;

namespace Policial
{
    public partial class frmPrincipal : Form
    {
        private IconButton currentButton;
        private Panel leftBorderBtn;
        internal static Usuario usuarioLogueado;
        Form currentChilForm;

        public frmPrincipal()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        //Metodos
        private void ActivateButton(object senderBtn, Color color)
        {
            if(senderBtn != null)
            {
                DisableButton();
                //button
                currentButton = (IconButton)senderBtn;
                currentButton.BackColor = Color.FromArgb(39, 39, 58);
                currentButton.ForeColor = color;
                currentButton.TextAlign = ContentAlignment.MiddleCenter;
                currentButton.IconColor = color;
                currentButton.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentButton.ImageAlign = ContentAlignment.MiddleRight;
                //left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentButton.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //Icon Current Child
                btnHijoActual.IconChar = currentButton.IconChar;
                btnHijoActual.IconColor = color;
                lblTituloFormularioHijo.Text = currentButton.Text;
                panelShadow.BackColor = color;
            }
        }
        private void DisableButton()
        {
            if (currentButton != null)
            {
                currentButton.BackColor = Color.FromArgb(51, 51, 76);
                currentButton.ForeColor = Color.Gainsboro;
                currentButton.TextAlign = ContentAlignment.MiddleLeft;
                currentButton.IconColor = Color.Gainsboro; 
                currentButton.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentButton.ImageAlign = ContentAlignment.MiddleLeft;;
            }
        }
        public struct RGBColors
        {
            public static Color color = Color.FromArgb(172,126,241);
            public static Color color1 = Color.FromArgb(248,118,176);
            public static Color color2 = Color.FromArgb(253,138,114);
            public static Color color3 = Color.FromArgb(95,77,221);
            public static Color color4 = Color.FromArgb(249,88,155);
            public static Color color5 = Color.FromArgb(24,161,251);
        }
        #region Eventos
        private void iconButton1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            OpenChildForm(new frmSocio());
            this.panelShadow.BackColor = RGBColors.color5;
            btnMaximizar.IconColor = RGBColors.color5;
            btnMinimizar.IconColor = RGBColors.color5;
            btnCerrar.IconColor = RGBColors.color5;
        }
        private void iconButton2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new frmNucleoFamiliar());
            this.panelShadow.BackColor = RGBColors.color2;
            btnMaximizar.IconColor = RGBColors.color2;
            btnMinimizar.IconColor = RGBColors.color2;
            btnCerrar.IconColor = RGBColors.color2;
        }
        private void iconButton3_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new frmReportes());
            this.panelShadow.BackColor = RGBColors.color1;
            btnMaximizar.IconColor = RGBColors.color1;
            btnMinimizar.IconColor = RGBColors.color1;
            btnCerrar.IconColor = RGBColors.color1;
        }
        private void iconButton4_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new frmRecibos());
            this.panelShadow.BackColor = RGBColors.color3;
            btnMaximizar.IconColor = RGBColors.color3;
            btnMinimizar.IconColor = RGBColors.color3;
            btnCerrar.IconColor = RGBColors.color3;
        }
        private void iconButton6_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color);
            OpenChildForm(new frmMantenimiento());
            this.panelShadow.BackColor = RGBColors.color;
            btnMaximizar.IconColor = RGBColors.color;
            btnMinimizar.IconColor = RGBColors.color;
            btnCerrar.IconColor = RGBColors.color;
        }
        private void iconButton5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnInicio_Click(object sender, EventArgs e)
        {
            currentChilForm.Close();
            this.panelShadow.BackColor = Color.Gainsboro;
            btnMaximizar.IconColor = Color.Gainsboro;
            btnMinimizar.IconColor = Color.Gainsboro;
            btnCerrar.IconColor = Color.Gainsboro;
            Reset();
        }
        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }
        private void btnimprimir_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            OpenChildForm(new frmImprimir());
            this.panelShadow.BackColor = RGBColors.color4;
            btnMaximizar.IconColor = RGBColors.color4;
            btnMinimizar.IconColor = RGBColors.color4;
            btnCerrar.IconColor = RGBColors.color4;
        }
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        private void OpenChildForm(Form form)
        {
            if (currentChilForm != null)
                currentChilForm.Close();
            currentChilForm = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelEscritorio.Controls.Add(form);
            panelEscritorio.Tag = form;
            form.BringToFront();
            form.Show();
            lblTituloFormularioHijo.Text = form.Text;
        }
        public void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            btnHijoActual.IconChar = IconChar.Home;
            btnHijoActual.IconColor = Color.Gainsboro;
            lblTituloFormularioHijo.Text = "Inicio";
            panelShadow.BackColor = Color.FromArgb(26, 32, 40);
        }

        //Drag Form
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("User32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParm, int lParm);
        private void panelTituloBarra_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void btnMaximizar_MouseHover(object sender, EventArgs e)
        {
            //BackColor = Color.FromArgb(39, 39, 58);
        }
    }
}
