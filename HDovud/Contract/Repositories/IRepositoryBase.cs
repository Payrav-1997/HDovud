using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDovud.Contract.Repositories
{
    public interface IRepositoryBase<T,TId>
    {
        Task CreateAsync(T entity);
        Task<T> GetById(TId id);
        void Delete(T entity);
        void Update(T entity);
        Task SaveAsync();
    }
}
