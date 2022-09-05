﻿using SernaSistemas.Jadet.Comun.Modelos;
using SernaSistemas.Jadet.Data.DTO;
using SernaSistemas.Jadet.Data.Repository;
using System.Collections.Generic;
using System.Linq;

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
            CatalogoDto catalogoDTO = CatalogoDto.ToDTO(catalogo);
            return dbConfiguracion.BorrarCatalogo(ref catalogoDTO);
        }

        public bool BorrarEstatus(Estatus estatus)
        {
            EstatusDto estatusDTO = EstatusDto.ToDTO(estatus);
            return dbConfiguracion.BorrarEstatus(ref estatusDTO);
        }

        public bool BorrarProducto(Producto producto)
        {
            ProductoDto productoDTO = ProductoDto.ToDTO(producto);
            return dbConfiguracion.BorrarProducto(ref productoDTO);
        }

        public bool BorrarTipoCatalogo(TipoCatalogo tipoCatalogo)
        {
            TipoCatalogoDto tipoCatalogoDTO = TipoCatalogoDto.ToDTO(tipoCatalogo);
            return dbConfiguracion.BorrarTipoCatalogo(ref tipoCatalogoDTO);
        }

        public bool BorrarTipoEstatus(TipoEstatus tipoEstatus)
        {
            TipoEstatusDto tipoEstatusDTO = TipoEstatusDto.ToDTO(tipoEstatus);
            return dbConfiguracion.BorrarTipoEstatus(ref tipoEstatusDTO);
        }

        public bool GuardarCatalogo(ref Catalogo catalogo)
        {
            CatalogoDto catalogoDTO = CatalogoDto.ToDTO(catalogo);
            var resultado = dbConfiguracion.GuardarCatalogo(ref catalogoDTO);
            catalogo = Catalogo.ToModel(catalogoDTO);
            return resultado;
        }

        public bool GuardarEstatus(ref Estatus estatus)
        {
            EstatusDto estatusDTO = EstatusDto.ToDTO(estatus);
            var resultado = dbConfiguracion.GuardarEstatus(ref estatusDTO);
            estatus = Estatus.ToModel(estatusDTO);
            return resultado;
        }

        public bool GuardarProducto(ref Producto producto)
        {
            ProductoDto productoDTO = ProductoDto.ToDTO(producto);
            var resultado = dbConfiguracion.GuardarProducto(ref productoDTO);
            producto = Producto.ToModel(productoDTO);
            return resultado;
        }

        public bool GuardarTipoCatalogo(ref TipoCatalogo tipoCatalogo)
        {
            TipoCatalogoDto tipoCatalogoDTO = TipoCatalogoDto.ToDTO(tipoCatalogo);
            var resultado = dbConfiguracion.GuardarTipoCatalogo(ref tipoCatalogoDTO);
            tipoCatalogo = TipoCatalogo.ToModel(tipoCatalogoDTO);
            return resultado;
        }

        public bool GuardarTipoEstatus(ref TipoEstatus tipoEstatus)
        {
            TipoEstatusDto tipoEstatusDTO = TipoEstatusDto.ToDTO(tipoEstatus);
            var resultado = dbConfiguracion.GuardarTipoEstatus(ref tipoEstatusDTO);
            tipoEstatus = TipoEstatus.ToModel(tipoEstatusDTO);
            return resultado;
        }

        public IEnumerable<Catalogo> ObtenerCatalogos(bool esId, Catalogo catalogo)
        {
            CatalogoDto catalogoDTO = new() { Nombre = catalogo.Nombre };
            if (esId)
            {
                catalogoDTO.Id = catalogo.Id;
            }
            else
            {
                catalogoDTO.IdTipoCatalogo = catalogo.Id;
            }
            return dbConfiguracion.ObtenerCatalogos(catalogoDTO)
                .Select(c => Catalogo.ToModel(c));
        }

        public IEnumerable<Estatus> ObtenerEstatuses(bool esId, Estatus estatus)
        {
            EstatusDto estatusDTO = new() { Nombre = estatus.Nombre };
            if (esId)
            {
                estatusDTO.Id = estatus.Id;
            }
            else
            {
                estatusDTO.IdTipoEstatus = estatus.Id;
            }
            return dbConfiguracion.ObtenerEstatuses(estatusDTO)
                .Select(e => Estatus.ToModel(e));
        }

        public IEnumerable<Producto> ObtenerProductos(byte idTipo, bool esSku, Producto producto)
        {
            ProductoDto productoDTO = new();
            switch (idTipo)
            {
                case 0:
                    productoDTO.Id = producto.Id;
                    break;
                case 1:
                    productoDTO.IdCatalogo = producto.Id;
                    break;
                case 2:
                    productoDTO.IdEstatus = producto.Id;
                    break;
                case 3:
                    productoDTO.IdTipoNota = producto.Id;
                    break;
                default:
                    if (esSku)
                    {
                        productoDTO.Sku = producto.Sku;
                    }
                    else
                    {
                        producto.Nombre = producto.Sku;
                    }
                    break;
            }
            return dbConfiguracion.ObtenerProductos(productoDTO)
                .Select(p => Producto.ToModel(p));
        }

        public IEnumerable<TipoCatalogo> ObtenerTiposCatalogo(TipoCatalogo tipoCatalogo)
        {
            return dbConfiguracion.ObtenerTiposCatalogos(TipoCatalogoDto.ToDTO(tipoCatalogo))
                .Select(t => TipoCatalogo.ToModel(t));
        }

        public IEnumerable<TipoEstatus> ObtenerTiposEstatus(TipoEstatus tipoEstatus)
        {
            return dbConfiguracion.ObtenerTiposEstatus(TipoEstatusDto.ToDTO(tipoEstatus))
                .Select(t => TipoEstatus.ToModel(t));
        }
    }
}
