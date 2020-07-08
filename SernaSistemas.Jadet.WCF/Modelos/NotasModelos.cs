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
    public class NotaRequest : BaseRequest
    {

    }

    [DataContract]
    public class NotaResponse : BaseResponse
    {

    }

    [DataContract]
    public class coleccionNotasResponse : BaseResponse
    {
        [DataMember]
        public List<NotaResponse> Items { get; set; }
    }
}
