using System;
using System.Collections.Generic;

#nullable disable

namespace SernaSistemas.Jadet.Data.Models
{
    public partial class Nota
    {
        public Nota()
        {
            Detalles = new HashSet<Detalle>();
            NotasComentarios = new HashSet<NotasComentario>();
            NotasTickets = new HashSet<NotasTicket>();
        }

        public int Folio { get; set; }
        public DateTime Fecha { get; set; }
        public int IdTipo { get; set; }
        public int IdEstatus { get; set; }
        public int IdPaqueteria { get; set; }
        public Guid IdCliente { get; set; }
        public string Guia { get; set; }
        public DateTime? FechaEnvio { get; set; }
        public decimal MontoMxn { get; set; }
        public decimal MontoUsd { get; set; }
        public decimal SaldoMxn { get; set; }
        public decimal SaldoUsd { get; set; }

        public virtual Usuario IdClienteNavigation { get; set; }
        public virtual Catalogo IdEstatusNavigation { get; set; }
        public virtual Catalogo IdPaqueteriaNavigation { get; set; }
        public virtual Catalogo IdTipoNavigation { get; set; }
        public virtual ICollection<Detalle> Detalles { get; set; }
        public virtual ICollection<NotasComentario> NotasComentarios { get; set; }
        public virtual ICollection<NotasTicket> NotasTickets { get; set; }
    }
}
