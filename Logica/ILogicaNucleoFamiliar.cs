using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Logica
{
    public interface ILogicaNucleoFamiliar
    {
        bool AltaNucleoFamiliar(NucleoFamiliar c, Usuario _usu);
        List<NucleoFamiliar> BuscarNucleoFamiliarPorCI(int socId);
        bool ModificarNF(NucleoFamiliar s, Usuario _usu);
        bool BajaNF(int s);
    }
}
