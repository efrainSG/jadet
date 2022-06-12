using SernaSistemas.Jadet.Data.Models;
using SernaSistemas.Jadet.Data.DTO;

namespace SernaSistemas.Jadet.Data.Repository
{
    public interface IDbAdministracionContext
    {
        #region TipoEstatus
        /// <summary>
        /// Para obtener uno o más tipos de estatus.
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        TiposEstatusDto ObtenerTiposEstatus(TipoEstatusDto tipo);
        /// <summary>
        /// Para Borrar un tipo de estatus.
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        bool BorrarTipoEstatus(ref TipoEstatusDto tipo);
        /// <summary>
        /// Para guardar un nuevo tipo de estatus o su actualización.
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        bool GuardarTipoEstatus(ref TipoEstatusDto tipo);
        #endregion

        #region Estatus
        /// <summary>
        /// Para obtener uno o más estatuses.
        /// </summary>
        /// <param name="estatus"></param>
        /// <returns></returns>
        EstatusesDto ObtenerEstatuses(EstatusDto estatus);
        /// <summary>
        /// Para Borrar un estatus.
        /// </summary>
        /// <param name="estatus"></param>
        /// <returns></returns>
        bool BorrarEstatus(ref EstatusDto estatus);
        /// <summary>
        /// Para guardar un nuevo estatus o su actualización.
        /// </summary>
        /// <param name="estatus"></param>
        /// <returns></returns>
        bool GuardarEstatus(ref EstatusDto estatus);
        #endregion

        #region TipoCatalogo
        /// <summary>
        /// Para obtener uno o más tipos de catálogos.
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        TiposCatalogosDto ObtenerTiposCatalogos(TipoCatalogoDto tipoCatalogo);
        /// <summary>
        /// Para Borrar un tipo de catálogo.
        /// </summary>
        /// <param name="tipoCatalogo"></param>
        /// <returns></returns>
        bool BorrarTipoCatalogo(ref TipoCatalogoDto tipoCatalogo);
        /// <summary>
        /// Para guardar un nuevo tipo de catálogo o su actualización.
        /// </summary>
        /// <param name="tipoCatalogo"></param>
        /// <returns></returns>
        bool GuardarTipoCatalogo(ref TipoCatalogoDto tipoCatalogo);
        #endregion

        #region Catalogo
        /// <summary>
        /// Para obtener uno o más catálogos.
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        CatalogosDto ObtenerCatalogos(CatalogoDto catalogo);
        /// <summary>
        /// Para Borrar un catalogo.
        /// </summary>
        /// <param name="catalogo"></param>
        /// <returns></returns>
        bool BorrarCatalogo(ref CatalogoDto catalogo);
        /// <summary>
        /// Para guardar un nuevo catálogo o su actualización.
        /// </summary>
        /// <param name="catalogo"></param>
        /// <returns></returns>
        bool GuardarCatalogo(ref CatalogoDto catalogo);
        #endregion

        #region Producto
        /// <summary>
        /// Para obtener uno o más productos.
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        ProductosDto ObtenerProductos(ProductoDto producto);
        /// <summary>
        /// Para Borrar un producto.
        /// </summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        bool BorrarProducto(ref ProductoDto producto);
        /// <summary>
        /// Para guardar un nuevo producto o su actualización.
        /// </summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        bool GuardarProducto(ref ProductoDto producto);
        #endregion

        #region Nota
        /// <summary>
        /// Para obtener uno o más notas.
        /// </summary>
        /// <param name="nota"></param>
        /// <returns></returns>
        NotasDto ObtenerNotas(NotaDto nota);
        /// <summary>
        /// Para guardar una actualización de nota.
        /// </summary>
        /// <param name="nota"></param>
        /// <returns></returns>
        bool GuardarNota(ref NotaDto nota);
        /// <summary>
        /// Para borrar una nota.
        /// </summary>
        /// <param name="nota"></param>
        /// <returns></returns>
        bool BorrarNota(ref NotaDto nota);
        #endregion

        #region Detalle
        /// <summary>
        /// Para obtener uno o más detalles.
        /// </summary>
        /// <param name="detalle"></param>
        /// <returns></returns>
        DetallesDto ObtenerDetalles(DetalleDto detalle);
        /// <summary>
        /// Para guardar una actualización de detalle de nota.
        /// </summary>
        /// <param name="detalle"></param>
        /// <returns></returns>
        bool GuardarDetalle(ref DetalleDto detalle);
        /// <summary>
        /// Para borrar un detalle de nota
        /// </summary>
        /// <param name="detalle"></param>
        /// <returns></returns>
        bool BorrarDetalle(ref DetalleDto detalle);
        #endregion

        #region NotaTicket
        /// <summary>
        /// Para obtener uno o más Tickets de notas.
        /// </summary>
        /// <param name="notaTicket"></param>
        /// <returns></returns>
        NotasTicketsDto ObtenerNotasTickets(NotaTicketDto notaTicket);
        #endregion

        #region NotaComentario
        /// <summary>
        /// Para obtener uno o más Comentarios de nota.
        /// </summary>
        /// <param name="notaComentario"></param>
        /// <returns></returns>
        NotasComentariosDto ObtenerNotasComentarios(NotaComentarioDto notaComentario);
        /// <summary>
        /// Para guardar un nuevo Comentario de nota o su actualización.
        /// </summary>
        /// <param name="notaComentario"></param>
        /// <returns></returns>
        bool GuardarNotaComentario(ref NotaComentarioDto notaComentario);
        /// <summary>
        /// Para borrar un comentario de nota.
        /// </summary>
        /// <param name="notaComentario"></param>
        /// <returns></returns>
        bool BorrarNotaComentario(ref NotaComentarioDto notaComentario);
        #endregion
    }
}
