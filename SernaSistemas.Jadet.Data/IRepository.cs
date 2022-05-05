using SernaSistemas.Jadet.Data.Dtos;
using System.Collections.Generic;

namespace SernaSistemas.Jadet.Data
{
    public interface IRepository
    {
        Carrito ObtenerCarrito(int id);
        IEnumerable<Carrito> ObtenerCarritos();
        Carrito GuardarCarrito(Carrito carrito);
        bool BorrarCarrito(int id);

        Catalogo ObtenerCatalogo(int id);
        IEnumerable<Catalogo> ObtenerCatalogos();
        Catalogo GuardarCatalogo(Catalogo catalogo);
        bool BorrarCatalogo(int id);

        Comentario ObtenerComentario(int id);
        IEnumerable<Comentario> ObtenerComentarios();
        Comentario GuardarComentario(Comentario comentario);
        bool BorrarComentario(int id);

        DetalleNota ObtenerDetalle(int folio);
        IEnumerable<DetalleNota> ObtenerDetallesNotas();
        DetalleNota GuardarDetalleNota(DetalleNota detalleNota);
        bool BorrarDetalleNota(int id);

        Estatus ObtenerEstatus(int id);
        IEnumerable<Estatus> ObtenerEstatuses();
        Estatus GuardarEstatus(Estatus estatus);
        bool BorrarEstatus(int id);

        Nota ObtenerNota(int folio);
        IEnumerable<Nota> ObtenerNotas();
        Nota GuardarNota(Nota nota);
        bool BorrarNota(int id);

        Producto ObtenerProducto(int id);
        IEnumerable<Producto> ObtenerProductos();
        Producto GuardarProducto(Producto producto);
        bool BorrarProducto(int id);

        Ticket ObtenerTicket(int id);
        IEnumerable<Ticket> ObtenerTickets();
        Ticket GuardarTicket(Ticket ticket);
        bool BorrarTicket(int id);

        Usuario ObtenerUsuario(int id);
        IEnumerable<Usuario> ObtenerUsuarios();
        Usuario GuardarUsuario(Usuario usuario);
        bool BorrarUsuario(int id);
    }
}
