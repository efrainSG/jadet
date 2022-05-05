using SernaSistemas.Jadet.Data.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace SernaSistemas.Jadet.Data
{
    public interface IRepositoryBase<out T> where T : class
    {
        IQueryable<T> Set<T>() where T : class;
        void RollbackChanges();
        void SaveChanges();
    }
}
