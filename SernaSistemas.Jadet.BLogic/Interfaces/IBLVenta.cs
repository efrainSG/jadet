using SernaSistemas.Jadet.Comun.Modelos;
using System.Collections.Generic;

namespace SernaSistemas.Jadet.BLogic
{
    public interface IBLVenta
    {
        IEnumerable<Estatus> ObtenerEstatuses(Estatus estatus);
        IEnumerable<Catalogo> ObtenerCatalogos(Catalogo catalogo);
        IEnumerable<Usuario> ObtenerUsuarios(Usuario usuario);
        IEnumerable<Producto> ObtenerProductos(Producto producto);
        IEnumerable<Nota> ObtenerNotas(Nota nota);
        IEnumerable<Detalle> ObtenerDetalles(Detalle detalle);
        IEnumerable<NotaTicket> ObtenerNotasTickets(NotaTicket notaTicket);
        IEnumerable<NotaComentario> ObtenerComentarios(NotaComentario notaComentario);

        bool GuardarProducto(ref Producto producto);
        bool GuardarNota(ref Producto producto);
        bool GuardarDetalle(ref Producto producto);
        bool GuardarNotaTicket(ref Producto producto);
        bool GuardarNotaComentario(ref Producto producto);

    }
}
