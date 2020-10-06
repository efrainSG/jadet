using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jadet.Models {
    public class Comentariomodel {
        public int Id { get; set; }
        public int IdPadre { get; set; }
        public int FolioNota { get; set; }
        public DateTime Fecha { get; set; }
        public string Mensaje { get; set; }
    }

    public class listaComentariosmodel {
        public notaModel Datos { get; set; }
        public List<Comentariomodel> Items { get; set; }
        public listaComentariosmodel() {
            Items = new List<Comentariomodel>();
        }

    }

}