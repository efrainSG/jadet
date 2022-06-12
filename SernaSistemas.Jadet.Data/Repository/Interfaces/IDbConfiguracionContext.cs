using SernaSistemas.Jadet.Data.Models;
using SernaSistemas.Jadet.Data.DTO;

namespace SernaSistemas.Jadet.Data.Repository
{
    public interface IDbConfiguracionContext
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

    }
}
