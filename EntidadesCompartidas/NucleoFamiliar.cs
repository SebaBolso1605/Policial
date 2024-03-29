﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
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
        private string nFTel;
        private string nFCelular;
        private string nFobservaciones;
        private bool nFActivo;
        private DateTime fecAlta;
        private DateTime fecModif;
        private int usuIdModif;
        private int usuIdAlta;

        public int NFId { get => nFId; set => nFId = value; }
        public int SocId { get => socId; set => socId = value; }
        public string NFPrimerApellido { get => nFPrimerApellido; set => nFPrimerApellido = value; }
        public string NFSegundoApellido { get => nFSegundoApellido; set => nFSegundoApellido = value; }
        public string NFPrimerNombre { get => nFPrimerNombre; set => nFPrimerNombre = value; }
        public string NFSegundoNombre { get => nFSegundoNombre; set => nFSegundoNombre = value; }
        public int NFCI { get => nFCI; set => nFCI = value; }
        public DateTime NFFechaNacimiento { get => nFFechaNacimiento; set => nFFechaNacimiento = value; }
        public string NFTel { get => nFTel; set => nFTel = value; }
        public string NFCelular { get => nFCelular; set => nFCelular = value; }
        public bool NFActivo { get => nFActivo; set => nFActivo = value; }
        public DateTime FecAlta { get => fecAlta; set => fecAlta = value; }
        public DateTime FecModif { get => fecModif; set => fecModif = value; }
        public int UsuIdModif { get => usuIdModif; set => usuIdModif = value; }
        public int UsuIdAlta { get => usuIdAlta; set => usuIdAlta = value; }
        public string NFobservaciones { get => nFobservaciones; set => nFobservaciones = value; }

        public NucleoFamiliar(){ }

        public NucleoFamiliar(int nFId, int socId, string nFPrimerApellido, string nFSegundoApellido, string nFPrimerNombre, string nFSegundoNombre, 
            int nFCI, DateTime nFFechaNacimiento, string nFTel, string nFCelular, string nFobservaciones, bool nFActivo,
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
