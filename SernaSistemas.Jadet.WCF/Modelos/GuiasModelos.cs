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
    public class GuiaRequest : BaseRequest
    {

    }
    [DataContract]
    public class GuiaResponse : BaseResponse
    {
        [DataMember]
        public string NUmeroGuia { get; set; }
    }
}
