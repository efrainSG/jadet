using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using SernaSistemas.Jadet.Comun.Modelos;
using SernaSistemas.Jadet.BLogic;
using System.Linq;
using System;
using SernaSistemas.Jadet.API.Interfaces;

namespace SernaSistemas.Jadet.API.Controllers.V1
{
    [ApiController]
    [Route("v1/[controller]")]
    public class SeguridadController : ControllerBase, ISeguridadController
    {

        private readonly IBLSeguridad bLSeguridad;

        public SeguridadController(IBLSeguridad bLSeguridad)
        {
            this.bLSeguridad = bLSeguridad;
        }

        public IActionResult DelRoles(int id) =>
            bLSeguridad.BorrarRol(new Rol { Id = id }) ? Ok() : BadRequest();

        public ActionResult<bool> DelSesion(Comun.Modelos.Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public IActionResult DelUsuarios(Guid id) =>
            bLSeguridad.BorrarUsuario(new Usuario { Id = id }) ? Ok() : BadRequest();

        public IEnumerable<Estatus> GetEstatus() =>
            bLSeguridad.ObtenerEstatuses(true, new Estatus { Id = 0 });

        public IEnumerable<Estatus> GetEstatus(bool esId, int id) =>
            bLSeguridad.ObtenerEstatuses(esId, new Estatus { Id = 0 });

        public IEnumerable<Estatus> GetEstatus(string nombre) =>
            bLSeguridad.ObtenerEstatuses(false, new Estatus { Id = 0 });

        public IEnumerable<Rol> GetRoles() =>
            bLSeguridad.ObtenerRoles(new() { Id = 0 });
        public IEnumerable<Rol> GetRoles(int id) =>
            bLSeguridad.ObtenerRoles(new() { Id = 0 });
        public IEnumerable<Rol> GetRoles(string nombre) =>
            bLSeguridad.ObtenerRoles(new() { Id = 0 });
        public IEnumerable<TipoEstatus> GetTiposEstatus() =>
            bLSeguridad.ObtenerTiposEstatus(new() { Id = 0 });

        public IEnumerable<TipoEstatus> GetTiposEstatus(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipoEstatus> GetTiposEstatus(string nombre)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetUsuarios()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetUsuarios(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetUsuarios(string nombre)
        {
            throw new NotImplementedException();
        }

        public ActionResult<Rol> PostRoles(Rol rol)
        {
            throw new NotImplementedException();
        }

        public ActionResult<Usuario> PostSesion(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public ActionResult<Usuario> PostUsuarios(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public ActionResult<Rol> PutRoles(int id, Rol rol)
        {
            throw new NotImplementedException();
        }

        public ActionResult<Usuario> PutUsuarios(int id, Usuario usuario)
        {
            throw new NotImplementedException();
        }

        //#region Tipos de Catálogo
        //[HttpGet("tipoCatalogo")]
        //public IEnumerable<TipoCatalogo> GetTiposCatalogo() =>
        //    bLSeguridad.ObtenerTiposCatalogo(new TipoCatalogo { Id = 0 }).ToArray();

        //[HttpGet("tipoCatalogoPorId")]
        //public IEnumerable<TipoCatalogo> GetTiposCatalogo([FromQuery] int id) =>
        //    bLSeguridad.ObtenerTiposCatalogo(new TipoCatalogo { Id = id, Nombre = string.Empty }).ToArray();

        //[HttpGet("tipoCatalogoPorNombre")]
        //public IEnumerable<TipoCatalogo> GetTiposCatalogo([FromQuery] string nombre) =>
        //    bLSeguridad.ObtenerTiposCatalogo(new TipoCatalogo { Id = 0, Nombre = nombre }).ToArray();

        //[HttpDelete("tipoCatalogo/{id}")]
        //public ActionResult DelTiposCatalogo(int id) =>
        //    bLSeguridad.BorrarTipoCatalogo(new TipoCatalogo { Id = id }) ? Ok() : BadRequest();
        //[HttpPost("tipoCatalogo")]
        //public ActionResult<TipoCatalogo> PostTipoCatalogo([FromBody] TipoCatalogo tipo) =>
        //    bLSeguridad.GuardarTipoCatalogo(ref tipo) ? new ActionResult<TipoCatalogo>(tipo) : BadRequest();
        //[HttpPut("tipoCatalogo/{id}")]
        //public ActionResult<TipoCatalogo> PutTipoCatalogo(int id, [FromBody] TipoCatalogo tipo)
        //{
        //    if (id == tipo.Id)
        //    {
        //        return bLSeguridad.GuardarTipoCatalogo(ref tipo) ? new ActionResult<TipoCatalogo>(tipo) : BadRequest();
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}
        //#endregion

        //#region Catálogo
        //[HttpGet("catalogo")]
        //public IEnumerable<Catalogo> GetCatalogo() =>
        //    bLSeguridad.ObtenerCatalogos(true, new Catalogo { Id = 0, Nombre = string.Empty }).ToArray();
        //[HttpGet("catalogoPorId/{esId}/{id}")]
        //public IEnumerable<Catalogo> GetCatalogo(bool esId, int id) =>
        //    bLSeguridad.ObtenerCatalogos(esId, new Catalogo { Id = id, Nombre = string.Empty }).ToArray();
        //[HttpGet("catalogoPorNombre/{nombre}")]
        //public IEnumerable<Catalogo> GetCatalogo(string nombre) =>
        //    bLSeguridad.ObtenerCatalogos(false, new Catalogo { Id = 0, Nombre = nombre }).ToArray();
        //[HttpDelete("catalogo/{id}")]
        //public ActionResult DelCatalogo(int id) =>
        //    bLSeguridad.BorrarCatalogo(new Catalogo { Id = id }) ? Ok() : BadRequest();
        //[HttpPost("catalogo")]
        //public ActionResult<Catalogo> PostCatalogo([FromBody] Catalogo catalogo) =>
        //    bLSeguridad.GuardarCatalogo(ref catalogo) ? new ActionResult<Catalogo>(catalogo) : BadRequest();
        //[HttpPut("catalogo/{id}")]
        //public ActionResult<Catalogo> PutCatalogo(int id, [FromBody] Catalogo catalogo)
        //{
        //    if (id == catalogo.Id)
        //    {
        //        return bLSeguridad.GuardarCatalogo(ref catalogo) ? new ActionResult<Catalogo>(catalogo) : BadRequest();
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}
        //#endregion

        //#region Tipos de estatus
        //[HttpGet("tipoEstatus")]
        //public IEnumerable<TipoEstatus> GetTiposEstatus() =>
        //    bLSeguridad.ObtenerTiposEstatus(new TipoEstatus { Id = 0, Nombre = string.Empty }).ToArray();
        //[HttpGet("tipoEstatusPorId/{id}")]
        //public IEnumerable<TipoEstatus> GetTiposEstatus(int id) =>
        //    bLSeguridad.ObtenerTiposEstatus(new TipoEstatus { Id = id, Nombre = string.Empty }).ToArray();
        //[HttpGet("tipoEstatusPorNombre/{nombre}")]
        //public IEnumerable<TipoEstatus> GetTiposEstatus(string nombre) =>
        //    bLSeguridad.ObtenerTiposEstatus(new TipoEstatus { Id = 0, Nombre = nombre }).ToArray();
        //[HttpDelete("tipoEstatus/{id}")]
        //public ActionResult DelTipoEstatus(int id) =>
        //    bLSeguridad.BorrarTipoEstatus(new TipoEstatus { Id = id }) ? Ok() : BadRequest();
        //[HttpPost("tipoEstatus")]
        //public ActionResult<TipoEstatus> PostTipoEstatus([FromBody] TipoEstatus tipo) =>
        //    bLSeguridad.GuardarTipoEstatus(ref tipo) ? new ActionResult<TipoEstatus>(tipo) : BadRequest();
        //[HttpPut("tipoEstatus/{id}")]
        //public ActionResult<TipoEstatus> PutTipoEstatus(int id, [FromBody] TipoEstatus tipo)
        //{
        //    if (id == tipo.Id)
        //    {
        //        return bLSeguridad.GuardarTipoEstatus(ref tipo) ? new ActionResult<TipoEstatus>(tipo) : BadRequest();
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}
        //#endregion

        //#region Estatuses
        //[HttpGet("estatus")]
        //public IEnumerable<Estatus> GetEstatus() =>
        //    bLSeguridad.ObtenerEstatuses(true, new Estatus { Id = 0, Nombre = string.Empty }).ToArray();
        //[HttpGet("estatusPorId/{esId}/{id}")]
        //public IEnumerable<Estatus> GetEstatus(bool esId, int id) =>
        //    bLSeguridad.ObtenerEstatuses(esId, new Estatus { Id = id }).ToArray();
        //[HttpGet("estatusPorNombre/{nombre}")]
        //public IEnumerable<Estatus> GetEstatus(string nombre) =>
        //    bLSeguridad.ObtenerEstatuses(true, new Estatus { Id = 0, Nombre = nombre }).ToArray();
        //[HttpDelete("estatus/{id}")]
        //public ActionResult DelEstatus(int id) =>
        //    bLSeguridad.BorrarEstatus(new Estatus { Id = id }) ? Ok() : BadRequest();
        //[HttpPost("estatus")]
        //public ActionResult<Estatus> PostEstatus([FromBody] Estatus estatus) =>
        //    bLSeguridad.GuardarEstatus(ref estatus) ? new ActionResult<Estatus>(estatus) : BadRequest();
        //[HttpPut("estatus/{id}")]
        //public ActionResult<Estatus> PutEstatus(int id, [FromBody] Estatus estatus)
        //{
        //    if (id == estatus.Id)
        //    {
        //        return bLSeguridad.GuardarEstatus(ref estatus) ? new ActionResult<Estatus>(estatus) : BadRequest();
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}
        //#endregion

        //#region Producto
        //[HttpGet("producto")]
        //public IEnumerable<Producto> GetProducto(byte tipoId, int id, bool esSku, string datoTexto) =>
        //    bLSeguridad.ObtenerProductos(tipoId, esSku, new Producto { Id = id, Sku = datoTexto }).ToArray();
        //[HttpGet("productoPorId/{tipoId}/{id}")]
        //public IEnumerable<Producto> GetProducto(byte tipoId, int id) =>
        //    bLSeguridad.ObtenerProductos(tipoId, false, new Producto { Id = id }).ToArray();
        //[HttpGet("productoPorValor/{esSku}/{datoTexto}")]
        //public IEnumerable<Producto> GetProducto(bool esSku, string datoTexto) =>
        //    bLSeguridad.ObtenerProductos(4, esSku, new Producto { Id = 0, Sku = datoTexto }).ToArray();
        //[HttpDelete("producto")]
        //public ActionResult DelProducto(int id) =>
        //    bLSeguridad.BorrarProducto(new Producto { Id = id }) ? Ok() : BadRequest();
        //[HttpPost("producto")]
        //public ActionResult<Producto> PostProducto(Producto producto) =>
        //    bLSeguridad.GuardarProducto(ref producto) ? new ActionResult<Producto>(producto) : BadRequest();
        //[HttpPut("producto")]
        //public ActionResult<Producto> PutProducto(int id, Producto producto)
        //{
        //    if (id == producto.Id)
        //    {
        //        return bLSeguridad.GuardarProducto(ref producto) ? new ActionResult<Producto>(producto) : BadRequest();
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}
        //#endregion

