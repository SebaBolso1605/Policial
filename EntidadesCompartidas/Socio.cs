using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
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

       
        public int SocId { get => socId; set => socId = value; }
        public string SocPrimerApellido { get => socPrimerApellido; set => socPrimerApellido = value; }
        public string SocSegundoApellido { get => socSegundoApellido; set => socSegundoApellido = value; }
        public string SocPrimerNombre { get => socPrimerNombre; set => socPrimerNombre = value; }
        public string SocSegundoNombre { get => socSegundoNombre; set => socSegundoNombre = value; }
        public int SocCI { get => socCI; set => socCI = value; }
        public DateTime SocFechaNacimiento { get => socFechaNacimiento; set => socFechaNacimiento = value; }
        public string SocDireccion { get => socDireccion; set => socDireccion = value; }
        public string SocTel { get => socTel; set => socTel = value; }
        public string SocCelular { get => socCelular; set => socCelular = value; }
        public string SocEmail { get => socEmail; set => socEmail = value; }
        public string SocObservaciones { get => socObservaciones; set => socObservaciones = value; }
        public bool SocAtivo { get => socAtivo; set => socAtivo = value; }
        public DateTime SocFechaIngreso { get => socFechaIngreso; set => socFechaIngreso = value; }
        public DateTime SocFechaEgreso { get => socFechaEgreso; set => socFechaEgreso = value; }
        public string SocMotivoEgreso { get => socMotivoEgreso; set => socMotivoEgreso = value; }
        public DateTime FecAlta { get => fecAlta; set => fecAlta = value; }
        public DateTime FecModif { get => fecModif; set => fecModif = value; }
        public int UsuIdModif { get => usuIdModif; set => usuIdModif = value; }
        public int UsuIdAlta { get => usuIdAlta; set => usuIdAlta = value; }
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
