﻿using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SernaSistemas.Jadet.WCF.Modelos {
    [DataContract]
    public class ItemCarritoRequest : DetalleNotaRequest {
    }

    [DataContract]
    public class ItemCarritoResponse : DetalleNotaResponse {

    }

    [DataContract]
    public class CarritoRequest : NotaRequest {
    }

    [DataContract]
    public class CarritoResponse : NotaResponse {
        [DataMember]
        public List<ItemCarritoResponse> Items { get; set; }
        public CarritoResponse() {
            Items = new List<ItemCarritoResponse>();
        }
    }

    [DataContract]
    public class ColeccionCarritoResponse : BaseResponse {
        [DataMember]
        public List<CarritoResponse> Items { get; set; }
        public ColeccionCarritoResponse() {
            Items = new List<CarritoResponse>();
        }
    }
}
