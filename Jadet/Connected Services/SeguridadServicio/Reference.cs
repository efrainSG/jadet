﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Jadet.SeguridadServicio {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BaseRequest", Namespace="http://schemas.datacontract.org/2004/07/SernaSistemas.Jadet.WCF.Modelos")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Jadet.SeguridadServicio.UsuarioRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Jadet.SeguridadServicio.LoginRequest))]
    public partial class BaseRequest : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UsuarioRequest", Namespace="http://schemas.datacontract.org/2004/07/SernaSistemas.Jadet.WCF.Modelos")]
    [System.SerializableAttribute()]
    public partial class UsuarioRequest : Jadet.SeguridadServicio.BaseRequest {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DireccionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] FotoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdEstatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdRolField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TelefonoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsuarioField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ZonaPaqueteriaField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Direccion {
            get {
                return this.DireccionField;
            }
            set {
                if ((object.ReferenceEquals(this.DireccionField, value) != true)) {
                    this.DireccionField = value;
                    this.RaisePropertyChanged("Direccion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] Foto {
            get {
                return this.FotoField;
            }
            set {
                if ((object.ReferenceEquals(this.FotoField, value) != true)) {
                    this.FotoField = value;
                    this.RaisePropertyChanged("Foto");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdEstatus {
            get {
                return this.IdEstatusField;
            }
            set {
                if ((this.IdEstatusField.Equals(value) != true)) {
                    this.IdEstatusField = value;
                    this.RaisePropertyChanged("IdEstatus");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdRol {
            get {
                return this.IdRolField;
            }
            set {
                if ((this.IdRolField.Equals(value) != true)) {
                    this.IdRolField = value;
                    this.RaisePropertyChanged("IdRol");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombre {
            get {
                return this.NombreField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreField, value) != true)) {
                    this.NombreField = value;
                    this.RaisePropertyChanged("Nombre");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Telefono {
            get {
                return this.TelefonoField;
            }
            set {
                if ((object.ReferenceEquals(this.TelefonoField, value) != true)) {
                    this.TelefonoField = value;
                    this.RaisePropertyChanged("Telefono");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Usuario {
            get {
                return this.UsuarioField;
            }
            set {
                if ((object.ReferenceEquals(this.UsuarioField, value) != true)) {
                    this.UsuarioField = value;
                    this.RaisePropertyChanged("Usuario");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ZonaPaqueteria {
            get {
                return this.ZonaPaqueteriaField;
            }
            set {
                if ((this.ZonaPaqueteriaField.Equals(value) != true)) {
                    this.ZonaPaqueteriaField = value;
                    this.RaisePropertyChanged("ZonaPaqueteria");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LoginRequest", Namespace="http://schemas.datacontract.org/2004/07/SernaSistemas.Jadet.WCF.Modelos")]
    [System.SerializableAttribute()]
    public partial class LoginRequest : Jadet.SeguridadServicio.BaseRequest {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsuarioField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string passwordField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Usuario {
            get {
                return this.UsuarioField;
            }
            set {
                if ((object.ReferenceEquals(this.UsuarioField, value) != true)) {
                    this.UsuarioField = value;
                    this.RaisePropertyChanged("Usuario");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string password {
            get {
                return this.passwordField;
            }
            set {
                if ((object.ReferenceEquals(this.passwordField, value) != true)) {
                    this.passwordField = value;
                    this.RaisePropertyChanged("password");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BaseResponse", Namespace="http://schemas.datacontract.org/2004/07/SernaSistemas.Jadet.WCF.Modelos")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Jadet.SeguridadServicio.UsuarioResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Jadet.SeguridadServicio.LoginResponse))]
    public partial class BaseResponse : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorMensajeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ErrorNumeroField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ErrorMensaje {
            get {
                return this.ErrorMensajeField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorMensajeField, value) != true)) {
                    this.ErrorMensajeField = value;
                    this.RaisePropertyChanged("ErrorMensaje");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ErrorNumero {
            get {
                return this.ErrorNumeroField;
            }
            set {
                if ((this.ErrorNumeroField.Equals(value) != true)) {
                    this.ErrorNumeroField = value;
                    this.RaisePropertyChanged("ErrorNumero");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UsuarioResponse", Namespace="http://schemas.datacontract.org/2004/07/SernaSistemas.Jadet.WCF.Modelos")]
    [System.SerializableAttribute()]
    public partial class UsuarioResponse : Jadet.SeguridadServicio.BaseResponse {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DireccionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] FotoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdEstatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdRolField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TelefonoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsuarioField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ZonaPaqueteriaField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Direccion {
            get {
                return this.DireccionField;
            }
            set {
                if ((object.ReferenceEquals(this.DireccionField, value) != true)) {
                    this.DireccionField = value;
                    this.RaisePropertyChanged("Direccion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] Foto {
            get {
                return this.FotoField;
            }
            set {
                if ((object.ReferenceEquals(this.FotoField, value) != true)) {
                    this.FotoField = value;
                    this.RaisePropertyChanged("Foto");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdEstatus {
            get {
                return this.IdEstatusField;
            }
            set {
                if ((this.IdEstatusField.Equals(value) != true)) {
                    this.IdEstatusField = value;
                    this.RaisePropertyChanged("IdEstatus");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdRol {
            get {
                return this.IdRolField;
            }
            set {
                if ((this.IdRolField.Equals(value) != true)) {
                    this.IdRolField = value;
                    this.RaisePropertyChanged("IdRol");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombre {
            get {
                return this.NombreField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreField, value) != true)) {
                    this.NombreField = value;
                    this.RaisePropertyChanged("Nombre");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Telefono {
            get {
                return this.TelefonoField;
            }
            set {
                if ((object.ReferenceEquals(this.TelefonoField, value) != true)) {
                    this.TelefonoField = value;
                    this.RaisePropertyChanged("Telefono");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Usuario {
            get {
                return this.UsuarioField;
            }
            set {
                if ((object.ReferenceEquals(this.UsuarioField, value) != true)) {
                    this.UsuarioField = value;
                    this.RaisePropertyChanged("Usuario");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ZonaPaqueteria {
            get {
                return this.ZonaPaqueteriaField;
            }
            set {
                if ((this.ZonaPaqueteriaField.Equals(value) != true)) {
                    this.ZonaPaqueteriaField = value;
                    this.RaisePropertyChanged("ZonaPaqueteria");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LoginResponse", Namespace="http://schemas.datacontract.org/2004/07/SernaSistemas.Jadet.WCF.Modelos")]
    [System.SerializableAttribute()]
    public partial class LoginResponse : Jadet.SeguridadServicio.BaseResponse {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid IdUsuarioField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreUsuarioField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Jadet.SeguridadServicio.Rol RolUsuarioField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime UltimoInicioField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsuarioField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid IdUsuario {
            get {
                return this.IdUsuarioField;
            }
            set {
                if ((this.IdUsuarioField.Equals(value) != true)) {
                    this.IdUsuarioField = value;
                    this.RaisePropertyChanged("IdUsuario");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NombreUsuario {
            get {
                return this.NombreUsuarioField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreUsuarioField, value) != true)) {
                    this.NombreUsuarioField = value;
                    this.RaisePropertyChanged("NombreUsuario");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Jadet.SeguridadServicio.Rol RolUsuario {
            get {
                return this.RolUsuarioField;
            }
            set {
                if ((object.ReferenceEquals(this.RolUsuarioField, value) != true)) {
                    this.RolUsuarioField = value;
                    this.RaisePropertyChanged("RolUsuario");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime UltimoInicio {
            get {
                return this.UltimoInicioField;
            }
            set {
                if ((this.UltimoInicioField.Equals(value) != true)) {
                    this.UltimoInicioField = value;
                    this.RaisePropertyChanged("UltimoInicio");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Usuario {
            get {
                return this.UsuarioField;
            }
            set {
                if ((object.ReferenceEquals(this.UsuarioField, value) != true)) {
                    this.UsuarioField = value;
                    this.RaisePropertyChanged("Usuario");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Rol", Namespace="http://schemas.datacontract.org/2004/07/SernaSistemas.Jadet.WCF.Modelos")]
    [System.SerializableAttribute()]
    public partial class Rol : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdRolField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdRol {
            get {
                return this.IdRolField;
            }
            set {
                if ((this.IdRolField.Equals(value) != true)) {
                    this.IdRolField = value;
                    this.RaisePropertyChanged("IdRol");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombre {
            get {
                return this.NombreField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreField, value) != true)) {
                    this.NombreField = value;
                    this.RaisePropertyChanged("Nombre");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SeguridadServicio.ISeguridad")]
    public interface ISeguridad {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeguridad/IniciarSesion", ReplyAction="http://tempuri.org/ISeguridad/IniciarSesionResponse")]
        Jadet.SeguridadServicio.LoginResponse IniciarSesion(Jadet.SeguridadServicio.LoginRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeguridad/IniciarSesion", ReplyAction="http://tempuri.org/ISeguridad/IniciarSesionResponse")]
        System.Threading.Tasks.Task<Jadet.SeguridadServicio.LoginResponse> IniciarSesionAsync(Jadet.SeguridadServicio.LoginRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeguridad/CerrarSesion", ReplyAction="http://tempuri.org/ISeguridad/CerrarSesionResponse")]
        Jadet.SeguridadServicio.LoginResponse CerrarSesion(Jadet.SeguridadServicio.LoginRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeguridad/CerrarSesion", ReplyAction="http://tempuri.org/ISeguridad/CerrarSesionResponse")]
        System.Threading.Tasks.Task<Jadet.SeguridadServicio.LoginResponse> CerrarSesionAsync(Jadet.SeguridadServicio.LoginRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeguridad/cambiarPerfil", ReplyAction="http://tempuri.org/ISeguridad/cambiarPerfilResponse")]
        Jadet.SeguridadServicio.UsuarioResponse cambiarPerfil(Jadet.SeguridadServicio.UsuarioRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISeguridad/cambiarPerfil", ReplyAction="http://tempuri.org/ISeguridad/cambiarPerfilResponse")]
        System.Threading.Tasks.Task<Jadet.SeguridadServicio.UsuarioResponse> cambiarPerfilAsync(Jadet.SeguridadServicio.UsuarioRequest request);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISeguridadChannel : Jadet.SeguridadServicio.ISeguridad, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SeguridadClient : System.ServiceModel.ClientBase<Jadet.SeguridadServicio.ISeguridad>, Jadet.SeguridadServicio.ISeguridad {
        
        public SeguridadClient() {
        }
        
        public SeguridadClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SeguridadClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SeguridadClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SeguridadClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Jadet.SeguridadServicio.LoginResponse IniciarSesion(Jadet.SeguridadServicio.LoginRequest request) {
            return base.Channel.IniciarSesion(request);
        }
        
        public System.Threading.Tasks.Task<Jadet.SeguridadServicio.LoginResponse> IniciarSesionAsync(Jadet.SeguridadServicio.LoginRequest request) {
            return base.Channel.IniciarSesionAsync(request);
        }
        
        public Jadet.SeguridadServicio.LoginResponse CerrarSesion(Jadet.SeguridadServicio.LoginRequest request) {
            return base.Channel.CerrarSesion(request);
        }
        
        public System.Threading.Tasks.Task<Jadet.SeguridadServicio.LoginResponse> CerrarSesionAsync(Jadet.SeguridadServicio.LoginRequest request) {
            return base.Channel.CerrarSesionAsync(request);
        }
        
        public Jadet.SeguridadServicio.UsuarioResponse cambiarPerfil(Jadet.SeguridadServicio.UsuarioRequest request) {
            return base.Channel.cambiarPerfil(request);
        }
        
        public System.Threading.Tasks.Task<Jadet.SeguridadServicio.UsuarioResponse> cambiarPerfilAsync(Jadet.SeguridadServicio.UsuarioRequest request) {
            return base.Channel.cambiarPerfilAsync(request);
        }
    }
}
