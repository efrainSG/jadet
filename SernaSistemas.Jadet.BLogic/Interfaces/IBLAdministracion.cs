using SernaSistemas.Jadet.Comun.Modelos;
using System.Collections.Generic;

namespace SernaSistemas.Jadet.BLogic
{
    public interface IBLAdministracion
    {
        IEnumerable<TipoEstatus> ObtenerTiposEstatus(TipoEstatus tipoEstatus);
        IEnumerable<Estatus> ObtenerEstatuses(bool esId, Estatus estatus);
        IEnumerable<TipoCatalogo> ObtenerTiposCatalogo(TipoCatalogo tipoCatalogo);
        IEnumerable<Catalogo> ObtenerCatalogos(bool esId, Catalogo catalogo);
        IEnumerable<Producto> ObtenerProductos(byte idTipo, bool esSku, Producto producto);
        IEnumerable<Nota> ObtenerNotas(byte tipoId, Nota nota);
        IEnumerable<Detalle> ObtenerDetalles(byte idTipo, Detalle detalle);
        IEnumerable<NotaTicket> ObtenerNotasTickets(bool esId, NotaTicket notaTicket);
        IEnumerable<NotaComentario> ObtenerComentarios(bool esId, NotaComentario notaComentario);

        bool GuardarTipoEstatus(ref TipoEstatus tipoEstatus);
        bool GuardarEstatus(ref Estatus estatus);
        bool GuardarTipoCatalogo(ref TipoCatalogo tipoCatalogo);
        bool GuardarCatalogo(ref Catalogo catalogo);
        bool GuardarProducto(ref Producto producto);
        bool GuardarNota(ref Nota nota);
        bool GuardarDetalle(ref Detalle detalle);

        bool BorrarTipoEstatus(TipoEstatus tipoEstatus);
        bool BorrarEstatus(Estatus estatus);
        bool BorrarTipoCatalogo(TipoCatalogo tipoCatalogo);
        bool BorrarCatalogo(Catalogo catalogo);
        bool BorrarProducto(Producto producto);
        bool BorrarNota(Nota nota);
        bool BorrarDetalle(Detalle detalle);
        bool BorrarNotaComentario(NotaComentario notaComentario);

    }
}
