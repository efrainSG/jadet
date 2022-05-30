using SernaSistemas.Jadet.DAccess.DTO;
using System;
using System.Linq;

namespace SernaSistemas.Jadet.DAccess.Repository
{
    public class DbAdministracionContext : IDbAdministracionContext
    {
        private readonly BDJadetEntities contexto;

        public DbAdministracionContext(BDJadetEntities entities)
        {
            contexto = entities;
        }
        public DbAdministracionContext(System.Data.Entity.DbContext dbContext)
        {
            contexto = dbContext as BDJadetEntities;
        }

        public bool BorrarCatalogo(ref CatalogoDTO catalogo)
        {
            int id = catalogo.Id;
            Catalogo _catalogo = contexto.Catalogoes.FirstOrDefault(c => c.Id == id);
            if (_catalogo != null)
            {
                TipoCatalogo tipo = _catalogo.TipoCatalogo;

                tipo.Catalogos.Remove(_catalogo);
                contexto.Catalogoes.Remove(_catalogo);

                return contexto.SaveChanges() != 0;
            }
            return false;
        }

        public bool BorrarDetalle(ref DetalleDTO detalle)
        {
            int id = detalle.Id;
            Detalle _detalle = contexto.Detalles.FirstOrDefault(d => d.Id == id);
            if (_detalle != null)
            {
                Nota nota = _detalle.Nota;
                Producto producto = _detalle.Producto;

                producto.Detalles.Remove(_detalle);
                nota.Detalles.Remove(_detalle);
                contexto.Detalles.Remove(_detalle);

                return contexto.SaveChanges() != 0;
            }
            return false;
        }

        public bool BorrarEstatus(ref EstatusDTO estatus)
        {
            int id = estatus.Id;
            Estatus _estatus = contexto.Estatus1.FirstOrDefault(e => e.Id == id);
            if (_estatus != null)
            {
                TipoEstatus tipo = _estatus.TipoEstatus;

                tipo.Estatuses.Remove(_estatus);
                contexto.Estatus1.Remove(_estatus);

                return contexto.SaveChanges() != 0;
            }
            return false;
        }

        public bool BorrarNota(ref NotaDTO nota)
        {
            int id = nota.Folio;
            Nota _nota = contexto.Notas.FirstOrDefault(n => n.Folio == id);
            if (_nota != null)
            {
                var estatus = _nota.CatEstatus;
                var tipo = _nota.CatTipo;
                var paqueteria = _nota.CatPaqueteria;

                estatus.NotasEstatus.Remove(_nota);
                tipo.NotasEstatus.Remove(_nota);
                paqueteria.NotasEstatus.Remove(_nota);

                contexto.Notas.Remove(_nota);
                return contexto.SaveChanges() != 0;
            }
            return false;
        }

        public bool BorrarNotaComentario(ref NotaComentarioDTO notaComentario)
        {
            int id = notaComentario.Id;
            NotaComentario comentario = contexto.NotaComentarios.FirstOrDefault(c => c.Id == id);
            if (comentario != null)
            {
                Nota nota = comentario.Nota;
                nota.NotasComentarios.Remove(comentario);
                contexto.NotaComentarios.Remove(comentario);
                return contexto.SaveChanges() != 0;
            }
            return false;
        }

        public bool BorrarProducto(ref ProductoDTO producto)
        {
            int id = producto.Id;
            Producto _producto = contexto.Productoes.FirstOrDefault(p => p.Id == id);
            if (_producto != null)
            {
                Catalogo catalogo = _producto.CatProducto;
                Catalogo estatus = _producto.CatEstatus;
                Catalogo tipoNota = _producto.CatTipoNota;

                catalogo.CatProductos.Remove(_producto);
                estatus.CatProductos.Remove(_producto);
                tipoNota.CatProductos.Remove(_producto);
                contexto.Productoes.Remove(_producto);

                return contexto.SaveChanges() != 0;
            }
            return false;
        }

        public bool BorrarTipoCatalogo(ref TipoCatalogoDTO tipoCatalogo)
        {
            int id = tipoCatalogo.Id;
            TipoCatalogo _tipoCatalogo = contexto.TipoCatalogoes.FirstOrDefault(t => t.Id == id);
            if (_tipoCatalogo != null)
            {
                contexto.TipoCatalogoes.Remove(_tipoCatalogo);

                return contexto.SaveChanges() != 0;
            }
            return false;
        }

