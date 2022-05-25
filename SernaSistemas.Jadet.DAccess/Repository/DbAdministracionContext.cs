using SernaSistemas.Jadet.DAccess.DTO;
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
            if(_catalogo == null)
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

            if(_detalle == null)
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
            Catalogo catTipo= contexto.Catalogoes.FirstOrDefault(c => c.Id == idTipo);
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
            if(_producto == null)
            {
                _producto = new Producto();
                contexto.Productoes.Add(_producto);
            }

            Catalogo _catalogo = contexto.Catalogoes.FirstOrDefault(c => c.Id == idCatalogo);
            Catalogo _estatus = contexto.Catalogoes.FirstOrDefault(e => e.Id == idEstatus);
            Catalogo _tipoNota = contexto.Catalogoes.FirstOrDefault(t=> t.Id == idTipoNota);

            _catalogo.CatProductos.Add(_producto);
            _estatus.EstProductos.Add(_producto);
            _tipoNota.CatProductos2.Add(_producto);

            int resultado = contexto.SaveChanges();

            producto = ProductoDTO.ToDTO(_producto);
            return resultado != 0;
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

        public DetallesDTO ObtenerDetalles(DetalleDTO detalle)
        {
            throw new System.NotImplementedException();
        }

        public EstatusDTO ObtenerEstatuses(EstatusDTO estatus)
        {
            throw new System.NotImplementedException();
        }

        public NotasDTO ObtenerNotas(NotaDTO nota)
        {
            throw new System.NotImplementedException();
        }

        public NotasComentariosDTO ObtenerNotasComentarios(NotaComentarioDTO notaComentario)
        {
            throw new System.NotImplementedException();
        }

        public NotasTicketsDTO ObtenerNotasTickets(NotaTicketDTO notaTicket)
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
