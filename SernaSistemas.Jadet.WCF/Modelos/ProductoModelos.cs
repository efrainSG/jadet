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
    public class ProductoRequest : BaseRequest
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string RutaImagen { get; set; }
        [DataMember]
        public int Existencias { get; set; }
    }

    [DataContract]
    public class ProductoResponse : BaseResponse
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string RutaImagen { get; set; }
        [DataMember]
        public int Existencias { get; set; }
    }

    [DataContract]
    public class coleccionProductoResponse : BaseResponse
    {
        [DataMember]
        public List<ProductoResponse> Items { get; set; }
    }
}
