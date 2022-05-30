using System;
using System.Collections.Generic;
using System.Linq;

namespace SernaSistemas.Jadet.Comun.Modelos
{
    public class NotaTicket
    {
        public int Id { get; set; }
        public int IdNota { get; set; }
        public byte[] Ticket { get; set; }
        public DateTime Fecha { get; set; }
        public decimal MontoMXN { get; set; }
        public decimal MontoUSD { get; set; }

        public static NotaTicket ToModel(dynamic notaTicket)
        {
            return new NotaTicket
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
}
