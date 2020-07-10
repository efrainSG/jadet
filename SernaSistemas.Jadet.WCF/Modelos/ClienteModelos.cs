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
    public class ClienteRequest : BaseRequest
    {
        [DataMember]
        public int IdCliente { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public byte[] Password { get; set; }
        [DataMember]
        public string Foto { get; set; }
    }

    [DataContract]
    public class ClienteResponse : BaseResponse
    {
        [DataMember]
        public int IdCliente { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public byte[] Password { get; set; }
        [DataMember]
        public string Foto { get; set; }
    }

    [DataContract]
    public class HistorialClienteResponse : BaseResponse
    {

    }

    [DataContract]
    public class coleccionClientesResponse : BaseResponse
    {
        [DataMember]
        public List<ClienteResponse> Items { get; set; }
        public coleccionClientesResponse()
        {
            Items = new List<ClienteResponse>();
        }
    }
}
