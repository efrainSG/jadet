using SernaSistemas.Jadet.Comun.Modelos;
using SernaSistemas.Jadet.Data.DTO;
using SernaSistemas.Jadet.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SernaSistemas.Jadet.BLogic
{
    public class BLAdministracion : IBLAdministracion
    {
        private readonly IDbAdministracionContext dBAdministracion;

        public BLAdministracion(IDbAdministracionContext dBAdministracion)
        {
            this.dBAdministracion = dBAdministracion;
        }

        public bool BorrarCatalogo(Catalogo catalogo)
        {
            CatalogoDTO _catalogo = CatalogoDTO.ToDTO(catalogo);
            return dBAdministracion.BorrarCatalogo(ref _catalogo);
        }

        public bool BorrarDetalle(Detalle detalle)
        {
            DetalleDTO _detalle = DetalleDTO.ToDTO(detalle);
            return dBAdministracion.BorrarDetalle(ref _detalle);
        }

        public bool BorrarEstatus(Estatus estatus)
        {
            EstatusDTO estatusDTO = EstatusDTO.ToDTO(estatus);
            return dBAdministracion.BorrarEstatus(ref estatusDTO);
        }

        public bool BorrarNota(Nota nota)
        {
            NotaDTO notaDTO = NotaDTO.ToDTO(nota);
            return dBAdministracion.BorrarNota(ref notaDTO);
        }

        public bool BorrarNotaComentario(NotaComentario notaComentario)
        {
            NotaComentarioDTO notaComentarioDTO = NotaComentarioDTO.ToDTO(notaComentario);
            return dBAdministracion.BorrarNotaComentario(ref notaComentarioDTO);
        }

        public bool BorrarProducto(Producto producto)
        {
            ProductoDTO productoDTO = ProductoDTO.ToDTO(producto);
            return dBAdministracion.BorrarProducto(ref productoDTO);
        }

        public bool BorrarTipoCatalogo(TipoCatalogo tipoCatalogo)
        {
            TipoCatalogoDTO tipoCatalogoDTO = TipoCatalogoDTO.ToDTO(tipoCatalogo);
            return dBAdministracion.BorrarTipoCatalogo(ref tipoCatalogoDTO);
        }

        public bool BorrarTipoEstatus(TipoEstatus tipoEstatus)
        {
            TipoEstatusDTO tipoEstatusDTO = TipoEstatusDTO.ToDTO(tipoEstatus);
            return dBAdministracion.BorrarTipoEstatus(ref tipoEstatusDTO);
        }

        public bool GuardarCatalogo(ref Catalogo catalogo)
        {
            CatalogoDTO catalogoDTO = CatalogoDTO.ToDTO(catalogo);
            bool resultado = dBAdministracion.GuardarCatalogo(ref catalogoDTO);
            catalogo = Catalogo.ToModel(catalogoDTO);
            return resultado;
        }

        public bool GuardarDetalle(ref Detalle detalle)
        {
            DetalleDTO detalleDTO = DetalleDTO.ToDTO(detalle);
            bool resultado = dBAdministracion.GuardarDetalle(ref detalleDTO);
            detalle = Detalle.ToModel(detalleDTO);
            return resultado;
        }

        public bool GuardarEstatus(ref Estatus estatus)
        {
            EstatusDTO estatusDTO = EstatusDTO.ToDTO(estatus);
            bool resultado = dBAdministracion.GuardarEstatus(ref estatusDTO);
            estatus = Estatus.ToModel(estatusDTO);
            return resultado;
        }

        public bool GuardarNota(ref Nota nota)
        {
            NotaDTO notaDTO = NotaDTO.ToDTO(nota);
            bool resultado = dBAdministracion.GuardarNota(ref notaDTO);
            nota = Nota.ToModel(notaDTO);
            return resultado;
        }

        public bool GuardarProducto(ref Producto producto)
        {
            ProductoDTO productoDTO = ProductoDTO.ToDTO(producto);
            bool resultado = dBAdministracion.GuardarProducto(ref productoDTO);
            producto = Producto.ToModel(productoDTO);
            return resultado;
        }

        public bool GuardarTipoCatalogo(ref TipoCatalogo tipoCatalogo)
        {
            TipoCatalogoDTO tipoCatalogoDTO = TipoCatalogoDTO.ToDTO(tipoCatalogo);
            bool resultado = dBAdministracion.GuardarTipoCatalogo(ref tipoCatalogoDTO);
            tipoCatalogo = TipoCatalogo.ToModel(tipoCatalogoDTO);
            return resultado;
        }

        public bool GuardarTipoEstatus(ref TipoEstatus tipoEstatus)
        {
            TipoEstatusDTO tipoEstatusDTO = TipoEstatusDTO.ToDTO(tipoEstatus);
            bool resultado = dBAdministracion.GuardarTipoEstatus(ref tipoEstatusDTO);
            tipoEstatus = TipoEstatus.ToModel(tipoEstatusDTO);
            return resultado;
        }

        #region Obtenciones
        public IEnumerable<Catalogo> ObtenerCatalogos(bool esId, Catalogo catalogo)
        {
            CatalogoDTO catalogoDTO = new CatalogoDTO { Nombre = catalogo.Nombre };
            if (esId)
            {
                catalogoDTO.Id = catalogo.Id;
            }
            else
            {
                catalogoDTO.IdTipoCatalogo = catalogo.Id;
            }
            return dBAdministracion.ObtenerCatalogos(catalogoDTO)
            .Select(c => Catalogo.ToModel(c));

        }

        public IEnumerable<NotaComentario> ObtenerComentarios(bool esId, NotaComentario notaComentario)
        {
            NotaComentarioDTO notaComentarioDTO = new NotaComentarioDTO();
            if (esId)
            {
                notaComentarioDTO.Id = notaComentario.Id;
            }
            else
            {
                notaComentarioDTO.IdNota = notaComentario.Id;
            }
            return dBAdministracion.ObtenerNotasComentarios(notaComentarioDTO)
                .Select(n => NotaComentario.ToModel(n));
        }

        public IEnumerable<Detalle> ObtenerDetalles(byte idTipo, Detalle detalle)
        {
            DetalleDTO detalleDTO = new DetalleDTO();
            switch (idTipo)
            {
                case 0:
                    detalleDTO.Id = detalle.Id;
                    break;
                case 1:
                    detalleDTO.IdNota = detalle.Id;
                    break;
                case 2:
                    detalleDTO.IdProducto = detalle.Id;
                    break;
                default:
                    break;
            }
            return dBAdministracion.ObtenerDetalles(detalleDTO)
                .Select(d => Detalle.ToModel(d));
        }

        public IEnumerable<Estatus> ObtenerEstatuses(bool esId, Estatus estatus)
        {
            EstatusDTO estatusDTO = new EstatusDTO { Nombre = estatus.Nombre };
            if (esId)
            {
                estatusDTO.Id = estatus.Id;
            }
            else
            {
                estatusDTO.IdTipoEstatus = estatus.Id;
            }
            return dBAdministracion.ObtenerEstatuses(EstatusDTO.ToDTO(estatus))
                .Select(e => Estatus.ToModel(e));
        }

        public IEnumerable<Nota> ObtenerNotas(byte tipoId, Nota nota)
        {
            NotaDTO notaDTO = new NotaDTO { IdCliente = nota.IdCliente };
            switch (tipoId)
            {
                case 0:
                    notaDTO.Folio = nota.Folio;
                    break;
                case 1:
                    notaDTO.IdEstatus = nota.Folio;
                    break;
                case 2:
                    notaDTO.IdPaqueteria = nota.Folio;
                    break;
                case 3:
                    notaDTO.IdTipo = nota.Folio;
                    break;
                default:
                    break;
            }
            return dBAdministracion.ObtenerNotas(NotaDTO.ToDTO(nota))
                .Select(n => Nota.ToModel(n));
        }

        public IEnumerable<NotaTicket> ObtenerNotasTickets(bool esId, NotaTicket notaTicket)
        {
            NotaTicketDTO notaTicketDTO = new NotaTicketDTO();
            if (esId)
            {
                notaTicketDTO.Id = notaTicket.Id;
            }
            else
            {
                notaTicketDTO.IdNota = notaTicket.Id;
            }
            return dBAdministracion.ObtenerNotasTickets(notaTicketDTO)
                .Select(n => NotaTicket.ToModel(n));
        }

        public IEnumerable<Producto> ObtenerProductos(byte idTipo, bool esSku, Producto producto)
        {
            ProductoDTO productoDTO = new ProductoDTO();
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
            return dBAdministracion.ObtenerProductos(productoDTO)
                .Select(p => Producto.ToModel(p));
        }

        public IEnumerable<TipoCatalogo> ObtenerTiposCatalogo(TipoCatalogo tipoCatalogo)
        {
            return dBAdministracion.ObtenerTiposCatalogos(TipoCatalogoDTO.ToDTO(tipoCatalogo))
                .Select(t => TipoCatalogo.ToModel(t));
        }

        public IEnumerable<TipoEstatus> ObtenerTiposEstatus(TipoEstatus tipoEstatus)
        {
            return dBAdministracion.ObtenerTiposEstatus(TipoEstatusDTO.ToDTO(tipoEstatus))
            .Select(t => TipoEstatus.ToModel(t));
        }
        #endregion
    }
}