        public bool BorrarTipoEstatus(ref TipoEstatusDTO tipo)
        {
            int id = tipo.Id;
            TipoEstatus _tipo = contexto.TipoEstatus1.FirstOrDefault(t => t.Id == id);
            if (_tipo != null)
            {
                contexto.TipoEstatus1.Remove(_tipo);

                return contexto.SaveChanges() != 0;
            }
            return false;
        }

        public bool GuardarCatalogo(ref CatalogoDTO catalogo)
        {
            int id = catalogo.Id;
            int idTipo = catalogo.IdTipoCatalogo;
            Catalogo _catalogo = contexto.Catalogoes.FirstOrDefault(c => c.Id == id);
            TipoCatalogo _tipo = contexto.TipoCatalogoes.FirstOrDefault(t => t.Id == idTipo);
            if (_catalogo == null)
            {
                _catalogo = new Catalogo();
                contexto.Catalogoes.Add(_catalogo);
            }
            _tipo.Catalogos.Add(_catalogo);

            _catalogo.Nombre = catalogo.Nombre;

            int resultado = contexto.SaveChanges();

            catalogo = CatalogoDTO.ToDTO(_catalogo);

            return resultado != 0;
        }

        public bool GuardarDetalle(ref DetalleDTO detalle)
        {
            int id = detalle.Id;
            int idNota = detalle.IdNota;
            int idProducto = detalle.IdProducto;

            Detalle _detalle = contexto.Detalles.FirstOrDefault(d => d.Id == id);
            Nota _nota = contexto.Notas.FirstOrDefault(n => n.Folio == idNota);
            Producto _producto = contexto.Productoes.FirstOrDefault(p => p.Id == idProducto);

            if (_detalle == null)
            {
                _detalle = new Detalle();
                contexto.Detalles.Add(_detalle);
            }
            _detalle.PrecioMXN = detalle.PrecioMXN;
            _detalle.PrecioUSD = detalle.PrecioUSD;
            _detalle.Cantidad = detalle.Cantidad;

            _nota.Detalles.Add(_detalle);
            _producto.Detalles.Add(_detalle);

            int resultado = contexto.SaveChanges();

            detalle = DetalleDTO.ToDTO(_detalle);

            return resultado != 0;
        }

        public bool GuardarEstatus(ref EstatusDTO estatus)
        {
            int id = estatus.Id;
            int idTipo = estatus.IdTipoEstatus;
            Estatus _estatus = contexto.Estatus1.FirstOrDefault(e => e.Id == id);
            TipoEstatus _tipo = contexto.TipoEstatus1.FirstOrDefault(t => t.Id == idTipo);
            if (_estatus == null)
            {
                _estatus = new Estatus();
                contexto.Estatus1.Add(_estatus);
            }

            _tipo.Estatuses.Add(_estatus);
            _estatus.Nombre = estatus.Nombre;

            int resultado = contexto.SaveChanges();

            estatus = EstatusDTO.ToDTO(_estatus);

            return resultado != 0;
        }

        public bool GuardarNota(ref NotaDTO nota)
        {
            int folio = nota.Folio;
            int idTipo = nota.IdTipo;
            int idPaqueteria = nota.IdPaqueteria;
            int idEstatus = nota.IdEstatus;

            Nota _nota = contexto.Notas.FirstOrDefault(n => n.Folio == folio);
            Catalogo catPaqueteria = contexto.Catalogoes.FirstOrDefault(c => c.Id == idPaqueteria);
            Catalogo catTipo = contexto.Catalogoes.FirstOrDefault(c => c.Id == idTipo);
            Catalogo catEstatus = contexto.Catalogoes.FirstOrDefault(e => e.Id == idEstatus);

            if (_nota == null)
            {
                _nota = new Nota();
                contexto.Notas.Add(_nota);
            }

            catPaqueteria.NotasPaqueteria.Add(_nota);
            catTipo.NotasTipo.Add(_nota);
            catEstatus.NotasEstatus.Add(_nota);

            _nota.Fecha = nota.Fecha;
            _nota.FechaEnvio = nota.FechaEnvio;
            _nota.Guia = nota.Guia;
            _nota.MontoMXN = nota.MontoMXN;
            _nota.MontoUSD = nota.MontoUSD;
            _nota.SaldoMXN = nota.SaldoMXN;
            _nota.SaldoUSD = nota.SaldoUSD;

            int resultado = contexto.SaveChanges();

            nota = NotaDTO.ToDTO(_nota);

            return resultado != 0;
        }

