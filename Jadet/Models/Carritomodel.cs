using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jadet.Models {
    public class Carritomodel : notaModel {

    }

    public class CarritoCompletoModel: notacompletaModel {

    }

    public class ItemCarritomodel : detallenotaModel {
        public int IdTipo { get; set; }
    }
}