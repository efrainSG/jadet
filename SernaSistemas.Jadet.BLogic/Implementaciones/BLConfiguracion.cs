using SernaSistemas.Jadet.Comun.Modelos;
using SernaSistemas.Jadet.DAccess.DTO;
using SernaSistemas.Jadet.DAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SernaSistemas.Jadet.BLogic
{
    public class BLConfiguracion : IBLConfiguracion
    {
        private readonly IDbConfiguracionContext dbConfiguracion;

        public BLConfiguracion(IDbConfiguracionContext dbConfiguracion)
        {
            this.dbConfiguracion = dbConfiguracion;
        }

        public bool BorrarCatalogo(Catalogo catalogo)
        {
            CatalogoDTO catalogoDTO = CatalogoDTO.ToDTO(catalogo);
            return dbConfiguracion.BorrarCatalogo(ref catalogoDTO);
        }

        public bool BorrarEstatus(Estatus estatus)
        {
            EstatusDTO estatusDTO = EstatusDTO.ToDTO(estatus);
            return dbConfiguracion.BorrarEstatus(ref estatusDTO);
        }

        public bool BorrarProducto(Producto producto)
        {
            ProductoDTO productoDTO = ProductoDTO.ToDTO(producto);
            return dbConfiguracion.BorrarProducto(ref productoDTO);
        }

        public bool BorrarTipoCatalogo(TipoCatalogo tipoCatalogo)
        {
            TipoCatalogoDTO tipoCatalogoDTO = TipoCatalogoDTO.ToDTO(tipoCatalogo);
            return dbConfiguracion.BorrarTipoCatalogo(ref tipoCatalogoDTO);
        }

        public bool BorrarTipoEstatus(TipoEstatus tipoEstatus)
        {
            TipoEstatusDTO tipoEstatusDTO = TipoEstatusDTO.ToDTO(tipoEstatus);
            return dbConfiguracion.BorrarTipoEstatus(ref tipoEstatusDTO);
        }

        public bool GuardarCatalogo(ref Catalogo catalogo)
        {
            CatalogoDTO catalogoDTO = CatalogoDTO.ToDTO(catalogo);
            var resultado = dbConfiguracion.GuardarCatalogo(ref catalogoDTO);
            catalogo = Catalogo.ToModel(catalogoDTO);
            return resultado;
        }

        public bool GuardarEstatus(ref Estatus estatus)
        {
            EstatusDTO estatusDTO = EstatusDTO.ToDTO(estatus);
            var resultado = dbConfiguracion.GuardarEstatus(ref estatusDTO);
            estatus = Estatus.ToModel(estatusDTO);
            return resultado;
        }

        public bool GuardarProducto(ref Producto producto)
        {
            ProductoDTO productoDTO = ProductoDTO.ToDTO(producto);
            var resultado = dbConfiguracion.GuardarProducto(ref productoDTO);
            producto = Producto.ToModel(productoDTO);
            return resultado;
        }

        public bool GuardarTipoCatalogo(ref TipoCatalogo tipoCatalogo)
        {
            TipoCatalogoDTO tipoCatalogoDTO = TipoCatalogoDTO.ToDTO(tipoCatalogo);
            var resultado = dbConfiguracion.GuardarTipoCatalogo(ref tipoCatalogoDTO);
            tipoCatalogo = TipoCatalogo.ToModel(tipoCatalogoDTO);
            return resultado;
        }

        public bool GuardarTipoEstatus(ref TipoEstatus tipoEstatus)
        {
            TipoEstatusDTO tipoEstatusDTO = TipoEstatusDTO.ToDTO(tipoEstatus);
            var resultado = dbConfiguracion.GuardarTipoEstatus(ref tipoEstatusDTO);
            tipoEstatus = TipoEstatus.ToModel(tipoEstatusDTO);
            return resultado;
        }

        public IEnumerable<Catalogo> ObtenerCatalogos(Catalogo catalogo)
        {
            return dbConfiguracion.ObtenerCatalogos(CatalogoDTO.ToDTO(catalogo))
                .Select(c => Catalogo.ToModel(c));
        }

        public IEnumerable<Estatus> ObtenerEstatuses(Estatus estatus)
        {
            return dbConfiguracion.ObtenerEstatuses(EstatusDTO.ToDTO(estatus))
                .Select(e => Estatus.ToModel(e));
        }

        public IEnumerable<Producto> ObtenerProductos(Producto producto)
        {
            return dbConfiguracion.ObtenerProductos(ProductoDTO.ToDTO(producto))
                .Select(p => Producto.ToModel(p));
        }

        public IEnumerable<TipoCatalogo> ObtenerTiposCatalogo(TipoCatalogo tipoCatalogo)
        {
            return dbConfiguracion.ObtenerTiposCatalogos(TipoCatalogoDTO.ToDTO(tipoCatalogo))
                .Select(t => TipoCatalogo.ToModel(t));
        }

        public IEnumerable<TipoEstatus> ObtenerTiposEstatus(TipoEstatus tipoEstatus)
        {
            return dbConfiguracion.ObtenerTiposEstatus(TipoEstatusDTO.ToDTO(tipoEstatus))
                .Select(t => TipoEstatus.ToModel(t));
        }
    }
}