        public bool GuardarNotaComentario(ref NotaComentarioDTO notaComentario)
        {
            int id = notaComentario.Id;
            int idNota = notaComentario.IdNota;
            int? idAnterior = notaComentario.IdComentarioAnterior;

            NotaComentario _notaComentario = contexto.NotaComentarios.FirstOrDefault(n => n.Id == id);
            Nota _nota = contexto.Notas.FirstOrDefault(n => n.Folio == idNota);
            NotaComentario _anterior;

            if (_notaComentario == null)
            {
                _notaComentario = new NotaComentario();
                contexto.NotaComentarios.Add(_notaComentario);
            }

            _nota.NotasComentarios.Add(_notaComentario);
            _notaComentario.Comentario = notaComentario.Comentario;
            _notaComentario.Fecha = notaComentario.Fecha;
            _notaComentario.IdComentarioAnterior = notaComentario.IdComentarioAnterior;

            int resultado = contexto.SaveChanges();

            notaComentario = NotaComentarioDTO.ToDTO(_notaComentario);

            return resultado != 0;

        }

        public bool GuardarProducto(ref ProductoDTO producto)
        {
            int id = producto.Id;
            int idCatalogo = producto.IdCatalogo;
            int idEstatus = producto.IdEstatus;
            int idTipoNota = producto.IdTipoNota;
            Producto _producto = contexto.Productoes.FirstOrDefault(p => p.Id == id);
            if (_producto == null)
            {
                _producto = new Producto();
                contexto.Productoes.Add(_producto);
            }

            Catalogo _catalogo = contexto.Catalogoes.FirstOrDefault(c => c.Id == idCatalogo);
            Catalogo _estatus = contexto.Catalogoes.FirstOrDefault(e => e.Id == idEstatus);
            Catalogo _tipoNota = contexto.Catalogoes.FirstOrDefault(t => t.Id == idTipoNota);

            _catalogo.CatProductos.Add(_producto);
            _estatus.EstProductos.Add(_producto);
            _tipoNota.CatProductos2.Add(_producto);

            int resultado = contexto.SaveChanges();

            producto = ProductoDTO.ToDTO(_producto);
            return resultado != 0;
        }

        public bool GuardarTipoCatalogo(ref TipoCatalogoDTO tipoCatalogo)
        {
            int id = tipoCatalogo.Id;
            TipoCatalogo _tipoCatalogo = contexto.TipoCatalogoes.FirstOrDefault(e => e.Id == id);
            if (_tipoCatalogo == null)
            {
                _tipoCatalogo = new TipoCatalogo();
                contexto.TipoCatalogoes.Add(_tipoCatalogo);
            }

            _tipoCatalogo.Nombre = tipoCatalogo.Nombre;

            int resultado = contexto.SaveChanges();
            tipoCatalogo = TipoCatalogoDTO.ToDTO(_tipoCatalogo);
            return resultado != 0;
        }

        public bool GuardarTipoEstatus(ref TipoEstatusDTO tipo)
        {
            int id = tipo.Id;

            TipoEstatus _tipo = contexto.TipoEstatus1.FirstOrDefault(t => t.Id == id);
            if (_tipo == null)
            {
                _tipo = new TipoEstatus();
                contexto.TipoEstatus1.Add(_tipo);
            }
            _tipo.Nombre = tipo.Nombre;
            int resultado = contexto.SaveChanges();
            tipo = TipoEstatusDTO.ToDTO(_tipo);
            return resultado != 0;
        }

        public CatalogosDTO ObtenerCatalogos(CatalogoDTO catalogo)
        {
            CatalogosDTO resultado = new CatalogosDTO();
            if (catalogo.Id != 0)
            {
                resultado.AddRange(CatalogosDTO.ToDTO(contexto.Catalogoes.Where(c => c.Id == catalogo.Id).ToList()));
            }
            else if (catalogo.IdTipoCatalogo != 0)
            {
                resultado.AddRange(CatalogosDTO.ToDTO(
                    contexto.Catalogoes.Where(c => c.IdTipoCatalogo == catalogo.IdTipoCatalogo).ToList()
                    ));
            }
            else if (!string.IsNullOrEmpty(catalogo.Nombre))
            {
                resultado.AddRange(CatalogosDTO.ToDTO(
                    contexto.Catalogoes.Where(c => c.Nombre.ToUpper().Contains(catalogo.Nombre.ToUpper())).ToList()
                    ));
            }
            else
            {
                resultado.AddRange(CatalogosDTO.ToDTO(contexto.Catalogoes.ToList()));
            }
            return resultado;
        }

