using System;
using System.Collections.Generic;

#nullable disable

namespace SernaSistemas.Jadet.Data.Models
{
    public partial class TipoCatalogo
    {
        public TipoCatalogo()
        {
            Catalogos = new HashSet<Catalogo>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Catalogo> Catalogos { get; set; }
    }
}
