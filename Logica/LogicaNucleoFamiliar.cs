using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaNucleoFamiliar : ILogicaNucleoFamiliar
    {
        private static LogicaNucleoFamiliar _instancia = null;
        private LogicaNucleoFamiliar() { }
        public static LogicaNucleoFamiliar GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaNucleoFamiliar();

            return _instancia;
        }

        public bool AltaNucleoFamiliar(NucleoFamiliar c, Usuario _usu)
        {
            bool resp = false;
            IPersistenciaNucleoFamiliar FSocio = FabricaPersistencia.getPersistenciaNucleoFamilial();
            resp = FSocio.AltaNucleoFamiliar(c, _usu);
            return resp;
        }

        public bool ModificarNF(NucleoFamiliar c, Usuario _usu)
        {
            bool resp = false;
            IPersistenciaNucleoFamiliar FSocio = FabricaPersistencia.getPersistenciaNucleoFamilial();
            resp = FSocio.ModificarNF(c, _usu);
            return resp;
        }

        public bool BajaNF(int id)
        {
            bool resp = false;
            IPersistenciaNucleoFamiliar FSocio = FabricaPersistencia.getPersistenciaNucleoFamilial();
            resp = FSocio.BajaNF(id);
            return resp;
        }

        List<NucleoFamiliar> ILogicaNucleoFamiliar.BuscarNucleoFamiliarPorCI(int socId)
        {
            List<NucleoFamiliar> s = null;
            IPersistenciaNucleoFamiliar FSocio = FabricaPersistencia.getPersistenciaNucleoFamilial();
            s = FSocio.BuscarNucleoFamiliarPorCI(socId);
            return s;
        }

        //public List<NucleoFamiliar> ListarNF(int a)
        //{
        //    IPersistenciaNucleoFamiliar FSocio = FabricaPersistencia.getPersistenciaNucleoFamilial();
        //    return (FSocio.BuscarNucleoFamiliarPorCI(a));
        //}
    }
}