        public DetallesDTO ObtenerDetalles(DetalleDTO detalle)
        {
            DetallesDTO resultado = new DetallesDTO();
            if (detalle.Id != 0)
            {
                resultado.AddRange(DetallesDTO.ToDTO(contexto.Detalles.Where(d => d.Id == detalle.Id).ToList()));
            }
            else if (detalle.IdNota != 0)
            {
                resultado.AddRange(DetallesDTO.ToDTO(contexto.Detalles.Where(d => d.IdNota == detalle.IdNota).ToList()));
            }
            else if (detalle.IdProducto != 0)
            {
                resultado.AddRange(DetallesDTO.ToDTO(contexto.Detalles.Where(d => d.IdProducto == detalle.IdProducto).ToList()));
            }
            else
            {
                resultado.AddRange(DetallesDTO.ToDTO(contexto.Detalles.ToList()));
            }
            return resultado;
        }

        public EstatusesDTO ObtenerEstatuses(EstatusDTO estatus)
        {
            EstatusesDTO resultado = new EstatusesDTO();
            if (estatus.Id != 0)
            {
                resultado.AddRange(EstatusesDTO.ToDTO(contexto.Estatus1.Where(e => e.Id == estatus.Id).ToList()));
            }
            else if (estatus.IdTipoEstatus != 0)
            {
                resultado.AddRange(EstatusesDTO.ToDTO(contexto.Estatus1.Where(e => e.IdTipoEstatus == estatus.IdTipoEstatus).ToList()));
            }
            else if (!string.IsNullOrEmpty(estatus.Nombre))
            {
                resultado.AddRange(EstatusesDTO.ToDTO(
                    contexto.Estatus1.Where(e => e.Nombre.ToUpper().Contains(estatus.Nombre.ToUpper())).ToList()));
            }
            return resultado;
        }

        public NotasDTO ObtenerNotas(NotaDTO nota)
        {
            NotasDTO resultado = new NotasDTO();
            if (nota.Folio != 0)
            {
                resultado.AddRange(NotasDTO.ToDTO(contexto.Notas.Where(n => n.Folio == nota.Folio).ToList()));
            }
            else if (nota.IdEstatus != 0)
            {
                resultado.AddRange(NotasDTO.ToDTO(contexto.Notas.Where(n => n.IdEstatus == nota.IdEstatus).ToList()));
            }
            else if (nota.IdPaqueteria != 0)
            {
                resultado.AddRange(NotasDTO.ToDTO(contexto.Notas.Where(n => n.IdPaqueteria == nota.IdPaqueteria).ToList()));
            }
            else if (nota.IdTipo != 0)
            {
                resultado.AddRange(NotasDTO.ToDTO(contexto.Notas.Where(n => n.IdTipo == nota.IdTipo).ToList()));
            }
            else if (nota.IdCliente != Guid.Empty)
            {
                resultado.AddRange(NotasDTO.ToDTO(contexto.Notas.Where(n => n.IdCliente == nota.IdCliente).ToList()));
            }
            else
            {
                resultado.AddRange(NotasDTO.ToDTO(contexto.Notas.ToList()));
            }
            return resultado;
        }

        public NotasComentariosDTO ObtenerNotasComentarios(NotaComentarioDTO notaComentario)
        {
            NotasComentariosDTO resultado = new NotasComentariosDTO();
            if (notaComentario.Id != 0)
            {
                resultado.AddRange(NotasComentariosDTO.ToDTO(contexto.NotaComentarios.Where(n => n.Id == notaComentario.Id).ToList()));
            }
            else if (notaComentario.IdNota != 0)
            {
                resultado.AddRange(NotasComentariosDTO.ToDTO(contexto.NotaComentarios.Where(n => n.IdNota == notaComentario.IdNota).ToList()));
            }
            else
            {
                resultado.AddRange(NotasComentariosDTO.ToDTO(contexto.NotaComentarios.ToList()));
            }
            return resultado;
        }

