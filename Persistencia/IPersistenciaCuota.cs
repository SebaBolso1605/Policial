using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaCuota
    {
        List<Cuota> BuscarCuotasSocio(int socId);
        bool AltaCuentaSocio(Cuota _c, Usuario _usu);
        bool PagarCuotaSocio(Cuota c, Usuario usu);
        bool AltaCuota(TipoCuota _c, Usuario _usu);
        bool ModificarCuota(TipoCuota _c, Usuario _usu);
        bool BajarCuota(int _c, Usuario _usu);
    }
}
