using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SernaSistemas.Jadet.WCF.Modelos {
    [DataContract]
    public class BaseRequest {

    }

    [DataContract]
    public class BaseResponse {
        [DataMember]
        public int ErrorNumero { get; set; }
        [DataMember]
        public string ErrorMensaje { get; set; }
        public BaseResponse() {
            ErrorNumero = 0;
            ErrorMensaje = string.Empty;
        }
    }

    [DataContract]
    public class ArchivoRequest : BaseRequest {
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
    public class ArchivoResponse : BaseResponse {

    }

    [DataContract]
    public class CatalogoRequest : BaseRequest {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public int IdTipoCatalogo { get; set; }
    }

    [DataContract]
    public class CatalogoResponse : BaseResponse {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public int IdTipoCatalogo { get; set; }
    }

    [DataContract]
    public class ColeccionCatalogoResponse : BaseResponse {
        [DataMember]
        public List<CatalogoResponse> Items { get; set; }
        public ColeccionCatalogoResponse() {
            Items = new List<CatalogoResponse>();
        }
    }

    [DataContract]
    public class TipoCatalogoResponse : BaseResponse {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
    }

    [DataContract]
    public class TipoCatalogoRequest : BaseRequest {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
    }

    [DataContract]
    public class ColeccionTipoCatalogoResponse : BaseResponse {
        [DataMember]
        public List<TipoCatalogoResponse> Items { get; set; }
        public ColeccionTipoCatalogoResponse() {
            Items = new List<TipoCatalogoResponse>();
        }
    }

    [DataContract]
    public class EstatusRequest : BaseRequest {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public int IdTipoEstatus { get; set; }
    }

    [DataContract]
    public class EstatusResponse : BaseResponse {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public int IdTipoEstatus { get; set; }
    }

    [DataContract]
    public class ColeccionEstatusResponse : BaseResponse {
        [DataMember]
        public List<EstatusResponse> Items { get; set; }
        public ColeccionEstatusResponse() {
            Items = new List<EstatusResponse>();
        }
    }

    [DataContract]
    public class TipoEstatusRequest : BaseRequest {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
    }

    [DataContract]
    public class TipoEstatusResponse : BaseResponse {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
    }

    [DataContract]
    public class ColeccionTipoEstatusResponse : BaseResponse {
        [DataMember]
        public List<TipoEstatusResponse> Items { get; set; }
        public ColeccionTipoEstatusResponse() {
            Items = new List<TipoEstatusResponse>();
        }
    }
}
