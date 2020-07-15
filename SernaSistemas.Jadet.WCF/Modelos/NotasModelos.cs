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
    public class NotaRequest : BaseRequest
    {
        [DataMember]
        public int Folio { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
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
        public DateTime FechaEnvio { get; set; }
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
    public class NotaResponse : BaseResponse
    {
        [DataMember]
        public int Folio { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
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
        public DateTime FechaEnvio { get; set; }
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
    public class coleccionNotasResponse : BaseResponse
    {
        [DataMember]
        public List<NotaResponse> Items { get; set; }
    }
}
