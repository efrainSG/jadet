using SernaSistemas.Jadet.DAccess.DTO;

namespace SernaSistemas.Jadet.DAccess.Repository
{
    public class DbConfiguracionContext : IDbConfiguracionContext
    {
        private readonly BDJadetEntities contexto;

        public DbConfiguracionContext(BDJadetEntities entities)
        {
            contexto = entities;
        }
        public DbConfiguracionContext(System.Data.Entity.DbContext dbContext)
        {
            contexto = dbContext as BDJadetEntities;
        }

        public bool BorrarCatalogo(ref CatalogoDTO catalogo)
        {
            throw new System.NotImplementedException();
        }

        public bool BorrarEstatus(ref EstatusDTO estatus)
        {
            throw new System.NotImplementedException();
        }

        public bool BorrarProducto(ref ProductoDTO producto)
        {
            throw new System.NotImplementedException();
        }

        public bool BorrarTipoCatalogo(ref TipoCatalogoDTO tipoCatalogo)
        {
            throw new System.NotImplementedException();
        }

        public bool BorrarTipoEstatus(ref TipoEstatusDTO tipo)
        {
            throw new System.NotImplementedException();
        }

        public bool GuardarCatalogo(ref CatalogoDTO catalogo)
        {
            throw new System.NotImplementedException();
        }

        public bool GuardarEstatus(ref EstatusDTO estatus)
        {
            throw new System.NotImplementedException();
        }

        public bool GuardarProducto(ref ProductoDTO producto)
        {
            throw new System.NotImplementedException();
        }

        public bool GuardarTipoCatalogo(ref EstatusDTO estatus)
        {
            throw new System.NotImplementedException();
        }

        public bool GuardarTipoEstatus(ref TipoEstatusDTO tipo)
        {
            throw new System.NotImplementedException();
        }

        public CatalogosDTO ObtenerCatalogos(CatalogoDTO catalogo)
        {
            throw new System.NotImplementedException();
        }

        public EstatusDTO ObtenerEstatuses(EstatusDTO estatus)
        {
            throw new System.NotImplementedException();
        }

        public ProductosDTO ObtenerProductos(ProductoDTO producto)
        {
            throw new System.NotImplementedException();
        }

        public TiposCatalogosDTO ObtenerTiposCatalogos(TipoCatalogoDTO tipoCatalogo)
        {
            throw new System.NotImplementedException();
        }

        public TiposEstatusDTO ObtenerTiposEstatus(TipoEstatusDTO tipo)
        {
            throw new System.NotImplementedException();
        }
    }
}
