using System.Runtime.Serialization;

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
