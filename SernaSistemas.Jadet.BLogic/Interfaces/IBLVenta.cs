using SernaSistemas.Jadet.Comun.Modelos;
using System.Collections.Generic;

namespace SernaSistemas.Jadet.BLogic
{
    public interface IBLVenta
    {
        IEnumerable<Estatus> ObtenerEstatuses(bool esId, Estatus estatus);
        IEnumerable<Catalogo> ObtenerCatalogos(bool esId, Catalogo catalogo);
        IEnumerable<Usuario> ObtenerUsuarios(Usuario usuario);
        IEnumerable<Producto> ObtenerProductos(byte idTipo, bool esSku, Producto producto);
        IEnumerable<Nota> ObtenerNotas(byte tipoId, Nota nota);
        IEnumerable<Detalle> ObtenerDetalles(byte idTipo, Detalle detalle);
        IEnumerable<NotaTicket> ObtenerNotasTickets(bool esId, NotaTicket notaTicket);
        IEnumerable<NotaComentario> ObtenerComentarios(bool esId, NotaComentario notaComentario);
        IEnumerable<Nota> ObtenerCarritos(Usuario usuario);

        bool GuardarProducto(ref Producto producto);
        bool GuardarNota(ref Producto producto);
        bool GuardarDetalle(ref Producto producto);
        bool GuardarNotaTicket(ref Producto producto);
        bool GuardarNotaComentario(ref Producto producto);

        bool BorrarProducto(ref Producto producto);
        bool BorrarNota(ref Producto producto);
        bool BorrarDetalle(ref Producto producto);
        bool BorrarNotaTicket(ref Producto producto);
        bool BorrarNotaComentario(ref Producto producto);
        bool VaciarCarrito(ref Nota carrito);
    }
}
