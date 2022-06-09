using System;
using System.Collections.Generic;

#nullable disable

namespace SernaSistemas.Jadet.Data.Models
{
    public partial class Catalogo
    {
        public Catalogo()
        {
            NotaIdEstatusNavigations = new HashSet<Nota>();
            NotaIdPaqueteriaNavigations = new HashSet<Nota>();
            NotaIdTipoNavigations = new HashSet<Nota>();
            ProductoIdCatalogoNavigations = new HashSet<Producto>();
            ProductoIdTipoNotaNavigations = new HashSet<Producto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdTipoCatalogo { get; set; }

        public virtual TipoCatalogo IdTipoCatalogoNavigation { get; set; }
        public virtual ICollection<Nota> NotaIdEstatusNavigations { get; set; }
        public virtual ICollection<Nota> NotaIdPaqueteriaNavigations { get; set; }
        public virtual ICollection<Nota> NotaIdTipoNavigations { get; set; }
        public virtual ICollection<Producto> ProductoIdCatalogoNavigations { get; set; }
        public virtual ICollection<Producto> ProductoIdTipoNotaNavigations { get; set; }
    }
}
