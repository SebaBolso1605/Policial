using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
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

        public int CuotaId { get => cuotaId; set => cuotaId = value; }
        public DateTime CuotaFechaDesde { get => cuotaFechaDesde; set => cuotaFechaDesde = value; }
        public DateTime CuotaFechaHasta { get => cuotaFechaHasta; set => cuotaFechaHasta = value; }
        public int CuotaTipo { get => cuotaTipo; set => cuotaTipo = value; }
        public DateTime FecAlta { get => fecAlta; set => fecAlta = value; }
        public DateTime FecModif { get => fecModif; set => fecModif = value; }
        public int UsuIdAlta { get => usuIdAlta; set => usuIdAlta = value; }
        public int UsuIdModif { get => usuIdModif; set => usuIdModif = value; }
        public int SocId { get => socId; set => socId = value; }
        public bool CuotaPaga { get => cuotaPaga; set => cuotaPaga = value; }
        public DateTime CuotaFechaPaga { get => cuotaFechaPaga; set => cuotaFechaPaga = value; }
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
