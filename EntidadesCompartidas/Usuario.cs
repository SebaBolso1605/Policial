using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceModel;
using System.Runtime.Serialization;

namespace EntidadesCompartidas
{
    [DataContract]
    public class Usuario
    {
        private int usuId;
        private string usuClaveAcceso;
        private string usuPass;
        private string usuNombre;
        private bool usuActivo;

        [DataMember]
        public int UsuId { get => usuId; set => usuId = value; }
        [DataMember]
        public string UsuClaveAcceso { get => usuClaveAcceso; set => usuClaveAcceso = value; }
        [DataMember]
        public string UsuPass { get => usuPass; set => usuPass = value; }
        [DataMember]
        public string UsuNombre { get => usuNombre; set => usuNombre = value; }
        [DataMember]
        public bool UsuActivo { get => usuActivo; set => usuActivo = value; }

        public Usuario(int usuId, string usuClaveAcceso, string usuPass, string usuNombre, bool usuActivo)
        {
            this.usuId = usuId;
            this.usuClaveAcceso = usuClaveAcceso;
            this.usuPass = usuPass;
            this.usuNombre = usuNombre;
            this.usuActivo = usuActivo;
        }

        public Usuario() { }
    }
}
