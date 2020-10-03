using Jadet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jadet.Models {
    public class notaModel {
        public int Folio { get; set; }
        public DateTime? Fecha { get; set; }
        public int IdTipo { get; set; }
        public string Tipo { get; set; }
        public int IdEstatus { get; set; }
        public string Estatus { get; set; }
        public int IdPaqueteria { get; set; }
        public string Paqueteria { get; set; }
        public Guid IdCliente { get; set; }
        public string Cliente { get; set; }
        public string Guia { get; set; }
        public DateTime? FechaEnvio { get; set; }
        public decimal MontoMXN { get; set; }
        public decimal MontoUSD { get; set; }
        public decimal SaldoMXN { get; set; }
        public decimal SaldoUSD { get; set; }
    }
    public class notacompletaModel : notaModel {
        public List<detallenotaModel> Items { get; set; }
        public List<Comentariomodel> Comentarios { get; set; }
        public List<Ticketmodel> Tickets { get; set; }
        public notacompletaModel() {
            Items = new List<detallenotaModel>();
            Comentarios = new List<Comentariomodel>();
            Tickets = new List<Ticketmodel>();
        }
    }

    public class notacollectionModel {
        public List<notaModel> Items { get; set; }
        public notacollectionModel() {
            Items = new List<notaModel>();
        }
    }
    public class detallenotaModel {
        public int Id { get; set; }
        public int IdNota { get; set; }
        public int IdProducto { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioMXN { get; set; }
        public decimal PrecioUSD { get; set; }
        public decimal MontoMXN { get { return Cantidad * PrecioMXN; } }
        public decimal MontoUSD { get { return Cantidad * PrecioUSD; } }
    }

    public class listaNotaModel {
        public List<notaModel> Items { get; set; }
        public listaNotaModel() {
            Items = new List<notaModel>();
        }
    }

}