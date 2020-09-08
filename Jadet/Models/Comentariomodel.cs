using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jadet.Models {
    public class Comentariomodel {
    }

    public class listaComentariosmodel {
        public List<Comentariomodel> Items { get; set; }
        public listaComentariosmodel() {
            Items = new List<Comentariomodel>();
        }

    }
}