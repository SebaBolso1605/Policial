using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FontAwesome.Sharp;
//using EntidadesCompartidas;
//using Logica;
using System.Xml;
using System.IO;
using Policial.ServicePolicial;

namespace Policial
{
    public partial class frmLogin : Form
    {
        public Usuario usuLogueado = null;
        string tituloMsg = "Logueo de Usuario";
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsuario.Text == "")
                {
                    string menssage = "Ingrese usuario.";
                    MessageBox.Show(menssage, tituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtPass.Text == "")
                {
                    string menssage = "Ingrese contraseña.";
                    MessageBox.Show(menssage, tituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //ILogicaUsuario _uns = FabricaLogica.getLogicaUsuario();
                    IServicePolicial _uns = new ServicePolicialClient();
                    Usuario _unEmpleado = _uns.Login(txtUsuario.Text.Trim(), txtPass.Text.Trim());

                    if (_unEmpleado == null)
                    {
                        string menssage = "No existe usuario.";
                        MessageBox.Show(menssage, tituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtUsuario.Focus();
                    }
                    else if (_unEmpleado.UsuPass == txtPass.Text.Trim())
                    {
                        string path = Application.StartupPath;
                        this.Hide();
                        usuLogueado = _unEmpleado;

                        Program.usuarioLogueado = usuLogueado;
                        frmPrincipal _unForm = new frmPrincipal();
                        frmPrincipal.usuarioLogueado = usuLogueado;
                        _unForm.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        string menssage = "Contraseña incorrecta.";
                        MessageBox.Show(menssage, tituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPass.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, tituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblBienvenido_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
