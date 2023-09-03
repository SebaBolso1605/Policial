using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using Logica;
using EntidadesCompartidas;

namespace WcfServicePolicial
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicePolicial : IServicePolicial
    {
        Usuario IServicePolicial.Login(string _Usuario, string _Password)
        {
            return (FabricaLogica.getLogicaUsuario().Login(_Usuario, _Password));
        }

        List<TipoCuota> IServicePolicial.ListarTC()
        {
            return (FabricaLogica.getLogicaSocio().ListarTC());
        }

        bool IServicePolicial.AltaSocio(Socio s, Cuota c, Usuario _usu)
        {
            return (FabricaLogica.getLogicaSocio().AltaSocio(s, c, _usu));
        }
         
        Socio IServicePolicial.BuscarSocioPorCI(int _cedula)
        {
            return (FabricaLogica.getLogicaSocio().BuscarSocioPorCI(_cedula));
        }

        List<Socio> IServicePolicial.ListarSocios()
        {
            return (FabricaLogica.getLogicaSocio().ListarSocios());
        }

        bool IServicePolicial.ModificarSocio(Socio s, Usuario _usu)
        {
            return (FabricaLogica.getLogicaSocio().ModificarSocio(s, _usu));
        }

        bool IServicePolicial.ActivarSocio(Socio s, Usuario _usu)
        {
            return (FabricaLogica.getLogicaSocio().ActivarSocio(s, _usu));
        }

        bool IServicePolicial.BajaSocio(Socio c, Usuario _usu)
        {
            return (FabricaLogica.getLogicaSocio().BajaSocio(c, _usu));
        }

        bool IServicePolicial.AltaNucleoFamiliar(NucleoFamiliar c, Usuario _usu)
        {
            return (FabricaLogica.getLogicaNucleoFamiliar().AltaNucleoFamiliar(c, _usu));
        }
    
        bool IServicePolicial.ModificarNF(NucleoFamiliar c, Usuario _usu)
        {
            return (FabricaLogica.getLogicaNucleoFamiliar().ModificarNF(c, _usu));
        }
        
        bool IServicePolicial.BajaNF(int id)
        {
            return (FabricaLogica.getLogicaNucleoFamiliar().BajaNF(id));
        }

        List<NucleoFamiliar> IServicePolicial.BuscarNucleoFamiliarPorCI(int socId)
        {
            return (FabricaLogica.getLogicaNucleoFamiliar().BuscarNucleoFamiliarPorCI(socId));
        }

        List<Cuota> IServicePolicial.BuscarCuotasSocio(int socId)
        {
            return (FabricaLogica.getLogicaCuota().BuscarCuotasSocio(socId));
        }

        bool IServicePolicial.AltaCuentaSocio(Cuota c, Usuario _usu)
        {
            return (FabricaLogica.getLogicaCuota().AltaCuentaSocio(c, _usu));
        }

        bool IServicePolicial.PagarCuotaSocio(Cuota c, Usuario _usu)
        {
            return (FabricaLogica.getLogicaCuota().PagarCuotaSocio(c, _usu));
        }

        bool IServicePolicial.AltaCuota(TipoCuota c, Usuario _usu)
        {
            return (FabricaLogica.getLogicaCuota().AltaCuota(c, _usu));
        }

        bool IServicePolicial.ModificarCuota(TipoCuota c, Usuario _usu)
        {
            return (FabricaLogica.getLogicaCuota().ModificarCuota(c, _usu));
        }

        bool IServicePolicial.BajarCuota(int id, Usuario _usu)
        {
            return (FabricaLogica.getLogicaCuota().BajarCuota(id,_usu));
        }

    }
}
