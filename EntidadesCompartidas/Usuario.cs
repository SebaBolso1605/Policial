using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Usuario
    {
        private int usuId;
        private string usuClaveAcceso;
        private string usuPass;
        private string usuNombre;
        private bool usuActivo;

        public Usuario(int usuId, string usuClaveAcceso, string usuPass, string usuNombre, bool usuActivo)
        {
            this.usuId = usuId;
            this.usuClaveAcceso = usuClaveAcceso;
            this.usuPass = usuPass;
            this.usuNombre = usuNombre;
            this.usuActivo = usuActivo;
        }

        public Usuario() {}

        public int UsuId { get => usuId; set => usuId = value; }
        public string UsuClaveAcceso { get => usuClaveAcceso; set => usuClaveAcceso = value; }
        public string UsuPass { get => usuPass; set => usuPass = value; }
        public string UsuNombre { get => usuNombre; set => usuNombre = value; }
        public bool UsuActivo { get => usuActivo; set => usuActivo = value; }
    }
}
