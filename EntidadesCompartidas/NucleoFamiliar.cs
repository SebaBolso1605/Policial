using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace EntidadesCompartidas
{
    [DataContract]
    public class NucleoFamiliar
    {
        private int nFId;
        private int socId;
        private string nFPrimerApellido;
        private string nFSegundoApellido;
        private string nFPrimerNombre;
        private string nFSegundoNombre;
        private int nFCI;
        private DateTime nFFechaNacimiento;
        private string nfTipoVinculo;
        private string nFTel;
        private string nFCelular;
        private string nFobservaciones;
        private bool nFActivo;
        private DateTime fecAlta;
        private DateTime fecModif;
        private int usuIdModif;
        private int usuIdAlta;

        [DataMember]
        public int NFId { get => nFId; set => nFId = value; }

        [DataMember]
        public int SocId { get => socId; set => socId = value; }

        [DataMember]
        public string NFPrimerApellido { get => nFPrimerApellido; set => nFPrimerApellido = value; }

        [DataMember]
        public string NFSegundoApellido { get => nFSegundoApellido; set => nFSegundoApellido = value; }

        [DataMember]
        public string NFPrimerNombre { get => nFPrimerNombre; set => nFPrimerNombre = value; }

        [DataMember]
        public string NFSegundoNombre { get => nFSegundoNombre; set => nFSegundoNombre = value; }

        [DataMember]
        public int NFCI { get => nFCI; set => nFCI = value; }

        [DataMember]
        public DateTime NFFechaNacimiento { get => nFFechaNacimiento; set => nFFechaNacimiento = value; }

        [DataMember]
        public string NFTel { get => nFTel; set => nFTel = value; }

        [DataMember]
        public string NFCelular { get => nFCelular; set => nFCelular = value; }

        [DataMember]
        public bool NFActivo { get => nFActivo; set => nFActivo = value; }

        [DataMember]
        public DateTime FecAlta { get => fecAlta; set => fecAlta = value; }

        [DataMember]
        public DateTime FecModif { get => fecModif; set => fecModif = value; }

        [DataMember]
        public int UsuIdModif { get => usuIdModif; set => usuIdModif = value; }

        [DataMember]
        public int UsuIdAlta { get => usuIdAlta; set => usuIdAlta = value; }

        [DataMember]
        public string NFobservaciones { get => nFobservaciones; set => nFobservaciones = value; }

        [DataMember]
        public string NfTipoVinculo { get => nfTipoVinculo; set => nfTipoVinculo = value; }

        public NucleoFamiliar(){ }

        public NucleoFamiliar(int nFId, int socId, string nFPrimerApellido, string nFSegundoApellido, string nFPrimerNombre, string nFSegundoNombre, 
            int nFCI, DateTime nFFechaNacimiento,string nfTipoVinculo, string nFTel, string nFCelular, string nFobservaciones, bool nFActivo,
            DateTime fecAlta, DateTime fecModif, int usuIdModif, int usuIdAlta)
        {
            this.nFId = nFId;
            this.socId = socId;
            this.nFPrimerApellido = nFPrimerApellido;
            this.nFSegundoApellido = nFSegundoApellido;
            this.nFPrimerNombre = nFPrimerNombre;
            this.nFSegundoNombre = nFSegundoNombre;
            this.nFCI = nFCI;
            this.nFFechaNacimiento = nFFechaNacimiento;
            this.nfTipoVinculo = nfTipoVinculo;
            this.nFTel = nFTel;
            this.nFCelular = nFCelular;
            this.nFobservaciones = nFobservaciones;
            this.nFActivo = nFActivo;
            this.fecAlta = fecAlta;
            this.fecModif = fecModif;
            this.usuIdModif = usuIdModif;
            this.usuIdAlta = usuIdAlta;
        }
    }
}
