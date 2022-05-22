using System.Runtime.Serialization;

namespace SernaSistemas.Jadet.WCF.Modelos
{
    [DataContract]
    public class GuiaRequest : BaseRequest
    {
        [DataMember]
        public string Folio { get; set; }
        public static GuiaRequest ToRequest(dynamic guia)
        {
            if (guia != null)
                return new GuiaRequest
                {
                    Folio = guia.ToString()
                };
            else
            {
                return new GuiaRequest();
            }
        }
    }

    [DataContract]
    public class GuiaResponse : BaseResponse
    {
        [DataMember]
        public string NumeroGuia { get; set; }

        public static GuiaResponse ToResponse(dynamic guia)
        {
            if (guia != null)
                return new GuiaResponse
                {
                    NumeroGuia = guia.ToString(),
                    ErrorMensaje = string.Empty,
                    ErrorNumero = 0
                };
            else
            {
                return new GuiaResponse();
            }
        }
    }
}
