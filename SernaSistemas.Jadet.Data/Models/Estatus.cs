using System;
using System.Collections.Generic;

#nullable disable

namespace SernaSistemas.Jadet.Data.Models
{
    public partial class Estatus
    {
        public Estatus()
        {
            Productos = new HashSet<Producto>();
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdTipoEstatus { get; set; }

        public virtual TipoEstatus IdTipoEstatusNavigation { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
