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
        public string strImagen { get { return System.Text.Encoding.UTF8.GetString(Imagen); } }
        public HttpPostedFile ImgArchivo { get; set; }
        public decimal PrecioMXN { get; set; }
        public decimal PrecioUSD { get; set; }
        public int ErrorNumero { get; set; }
        public string ErrorMensaje { get; set; }
        public bool AplicaExistencias { get; set; }
        public int Id { get; set; }
        public int IdCategoria { get; set; }
        public string Categoria { get; set; }
        public int IdEstatus { get; set; }
        public string Estatus { get; set; }
        public int IdTipo { get; set; }
        public string Tipo { get; set; }
    }
    public class listaproductosmodel {
        public int IdTipoVenta { get; set; }
        public string TipoVenta { get; set; }
        public List<productomodel> Items { get; set; }
        public listaproductosmodel() {
            Items = new List<productomodel>();
        }
    }
}