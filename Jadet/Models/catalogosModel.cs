using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jadet.Models {
    public class catalogoModel {
        public int Id { get; set; }
        public string Tabla { get; set; }
        public string Nombre { get; set; }
        public int IdTipoCatalogo { get; set; }
        public string TipoCatalogo { get; set; }
    }
    public class listacatalogoModel {
        public List<catalogoModel> Items { get; set; }
        public listacatalogoModel() {
            Items = new List<catalogoModel>();
        }
    }

}