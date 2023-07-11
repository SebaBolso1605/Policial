using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logica
{
    public class FabricaLogica
    {
        public static ILogicaUsuario getLogicaUsuario()
        {
            return (LogicaUsuario.GetInstancia());
        }
        public static ILogicaSocio getLogicaSocio()
        {
            return (LogicaSocio.GetInstancia());
        }
        public static ILogicaNucleoFamiliar getLogicaNucleoFamiliar()
        {
            return (LogicaNucleoFamiliar.GetInstancia());
        }
        public static ILogicaCuota getLogicaCuota()
        {
            return (LogicaCuota.GetInstancia());
        }
    }
}
