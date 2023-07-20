using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace EntidadesCompartidas
{
    [DataContract]
    public class Socio
    {
        private int socId;
        private string socPrimerApellido;
        private string socSegundoApellido;
        private string socPrimerNombre;
        private string socSegundoNombre;
        private int socCI;
        private DateTime socFechaNacimiento;
        private string socDireccion;
        private string socTel;
        private string socCelular;
        private string socEmail;
        private string socObservaciones;
        private bool socAtivo;
        private DateTime socFechaIngreso;
        private int socTipoCuota;
        private DateTime socFechaEgreso;
        private string socMotivoEgreso;
        private DateTime fecAlta;
        private DateTime fecModif;
        private int usuIdModif;
        private int usuIdAlta;

        [DataMember]
        public int SocId { get => socId; set => socId = value; }

        [DataMember]
        public string SocPrimerApellido { get => socPrimerApellido; set => socPrimerApellido = value; }

        [DataMember]
        public string SocSegundoApellido { get => socSegundoApellido; set => socSegundoApellido = value; }

        [DataMember]
        public string SocPrimerNombre { get => socPrimerNombre; set => socPrimerNombre = value; }

        [DataMember]
        public string SocSegundoNombre { get => socSegundoNombre; set => socSegundoNombre = value; }

        [DataMember]
        public int SocCI { get => socCI; set => socCI = value; }

        [DataMember]
        public DateTime SocFechaNacimiento { get => socFechaNacimiento; set => socFechaNacimiento = value; }

        [DataMember]
        public string SocDireccion { get => socDireccion; set => socDireccion = value; }

        [DataMember]
        public string SocTel { get => socTel; set => socTel = value; }

        [DataMember]
        public string SocCelular { get => socCelular; set => socCelular = value; }

        [DataMember]
        public string SocEmail { get => socEmail; set => socEmail = value; }

        [DataMember]
        public string SocObservaciones { get => socObservaciones; set => socObservaciones = value; }

        [DataMember]
        public bool SocAtivo { get => socAtivo; set => socAtivo = value; }

        [DataMember]
        public DateTime SocFechaIngreso { get => socFechaIngreso; set => socFechaIngreso = value; }

        [DataMember]
        public DateTime SocFechaEgreso { get => socFechaEgreso; set => socFechaEgreso = value; }

        [DataMember]
        public string SocMotivoEgreso { get => socMotivoEgreso; set => socMotivoEgreso = value; }

        [DataMember]
        public DateTime FecAlta { get => fecAlta; set => fecAlta = value; }

        [DataMember]
        public DateTime FecModif { get => fecModif; set => fecModif = value; }

        [DataMember]
        public int UsuIdModif { get => usuIdModif; set => usuIdModif = value; }

        [DataMember]
        public int UsuIdAlta { get => usuIdAlta; set => usuIdAlta = value; }

        [DataMember]
        public int SocTipoCuota { get => socTipoCuota; set => socTipoCuota = value; }

        public Socio(){ }

        public Socio(int socId, string socPrimerApellido, string socSegundoApellido, string socPrimerNombre, string socSegundoNombre,
           int socCI, DateTime socFechaNacimiento, string socDireccion, string socTel, string socCelular, string socEmail,
           string socObservaciones, bool socAtivo, DateTime socFechaIngreso, int SocTipoCuota,DateTime socFechaEgreso,
           string socMotivoEgreso, DateTime fecAlta, DateTime fecModif, int usuIdModif, int usuIdAlta)
        {
            SocId = socId;
            SocPrimerApellido = socPrimerApellido;
            SocSegundoApellido = socSegundoApellido;
            SocPrimerNombre = socPrimerNombre;
            SocSegundoNombre = socSegundoNombre;
            SocCI = socCI;
            SocFechaNacimiento = socFechaNacimiento;
            SocDireccion = socDireccion;
            SocTel = socTel;
            SocCelular = socCelular;
            SocEmail = socEmail;
            SocObservaciones = socObservaciones;
            SocAtivo = socAtivo;
            SocFechaIngreso = socFechaIngreso;
            socTipoCuota = SocTipoCuota;
            SocFechaEgreso = socFechaEgreso;
            SocMotivoEgreso = socMotivoEgreso;
            FecAlta = fecAlta;
            FecModif = fecModif;
            UsuIdModif = usuIdModif;
            UsuIdAlta = usuIdAlta;        
        }
    }
}
