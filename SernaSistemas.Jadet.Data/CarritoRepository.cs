using SernaSistemas.Jadet.Data.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace SernaSistemas.Jadet.Data
{
    public class CarritoRepository : ICarritoRepository
    {
        private readonly IRepositoryBase<Carrito> _repositoryBase;

        public CarritoRepository(IRepositoryBase<Carrito> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }
        public bool BorrarCarrito(int id)
        {
            throw new System.NotImplementedException();
        }

        public Carrito GuardarCarrito(Carrito carrito)
        {
            throw new System.NotImplementedException();
        }

        public Carrito ObtenerCarrito(int id)
        {
            var carrito = new Carrito();
            carrito = Set<Carrito>().FirstOrDefault(c => c.Id.Equals(id));
            return carrito;
        }

        public IEnumerable<Carrito> ObtenerCarritos()
        {
            throw new System.NotImplementedException();
        }

        public void RollbackChanges()
        {
            throw new System.NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<T> Set<T>() where T : class
        {
            return _repositoryBase.Set<T>();
        }
    }
}
