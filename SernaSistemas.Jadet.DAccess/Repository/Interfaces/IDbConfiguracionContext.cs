using SernaSistemas.Jadet.DAccess.DTO;

namespace SernaSistemas.Jadet.DAccess.Repository
{
    public interface IDbConfiguracionContext
    {
        #region TipoEstatus
        /// <summary>
        /// Para obtener uno o más tipos de estatus.
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        TiposEstatusDTO ObtenerTiposEstatus(TipoEstatusDTO tipo);
        /// <summary>
        /// Para Borrar un tipo de estatus.
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        bool BorrarTipoEstatus(ref TipoEstatusDTO tipo);
        /// <summary>
        /// Para guardar un nuevo tipo de estatus o su actualización.
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        bool GuardarTipoEstatus(ref TipoEstatusDTO tipo);
        #endregion

        #region Estatus
        /// <summary>
        /// Para obtener uno o más estatuses.
        /// </summary>
        /// <param name="estatus"></param>
        /// <returns></returns>
        EstatusesDTO ObtenerEstatuses(EstatusDTO estatus);
        /// <summary>
        /// Para Borrar un estatus.
        /// </summary>
        /// <param name="estatus"></param>
        /// <returns></returns>
        bool BorrarEstatus(ref EstatusDTO estatus);
        /// <summary>
        /// Para guardar un nuevo estatus o su actualización.
        /// </summary>
        /// <param name="estatus"></param>
        /// <returns></returns>
        bool GuardarEstatus(ref EstatusDTO estatus);
        #endregion

        #region TipoCatalogo
        /// <summary>
        /// Para obtener uno o más tipos de catálogos.
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        TiposCatalogosDTO ObtenerTiposCatalogos(TipoCatalogoDTO tipoCatalogo);
        /// <summary>
        /// Para Borrar un tipo de catálogo.
        /// </summary>
        /// <param name="tipoCatalogo"></param>
        /// <returns></returns>
        bool BorrarTipoCatalogo(ref TipoCatalogoDTO tipoCatalogo);
        /// <summary>
        /// Para guardar un nuevo tipo de catálogo o su actualización.
        /// </summary>
        /// <param name="tipoCatalogo"></param>
        /// <returns></returns>
        bool GuardarTipoCatalogo(ref TipoCatalogoDTO tipoCatalogo);
        #endregion

        #region Catalogo
        /// <summary>
        /// Para obtener uno o más catálogos.
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        CatalogosDTO ObtenerCatalogos(CatalogoDTO catalogo);
        /// <summary>
        /// Para Borrar un catalogo.
        /// </summary>
        /// <param name="catalogo"></param>
        /// <returns></returns>
        bool BorrarCatalogo(ref CatalogoDTO catalogo);
        /// <summary>
        /// Para guardar un nuevo catálogo o su actualización.
        /// </summary>
        /// <param name="catalogo"></param>
        /// <returns></returns>
        bool GuardarCatalogo(ref CatalogoDTO catalogo);
        #endregion

        #region Producto
        /// <summary>
        /// Para obtener uno o más productos.
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        ProductosDTO ObtenerProductos(ProductoDTO producto);
        /// <summary>
        /// Para Borrar un producto.
        /// </summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        bool BorrarProducto(ref ProductoDTO producto);
        /// <summary>
        /// Para guardar un nuevo producto o su actualización.
        /// </summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        bool GuardarProducto(ref ProductoDTO producto);
        #endregion

    }
}
