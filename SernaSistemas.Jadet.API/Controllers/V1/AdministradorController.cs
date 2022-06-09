using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using SernaSistemas.Jadet.Comun.Modelos;
using SernaSistemas.Jadet.BLogic;
using System.Linq;
using System;

namespace SernaSistemas.Jadet.API.Controllers.V1
{
    [ApiController]
    [Route("v1/[controller]")]
    public class AdministradorController : ControllerBase
    {

        private readonly IBLAdministracion bLAdministracion;

        public AdministradorController(IBLAdministracion bLAdministracion)
        {
            this.bLAdministracion = bLAdministracion;
        }

        [HttpGet("tipoCatalogo")]
        public IEnumerable<TipoCatalogo> GetTiposCatalogo() =>
            bLAdministracion.ObtenerTiposCatalogo(new TipoCatalogo { Id = 0 }).ToArray();

        [HttpGet("tipoCatalogoPorId")]
        public IEnumerable<TipoCatalogo> GetTiposCatalogo([FromQuery] int id) =>
            bLAdministracion.ObtenerTiposCatalogo(new TipoCatalogo { Id = id, Nombre = string.Empty}).ToArray();

        [HttpGet("tipoCatalogoPorNombre")]
        public IEnumerable<TipoCatalogo> GetTiposCatalogo([FromQuery] string nombre) =>
            bLAdministracion.ObtenerTiposCatalogo(new TipoCatalogo { Id = 0, Nombre = nombre }).ToArray();

