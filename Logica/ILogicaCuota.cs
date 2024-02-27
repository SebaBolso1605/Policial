using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Logica
{
    public interface ILogicaCuota
    {
        List<Cuota> BuscarCuotasSocio(int socId);
        bool AltaCuentaSocio(Cuota _c, Usuario _usu);
        bool PagarCuotaSocio(Cuota c, Usuario usu);
        bool AltaCuota(TipoCuota _c, Usuario _usu);
        bool ModificarCuota(TipoCuota _c, Usuario _usu);
        bool BajarCuota(int _c, Usuario _usu);
        List<Impresion> ListarImpresion();
        void ModificarCuotaImpresa(List<int> listaId, Usuario _usu);
    }
}
