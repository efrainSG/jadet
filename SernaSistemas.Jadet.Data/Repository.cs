using Microsoft.EntityFrameworkCore;
using SernaSistemas.Jadet.Data.Dtos;
using System;
using System.Collections.Generic;

namespace SernaSistemas.Jadet.Data
{
    public class Repository : IRepository
    {
        public Repository(DbContext _dbContext)
        {

        }
        public bool BorrarCarrito(int id)
        {
            throw new NotImplementedException();
        }

        public bool BorrarCatalogo(int id)
        {
            throw new NotImplementedException();
        }

        public bool BorrarComentario(int id)
        {
            throw new NotImplementedException();
        }

        public bool BorrarDetalleNota(int id)
        {
            throw new NotImplementedException();
        }

        public bool BorrarEstatus(int id)
        {
            throw new NotImplementedException();
        }

        public bool BorrarNota(int id)
        {
            throw new NotImplementedException();
        }

        public bool BorrarProducto(int id)
        {
            throw new NotImplementedException();
        }

        public bool BorrarTicket(int id)
        {
            throw new NotImplementedException();
        }

        public bool BorrarUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public Carrito GuardarCarrito(Carrito carrito)
        {
            throw new NotImplementedException();
        }

        public Catalogo GuardarCatalogo(Catalogo catalogo)
        {
            throw new NotImplementedException();
        }

        public Comentario GuardarComentario(Comentario comentario)
        {
            throw new NotImplementedException();
        }

        public DetalleNota GuardarDetalleNota(DetalleNota detalleNota)
        {
            throw new NotImplementedException();
        }

        public Estatus GuardarEstatus(Estatus estatus)
        {
            throw new NotImplementedException();
        }

        public Nota GuardarNota(Nota nota)
        {
            throw new NotImplementedException();
        }

        public Producto GuardarProducto(Producto producto)
        {
            throw new NotImplementedException();
        }

        public Ticket GuardarTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public Usuario GuardarUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Carrito ObtenerCarrito(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Carrito> ObtenerCarritos()
        {
            throw new NotImplementedException();
        }

        public Catalogo ObtenerCatalogo(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Catalogo> ObtenerCatalogos()
        {
            throw new NotImplementedException();
        }

        public Comentario ObtenerComentario(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comentario> ObtenerComentarios()
        {
            throw new NotImplementedException();
        }

        public DetalleNota ObtenerDetalle(int folio)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DetalleNota> ObtenerDetallesNotas()
        {
            throw new NotImplementedException();
        }

        public Estatus ObtenerEstatus(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Estatus> ObtenerEstatuses()
        {
            throw new NotImplementedException();
        }

        public Nota ObtenerNota(int folio)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Nota> ObtenerNotas()
        {
            throw new NotImplementedException();
        }

        public Producto ObtenerProducto(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Producto> ObtenerProductos()
        {
            throw new NotImplementedException();
        }

        public Ticket ObtenerTicket(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ticket> ObtenerTickets()
        {
            throw new NotImplementedException();
        }

        public Usuario ObtenerUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> ObtenerUsuarios()
        {
            throw new NotImplementedException();
        }
    }
}
