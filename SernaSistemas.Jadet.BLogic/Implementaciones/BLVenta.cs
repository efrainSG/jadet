using SernaSistemas.Jadet.Comun.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SernaSistemas.Jadet.BLogic
{
    public class BLVenta : IBLVenta
    {
        public bool BorrarDetalle(ref Producto producto)
        {
            throw new NotImplementedException();
        }

        public bool BorrarNota(ref Producto producto)
        {
            throw new NotImplementedException();
        }

        public bool BorrarNotaComentario(ref Producto producto)
        {
            throw new NotImplementedException();
        }

        public bool BorrarNotaTicket(ref Producto producto)
        {
            throw new NotImplementedException();
        }

        public bool BorrarProducto(ref Producto producto)
        {
            throw new NotImplementedException();
        }

        public bool GuardarDetalle(ref Producto producto)
        {
            throw new NotImplementedException();
        }

        public bool GuardarNota(ref Producto producto)
        {
            throw new NotImplementedException();
        }

        public bool GuardarNotaComentario(ref Producto producto)
        {
            throw new NotImplementedException();
        }

        public bool GuardarNotaTicket(ref Producto producto)
        {
            throw new NotImplementedException();
        }

        public bool GuardarProducto(ref Producto producto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Nota> ObtenerCarritos(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Catalogo> ObtenerCatalogos(bool esId, Catalogo catalogo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NotaComentario> ObtenerComentarios(bool esId, NotaComentario notaComentario)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Detalle> ObtenerDetalles(byte idTipo, Detalle detalle)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Estatus> ObtenerEstatuses(bool esId, Estatus estatus)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Nota> ObtenerNotas(byte idTipo, Nota nota)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NotaTicket> ObtenerNotasTickets(bool esId, NotaTicket notaTicket)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Producto> ObtenerProductos(byte idTipo, bool esSku, Producto producto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> ObtenerUsuarios(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public bool VaciarCarrito(ref Nota carrito)
        {
            throw new NotImplementedException();
        }
    }
}
