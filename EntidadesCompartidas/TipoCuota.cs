using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
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

        public int TCId { get => tCId; set => tCId = value; }
        public string TCDescripcion { get => tCDescripcion; set => tCDescripcion = value; }
        public int TCMonto { get => tCMonto; set => tCMonto = value; }
        public DateTime FecAlta { get => fecAlta; set => fecAlta = value; }
        public DateTime FecModif { get => fecModif; set => fecModif = value; }
        public int UsuIdAlta { get => usuIdAlta; set => usuIdAlta = value; }
        public int UsuIdModif { get => usuIdModif; set => usuIdModif = value; }
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
