﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SernaSistemas.Jadet.WCF.Modelos {
    [DataContract]
    public class ItemCarritoRequest : BaseRequest {

    }

    [DataContract]
    public class ItemCarritoResponse : BaseResponse {

    }

    [DataContract]
    public class CarritoRequest : BaseRequest {

    }

    [DataContract]
    public class CarritoResponse : BaseResponse {
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
