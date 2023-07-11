using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaUsuario
    {
        Usuario Login(string _Documento, string _Password);
    }
}
