using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SernaSistemas.Jadet.WCF.Modelos {
    [DataContract]
    public class GuiaRequest : BaseRequest {
        [DataMember]
        public string Folio { get; set; }
    }
    [DataContract]
    public class GuiaResponse : BaseResponse {
        [DataMember]
        public string NUmeroGuia { get; set; }
    }
}
