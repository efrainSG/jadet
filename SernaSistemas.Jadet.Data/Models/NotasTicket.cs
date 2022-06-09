using System;
using System.Collections.Generic;

#nullable disable

namespace SernaSistemas.Jadet.Data.Models
{
    public partial class NotasTicket
    {
        public int Id { get; set; }
        public int IdNota { get; set; }
        public byte[] Ticket { get; set; }
        public decimal? MontoMxn { get; set; }
        public decimal? MontoUsd { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual Nota IdNotaNavigation { get; set; }
    }
}