        [HttpDelete("tipoCatalogo/{id}")]
        public ActionResult DelTiposCatalogo(int id) =>
            bLAdministracion.BorrarTipoCatalogo(new TipoCatalogo { Id = id }) ? Ok() : BadRequest();
        [HttpPost("tipoCatalogo")]
        public ActionResult<TipoCatalogo> PostTipoCatalogo([FromBody] TipoCatalogo tipo) =>
            bLAdministracion.GuardarTipoCatalogo(ref tipo) ? new ActionResult<TipoCatalogo>(tipo) : BadRequest();
        [HttpPut("tipoCatalogo/{id}")]
        public ActionResult<TipoCatalogo> PutTipoCatalogo(int id, [FromBody] TipoCatalogo tipo)
        {
            if (id == tipo.Id)
            {
                return bLAdministracion.GuardarTipoCatalogo(ref tipo) ? new ActionResult<TipoCatalogo>(tipo) : BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpGet("catalogo")]
        public IEnumerable<Catalogo> GetCatalogo() =>
            bLAdministracion.ObtenerCatalogos(true, new Catalogo { Id = 0, Nombre = string.Empty}).ToArray();
        [HttpGet("catalogoPorId/{esId}/{id}")]
        public IEnumerable<Catalogo> GetCatalogo(bool esId, int id) =>
            bLAdministracion.ObtenerCatalogos(esId, new Catalogo { Id = id, Nombre = string.Empty}).ToArray();
        [HttpGet("catalogoPorNombre/{nombre}")]
        public IEnumerable<Catalogo> GetCatalogo(string nombre) =>
            bLAdministracion.ObtenerCatalogos(false, new Catalogo { Id = 0, Nombre = nombre }).ToArray();
        [HttpDelete("catalogo/{id}")]
        public ActionResult DelCatalogo(int id) =>
            bLAdministracion.BorrarCatalogo(new Catalogo { Id = id }) ? Ok() : BadRequest();
        [HttpPost("catalogo")]
        public ActionResult<Catalogo> PostCatalogo([FromBody] Catalogo catalogo) =>
            bLAdministracion.GuardarCatalogo(ref catalogo) ? new ActionResult<Catalogo>(catalogo) : BadRequest();
        [HttpPut("catalogo/{id}")]
        public ActionResult<Catalogo> PutCatalogo(int id, [FromBody] Catalogo catalogo)
        {
            if (id == catalogo.Id)
            {
                return bLAdministracion.GuardarCatalogo(ref catalogo) ? new ActionResult<Catalogo>(catalogo) : BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("tipoEstatus/{id}/{nombre}")]
        public IEnumerable<TipoEstatus> GetTipoEstatus(int id, string nombre) =>
            bLAdministracion.ObtenerTiposEstatus(new TipoEstatus { Id = id, Nombre = nombre }).ToArray();
        [HttpDelete("tipoEstatus/{id}")]
        public ActionResult DelTipoEstatus(int id) =>
            bLAdministracion.BorrarTipoEstatus(new TipoEstatus { Id = id }) ? Ok() : BadRequest();
        [HttpPost("tipoEstatus")]
        public ActionResult<TipoEstatus> PostTipoEstatus([FromBody] TipoEstatus tipo) =>
            bLAdministracion.GuardarTipoEstatus(ref tipo) ? new ActionResult<TipoEstatus>(tipo) : BadRequest();
        [HttpPut("tipoEstatus/{id}")]
        public ActionResult<TipoEstatus> PutTipoEstatus(int id, [FromBody] TipoEstatus tipo)
        {
            if (id == tipo.Id)
            {
                return bLAdministracion.GuardarTipoEstatus(ref tipo) ? new ActionResult<TipoEstatus>(tipo) : BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("estatus/{esId}/{id}/{nombre}")]
        public IEnumerable<Estatus> GetEstatus(bool esId, int id, string nombre) =>
            bLAdministracion.ObtenerEstatuses(esId, new Estatus { Id = id, Nombre = nombre }).ToArray();
        [HttpDelete("estatus/{id}")]
        public ActionResult DelEstatus(int id) =>
            bLAdministracion.BorrarEstatus(new Estatus { Id = id }) ? Ok() : BadRequest();
        [HttpPost("estatus")]
        public ActionResult<Estatus> PostEstatus([FromBody] Estatus estatus) =>
            bLAdministracion.GuardarEstatus(ref estatus) ? new ActionResult<Estatus>(estatus) : BadRequest();
        [HttpPut("estatus/{id}")]
        public ActionResult<Estatus> PutEstatus(int id, [FromBody] Estatus estatus)
        {
            if (id == estatus.Id)
            {
                return bLAdministracion.GuardarEstatus(ref estatus) ? new ActionResult<Estatus>(estatus) : BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("producto")]
        public IEnumerable<Producto> GetProducto(byte tipoId, int id, bool esSku, string datoTexto) =>
            bLAdministracion.ObtenerProductos(tipoId, esSku, new Producto { Id = id, Sku = datoTexto }).ToArray();
        [HttpDelete("producto")]
        public ActionResult DelProducto(int id) =>
            bLAdministracion.BorrarProducto(new Producto { Id = id }) ? Ok() : BadRequest();
        [HttpPost("producto")]
        public ActionResult<Producto> PostProducto(Producto producto) =>
            bLAdministracion.GuardarProducto(ref producto) ? new ActionResult<Producto>(producto) : BadRequest();
        [HttpPut("producto")]
        public ActionResult<Producto> PutProducto(int id, Producto producto)
        {
            if (id == producto.Id)
            {
                return bLAdministracion.GuardarProducto(ref producto) ? new ActionResult<Producto>(producto) : BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("nota")]
        public IEnumerable<Nota> GetNota(byte tipoId, int id, Guid idCliente) =>
            bLAdministracion.ObtenerNotas(tipoId, new Nota { Folio = id, IdCliente = idCliente }).ToArray();
        [HttpDelete("nota")]
        public ActionResult DelNota(int id) =>
            bLAdministracion.BorrarNota(new Nota { Folio = id }) ? Ok() : BadRequest();
        [HttpPost("nota")]
        public ActionResult<Nota> PostNota(Nota nota) =>
            bLAdministracion.GuardarNota(ref nota) ? new ActionResult<Nota>(nota) : BadRequest();
        [HttpPut("nota")]
        public ActionResult<Nota> PutNota(int id, Nota nota)
        {
            if (id == nota.Folio)
            {
                return bLAdministracion.GuardarNota(ref nota) ? new ActionResult<Nota>(nota) : BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("detalle")]
        public IEnumerable<Detalle> GetDetalle(byte idTipo, int id) =>
            bLAdministracion.ObtenerDetalles(idTipo, new Detalle { Id = id }).ToArray();
        [HttpDelete("detalle")]
        public ActionResult DelDetalle(int id) =>
            bLAdministracion.BorrarDetalle(new Detalle { Id = id }) ? Ok() : BadRequest();
        [HttpPost("detalle")]
        public ActionResult<Detalle> PostDetalle(Detalle detalle) =>
            bLAdministracion.GuardarDetalle(ref detalle) ? new ActionResult<Detalle>(detalle) : BadRequest();
        [HttpPut("detalle")]
        public ActionResult<Detalle> PutDetalle(int id, Detalle detalle)
        {
            if (id == detalle.Id)
            {
                return bLAdministracion.GuardarDetalle(ref detalle) ? new ActionResult<Detalle>(detalle) : BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("notaComentario")]
        public IEnumerable<NotaComentario> GetComentario(bool esId, int id) =>
            bLAdministracion.ObtenerComentarios(esId, new NotaComentario { Id = id }).ToArray();
        [HttpDelete("notaComentario")]
        public ActionResult DeleteComentario(int id) =>
            bLAdministracion.BorrarNotaComentario(new NotaComentario { Id = id }) ? Ok() : BadRequest();

        [HttpGet("notaTicket")]
        public IEnumerable<NotaTicket> GetNotaTicket(bool esId, int id) =>
            bLAdministracion.ObtenerNotasTickets(esId, new NotaTicket()).ToArray();

    }
}
