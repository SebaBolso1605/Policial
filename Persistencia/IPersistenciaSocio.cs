using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaSocio
    {
        List<TipoCuota> ListarTC();
        bool AltaSocio(Socio s, Cuota c, Usuario _usu);
        Socio BuscarSocioPorCI(int _ci);
        List<Socio> ListarSocios();
        bool ModificarSocio(Socio s, Usuario _usu);
        bool BajaSocio(Socio s, Usuario _usu);
    }
}
