using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.Web.Services.Protocols;
using EntidadesCompartidas;
using Logica;

namespace WcfServicePolicial
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicePolicial
    {
        [OperationContract]
        Usuario Login(string _Usuario, string _Password);

        [OperationContract]
        List<TipoCuota> ListarTC();

        [OperationContract]
        bool AltaSocio(Socio s, Cuota c, Usuario _usu);

        [OperationContract]
        bool ActivarSocio(Socio s, Usuario _usu);

        [OperationContract]
        Socio BuscarSocioPorCI(int _cedula);

        [OperationContract]
        List<Socio> ListarSocios();

        [OperationContract]
        List<Socio> ListarSociosImprimirRecibos();

        [OperationContract]
        bool ModificarSocio(Socio s, Usuario _usu);

        [OperationContract]
        bool BajaSocio(Socio c, Usuario _usu);

        [OperationContract]
        bool AltaNucleoFamiliar(NucleoFamiliar c, Usuario _usu);

        [OperationContract]
        bool ModificarNF(NucleoFamiliar c, Usuario _usu);

        [OperationContract]
        bool BajaNF(int id);

        [OperationContract]
        List<NucleoFamiliar> BuscarNucleoFamiliarPorCI(int socId);

        [OperationContract]
        List<Cuota> BuscarCuotasSocio(int socId);

        [OperationContract]
        bool AltaCuentaSocio(Cuota c, Usuario _usu);

        [OperationContract]
        bool PagarCuotaSocio(Cuota c, Usuario _usu);

        [OperationContract]
        bool AltaCuota(TipoCuota c, Usuario _usu);

        [OperationContract]
         bool ModificarCuota(TipoCuota c, Usuario _usu);

        [OperationContract]
        bool BajarCuota(int id, Usuario _usu);

        [OperationContract]
        List<Impresion> ListarImpresion();       

    }
}

