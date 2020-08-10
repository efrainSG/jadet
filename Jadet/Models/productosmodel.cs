using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jadet.Models {
    public class productomodel {
        public string Sku { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Existencias { get; set; }
        public byte[] Imagen { get; set; }
        public decimal PrecioMXN { get; set; }
        public decimal PrecioUSD { get; set; }
        public int ErrorNumero { get; set; }
        public string ErrorMensaje { get; set; }
        public bool AplicaExistencias { get; set; }
        public int Id { get; set; }
        public int IdCategoria { get; set; }
        public string Categoria { get; set; }
    }
    public class listaproductosmodel {
        public List<productomodel> Items { get; set; }
        public listaproductosmodel() {
            Items = new List<productomodel>();
        }
    }
}