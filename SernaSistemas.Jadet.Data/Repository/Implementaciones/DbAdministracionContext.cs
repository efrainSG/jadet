using SernaSistemas.Jadet.Data.Models;
using SernaSistemas.Jadet.Data.DTO;
using System;
using System.Linq;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace SernaSistemas.Jadet.Data.Repository
{
    public class DbAdministracionContext : IDbAdministracionContext
    {
        private readonly BDJadetContext contexto;

        public DbAdministracionContext(BDJadetContext entities)
        {
            contexto = entities;
        }
        public DbAdministracionContext(DbContext dbContext)
        {
            contexto = dbContext as BDJadetContext;
        }

        public bool BorrarCatalogo(ref CatalogoDto catalogo)
        {
            int id = catalogo.Id;
            Catalogo _catalogo = contexto.Catalogos.FirstOrDefault(c => c.Id == id);
            if (_catalogo != null)
            {
                TipoCatalogo tipo = _catalogo.IdTipoCatalogoNavigation;

                tipo.Catalogos.Remove(_catalogo);
                contexto.Catalogos.Remove(_catalogo);

                return contexto.SaveChanges() != 0;
            }
            return false;
        }

        public bool BorrarDetalle(ref DetalleDto detalle)
        {
            int id = detalle.Id;
            Detalle _detalle = contexto.Detalles.FirstOrDefault(d => d.Id == id);
            if (_detalle != null)
            {
                Nota nota = _detalle.IdNotaNavigation;
                Producto producto = _detalle.IdProductoNavigation;

                producto.Detalles.Remove(_detalle);
                nota.Detalles.Remove(_detalle);
                contexto.Detalles.Remove(_detalle);

                return contexto.SaveChanges() != 0;
            }
            return false;
        }

        public bool BorrarEstatus(ref EstatusDto estatus)
        {
            int id = estatus.Id;
            Estatus _estatus = contexto.Estatuses.FirstOrDefault(e => e.Id == id);
            if (_estatus != null)
            {
                TipoEstatus tipo = _estatus.IdTipoEstatusNavigation;

                tipo.Estatuses.Remove(_estatus);
                contexto.Estatuses.Remove(_estatus);

                return contexto.SaveChanges() != 0;
            }
            return false;
        }

        public bool BorrarNota(ref NotaDto nota)
        {
            int id = nota.Folio;
            Nota _nota = contexto.Notas.FirstOrDefault(n => n.Folio == id);
            if (_nota != null)
            {
                var estatus = _nota.IdEstatusNavigation;
                var tipo = _nota.IdTipoNavigation;
                var paqueteria = _nota.IdPaqueteriaNavigation;

                estatus.NotaIdEstatusNavigations.Remove(_nota);
                tipo.NotaIdTipoNavigations.Remove(_nota);
                paqueteria.NotaIdPaqueteriaNavigations.Remove(_nota);

                contexto.Notas.Remove(_nota);
                return contexto.SaveChanges() != 0;
            }
            return false;
        }

        public bool BorrarNotaComentario(ref NotaComentarioDto notaComentario)
        {
            int id = notaComentario.Id;
            NotasComentario comentario = contexto.NotasComentarios.FirstOrDefault(c => c.Id == id);
            if (comentario != null)
            {
                Nota nota = comentario.IdNotaNavigation;
                nota.NotasComentarios.Remove(comentario);
                contexto.NotasComentarios.Remove(comentario);
                return contexto.SaveChanges() != 0;
            }
            return false;
        }

        public bool BorrarProducto(ref ProductoDto producto)
        {
            int id = producto.Id;
            Producto _producto = contexto.Productos.FirstOrDefault(p => p.Id == id);
            if (_producto != null)
            {
                Catalogo catalogo = _producto.IdCatalogoNavigation;
                Estatus estatus = _producto.IdEstatusNavigation;
                Catalogo tipoNota = _producto.IdTipoNotaNavigation;

                catalogo.ProductoIdCatalogoNavigations.Remove(_producto);
                estatus.Productos.Remove(_producto);
                tipoNota.ProductoIdCatalogoNavigations.Remove(_producto);
                contexto.Productos.Remove(_producto);

                return contexto.SaveChanges() != 0;
            }
            return false;
        }

        public bool BorrarTipoCatalogo(ref TipoCatalogoDto tipoCatalogo)
        {
            int id = tipoCatalogo.Id;
            TipoCatalogo _tipoCatalogo = contexto.TipoCatalogos.FirstOrDefault(t => t.Id == id);
            if (_tipoCatalogo != null)
            {
                contexto.TipoCatalogos.Remove(_tipoCatalogo);

                return contexto.SaveChanges() != 0;
            }
            return false;
        }

        public bool BorrarTipoEstatus(ref TipoEstatusDto tipo)
        {
            int id = tipo.Id;
            TipoEstatus _tipo = contexto.TipoEstatuses.FirstOrDefault(t => t.Id == id);
            if (_tipo != null)
            {
                contexto.TipoEstatuses.Remove(_tipo);

                return contexto.SaveChanges() != 0;
            }
            return false;
        }

        public bool GuardarCatalogo(ref CatalogoDto catalogo)
        {
            int id = catalogo.Id;
            int idTipo = catalogo.IdTipoCatalogo;
            Catalogo _catalogo = contexto.Catalogos.FirstOrDefault(c => c.Id == id);
            TipoCatalogo _tipo = contexto.TipoCatalogos.FirstOrDefault(t => t.Id == idTipo);
            if (_catalogo == null)
            {
                _catalogo = new Catalogo();
                contexto.Catalogos.Add(_catalogo);
            }
            _tipo.Catalogos.Add(_catalogo);

            _catalogo.Nombre = catalogo.Nombre;

            int resultado = contexto.SaveChanges();

            catalogo = CatalogoDto.ToDTO(_catalogo);

            return resultado != 0;
        }

        public bool GuardarDetalle(ref DetalleDto detalle)
        {
            int id = detalle.Id;
            int idNota = detalle.IdNota;
            int idProducto = detalle.IdProducto;

            Detalle _detalle = contexto.Detalles.FirstOrDefault(d => d.Id == id);
            Nota _nota = contexto.Notas.FirstOrDefault(n => n.Folio == idNota);
            Producto _producto = contexto.Productos.FirstOrDefault(p => p.Id == idProducto);

            if (_detalle == null)
            {
                _detalle = new Detalle();
                contexto.Detalles.Add(_detalle);
            }
            _detalle.PrecioMxn = detalle.PrecioMXN;
            _detalle.PrecioUsd = detalle.PrecioUSD;
            _detalle.Cantidad = detalle.Cantidad;

            _nota.Detalles.Add(_detalle);
            _producto.Detalles.Add(_detalle);

            int resultado = contexto.SaveChanges();

            detalle = DetalleDto.ToDTO(_detalle);

            return resultado != 0;
        }

        public bool GuardarEstatus(ref EstatusDto estatus)
        {
            int id = estatus.Id;
            int idTipo = estatus.IdTipoEstatus;
            Estatus _estatus = contexto.Estatuses.FirstOrDefault(e => e.Id == id);
            TipoEstatus _tipo = contexto.TipoEstatuses.FirstOrDefault(t => t.Id == idTipo);
            if (_estatus == null)
            {
                _estatus = new Estatus();
                contexto.Estatuses.Add(_estatus);
            }

            _tipo.Estatuses.Add(_estatus);
            _estatus.Nombre = estatus.Nombre;

            int resultado = contexto.SaveChanges();

            estatus = EstatusDto.ToDTO(_estatus);

            return resultado != 0;
        }

        public bool GuardarNota(ref NotaDto nota)
        {
            int folio = nota.Folio;
            int idTipo = nota.IdTipo;
            int idPaqueteria = nota.IdPaqueteria;
            int idEstatus = nota.IdEstatus;

            Nota _nota = contexto.Notas.FirstOrDefault(n => n.Folio == folio);
            Catalogo catPaqueteria = contexto.Catalogos.FirstOrDefault(c => c.Id == idPaqueteria);
            Catalogo catTipo = contexto.Catalogos.FirstOrDefault(c => c.Id == idTipo);
            Catalogo catEstatus = contexto.Catalogos.FirstOrDefault(e => e.Id == idEstatus);

            if (_nota == null)
            {
                _nota = new Nota();
                contexto.Notas.Add(_nota);
            }

            catPaqueteria.NotaIdPaqueteriaNavigations.Add(_nota);
            catTipo.NotaIdTipoNavigations.Add(_nota);
            catEstatus.NotaIdEstatusNavigations.Add(_nota);

            _nota.Fecha = nota.Fecha;
            _nota.FechaEnvio = nota.FechaEnvio;
            _nota.Guia = nota.Guia;
            _nota.MontoMxn = nota.MontoMXN;
            _nota.MontoUsd = nota.MontoUSD;
            _nota.SaldoMxn = nota.SaldoMXN;
            _nota.SaldoUsd = nota.SaldoUSD;

            int resultado = contexto.SaveChanges();

            nota = NotaDto.ToDTO(_nota);

            return resultado != 0;
        }

        public bool GuardarNotaComentario(ref NotaComentarioDto notaComentario)
        {
            int id = notaComentario.Id;
            int idNota = notaComentario.IdNota;
            int? idAnterior = notaComentario.IdComentarioAnterior;

            NotasComentario _notaComentario = contexto.NotasComentarios.FirstOrDefault(n => n.Id == id);
            Nota _nota = contexto.Notas.FirstOrDefault(n => n.Folio == idNota);
            NotasComentario _anterior;

            if (_notaComentario == null)
            {
                _notaComentario = new NotasComentario();
                contexto.NotasComentarios.Add(_notaComentario);
            }

            _nota.NotasComentarios.Add(_notaComentario);
            _notaComentario.Comentario = notaComentario.Comentario;
            _notaComentario.Fecha = notaComentario.Fecha;
            _notaComentario.IdComentarioAnterior = notaComentario.IdComentarioAnterior;

            int resultado = contexto.SaveChanges();

            notaComentario = NotaComentarioDto.ToDTO(_notaComentario);

            return resultado != 0;

        }

        public bool GuardarProducto(ref ProductoDto producto)
        {
            int id = producto.Id;
            int idCatalogo = producto.IdCatalogo;
            int idEstatus = producto.IdEstatus;
            int idTipoNota = producto.IdTipoNota;
            Producto _producto = contexto.Productos.FirstOrDefault(p => p.Id == id);
            if (_producto == null)
            {
                _producto = new Producto();
                contexto.Productos.Add(_producto);
            }

            Catalogo _catalogo = contexto.Catalogos.FirstOrDefault(c => c.Id == idCatalogo);
            Estatus _estatus = contexto.Estatuses.FirstOrDefault(e => e.Id == idEstatus);
            Catalogo _tipoNota = contexto.Catalogos.FirstOrDefault(t => t.Id == idTipoNota);

            _catalogo.ProductoIdCatalogoNavigations.Add(_producto);
            _estatus.Productos.Add(_producto);
            _tipoNota.ProductoIdTipoNotaNavigations.Add(_producto);

            int resultado = contexto.SaveChanges();

            producto = ProductoDto.ToDTO(_producto);
            return resultado != 0;
        }

        public bool GuardarTipoCatalogo(ref TipoCatalogoDto tipoCatalogo)
        {
            int id = tipoCatalogo.Id;
            TipoCatalogo _tipoCatalogo = contexto.TipoCatalogos.FirstOrDefault(e => e.Id == id);
            if (_tipoCatalogo == null)
            {
                _tipoCatalogo = new TipoCatalogo();
                contexto.TipoCatalogos.Add(_tipoCatalogo);
            }

            _tipoCatalogo.Nombre = tipoCatalogo.Nombre;

            int resultado = contexto.SaveChanges();
            tipoCatalogo = TipoCatalogoDto.ToDTO(_tipoCatalogo);
            return resultado != 0;
        }

        public bool GuardarTipoEstatus(ref TipoEstatusDto tipo)
        {
            int id = tipo.Id;

            TipoEstatus _tipo = contexto.TipoEstatuses.FirstOrDefault(t => t.Id == id);
            if (_tipo == null)
            {
                _tipo = new TipoEstatus();
                contexto.TipoEstatuses.Add(_tipo);
            }
            _tipo.Nombre = tipo.Nombre;
            int resultado = contexto.SaveChanges();
            tipo = TipoEstatusDto.ToDTO(_tipo);
            return resultado != 0;
        }

        public CatalogosDto ObtenerCatalogos(CatalogoDto catalogo)
        {
            CatalogosDto resultado = new CatalogosDto();
            if (catalogo.Id != 0)
            {
                resultado.AddRange(CatalogosDto.ToDTO(contexto.Catalogos.Where(c => c.Id == catalogo.Id).ToList()));
            }
            else if (catalogo.IdTipoCatalogo != 0)
            {
                resultado.AddRange(CatalogosDto.ToDTO(
                    contexto.Catalogos.Where(c => c.IdTipoCatalogo == catalogo.IdTipoCatalogo).ToList()
                    ));
            }
            else if (!string.IsNullOrEmpty(catalogo.Nombre))
            {
                resultado.AddRange(CatalogosDto.ToDTO(
                    contexto.Catalogos.Where(c => c.Nombre.ToUpper().Contains(catalogo.Nombre.ToUpper())).ToList()
                    ));
            }
            else
            {
                resultado.AddRange(CatalogosDto.ToDTO(contexto.Catalogos.ToList()));
            }
            return resultado;
        }

        public DetallesDto ObtenerDetalles(DetalleDto detalle)
        {
            DetallesDto resultado = new DetallesDto();
            if (detalle.Id != 0)
            {
                resultado.AddRange(DetallesDto.ToDTO(contexto.Detalles.Where(d => d.Id == detalle.Id).ToList()));
            }
            else if (detalle.IdNota != 0)
            {
                resultado.AddRange(DetallesDto.ToDTO(contexto.Detalles.Where(d => d.IdNota == detalle.IdNota).ToList()));
            }
            else if (detalle.IdProducto != 0)
            {
                resultado.AddRange(DetallesDto.ToDTO(contexto.Detalles.Where(d => d.IdProducto == detalle.IdProducto).ToList()));
            }
            else
            {
                resultado.AddRange(DetallesDto.ToDTO(contexto.Detalles.ToList()));
            }
            return resultado;
        }

        public EstatusesDto ObtenerEstatuses(EstatusDto estatus)
        {
            EstatusesDto resultado = new EstatusesDto();
            if (estatus.Id != 0)
            {
                resultado.AddRange(EstatusesDto.ToDTO(contexto.Estatuses.Where(e => e.Id == estatus.Id).ToList()));
            }
            else if (estatus.IdTipoEstatus != 0)
            {
                resultado.AddRange(EstatusesDto.ToDTO(contexto.Estatuses.Where(e => e.IdTipoEstatus == estatus.IdTipoEstatus).ToList()));
            }
            else if (!string.IsNullOrEmpty(estatus.Nombre))
            {
                resultado.AddRange(EstatusesDto.ToDTO(
                    contexto.Estatuses.Where(e => e.Nombre.ToUpper().Contains(estatus.Nombre.ToUpper())).ToList()));
            }
            return resultado;
        }

        public NotasDto ObtenerNotas(NotaDto nota)
        {
            NotasDto resultado = new NotasDto();
            if (nota.Folio != 0)
            {
                resultado.AddRange(NotasDto.ToDTO(contexto.Notas.Where(n => n.Folio == nota.Folio).ToList()));
            }
            else if (nota.IdEstatus != 0)
            {
                resultado.AddRange(NotasDto.ToDTO(contexto.Notas.Where(n => n.IdEstatus == nota.IdEstatus).ToList()));
            }
            else if (nota.IdPaqueteria != 0)
            {
                resultado.AddRange(NotasDto.ToDTO(contexto.Notas.Where(n => n.IdPaqueteria == nota.IdPaqueteria).ToList()));
            }
            else if (nota.IdTipo != 0)
            {
                resultado.AddRange(NotasDto.ToDTO(contexto.Notas.Where(n => n.IdTipo == nota.IdTipo).ToList()));
            }
            else if (nota.IdCliente != Guid.Empty)
            {
                resultado.AddRange(NotasDto.ToDTO(contexto.Notas.Where(n => n.IdCliente == nota.IdCliente).ToList()));
            }
            else
            {
                resultado.AddRange(NotasDto.ToDTO(contexto.Notas.ToList()));
            }
            return resultado;
        }

        public NotasComentariosDto ObtenerNotasComentarios(NotaComentarioDto notaComentario)
        {
            NotasComentariosDto resultado = new NotasComentariosDto();
            if (notaComentario.Id != 0)
            {
                resultado.AddRange(NotasComentariosDto.ToDTO(contexto.NotasComentarios.Where(n => n.Id == notaComentario.Id).ToList()));
            }
            else if (notaComentario.IdNota != 0)
            {
                resultado.AddRange(NotasComentariosDto.ToDTO(contexto.NotasComentarios.Where(n => n.IdNota == notaComentario.IdNota).ToList()));
            }
            else
            {
                resultado.AddRange(NotasComentariosDto.ToDTO(contexto.NotasComentarios.ToList()));
            }
            return resultado;
        }

        public NotasTicketsDto ObtenerNotasTickets(NotaTicketDto notaTicket)
        {
            NotasTicketsDto resultado = new NotasTicketsDto();
            if (notaTicket.Id != 0)
            {
                resultado.AddRange(NotasTicketsDto.ToDTO(contexto.NotasTickets.Where(n => n.Id == notaTicket.Id).ToList()));
            }
            else if (notaTicket.IdNota != 0)
            {
                resultado.AddRange(NotasTicketsDto.ToDTO(contexto.NotasTickets.Where(n => n.IdNota == notaTicket.IdNota).ToList()));
            }
            else
            {
                resultado.AddRange(NotasTicketsDto.ToDTO(contexto.NotasTickets.ToList()));
            }
            return resultado;
        }

        public ProductosDto ObtenerProductos(ProductoDto producto)
        {
            ProductosDto resultado = new ProductosDto();
            if (producto.Id != 0)
            {
                resultado.AddRange(ProductosDto.ToDTO(contexto.Productos.Where(p => p.Id == producto.Id).ToList()));
            }
            else if (producto.IdCatalogo != 0)
            {
                resultado.AddRange(ProductosDto.ToDTO(contexto.Productos.Where(p => p.IdCatalogo == producto.IdCatalogo).ToList()));
            }
            else if (producto.IdEstatus != 0)
            {
                resultado.AddRange(ProductosDto.ToDTO(contexto.Productos.Where(p => p.IdEstatus == producto.IdEstatus).ToList()));
            }
            else if (producto.IdTipoNota != 0)
            {
                resultado.AddRange(ProductosDto.ToDTO(contexto.Productos.Where(p => p.IdTipoNota == producto.IdTipoNota).ToList()));
            }
            else if (!string.IsNullOrEmpty(producto.Sku))
            {
                resultado.AddRange(ProductosDto.ToDTO(contexto.Productos.Where(p => p.Sku.ToUpper().Contains(producto.Sku.ToUpper())).ToList()));
            }
            else if (!string.IsNullOrEmpty(producto.Nombre))
            {
                resultado.AddRange(ProductosDto.ToDTO(contexto.Productos.Where(p => p.Nombre.ToUpper().Contains(producto.Nombre.ToUpper())).ToList()));
            }
            else
            {
                resultado.AddRange(ProductosDto.ToDTO(contexto.Productos.ToList()));
            }
            return resultado;
        }

        public TiposCatalogosDto ObtenerTiposCatalogos(TipoCatalogoDto tipoCatalogo)
        {
            TiposCatalogosDto resultado = new TiposCatalogosDto();
            if (tipoCatalogo.Id != 0)
            {
                resultado.AddRange(TiposCatalogosDto.ToDTO(contexto.TipoCatalogos.Where(t => t.Id == tipoCatalogo.Id).ToList()));
            }
            else if (!string.IsNullOrEmpty(tipoCatalogo.Nombre))
            {
                resultado.AddRange(TiposCatalogosDto.ToDTO(contexto.TipoCatalogos.Where(t => t.Nombre.ToUpper().Contains(tipoCatalogo.Nombre.ToUpper())).ToList()));
            }
            else
            {
                resultado.AddRange(TiposCatalogosDto.ToDTO(contexto.TipoCatalogos.ToList()));
            }
            return resultado;
        }

        public TiposEstatusDto ObtenerTiposEstatus(TipoEstatusDto tipo)
        {
            TiposEstatusDto resultado = new TiposEstatusDto();
            if (tipo.Id != 0)
            {
                resultado.AddRange(TiposEstatusDto.ToDTO(contexto.TipoEstatuses.Where(t => t.Id == tipo.Id).ToList()));
            }
            else if (!string.IsNullOrEmpty(tipo.Nombre))
            {
                resultado.AddRange(TiposEstatusDto.ToDTO(contexto.TipoEstatuses.Where(t => t.Id == tipo.Id).ToList()));
            }
            else
            {
                resultado.AddRange(TiposEstatusDto.ToDTO(contexto.TipoEstatuses.ToList()));
            }
            return resultado;
        }
    }
}
