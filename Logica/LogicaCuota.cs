using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaCuota : ILogicaCuota
    {
        private static LogicaCuota _instancia = null;
        private LogicaCuota() { }
        public static LogicaCuota GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaCuota();

            return _instancia;
        }
        List<Cuota> ILogicaCuota.BuscarCuotasSocio(int socId)
        {
            List<Cuota> s = null;
            IPersistenciaCuota FSocio = FabricaPersistencia.getPersistenciaCuota();
            s = FSocio.BuscarCuotasSocio(socId);
            return s;
        }
        public bool AltaCuentaSocio(Cuota c, Usuario _usu)
        {
            bool resp = false;
            IPersistenciaCuota FSocio = FabricaPersistencia.getPersistenciaCuota();
            resp = FSocio.AltaCuentaSocio(c, _usu);
            return resp;
        }
        public bool PagarCuotaSocio(Cuota c, Usuario _usu)
        {
            bool resp = false;
            IPersistenciaCuota FSocio = FabricaPersistencia.getPersistenciaCuota();
            resp = FSocio.PagarCuotaSocio(c, _usu);
            return resp;
        }
        public bool AltaCuota(TipoCuota c, Usuario _usu)
        {
            bool resp = false;
            IPersistenciaCuota FSocio = FabricaPersistencia.getPersistenciaCuota();
            resp = FSocio.AltaCuota(c, _usu);
            return resp;
        }
        public bool ModificarCuota(TipoCuota c, Usuario _usu)
        {
            bool resp = false;
            IPersistenciaCuota FSocio = FabricaPersistencia.getPersistenciaCuota();
            resp = FSocio.ModificarCuota(c, _usu);
            return resp;
        }
        public bool BajarCuota(int id, Usuario _usu)
        {
            bool resp = false;
            IPersistenciaCuota FSocio = FabricaPersistencia.getPersistenciaCuota();
            resp = FSocio.BajarCuota(id, _usu);
            return resp;
        }
    }
}
