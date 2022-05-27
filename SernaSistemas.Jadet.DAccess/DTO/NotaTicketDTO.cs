using System;
using System.Collections.Generic;
using System.Linq;

namespace SernaSistemas.Jadet.DAccess.DTO
{
    public class NotaTicketDTO
    {
        public int Id { get; set; }
        public int IdNota { get; set; }
        public byte[] Ticket { get; set; }
        public DateTime Fecha { get; set; }
        public decimal MontoMXN { get; set; }
        public decimal MontoUSD { get; set; }

        public static NotaTicketDTO ToDTO(dynamic notaTicket)
        {
            return new NotaTicketDTO
            {
                Id = notaTicket.Id,
                IdNota = notaTicket.IdNota,
                Ticket = notaTicket.Ticket,
                Fecha = notaTicket.Fecha,
                MontoMXN = notaTicket.MontoMXN,
                MontoUSD = notaTicket.MontoUSD
            };
        }
    }

    public class NotasTicketsDTO : List<NotaTicketDTO>
    {
        public static List<NotaTicketDTO> ToDTO(List<NotaTicket> notasTickets) =>
            (List<NotaTicketDTO>)notasTickets.Select(n => NotaTicketDTO.ToDTO(n));
    }
}
