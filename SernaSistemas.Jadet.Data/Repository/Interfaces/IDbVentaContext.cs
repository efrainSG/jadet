using SernaSistemas.Jadet.Data.DTO;
using SernaSistemas.Jadet.Data.Models;

namespace SernaSistemas.Jadet.Data.Repository
{
    public interface IDbVentaContext
    {
        #region Estatus
        /// <summary>
        /// Para obtener uno o más estatuses.
        /// </summary>
        /// <param name="estatus"></param>
        /// <returns></returns>
        EstatusesDTO ObtenerEstatuses(EstatusDTO estatus);
        #endregion

        #region Catalogo
        /// <summary>
        /// Para obtener uno o más catálogos.
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        CatalogosDTO ObtenerCatalogos(CatalogoDTO catalogo);
        #endregion

        #region Usuario
        /// <summary>
        /// Para obtener uno o más usuarios.
        /// </summary>
        /// <param name="rol"></param>
        /// <returns></returns>
        UsuariosDTO ObtenerUsuarios(UsuarioDTO usuario);
        #endregion

        #region Producto
        /// <summary>
        /// Para obtener uno o más productos.
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        ProductosDTO ObtenerProductos(ProductoDTO producto);
        /// <summary>
        /// Para guardar un nuevo producto o su actualización.
        /// </summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        bool GuardarProducto(ref ProductoDTO producto);
        #endregion

        #region Nota
        /// <summary>
        /// Para obtener uno o más notas.
        /// </summary>
        /// <param name="nota"></param>
        /// <returns></returns>
        NotasDTO ObtenerNotas(NotaDTO nota);
        /// <summary>
        /// Para guardar una nueva nota o su actualización.
        /// </summary>
        /// <param name="nota"></param>
        /// <returns></returns>
        bool GuardarNota(ref NotaDTO nota);
        /// <summary>
        /// Para borrar una nota.
        /// </summary>
        /// <param name="nota"></param>
        /// <returns></returns>
        bool BorrarNota(ref NotaDTO nota);
        #endregion

        #region Detalle
        /// <summary>
        /// Para obtener uno o más detalles.
        /// </summary>
        /// <param name="detalle"></param>
        /// <returns></returns>
        DetallesDTO ObtenerDetalles(DetalleDTO detalle);
        /// <summary>
        /// Para guardar un nuevo detalle de nota o su actualización.
        /// </summary>
        /// <param name="detalle"></param>
        /// <returns></returns>
        bool GuardarDetalle(ref DetalleDTO detalle);
        /// <summary>
        /// Para borrar un detalle de nota
        /// </summary>
        /// <param name="detalle"></param>
        /// <returns></returns>
        bool BorrarDetalle(ref DetalleDTO detalle);
        #endregion

        #region NotaTicket
        /// <summary>
        /// Para obtener uno o más Tickets de notas.
        /// </summary>
        /// <param name="notaTicket"></param>
        /// <returns></returns>
        NotasTicketsDTO ObtenerNotasTickets(NotaTicketDTO notaTicket);
        /// <summary>
        /// Para guardar un nuevo ticket de nota o su actualización.
        /// </summary>
        /// <param name="notaTicket"></param>
        /// <returns></returns>
        bool GuardarNotaTicket(ref NotaTicketDTO notaTicket);
        /// <summary>
        /// Para borrar un ticket de nota.
        /// </summary>
        /// <param name="notaTicket"></param>
        /// <returns></returns>
        bool BorrarNotaTicket(ref NotaTicketDTO notaTicket);
        #endregion

        #region NotaComentario
        /// <summary>
        /// Para obtener uno o más Comentarios de nota.
        /// </summary>
        /// <param name="notaComentario"></param>
        /// <returns></returns>
        NotasComentariosDTO ObtenerNotasComentarios(NotaComentarioDTO notaComentario);
        /// <summary>
        /// Para guardar un nuevo Comentario de nota o su actualización.
        /// </summary>
        /// <param name="notaComentario"></param>
        /// <returns></returns>
        bool GuardarNotaComentario(ref NotaComentarioDTO notaComentario);
        /// <summary>
        /// Para borrar un comentario de nota.
        /// </summary>
        /// <param name="notaComentario"></param>
        /// <returns></returns>
        bool BorrarNotaComentario(ref NotaComentarioDTO notaComentario);
        #endregion
    }
}
