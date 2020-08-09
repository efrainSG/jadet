using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SernaSistemas.Jadet.WCF.Modelos {
    [DataContract]
    public class NotaRequest : BaseRequest {
        [DataMember]
        public int Folio { get; set; }
        [DataMember]
        public DateTime? Fecha { get; set; }
        [DataMember]
        public int IdTipo { get; set; }
        [DataMember]
        public int IdEstatus { get; set; }
        [DataMember]
        public int IdPaqueteria { get; set; }
        [DataMember]
        public Guid IdCliente { get; set; }
        [DataMember]
        public string Guia { get; set; }
        [DataMember]
        public DateTime? FechaEnvio { get; set; }
        [DataMember]
        public decimal MontoMXN { get; set; }
        [DataMember]
        public decimal MontoUSD { get; set; }
        [DataMember]
        public decimal SaldoMXN { get; set; }
        [DataMember]
        public decimal SaldoUSD { get; set; }
    }

    [DataContract]
    public class NotaResponse : BaseResponse {
        [DataMember]
        public int Folio { get; set; }
        [DataMember]
        public DateTime? Fecha { get; set; }
        [DataMember]
        public int IdTipo { get; set; }
        [DataMember]
        public int IdEstatus { get; set; }
        [DataMember]
        public int IdPaqueteria { get; set; }
        [DataMember]
        public Guid IdCliente { get; set; }
        [DataMember]
        public string Guia { get; set; }
        [DataMember]
        public DateTime? FechaEnvio { get; set; }
        [DataMember]
        public decimal MontoMXN { get; set; }
        [DataMember]
        public decimal MontoUSD { get; set; }
        [DataMember]
        public decimal SaldoMXN { get; set; }
        [DataMember]
        public decimal SaldoUSD { get; set; }
    }

    [DataContract]
    public class coleccionNotasResponse : BaseResponse {
        [DataMember]
        public List<NotaResponse> Items { get; set; }
        public coleccionNotasResponse() {
            Items = new List<NotaResponse>();
        }
    }

    [DataContract]
    public class DetalleNotaRequest : BaseRequest {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IdNota { get; set; }
        [DataMember]
        public int IdProducto { get; set; }
        [DataMember]
        public int Cantidad { get; set; }
        [DataMember]
        public decimal PrecioMXN { get; set; }
        [DataMember]
        public decimal PrecioUSD { get; set; }
    }

    [DataContract]
    public class DetalleNotaResponse : BaseResponse {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IdNota { get; set; }
        [DataMember]
        public int IdProducto { get; set; }
        [DataMember]
        public int Cantidad { get; set; }
        [DataMember]
        public decimal PrecioMXN { get; set; }
        [DataMember]
        public decimal PrecioUSD { get; set; }
    }

    [DataContract]
    public class coleccionDetalleNotaResponse : BaseResponse {
        [DataMember]
        public List<DetalleNotaResponse> Items { get; set; }
    }

    [DataContract]
    public class NotaComentarioRequest : BaseRequest {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IdNota { get; set; }
        [DataMember]
        public string Comentario { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
    }

    [DataContract]
    public class NotaComentarioResponse : BaseResponse {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IdNota { get; set; }
        [DataMember]
        public string Comentario { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
    }

    [DataContract]
    public class coleccionNotaComentarioResponse : BaseResponse {
        [DataMember]
        public List<NotaComentarioResponse> Items { get; set; }
    }

    [DataContract]
    public class NotaTicketRequest : BaseRequest {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IdNota { get; set; }
        [DataMember]
        public byte[] Ticket { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
    }

    [DataContract]
    public class NotaTicketResponse : BaseResponse {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IdNota { get; set; }
        [DataMember]
        public byte[] Ticket { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
    }

    [DataContract]
    public class coleccionNotaTicketResponse : BaseResponse {
        [DataMember]
        public List<NotaTicketResponse> Items { get; set; }
    }
}
