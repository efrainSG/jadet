using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jadet.Models {
    public class Ticketmodel {
        public int Id { get; set; }
        public int IdNota { get; set; }
        public string Ruta {
            get {
                return System.Text.Encoding.UTF8.GetString(Ticket);
            }
        }
        public byte[] Ticket { get; set; }
        public DateTime Fecha { get; set; }
        public decimal MontoMXN { get; set; }
        public decimal MontoUSD { get; set; }
    }

    public class listaTicketsmodel {
        public int Folio { get; set; }
        public int IdTipo { get; set; }
        public string Tipo { get; set; }
        public decimal MontoMXN { get; set; }
        public decimal MontoUSD { get; set; }
        public decimal SaldoMXN { get; set; }
        public decimal SaldoUSD { get; set; }
        public List<Ticketmodel> Items { get; set; }
        public listaTicketsmodel() {
            Items = new List<Ticketmodel>();
        }
    }
}