using System;
using System.Collections.Generic;

#nullable disable

namespace SernaSistemas.Jadet.Data.Models
{
    public partial class TipoEstatus
    {
        public TipoEstatus()
        {
            Estatuses = new HashSet<Estatus>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Estatus> Estatuses { get; set; }
    }
}
