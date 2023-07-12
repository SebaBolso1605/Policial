using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Persistencia
{
    public class FabricaPersistencia
    {
        public static IPersistenciaUsuario getPersistenciaUsuario()
        {
            return PersistenciaUsuario.GetInstancia();
        }
        public static IPersistenciaSocio getPersistenciaSocio()
        {
            return PersistenciaSocio.GetInstancia();
        }
        public static IPersistenciaCuota getPersistenciaCuota()
        {
            return PersistenciaCuota.GetInstancia();
        }
        public static IPersistenciaNucleoFamiliar getPersistenciaNucleoFamilial()
        {
            return PersistenciaNucleoFamiliar.GetInstancia();
        }
    }
}
