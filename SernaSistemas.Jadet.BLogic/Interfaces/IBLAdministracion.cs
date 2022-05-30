using SernaSistemas.Jadet.Comun.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SernaSistemas.Jadet.BLogic
{
    public interface IBLAdministracion
    {
        IEnumerable<TipoEstatus> ObtenerTiposEstatus(TipoEstatus tipoEstatus);
        IEnumerable<Estatus> ObtenerEstatuses(Estatus estatus);
        IEnumerable<TipoCatalogo> ObtenerTiposCatalogo(TipoCatalogo tipoCatalogo);
        IEnumerable<Catalogo> ObtenerCatalogos(Catalogo catalogo);
        IEnumerable<Producto> ObtenerProductos(Producto producto);
        IEnumerable<Nota> ObtenerNotas(Nota nota);
        IEnumerable<Detalle> ObtenerDetalles(Detalle detalle);
        IEnumerable<NotaTicket> ObtenerNotasTickets(NotaTicket notaTicket);
        IEnumerable<NotaComentario> ObtenerComentarios(NotaComentario notaComentario);

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