        public NotasTicketsDTO ObtenerNotasTickets(NotaTicketDTO notaTicket)
        {
            NotasTicketsDTO resultado = new NotasTicketsDTO();
            if (notaTicket.Id != 0)
            {
                resultado.AddRange(NotasTicketsDTO.ToDTO(contexto.NotaTickets.Where(n => n.Id == notaTicket.Id).ToList()));
            }
            else if (notaTicket.IdNota != 0)
            {
                resultado.AddRange(NotasTicketsDTO.ToDTO(contexto.NotaTickets.Where(n => n.IdNota == notaTicket.IdNota).ToList()));
            }
            else
            {
                resultado.AddRange(NotasTicketsDTO.ToDTO(contexto.NotaTickets.ToList()));
            }
            return resultado;
        }

        public ProductosDTO ObtenerProductos(ProductoDTO producto)
        {
            ProductosDTO resultado = new ProductosDTO();
            if (producto.Id != 0)
            {
                resultado.AddRange(ProductosDTO.ToDTO(contexto.Productoes.Where(p => p.Id == producto.Id).ToList()));
            }
            else if (producto.IdCatalogo != 0)
            {
                resultado.AddRange(ProductosDTO.ToDTO(contexto.Productoes.Where(p => p.IdCatalogo == producto.IdCatalogo).ToList()));
            }
            else if (producto.IdEstatus != 0)
            {
                resultado.AddRange(ProductosDTO.ToDTO(contexto.Productoes.Where(p => p.IdEstatus == producto.IdEstatus).ToList()));
            }
            else if (producto.IdTipoNota != 0)
            {
                resultado.AddRange(ProductosDTO.ToDTO(contexto.Productoes.Where(p => p.IdTipoNota == producto.IdTipoNota).ToList()));
            }
            else if (!string.IsNullOrEmpty(producto.Sku))
            {
                resultado.AddRange(ProductosDTO.ToDTO(contexto.Productoes.Where(p => p.sku.ToUpper().Contains(producto.Sku.ToUpper())).ToList()));
            }
            else if (!string.IsNullOrEmpty(producto.Nombre))
            {
                resultado.AddRange(ProductosDTO.ToDTO(contexto.Productoes.Where(p => p.Nombre.ToUpper().Contains(producto.Nombre.ToUpper())).ToList()));
            }
            else
            {
                resultado.AddRange(ProductosDTO.ToDTO(contexto.Productoes.ToList()));
            }
            return resultado;
        }

        public TiposCatalogosDTO ObtenerTiposCatalogos(TipoCatalogoDTO tipoCatalogo)
        {
            TiposCatalogosDTO resultado = new TiposCatalogosDTO();
            if (tipoCatalogo.Id != 0)
            {
                resultado.AddRange(TiposCatalogosDTO.ToDTO(contexto.TipoCatalogoes.Where(t => t.Id == tipoCatalogo.Id).ToList()));
            }
            else if (!string.IsNullOrEmpty(tipoCatalogo.Nombre))
            {
                resultado.AddRange(TiposCatalogosDTO.ToDTO(contexto.TipoCatalogoes.Where(t => t.Nombre.ToUpper().Contains(tipoCatalogo.Nombre.ToUpper())).ToList()));
            }
            else
            {
                resultado.AddRange(TiposCatalogosDTO.ToDTO(contexto.TipoCatalogoes.ToList()));
            }
            return resultado;
        }

        public TiposEstatusDTO ObtenerTiposEstatus(TipoEstatusDTO tipo)
        {
            TiposEstatusDTO resultado = new TiposEstatusDTO();
            if (tipo.Id != 0)
            {
                resultado.AddRange(TiposEstatusDTO.ToDTO(contexto.TipoEstatus1.Where(t => t.Id == tipo.Id).ToList()));
            }
            else if (!string.IsNullOrEmpty(tipo.Nombre))
            {
                resultado.AddRange(TiposEstatusDTO.ToDTO(contexto.TipoEstatus1.Where(t => t.Id == tipo.Id).ToList()));
            }
            else
            {
                resultado.AddRange(TiposEstatusDTO.ToDTO(contexto.TipoEstatus1.ToList()));
            }
            return resultado;
        }
    }
}