        //#region Notas
        //[HttpGet("nota")]
        //public IEnumerable<Nota> GetNota() =>
        //    bLSeguridad.ObtenerNotas(4, new Nota { Folio = 0, IdCliente = Guid.Empty }).ToArray();
        //[HttpGet("notaPorId/{tipoId}/{id}")]
        //public IEnumerable<Nota> GetNota(byte tipoId, int id) =>
        //    bLSeguridad.ObtenerNotas(tipoId, new Nota { Folio = id, IdCliente = Guid.Empty }).ToArray();
        //[HttpGet("notaPorIdCliente/{idCliente}")]
        //public IEnumerable<Nota> GetNota(Guid idCliente) =>
        //    bLSeguridad.ObtenerNotas(4, new Nota { Folio = 0, IdCliente = idCliente }).ToArray();
        //[HttpDelete("nota")]
        //public ActionResult DelNota(int id) =>
        //    bLSeguridad.BorrarNota(new Nota { Folio = id }) ? Ok() : BadRequest();
        //[HttpPost("nota")]
        //public ActionResult<Nota> PostNota(Nota nota) =>
        //    bLSeguridad.GuardarNota(ref nota) ? new ActionResult<Nota>(nota) : BadRequest();
        //[HttpPut("nota")]
        //public ActionResult<Nota> PutNota(int id, Nota nota)
        //{
        //    if (id == nota.Folio)
        //    {
        //        return bLSeguridad.GuardarNota(ref nota) ? new ActionResult<Nota>(nota) : BadRequest();
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}
        //#endregion

