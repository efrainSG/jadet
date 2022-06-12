using SernaSistemas.Jadet.Comun.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SernaSistemas.Jadet.BLogic
{
    public interface IBLConfiguracion
    {
        IEnumerable<TipoEstatus> ObtenerTiposEstatus(TipoEstatus tipoEstatus);
        IEnumerable<Estatus> ObtenerEstatuses(bool esId, Estatus estatus);
        IEnumerable<TipoCatalogo> ObtenerTiposCatalogo(TipoCatalogo tipoCatalogo);
        IEnumerable<Catalogo> ObtenerCatalogos(bool esId, Catalogo catalogo);
        IEnumerable<Producto> ObtenerProductos(byte idTipo, bool esSku, Producto producto);

        bool GuardarTipoEstatus(ref TipoEstatus tipoEstatus);
        bool GuardarEstatus(ref Estatus estatus);
        bool GuardarTipoCatalogo(ref TipoCatalogo tipoCatalogo);
        bool GuardarCatalogo(ref Catalogo catalogo);
        bool GuardarProducto(ref Producto producto);

        bool BorrarTipoEstatus(TipoEstatus tipoEstatus);
        bool BorrarEstatus(Estatus estatus);
        bool BorrarTipoCatalogo(TipoCatalogo tipoCatalogo);
        bool BorrarCatalogo(Catalogo catalogo);
        bool BorrarProducto(Producto producto);

    }
}
