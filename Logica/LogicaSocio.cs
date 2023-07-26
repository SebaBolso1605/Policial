using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaSocio : ILogicaSocio
    {
        private static LogicaSocio _instancia = null;
        private LogicaSocio() { }
        public static LogicaSocio GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaSocio();

            return _instancia;
        }

        public List<TipoCuota> ListarTC()
        {
            IPersistenciaSocio tp = FabricaPersistencia.getPersistenciaSocio();
            return (tp.ListarTC());
        }
        public bool AltaSocio(Socio s, Cuota c, Usuario _usu)
        {
            bool resp = false;
            IPersistenciaSocio FSocio = FabricaPersistencia.getPersistenciaSocio();
            resp = FSocio.AltaSocio(s, c, _usu);
            return resp;
        }
        public Socio BuscarSocioPorCI(int _cedula)
        {
            Socio s = null;
            IPersistenciaSocio FSocio = FabricaPersistencia.getPersistenciaSocio();
            s = FSocio.BuscarSocioPorCI(_cedula);
            return s;
        }
        public List<Socio> ListarSocios()
        {
            IPersistenciaSocio FSocio = FabricaPersistencia.getPersistenciaSocio();
            return (FSocio.ListarSocios());
        }
        public bool ModificarSocio(Socio s ,Usuario _usu)
        {
            bool resp = false;
            IPersistenciaSocio FSocio = FabricaPersistencia.getPersistenciaSocio();
            resp = FSocio.ModificarSocio(s, _usu);
            return resp;
        }
        public bool BajaSocio(Socio c, Usuario _usu)
        {
            bool resp = false;
            IPersistenciaSocio FCuota = FabricaPersistencia.getPersistenciaSocio();
            resp = FCuota.BajaSocio(c, _usu);
            return resp;
        }
    }
}
