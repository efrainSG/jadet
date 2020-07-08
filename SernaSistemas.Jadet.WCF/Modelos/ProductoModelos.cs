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

    }

    [DataContract]
    public class ProductoResponse : BaseResponse
    {

    }

    [DataContract]
    public class coleccionProductoResponse : BaseResponse
    {
        [DataMember]
        public List<ProductoResponse> Items { get; set; }
    }
}
