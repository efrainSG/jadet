using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SernaSistemas.Jadet.WCF.Modelos {
    [DataContract]
    public class ClienteRequest : BaseRequest {
        [DataMember]
        public Guid IdCliente { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public byte[] Password { get; set; }
        [DataMember]
        public byte[] Foto { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public int IdEstatus { get; set; }
        [DataMember]
        public int IdRol { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public int ZonaPaqueteria { get; set; }
    }

    [DataContract]
    public class ClienteResponse : BaseResponse {
        [DataMember]
        public Guid IdCliente { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public byte[] Password { get; set; }
        [DataMember]
        public byte[] Foto { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public int IdEstatus { get; set; }
        [DataMember]
        public int IdRol { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public int ZonaPaqueteria { get; set; }
    }

    [DataContract]
    public class HistorialClienteResponse : BaseResponse {

    }

    [DataContract]
    public class coleccionClientesResponse : BaseResponse {
        [DataMember]
        public List<ClienteResponse> Items { get; set; }
        public coleccionClientesResponse() {
            Items = new List<ClienteResponse>();
        }
    }
}
