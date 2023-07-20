using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace EntidadesCompartidas.Enums
{
    [DataContract]
    public enum EnumMeses
    {
        [DataMember]
        Enero = 1,
        [DataMember]
        Febrero = 2,
        [DataMember]
        Marzo = 3,
        [DataMember]
        Abril = 4,
        [DataMember]
        Mayo = 5,
        [DataMember]
        Junio = 6,
        [DataMember]
        Julio = 7,
        [DataMember]
        Agosto = 8,
        [DataMember]
        Setiembre = 9,
        [DataMember]
        Octubre = 10,
        [DataMember]
        Noviembre = 11,
        [DataMember]
        Diciembre = 12
    }
}
