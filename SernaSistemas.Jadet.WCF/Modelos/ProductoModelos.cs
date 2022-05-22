using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SernaSistemas.Jadet.WCF.Modelos {
    [DataContract]
    public class ProductoRequest : BaseRequest {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string SKU { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public decimal PrecioMXN { get; set; }
        [DataMember]
        public decimal PrecioUSD { get; set; }
        [DataMember]
        public int Existencias { get; set; }
        [DataMember]
        public bool AplicaExistencias { get; set; }
        [DataMember]
        public byte[] Foto { get; set; }
        [DataMember]
        public int IdCategoria { get; set; }
        [DataMember]
        public int IdEstatus { get; set; }
        [DataMember]
        public int IdTipo { get; set; }
        [DataMember]
        public string Tipo { get; set; }

        public static ProductoRequest ToRequest(dynamic producto)
        {
            if (producto != null)
            {
                return new ProductoRequest
                {
                    AplicaExistencias = producto.AplicaExistencias,
                    Descripcion = producto.Descripcion,
                    Foto = producto.Foto,
                    IdCategoria = producto.IdCategoria,
                    Existencias = producto.Existencias,
                    IdEstatus = producto.IdEstatus,
                    Id = producto.Id,
                    IdTipo = producto.IdTipo,
                    Nombre = producto.Nombre,
                    PrecioMXN = producto.PrecioMXN,
                    PrecioUSD = producto.PrecioUSD,
                    SKU = producto.SKU,
                    Tipo = producto.Tipo,
                };
            }
            else
            {
                return new ProductoRequest();
            }
        }

    }

    [DataContract]
    public class ProductoResponse : BaseResponse {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string SKU { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public decimal PrecioMXN { get; set; }
        [DataMember]
        public decimal PrecioUSD { get; set; }
        [DataMember]
        public int Existencias { get; set; }
        [DataMember]
        public bool AplicaExistencias { get; set; }
        [DataMember]
        public byte[] Foto { get; set; }
        [DataMember]
        public int IdCategoria { get; set; }
        [DataMember]
        public int IdEstatus { get; set; }
        [DataMember]
        public int IdTipo { get; set; }
        [DataMember]
        public string Tipo { get; set; }

        public static ProductoResponse ToResponse(dynamic producto)
        {
            if (producto != null)
            {
                return new ProductoResponse
                {
                    AplicaExistencias = producto.AplicaExistencias,
                    Descripcion = producto.Descripcion,
                    ErrorMensaje = string.Empty,
                    ErrorNumero = 0,
                    Foto = producto.Foto,
                    IdCategoria = producto.IdCategoria,
                    Existencias = producto.Existencias,
                    IdEstatus = producto.IdEstatus,
                    Id = producto.Id,
                    IdTipo = producto.IdTipo,
                    Nombre = producto.Nombre,
                    PrecioMXN = producto.PrecioMXN,
                    PrecioUSD = producto.PrecioUSD,
                    SKU = producto.SKU,
                    Tipo = producto.Tipo,
                };
            }
            else
            {
                return new ProductoResponse();
            }
        }
    }

    [DataContract]
    public class ColeccionProductoResponse : BaseResponse {
        [DataMember]
        public List<ProductoResponse> Items { get; set; }
        public ColeccionProductoResponse() {
            Items = new List<ProductoResponse>();
        }
    }

    [DataContract]
    public class CategoriaResponse: BaseResponse {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }

        public static CategoriaResponse ToResponse(dynamic categoria)
        {
            if (categoria != null)
            {
                return new CategoriaResponse
                {
                    ErrorMensaje = string.Empty,
                    ErrorNumero = 0,
                    Id = categoria.Id,
                    Nombre = categoria.Nombre
                };
            }
            else
            {
                return new CategoriaResponse();
            }
        }
    }

    [DataContract]
    public class ColeccionCategoriasResponse : BaseResponse {
        [DataMember]
        public List<CategoriaResponse> Items { get; set; }
        public ColeccionCategoriasResponse() {
            Items = new List<CategoriaResponse>();
        }
    }
}