using SernaSistemas.Jadet.Data.Dtos;
using System.Collections.Generic;

namespace SernaSistemas.Jadet.Data
{
    public interface ICarritoRepository:IRepositoryBase<Carrito>
    {
        Carrito ObtenerCarrito(int id);
        IEnumerable<Carrito> ObtenerCarritos();
        Carrito GuardarCarrito(Carrito carrito);
        bool BorrarCarrito(int id);
    }
}
