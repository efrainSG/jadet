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
        public string Descripcion{ get; set; }
        [DataMember]
        public int Existencias { get; set; }
        [DataMember]
        public decimal PrecioMXN { get; set; }
        [DataMember]
        public decimal PrecioUSD { get; set; }
        [DataMember]
        public categoriaResponse Categoria { get; set; }

    }

    [DataContract]
    public class coleccionProductoResponse : BaseResponse
    {
        [DataMember]
        public List<ProductoResponse> Items { get; set; }
        public coleccionProductoResponse()
        {
            Items = new List<ProductoResponse>();
        }
    }

    [DataContract]
    public class categoriaResponse
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre{ get; set; }
    }

    [DataContract]
    public class coleccionCategoriasResponse : BaseResponse
    {
        [DataMember]
        public List<categoriaResponse> Items { get; set; }
    }
}