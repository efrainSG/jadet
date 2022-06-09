using System;
using System.Collections.Generic;

#nullable disable

namespace SernaSistemas.Jadet.Data.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Detalles = new HashSet<Detalle>();
        }

        public int Id { get; set; }
        public string Sku { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioMxn { get; set; }
        public decimal PrecioUsd { get; set; }
        public int Existencias { get; set; }
        public bool AplicaExistencias { get; set; }
        public byte[] Foto { get; set; }
        public int IdCatalogo { get; set; }
        public int IdEstatus { get; set; }
        public int IdTipoNota { get; set; }

        public virtual Catalogo IdCatalogoNavigation { get; set; }
        public virtual Estatus IdEstatusNavigation { get; set; }
        public virtual Catalogo IdTipoNotaNavigation { get; set; }
        public virtual ICollection<Detalle> Detalles { get; set; }
    }
}
