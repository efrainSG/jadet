using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SernaSistemas.Jadet.WCF.Modelos
{
    [DataContract]
    public class ClienteRequest : BaseRequest
    {
        [DataMember]
        public Guid IdCliente { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public byte[] Password { get; set; }
        [DataMember]
        public byte[] Foto { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public int IdEstatus { get; set; }
        [DataMember]
        public int IdRol { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public int ZonaPaqueteria { get; set; }

        public static ClienteRequest ToRequest(dynamic cliente)
        {
            if (cliente != null)
            {
                return new ClienteRequest
                {
                    IdCliente = cliente.IdCliente,
                    Direccion = cliente.Direccion,
                    Foto = cliente.Foto,
                    IdEstatus = cliente.IdEstatus,
                    IdRol = cliente.IdRol,
                    Telefono = cliente.Telefono,
                    UserName = cliente.UserName,
                    Nombre = cliente.Nombre,
                    Password = cliente.Password,
                    ZonaPaqueteria = cliente.ZonaPaqueteria
                };
            }
            else
            {
                return new ClienteRequest();
            }
        }
    }

    [DataContract]
    public class ClienteResponse : BaseResponse
    {
        [DataMember]
        public Guid IdCliente { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public byte[] Password { get; set; }
        [DataMember]
        public byte[] Foto { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public int IdEstatus { get; set; }
        [DataMember]
        public int IdRol { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public int ZonaPaqueteria { get; set; }

        public static ClienteResponse ToResponse(dynamic cliente)
        {
            if (cliente != null)
            {
                return new ClienteResponse
                {
                    ZonaPaqueteria = cliente.ZonaPaqueteria,
                    Direccion = cliente.Direccion,
                    Password = cliente.Password,
                    Foto = cliente.Foto,
                    Nombre = cliente.Nombre,
                    UserName = cliente.UserName,
                    Telefono = cliente.Telefono,
                    ErrorMensaje = string.Empty,
                    ErrorNumero = 0,
                    IdCliente = cliente.IdCliente,
                    IdRol = cliente.IdRol,
                    IdEstatus = cliente.IdEstatus
                };
            }
            else
            {
                return new ClienteResponse();
            }
        }
    }

    [DataContract]
    public class HistorialClienteResponse : BaseResponse
    {

    }

    [DataContract]
    public class ColeccionClientesResponse : BaseResponse
    {
        [DataMember]
        public List<ClienteResponse> Items { get; set; }
        public ColeccionClientesResponse()
        {
            Items = new List<ClienteResponse>();
        }
    }
}
