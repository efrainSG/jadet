using SernaSistemas.Jadet.DAccess.DTO;

namespace SernaSistemas.Jadet.DAccess.Repository
{
    public class DbVentaContext : IDbVentaContext
    {
        private readonly BDJadetEntities contexto;

        public DbVentaContext(BDJadetEntities entities)
        {
            contexto = entities;
        }
        public DbVentaContext(System.Data.Entity.DbContext dbContext)
        {
            contexto = dbContext as BDJadetEntities;
        }

        public bool BorrarDetalle(ref DetalleDTO detalle)
        {
            throw new System.NotImplementedException();
        }

        public bool BorrarNota(ref NotaDTO nota)
        {
            throw new System.NotImplementedException();
        }

        public bool BorrarNotaComentario(ref NotaComentarioDTO notaComentario)
        {
            throw new System.NotImplementedException();
        }

        public bool BorrarNotaTicket(ref NotaTicketDTO notaTicket)
        {
            throw new System.NotImplementedException();
        }

        public bool GuardarDetalle(ref DetalleDTO detalle)
        {
            throw new System.NotImplementedException();
        }

        public bool GuardarNota(ref NotaDTO nota)
        {
            throw new System.NotImplementedException();
        }

        public bool GuardarNotaComentario(ref NotaComentarioDTO notaComentario)
        {
            throw new System.NotImplementedException();
        }

        public bool GuardarNotaTicket(ref NotaTicketDTO notaTicket)
        {
            throw new System.NotImplementedException();
        }

        public bool GuardarProducto(ref ProductoDTO producto)
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

        public RolesDTO ObtenerUsuarios(UsuarioDTO usuario)
        {
            throw new System.NotImplementedException();
        }
    }
}
