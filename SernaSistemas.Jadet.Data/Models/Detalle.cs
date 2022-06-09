using System;
using System.Collections.Generic;

#nullable disable

namespace SernaSistemas.Jadet.Data.Models
{
    public partial class Detalle
    {
        public int Id { get; set; }
        public int IdNota { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioMxn { get; set; }
        public decimal PrecioUsd { get; set; }

        public virtual Nota IdNotaNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
    }
}
