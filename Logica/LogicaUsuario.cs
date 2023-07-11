using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaUsuario : ILogicaUsuario
    {
        private static LogicaUsuario _instancia = null;
        private LogicaUsuario() { }
        public static LogicaUsuario GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaUsuario();

            return _instancia;
        }

        public Usuario Login(string _Usuario, string _Password)
        {
            Usuario U = null;
            U = (FabricaPersistencia.getPersistenciaUsuario().Login(_Usuario, _Password));
            return U;
        }
    }
}
