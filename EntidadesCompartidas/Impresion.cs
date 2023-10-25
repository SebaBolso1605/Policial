using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace EntidadesCompartidas
{
    [DataContract]
    public class Impresion
    {
        private Socio socioImp;
        private Cuota cuotaImp;

        [DataMember]
        public Socio SocioImp {get;set;}
        [DataMember]
        public Cuota CuotaImp { get;set;}


        public Impresion(Socio s, Cuota c)
        {
            this.socioImp = s;
            this.cuotaImp = c;
        }

        public Impresion() { }
    }
}
