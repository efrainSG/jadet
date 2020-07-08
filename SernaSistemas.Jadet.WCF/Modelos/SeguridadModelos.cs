using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SernaSistemas.Jadet.WCF.Modelos
{
    [DataContract]
    public class LoginRequest : BaseRequest
    {
        [DataMember]
        public string Usuario { get; set; }
        [DataMember]
        public string password { get; set; }
    }
    [DataContract]
    public class LoginResponse : BaseResponse
    {
        [DataMember]
        public Guid IdUsuario { get; set; }
        [DataMember]
        public string Usuario { get; set; }
        [DataMember]
        public DateTime UltimoInicio { get; set; }
        [DataMember]
        public Nombre NombreUsuario { get; set; }
        [DataMember]
        public Rol RolUsuario { get; set; }
    }

    [DataContract]
    public class Nombre
    {
        [DataMember]
        public string Nombres { get; set; }
        [DataMember]
        public string ApellidoPaterno { get; set; }
        [DataMember]
        public string ApellidoMaterno { get; set; }
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Nombres, ApellidoPaterno, ApellidoMaterno); 
        }
    }

    [DataContract]
    public class Rol
    {
        [DataMember]
        public int IdRol { get; set; }
        [DataMember]
        public string NombreRol { get; set; }
    }
}
