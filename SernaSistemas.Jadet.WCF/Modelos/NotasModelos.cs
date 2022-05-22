using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

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

        public static NotaRequest ToRequest(dynamic nota)
        {
            if (nota != null)
            {
                return new NotaRequest
                {
                    Fecha = nota.Fecha,
                    FechaEnvio = nota.FechaEnvio,
                    Folio = nota.Folio,
                    Guia = nota.Guia,
                    IdCliente = nota.IdCliente,
                    IdTipo = nota.IdTipo,
                    IdEstatus = nota.IdEstatus,
                    IdPaqueteria = nota.IdPaqueteria,
                    MontoMXN = nota.MontoMXN,
                    MontoUSD = nota.MontoUSD,
                    SaldoMXN = nota.SaldoMXN,
                    SaldoUSD = nota.SaldoUSD
                };
            }
            else
            {
                return new NotaRequest();
            }
        }
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

        public static NotaResponse ToResponse(dynamic nota)
        {
            if (nota != null)
            {
                return new NotaResponse
                {
                    Fecha = nota.Fecha,
                    FechaEnvio = nota.FechaEnvio,
                    Folio = nota.Folio,
                    Guia = nota.Guia,
                    IdCliente = nota.IdCliente,
                    IdTipo = nota.IdTipo,
                    IdEstatus = nota.IdEstatus,
                    IdPaqueteria = nota.IdPaqueteria,
                    MontoMXN = nota.MontoMXN,
                    MontoUSD = nota.MontoUSD,
                    SaldoMXN = nota.SaldoMXN,
                    SaldoUSD = nota.SaldoUSD,
                    ErrorMensaje = string.Empty,
                    ErrorNumero = 0
                };
            }
            else
            {
                return new NotaResponse();
            }
        }

    }

    [DataContract]
    public class ColeccionNotasResponse : BaseResponse {
        [DataMember]
        public List<NotaResponse> Items { get; set; }
        public ColeccionNotasResponse() {
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

        public static DetalleNotaRequest ToRequest(dynamic detalleNota)
        {
            if (detalleNota != null)
            {
                return new DetalleNotaRequest
                {
                    Cantidad = detalleNota.Cantidad,
                    Id = detalleNota.Id,
                    IdNota = detalleNota.IdNota,
                    IdProducto = detalleNota.IdProducto,
                    PrecioMXN = detalleNota.PrecioMXN,
                    PrecioUSD = detalleNota.PrecioUSD
                };
            }
            else
            {
                return new DetalleNotaRequest();
            }
        }
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

        public static DetalleNotaResponse ToResponse(dynamic detalleNota)
        {
            if (detalleNota != null)
            {
                return new DetalleNotaResponse
                {
                    Cantidad = detalleNota.Cantidad,
                    ErrorMensaje = string.Empty,
                    ErrorNumero = 0,
                    Id = detalleNota.Id,
                    IdNota = detalleNota.IdNota,
                    IdProducto = detalleNota.IdProducto,
                    PrecioMXN = detalleNota.PrecioMXN,
                    PrecioUSD = detalleNota.PrecioUSD
                };
            }
            else
            {
                return new DetalleNotaResponse();
            }
        }
    }

    [DataContract]
    public class ColeccionDetalleNotaResponse : BaseResponse {
        [DataMember]
        public List<DetalleNotaResponse> Items { get; set; }
        public ColeccionDetalleNotaResponse() {
            Items = new List<DetalleNotaResponse>();
        }
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
        [DataMember]
        public int IdComentarioAnterior { get; set; }

        public static NotaComentarioRequest ToRequest(dynamic notaComentario)
        {
            if (notaComentario != null)
            {
                return new NotaComentarioRequest
                {
                    Comentario = notaComentario.ToString(),
                    Fecha = notaComentario.ToString(),
                    Id = notaComentario.Id,
                    IdComentarioAnterior = notaComentario.Id,
                    IdNota = notaComentario.IdNota
                };
            }
            else
            {
                return new NotaComentarioRequest();
            }
        }
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
        [DataMember]
        public int IdComentarioAnterior { get; set; }

        public static NotaComentarioResponse ToResponse(dynamic notaComentario)
        {
            if (notaComentario != null)
            {
                return new NotaComentarioResponse
                {
                    Comentario = notaComentario.ToString(),
                    ErrorMensaje = string.Empty,
                    ErrorNumero = 0,
                    Fecha = notaComentario.Fecha,
                    IdComentarioAnterior = notaComentario.IdComentarioAnterior,
                    IdNota = notaComentario.IdNota,
                    Id = notaComentario.Id
                };
            } else
            {
                return new NotaComentarioResponse();
            }
        }
    }

    [DataContract]
    public class ColeccionNotaComentarioResponse : BaseResponse {
        [DataMember]
        public List<NotaComentarioResponse> Items { get; set; }
        public ColeccionNotaComentarioResponse() {
            Items = new List<NotaComentarioResponse>();
        }
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
        [DataMember]
        public decimal MontoMXN { get; set; }
        [DataMember]
        public decimal MontoUSD { get; set; }

        public static NotaTicketRequest ToRequest(dynamic notaTicket)
        {
            if (notaTicket != null)
            {
                return new NotaTicketRequest
                {
                    Fecha = notaTicket.Fecha,
                    Id = notaTicket.Id,
                    IdNota = notaTicket.IdNota,
                    MontoMXN = notaTicket.MontoMXN,
                    MontoUSD = notaTicket.MontoUSD,
                    Ticket = notaTicket.Ticket
                };
            }
            else
            {
                return new NotaTicketRequest();
            }
        }
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
        [DataMember]
        public decimal MontoMXN { get; set; }
        [DataMember]
        public decimal MontoUSD { get; set; }

        public static NotaTicketResponse ToResponse(dynamic notaTicket)
        {
            if (notaTicket != null)
            {
                return new NotaTicketResponse
                {
                    ErrorMensaje = string.Empty,
                    ErrorNumero = 0,
                    Fecha = notaTicket.Fecha,
                    Id = notaTicket.Id,
                    IdNota = notaTicket.IdNota,
                    MontoMXN = notaTicket.MontoMXN,
                    MontoUSD = notaTicket.MontoUSD,
                    Ticket = notaTicket.Ticket
                };
            }
            else
            {
                return new NotaTicketResponse();
            }
        }
    }

    [DataContract]
    public class ColeccionNotaTicketResponse : BaseResponse {
        [DataMember]
        public List<NotaTicketResponse> Items { get; set; }
        public ColeccionNotaTicketResponse() {
            Items = new List<NotaTicketResponse>();
        }
    }
}
