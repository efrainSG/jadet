using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SernaSistemas.Jadet.WCF.Modelos {
    [DataContract]
    public class LoginRequest : BaseRequest {
        [DataMember]
        public string Usuario { get; set; }
        [DataMember]
        public string password { get; set; }
    }
    [DataContract]
    public class LoginResponse : BaseResponse {
        [DataMember]
        public Guid IdUsuario { get; set; }
        [DataMember]
        public string Usuario { get; set; }
        [DataMember]
        public DateTime UltimoInicio { get; set; }
        [DataMember]
        public string NombreUsuario { get; set; }
        [DataMember]
        public Rol RolUsuario { get; set; }
    }

    [DataContract]
    public class Rol {
        [DataMember]
        public int IdRol { get; set; }
        [DataMember]
        public string Nombre { get; set; }
    }

    [DataContract]
    public class UsuarioResponse : BaseResponse {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public byte[] Foto { get; set; }
        [DataMember]
        public string Usuario { get; set; }
        [DataMember]
        public byte[] Password { get; set; }
        [DataMember]
        public int IdRol { get; set; }
        [DataMember]
        public int ZonaPaqueteria { get; set; }
        [DataMember]
        public int IdEstatus { get; set; }
    }

    [DataContract]
    public class UsuarioRequest : BaseRequest {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public byte[] Foto { get; set; }
        [DataMember]
        public string Usuario { get; set; }
        [DataMember]
        public byte[] Password { get; set; }
        [DataMember]
        public int IdRol { get; set; }
        [DataMember]
        public int ZonaPaqueteria { get; set; }
        [DataMember]
        public int IdEstatus { get; set; }
    }
}
