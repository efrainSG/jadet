using System;
using System.Collections.Generic;

#nullable disable

namespace SernaSistemas.Jadet.Data.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Nota = new HashSet<Nota>();
        }

        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public byte[] Foto { get; set; }
        public string Usuario1 { get; set; }
        public byte[] Passwd { get; set; }
        public int IdRol { get; set; }
        public int? ZonaPaqueteria { get; set; }
        public int IdEstatus { get; set; }

        public virtual Estatus IdEstatusNavigation { get; set; }
        public virtual Rol IdRolNavigation { get; set; }
        public virtual ICollection<Nota> Nota { get; set; }
    }
}
