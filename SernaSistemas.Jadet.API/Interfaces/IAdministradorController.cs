using Microsoft.AspNetCore.Mvc;
using SernaSistemas.Jadet.Comun.Modelos;
using System;
using System.Collections.Generic;

namespace SernaSistemas.Jadet.API.Interfaces
{
    public interface IAdministradorController
    {
        #region Tipos de Catálogo
        [HttpGet("tipoCatalogo")]
        public IEnumerable<TipoCatalogo> GetTiposCatalogo();

        [HttpGet("tipoCatalogoPorId/{id}")]
        public IEnumerable<TipoCatalogo> GetTiposCatalogo(int id);

        [HttpGet("tipoCatalogoPorNombre/{nombre}")]
        public IEnumerable<TipoCatalogo> GetTiposCatalogo(string nombre);

        [HttpDelete("tipoCatalogo/{id}")]
        public ActionResult DelTiposCatalogo(int id);
        [HttpPost("tipoCatalogo")]
        public ActionResult<TipoCatalogo> PostTipoCatalogo(TipoCatalogo tipo);
        [HttpPut("tipoCatalogo/{id}")]
        public ActionResult<TipoCatalogo> PutTipoCatalogo(int id, TipoCatalogo tipo);
        #endregion

        #region Catálogo
        [HttpGet("catalogo")]
        public IEnumerable<Catalogo> GetCatalogo();
        [HttpGet("catalogoPorId/{esId}/{id}")]
        public IEnumerable<Catalogo> GetCatalogo(bool esId, int id);
        [HttpGet("catalogoPorNombre/{nombre}")]
        public IEnumerable<Catalogo> GetCatalogo(string nombre);
        [HttpDelete("catalogo/{id}")]
        public ActionResult DelCatalogo(int id);
        [HttpPost("catalogo")]
        public ActionResult<Catalogo> PostCatalogo(Catalogo catalogo);
        [HttpPut("catalogo/{id}")]
        public ActionResult<Catalogo> PutCatalogo(int id, Catalogo catalogo);
        #endregion

        #region Tipos de estatus
        [HttpGet("tipoEstatus")]
        public IEnumerable<TipoEstatus> GetTipoEstatus();
        [HttpGet("tipoEstatusPorId/{id}")]
        public IEnumerable<TipoEstatus> GetTipoEstatus(int id);
        [HttpGet("tipoEstatusPorNombre/{nombre}")]
        public IEnumerable<TipoEstatus> GetTipoEstatus(string nombre);
        [HttpDelete("tipoEstatus/{id}")]
        public ActionResult DelTipoEstatus(int id);
        [HttpPost("tipoEstatus")]
        public ActionResult<TipoEstatus> PostTipoEstatus(TipoEstatus tipo);
        [HttpPut("tipoEstatus/{id}")]
        public ActionResult<TipoEstatus> PutTipoEstatus(int id, TipoEstatus tipo);
        #endregion

        #region Estatuses
        [HttpGet("estatus")]
        public IEnumerable<Estatus> GetEstatus();
        [HttpGet("estatusPorId/{esId}/{id}")]
        public IEnumerable<Estatus> GetEstatus(bool esId, int id);
        [HttpGet("estatusPorNombre/{nombre}")]
        public IEnumerable<Estatus> GetEstatus(string nombre);
        [HttpDelete("estatus/{id}")]
        public ActionResult DelEstatus(int id);
        [HttpPost("estatus")]
        public ActionResult<Estatus> PostEstatus(Estatus estatus);
        [HttpPut("estatus/{id}")]
        public ActionResult<Estatus> PutEstatus(int id, Estatus estatus);
        #endregion

        #region Producto
        [HttpGet("producto")]
        public IEnumerable<Producto> GetProducto(byte tipoId, int id, bool esSku, string datoTexto);
        [HttpGet("productoPorId/{tipoId}/{id}")]
        public IEnumerable<Producto> GetProducto(byte tipoId, int id);
        [HttpGet("productoPorValor/{esSku}/{datoTexto}")]
        public IEnumerable<Producto> GetProducto(bool esSku, string datoTexto);
        [HttpDelete("producto")]
        public ActionResult DelProducto(int id);
        [HttpPost("producto")]
        public ActionResult<Producto> PostProducto(Producto producto);
        [HttpPut("producto")]
        public ActionResult<Producto> PutProducto(int id, Producto producto);
        #endregion

        #region Notas
        [HttpGet("nota")]
        public IEnumerable<Nota> GetNota();
        [HttpGet("notaPorId/{tipoId}/{id}")]
        public IEnumerable<Nota> GetNota(byte tipoId, int id);
        [HttpGet("notaPorIdCliente/{idCliente}")]
        public IEnumerable<Nota> GetNota(Guid idCliente);
        [HttpDelete("nota")]
        public ActionResult DelNota(int id);
        [HttpPost("nota")]
        public ActionResult<Nota> PostNota(Nota nota);
        [HttpPut("nota")]
        public ActionResult<Nota> PutNota(int id, Nota nota);
        #endregion

        #region Detalle de notas
        [HttpGet("detalle")]
        public IEnumerable<Detalle> GetDetalle();
        [HttpGet("detallePorId/{idTipo}/{id}")]
        public IEnumerable<Detalle> GetDetalle(byte idTipo, int id);
        [HttpDelete("detalle")]
        public ActionResult DelDetalle(int id);
        [HttpPost("detalle")]
        public ActionResult<Detalle> PostDetalle(Detalle detalle);
        [HttpPut("detalle")]
        public ActionResult<Detalle> PutDetalle(int id, Detalle detalle);
        #endregion

        #region Comentarios de notas
        [HttpGet("notaComentario")]
        public IEnumerable<NotaComentario> GetComentario();
        [HttpGet("notaComentarioPorId/{esId}/{id}")]
        public IEnumerable<NotaComentario> GetComentario(bool esId, int id);
        [HttpDelete("notaComentario")]
        public ActionResult DeleteComentario(int id);
        #endregion

        #region Tickets
        [HttpGet("notaTicket")]
        public IEnumerable<NotaTicket> GetNotaTicket();
        [HttpGet("notaTicketPorId/{esId}/{id}")]
        public IEnumerable<NotaTicket> GetNotaTicket(bool esId, int id);
        #endregion
    }
}
