﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Policial.ServicioPolicialWCF {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServicioPolicialWCF.IServicioPolicial")]
    public interface IServicioPolicial {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioPolicial/Login", ReplyAction="http://tempuri.org/IServicioPolicial/LoginResponse")]
        EntidadesCompartidas.Usuario Login(string _Usuario, string _Password);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServicioPolicialChannel : Policial.ServicioPolicialWCF.IServicioPolicial, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServicioPolicialClient : System.ServiceModel.ClientBase<Policial.ServicioPolicialWCF.IServicioPolicial>, Policial.ServicioPolicialWCF.IServicioPolicial {
        
        public ServicioPolicialClient() {
        }
        
        public ServicioPolicialClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServicioPolicialClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioPolicialClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioPolicialClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public EntidadesCompartidas.Usuario Login(string _Usuario, string _Password) {
            return base.Channel.Login(_Usuario, _Password);
        }
    }
}