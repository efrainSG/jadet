using Microsoft.AspNetCore.Mvc;
using SernaSistemas.Jadet.Comun.Modelos;
using System;
using System.Collections.Generic;

namespace SernaSistemas.Jadet.API.Interfaces
{
    public interface IConfiguracionController
    {
        #region Tipos de estatus
        [HttpGet("tiposEstatus")]
        public IEnumerable<TipoEstatus> GetTiposEstatus();
        [HttpGet("tiposEstatusPorId/{id}")]
        public IEnumerable<TipoEstatus> GetTiposEstatus(int id);
        [HttpGet("tiposEstatusPorNombre/{nombre}")]
        public IEnumerable<TipoEstatus> GetTiposEstatus(string nombre);
        [HttpDelete("tiposEstatus/{id}")]
        public ActionResult DelTiposEstatus(int id);
        [HttpPost("tiposEstatus")]
        public ActionResult<TipoEstatus> PostTiposEstatus([FromBody] TipoEstatus tipoEstatus);
        [HttpPut("tiposEstatus/{id}")]
        public ActionResult<TipoEstatus> PutTiposEstatus(int id, [FromBody] TipoEstatus tipoEstatus);
        #endregion

        #region Tipos de catálogo
        [HttpGet("tiposCatalogos")]
        public IEnumerable<TipoCatalogo> GetTiposCatalogos();
        [HttpGet("tiposCatalogosPorId/{id}")]
        public IEnumerable<TipoCatalogo> GetTiposCatalogos(int id);
        [HttpGet("tiposCatalogosPorNombre/{nombre}")]
        public IEnumerable<TipoCatalogo> GetTiposCatalogos(string nombre);
        [HttpDelete("tiposCatalogos/{id}")]
        public ActionResult DelTiposCatalogos(int id);
        [HttpPost("tiposCatalogos")]
        public ActionResult<TipoCatalogo> PostTiposCatalogos([FromBody] TipoCatalogo tipoCatalogo);
        [HttpPut("tiposCatalogos/{id}")]
        public ActionResult<TipoCatalogo> PutTiposCatalogos(int id, [FromBody] TipoCatalogo tipoCatalogo);
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
        public ActionResult<Estatus> PostEstatus([FromBody] Estatus estatus);
        [HttpPut("estatus/{id}")]
        public ActionResult<Estatus> PutEstatus(int id, [FromBody] Estatus estatus);
        #endregion

        #region Catálogos
        [HttpGet("catalogos")]
        public IEnumerable<Catalogo> GetCatalogos();
        [HttpGet("catalogosPorId/{esId}/{id}")]
        public IEnumerable<Catalogo> GetCatalogos(bool esId, int id);
        [HttpGet("catalogosPorNombre/{nombre}")]
        public IEnumerable<Catalogo> GetCatalogos(string nombre);
        [HttpDelete("catalogos/{id}")]
        public ActionResult DelCatalogos(int id);
        [HttpPost("catalogos")]
        public ActionResult<Catalogo> PostCatalogos([FromBody] Catalogo catalogo);
        [HttpPut("catalogos/{id}")]
        public ActionResult<Catalogo> PutCatalogos(int id, [FromBody] Catalogo catalogo);
        #endregion

        #region Productos
        [HttpGet("productos")]
        public IEnumerable<Producto> GetProductos();
        [HttpGet("productosPorId/{esId}/{id}")]
        public IEnumerable<Producto> GetProductos(byte tipoId, int id);
        [HttpGet("productosPorValor/{esSku}/{nombre}")]
        public IEnumerable<Producto> GetProductos(bool esSku, string nombre);
        [HttpDelete("productos/{id}")]
        public ActionResult DelProductos(int id);
        [HttpPost("productos")]
        public ActionResult<Producto> PostProducto([FromBody] Producto producto);
        [HttpPut("productos/{id}")]
        public ActionResult<Producto> PutProducto(int id, [FromBody] Producto producto);
        #endregion
    }
}
