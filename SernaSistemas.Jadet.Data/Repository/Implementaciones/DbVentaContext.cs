using SernaSistemas.Jadet.Data.Models;
using SernaSistemas.Jadet.Data.DTO;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SernaSistemas.Jadet.Data.Repository
{
    public class DbVentaContext : IDbVentaContext
    {
        private readonly BDJadetContext contexto;

        public DbVentaContext(BDJadetContext entities)
        {
            contexto = entities;
        }
        public DbVentaContext(DbContext dbContext)
        {
            contexto = dbContext as BDJadetContext;
        }

        public bool BorrarDetalle(ref DetalleDTO detalle)
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

        public bool BorrarNota(ref NotaDTO nota)
        {
            int id = nota.Folio;
            Nota _nota = contexto.Notas.FirstOrDefault(n => n.Folio == id);
            if (_nota != null)
            {
                var estatus = _nota.IdEstatusNavigation;
                var tipo = _nota.IdTipoNavigation;
                var paqueteria = _nota.IdPaqueteriaNavigation;

                estatus.NotaIdEstatusNavigations.Remove(_nota);
                tipo.NotaIdEstatusNavigations.Remove(_nota);
                paqueteria.NotaIdPaqueteriaNavigations.Remove(_nota);

                contexto.Notas.Remove(_nota);
                return contexto.SaveChanges() != 0;
            }
            return false;
        }

        public bool BorrarNotaComentario(ref NotaComentarioDTO notaComentario)
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

        public bool BorrarNotaTicket(ref NotaTicketDTO notaTicket)
        {
            int id = notaTicket.Id;
            NotasTicket ticket = contexto.NotasTickets.FirstOrDefault(c => c.Id == id);
            if (ticket != null)
            {
                Nota nota = ticket.IdNotaNavigation;
                nota.NotasTickets.Remove(ticket);
                contexto.NotasTickets.Remove(ticket);
                return contexto.SaveChanges() != 0;
            }
            return false;
        }

        public bool GuardarDetalle(ref DetalleDTO detalle)
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

            detalle = DetalleDTO.ToDTO(_detalle);

            return resultado != 0;
        }

        public bool GuardarNota(ref NotaDTO nota)
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

            nota = NotaDTO.ToDTO(_nota);

            return resultado != 0;
        }

        public bool GuardarNotaComentario(ref NotaComentarioDTO notaComentario)
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

            notaComentario = NotaComentarioDTO.ToDTO(_notaComentario);

            return resultado != 0;

        }

        public bool GuardarNotaTicket(ref NotaTicketDTO notaTicket)
        {
            int id = notaTicket.Id;
            int folio = notaTicket.IdNota;

            NotasTicket ticket = contexto.NotasTickets.FirstOrDefault(t => t.Id == id);
            Nota _nota = contexto.Notas.FirstOrDefault(n => n.Folio == folio);

            if(ticket == null)
            {
                ticket = new NotasTicket();
                contexto.NotasTickets.Add(ticket);
            }
            
            ticket.MontoMxn = notaTicket.MontoMXN;
            ticket.MontoUsd = notaTicket.MontoUSD;
            ticket.Ticket = notaTicket.Ticket;
            ticket.Fecha = notaTicket.Fecha;

            _nota.NotasTickets.Add(ticket);

            int resultado = contexto.SaveChanges();

            notaTicket = NotaTicketDTO.ToDTO(_nota);

            return resultado != 0;
        }

        public bool GuardarProducto(ref ProductoDTO producto)
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
            _tipoNota.ProductoIdCatalogoNavigations.Add(_producto);

            int resultado = contexto.SaveChanges();

            producto = ProductoDTO.ToDTO(_producto);
            return resultado != 0;
        }

        public CatalogosDTO ObtenerCatalogos(CatalogoDTO catalogo)
        {
            CatalogosDTO resultado = new CatalogosDTO();
            if (catalogo.Id != 0)
            {
                resultado.AddRange(CatalogosDTO.ToDTO(contexto.Catalogos.Where(c => c.Id == catalogo.Id).ToList()));
            }
            else if (catalogo.IdTipoCatalogo != 0)
            {
                resultado.AddRange(CatalogosDTO.ToDTO(
                    contexto.Catalogos.Where(c => c.IdTipoCatalogo == catalogo.IdTipoCatalogo).ToList()
                    ));
            }
            else if (!string.IsNullOrEmpty(catalogo.Nombre))
            {
                resultado.AddRange(CatalogosDTO.ToDTO(
                    contexto.Catalogos.Where(c => c.Nombre.ToUpper().Contains(catalogo.Nombre.ToUpper())).ToList()
                    ));
            }
            else
            {
                resultado.AddRange(CatalogosDTO.ToDTO(contexto.Catalogos.ToList()));
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
                resultado.AddRange(EstatusesDTO.ToDTO(contexto.Estatuses.Where(e => e.Id == estatus.Id).ToList()));
            }
            else if (estatus.IdTipoEstatus != 0)
            {
                resultado.AddRange(EstatusesDTO.ToDTO(contexto.Estatuses.Where(e => e.IdTipoEstatus == estatus.IdTipoEstatus).ToList()));
            }
            else if (!string.IsNullOrEmpty(estatus.Nombre))
            {
                resultado.AddRange(EstatusesDTO.ToDTO(
                    contexto.Estatuses.Where(e => e.Nombre.ToUpper().Contains(estatus.Nombre.ToUpper())).ToList()));
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
                resultado.AddRange(NotasComentariosDTO.ToDTO(contexto.NotasComentarios.Where(n => n.Id == notaComentario.Id).ToList()));
            }
            else if (notaComentario.IdNota != 0)
            {
                resultado.AddRange(NotasComentariosDTO.ToDTO(contexto.NotasComentarios.Where(n => n.IdNota == notaComentario.IdNota).ToList()));
            }
            else
            {
                resultado.AddRange(NotasComentariosDTO.ToDTO(contexto.NotasComentarios.ToList()));
            }
            return resultado;
        }

        public NotasTicketsDTO ObtenerNotasTickets(NotaTicketDTO notaTicket)
        {
            NotasTicketsDTO resultado = new NotasTicketsDTO();
            if (notaTicket.Id != 0)
            {
                resultado.AddRange(NotasTicketsDTO.ToDTO(contexto.NotasTickets.Where(n => n.Id == notaTicket.Id).ToList()));
            }
            else if (notaTicket.IdNota != 0)
            {
                resultado.AddRange(NotasTicketsDTO.ToDTO(contexto.NotasTickets.Where(n => n.IdNota == notaTicket.IdNota).ToList()));
            }
            else
            {
                resultado.AddRange(NotasTicketsDTO.ToDTO(contexto.NotasTickets.ToList()));
            }
            return resultado;
        }

        public ProductosDTO ObtenerProductos(ProductoDTO producto)
        {
            ProductosDTO resultado = new ProductosDTO();
            if (producto.Id != 0)
            {
                resultado.AddRange(ProductosDTO.ToDTO(contexto.Productos.Where(p => p.Id == producto.Id).ToList()));
            }
            else if (producto.IdCatalogo != 0)
            {
                resultado.AddRange(ProductosDTO.ToDTO(contexto.Productos.Where(p => p.IdCatalogo == producto.IdCatalogo).ToList()));
            }
            else if (producto.IdEstatus != 0)
            {
                resultado.AddRange(ProductosDTO.ToDTO(contexto.Productos.Where(p => p.IdEstatus == producto.IdEstatus).ToList()));
            }
            else if (producto.IdTipoNota != 0)
            {
                resultado.AddRange(ProductosDTO.ToDTO(contexto.Productos.Where(p => p.IdTipoNota == producto.IdTipoNota).ToList()));
            }
            else if (!string.IsNullOrEmpty(producto.Sku))
            {
                resultado.AddRange(ProductosDTO.ToDTO(contexto.Productos.Where(p => p.Sku.ToUpper().Contains(producto.Sku.ToUpper())).ToList()));
            }
            else if (!string.IsNullOrEmpty(producto.Nombre))
            {
                resultado.AddRange(ProductosDTO.ToDTO(contexto.Productos.Where(p => p.Nombre.ToUpper().Contains(producto.Nombre.ToUpper())).ToList()));
            }
            else
            {
                resultado.AddRange(ProductosDTO.ToDTO(contexto.Productos.ToList()));
            }
            return resultado;
        }

        public UsuariosDTO ObtenerUsuarios(UsuarioDTO usuario)
        {
            UsuariosDTO resultado = new UsuariosDTO();
            if (usuario.Id != Guid.Empty)
            {
                resultado.AddRange(UsuariosDTO.ToDTO(contexto.Usuarios.Where(u => u.Id == usuario.Id).ToList()));
            }
            else if (usuario.IdEstatus != 0)
            {
                resultado.AddRange(UsuariosDTO.ToDTO(contexto.Usuarios.Where(u => u.IdEstatus == usuario.IdEstatus).ToList()));
            }
            else if (usuario.IdRol != 0)
            {
                resultado.AddRange(UsuariosDTO.ToDTO(contexto.Usuarios.Where(u => u.IdRol == usuario.IdRol).ToList()));
            }
            else if (!string.IsNullOrEmpty(usuario.NomUsuario))
            {
                resultado.AddRange(UsuariosDTO.ToDTO(
                    contexto.Usuarios.Where(u => u.Usuario1.ToUpper().Contains(usuario.NomUsuario.ToUpper())).ToList())
                    );
            }
            else if (!string.IsNullOrEmpty(usuario.Nombre))
            {
                resultado.AddRange(UsuariosDTO.ToDTO(
                    contexto.Usuarios.Where(u => u.Nombre.ToUpper().Contains(usuario.Nombre.ToUpper())).ToList())
                    );
            }
            return resultado;
        }
    }
}
