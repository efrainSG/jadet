using Microsoft.AspNetCore.Mvc;
using SernaSistemas.Jadet.Data.Models;
using System.Collections.Generic;

namespace SernaSistemas.Jadet.API.Interfaces
{
    public interface IVentasController
    {
        [HttpGet("catalogo")]
        public IEnumerable<Catalogo> GetCatalogo();

        [HttpGet("carritos")]
        public IEnumerable<Nota> GetCarritos();

        [HttpGet("comentarios")]
        public IEnumerable<NotasComentario> GetComentarios();
        [HttpDelete("comentarios/{id}")]
        public ActionResult DelComentario(int id);
        [HttpPost("comentarios")]
        public ActionResult<NotasComentario> PostComentario(NotasComentario notasComentario);
        [HttpPut("comentarios/{id}")]
        public ActionResult<NotasComentario> PutComentario(int id, NotasComentario notasComentario);

        [HttpGet("detalles")]
        public IEnumerable<Detalle> GetDetalles();
        [HttpDelete("detalles/{id}")]
        public ActionResult DelDetalles(int id);
        [HttpPost("detalles")]
        public ActionResult<Detalle> PostDetalle(Detalle detalle);
        [HttpPut("detalles/{id}")]
        public ActionResult<Detalle> PutDetalle(int id, Detalle detalle);

        [HttpGet("estatus")]
        public IEnumerable<Estatus> GetEstatus();

        [HttpGet("nota")]
        public IEnumerable<Nota> GetNotas();
        [HttpDelete("nota/{id}")]
        public ActionResult DelNota(int id);
        [HttpPost("nota")]
        public ActionResult<Nota> PostNota(Nota nota);
        [HttpPut("nota/{id}")]
        public ActionResult<Nota> PutNota(int id, Nota nota);

        [HttpGet("ticket")]
        public IEnumerable<NotasTicket> ObtenerNotasTickets();
        [HttpDelete("ticket/{id}")]
        public ActionResult DelNotaTicket(int id);

        [HttpGet("producto")]
        public IEnumerable<Producto> GetProductos();
        [HttpDelete("producto/{id}")]
        public ActionResult DelProducto(int id);

        [HttpGet("")]
        public IEnumerable<Usuario> GetUsuarios();
    }
}
