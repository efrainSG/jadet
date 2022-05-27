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
        IEnumerable<Estatus> ObtenerEstatuses(Estatus estatus);
        IEnumerable<TipoCatalogo> ObtenerTiposCatalogo(TipoCatalogo tipoCatalogo);
        IEnumerable<Catalogo> ObtenerCatalogos(Catalogo catalogo);
        IEnumerable<Producto> ObtenerProductos(Producto producto);

        bool GuardarTipoEstatus(TipoEstatus tipoEstatus);
        bool GuardarEstatus(Estatus estatus);
        bool GuardarTipoCatalogo(TipoCatalogo tipoCatalogo);
        bool GuardarCatalogo(Catalogo catalogo);
        bool GuardarProducto(Producto producto);

        bool BorrarTipoEstatus(TipoEstatus tipoEstatus);
        bool BorrarEstatus(Estatus estatus);
        bool BorrarTipoCatalogo(TipoCatalogo tipoCatalogo);
        bool BorrarCatalogo(Catalogo catalogo);
        bool BorrarProducto(Producto producto);

    }
}
