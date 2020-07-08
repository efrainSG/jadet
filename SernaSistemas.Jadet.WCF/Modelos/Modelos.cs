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
    public class BaseRequest
    {

    }

    [DataContract]
    public class BaseResponse
    {
        [DataMember]
        public int ErrorNumero { get; set; }
        [DataMember]
        public string ErrorMensaje { get; set; }
    }

    [DataContract]
    public class ArchivoRequest : BaseRequest
    {
        [DataMember]
        public string Ruta { get; set; }
        [DataMember]
        public string TipoArchivo { get; set; }
        [DataMember]
        public int Longitud { get; set; }
        [DataMember]
        public DateTime FechaCarga { get; set; }
        [DataMember]
        public DateTime UltimaModificacion { get; set; }
    }

    [DataContract]
    public class ArchivoResponse : BaseResponse
    {

    }
}
