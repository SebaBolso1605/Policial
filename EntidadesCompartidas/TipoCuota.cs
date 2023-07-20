using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace EntidadesCompartidas
{
    [DataContract]
    public class TipoCuota
    {
        private int tCId;
        private string tCDescripcion;
        private int tCMonto;
        private bool tCActivo;
        private DateTime fecAlta;
        private DateTime fecModif;
        private int usuIdAlta;
        private int usuIdModif;

        [DataMember]
        public int TCId { get => tCId; set => tCId = value; }

        [DataMember]
        public string TCDescripcion { get => tCDescripcion; set => tCDescripcion = value; }

        [DataMember]
        public int TCMonto { get => tCMonto; set => tCMonto = value; }

        [DataMember]
        public DateTime FecAlta { get => fecAlta; set => fecAlta = value; }

        [DataMember]
        public DateTime FecModif { get => fecModif; set => fecModif = value; }

        [DataMember]
        public int UsuIdAlta { get => usuIdAlta; set => usuIdAlta = value; }

        [DataMember]
        public int UsuIdModif { get => usuIdModif; set => usuIdModif = value; }

        [DataMember]
        public bool TCActivo { get => tCActivo; set => tCActivo = value; }

        public TipoCuota(){ }

        public TipoCuota(int tCId, string tCDescripcion, int tCMonto, DateTime fecAlta, DateTime fecModif, int usuIdAlta, int usuIdModif)
        {
            this.tCId = tCId;
            this.tCDescripcion = tCDescripcion;
            this.tCMonto = tCMonto;
            this.fecAlta = fecAlta;
            this.fecModif = fecModif;
            this.usuIdAlta = usuIdAlta;
            this.usuIdModif = usuIdModif;
        }
    }
}
