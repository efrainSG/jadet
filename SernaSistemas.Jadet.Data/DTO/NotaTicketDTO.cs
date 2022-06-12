using SernaSistemas.Jadet.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SernaSistemas.Jadet.Data.DTO
{
    public class NotaTicketDto
    {
        public int Id { get; set; }
        public int IdNota { get; set; }
        public byte[] Ticket { get; set; }
        public DateTime Fecha { get; set; }
        public decimal MontoMXN { get; set; }
        public decimal MontoUSD { get; set; }

        public static NotaTicketDto ToDTO(dynamic notaTicket)
        {
            return new NotaTicketDto
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

    public class NotasTicketsDto : List<NotaTicketDto>
    {
        public static List<NotaTicketDto> ToDTO(List<NotasTicket> notasTickets) =>
            notasTickets.Select(n => NotaTicketDto.ToDTO(n)).ToList();
    }
}
