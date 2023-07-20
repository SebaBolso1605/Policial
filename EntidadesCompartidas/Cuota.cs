using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace EntidadesCompartidas
{
    [DataContract]
    public class Cuota
    {
        private int cuotaId;
        private int socId;
        private DateTime cuotaFechaDesde;
        private DateTime cuotaFechaHasta;
        private int cuotaTipo;
        private bool cuotaPaga;
        private DateTime cuotaFechaPaga;
        private string cuotaAAAAMM;
        private DateTime fecAlta;
        private DateTime fecModif;
        private int usuIdAlta;
        private int usuIdModif;

        [DataMember]
        public int CuotaId { get => cuotaId; set => cuotaId = value; }

        [DataMember]
        public DateTime CuotaFechaDesde { get => cuotaFechaDesde; set => cuotaFechaDesde = value; }

        [DataMember]
        public DateTime CuotaFechaHasta { get => cuotaFechaHasta; set => cuotaFechaHasta = value; }

        [DataMember]
        public int CuotaTipo { get => cuotaTipo; set => cuotaTipo = value; }

        [DataMember]
        public DateTime FecAlta { get => fecAlta; set => fecAlta = value; }

        [DataMember]
        public DateTime FecModif { get => fecModif; set => fecModif = value; }

        [DataMember]
        public int UsuIdAlta { get => usuIdAlta; set => usuIdAlta = value; }

        [DataMember]
        public int UsuIdModif { get => usuIdModif; set => usuIdModif = value; }

        [DataMember]
        public int SocId { get => socId; set => socId = value; }

        [DataMember]
        public bool CuotaPaga { get => cuotaPaga; set => cuotaPaga = value; }

        [DataMember]
        public DateTime CuotaFechaPaga { get => cuotaFechaPaga; set => cuotaFechaPaga = value; }

        [DataMember]
        public string CuotaAAAAMM { get => cuotaAAAAMM; set => cuotaAAAAMM = value; }

        public Cuota(){ }

        public Cuota(int cuotaId, int socId, DateTime cuotaFechaDesde, DateTime cuotaFechaHasta, int cuotaTipo, DateTime cuotafechaPago,bool cuotaPaga, string cuotaAAAAMM,
            DateTime fecAlta, DateTime fecModif, int usuIdAlta, int usuIdModif)
        {
            this.cuotaId = cuotaId;
            this.socId = socId;
            this.cuotaFechaDesde = cuotaFechaDesde;
            this.cuotaFechaHasta = cuotaFechaHasta;
            this.cuotaTipo = cuotaTipo;
            this.cuotaPaga = cuotaPaga;
            this.cuotaAAAAMM = cuotaAAAAMM;
            this.cuotaFechaDesde = cuotafechaPago;
            this.fecAlta = fecAlta;
            this.fecModif = fecModif;
            this.usuIdAlta = usuIdAlta;
            this.usuIdModif = usuIdModif;
        }
    }
}