        //#region Detalle de notas
        //[HttpGet("detalle")]
        //public IEnumerable<Detalle> GetDetalle() =>
        //    bLSeguridad.ObtenerDetalles(3, new Detalle { Id = 0 }).ToArray();
        //[HttpGet("detallePorId/{idTipo}/{id}")]
        //public IEnumerable<Detalle> GetDetalle(byte idTipo, int id) =>
        //    bLSeguridad.ObtenerDetalles(idTipo, new Detalle { Id = id }).ToArray();
        //[HttpDelete("detalle")]
        //public ActionResult DelDetalle(int id) =>
        //    bLSeguridad.BorrarDetalle(new Detalle { Id = id }) ? Ok() : BadRequest();
        //[HttpPost("detalle")]
        //public ActionResult<Detalle> PostDetalle(Detalle detalle) =>
        //    bLSeguridad.GuardarDetalle(ref detalle) ? new ActionResult<Detalle>(detalle) : BadRequest();
        //[HttpPut("detalle")]
        //public ActionResult<Detalle> PutDetalle(int id, Detalle detalle)
        //{
        //    if (id == detalle.Id)
        //    {
        //        return bLSeguridad.GuardarDetalle(ref detalle) ? new ActionResult<Detalle>(detalle) : BadRequest();
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}
        //#endregion

        //#region Comentarios de notas
        //[HttpGet("notaComentario")]
        //public IEnumerable<NotaComentario> GetComentario() =>
        //    bLSeguridad.ObtenerComentarios(false, new NotaComentario { Id = 0 }).ToArray();
        //[HttpGet("notaComentarioPorId/{esId}/{id}")]
        //public IEnumerable<NotaComentario> GetComentario(bool esId, int id) =>
        //    bLSeguridad.ObtenerComentarios(esId, new NotaComentario { Id = id }).ToArray();
        //[HttpDelete("notaComentario")]
        //public ActionResult DeleteComentario(int id) =>
        //    bLSeguridad.BorrarNotaComentario(new NotaComentario { Id = id }) ? Ok() : BadRequest();
        //#endregion

        //#region Tickets
        //[HttpGet("notaTicket")]
        //public IEnumerable<NotaTicket> GetNotaTicket() =>
        //    bLSeguridad.ObtenerNotasTickets(false, new NotaTicket()).ToArray();
        //[HttpGet("notaTicketPorId/{esId}/{id}")]
        //public IEnumerable<NotaTicket> GetNotaTicket(bool esId, int id) =>
        //    bLSeguridad.ObtenerNotasTickets(esId, new NotaTicket { Id = id }).ToArray();
        //#endregion
    }
}
