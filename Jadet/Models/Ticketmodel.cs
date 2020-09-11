using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jadet.Models {
    public class Ticketmodel {

    }

    public class listaTicketsmodel {
        public List<Ticketmodel> Items { get; set; }
        public listaTicketsmodel() {
            Items = new List<Ticketmodel>();
        }

    }
}