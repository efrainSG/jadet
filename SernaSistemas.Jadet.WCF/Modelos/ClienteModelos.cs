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
    }

    [DataContract]
    public class ClienteResponse : BaseResponse
    {

    }
    
    [DataContract]
    public class HistorialClienteResponse : BaseResponse
    {

    }
}
