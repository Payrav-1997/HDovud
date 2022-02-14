using HDovud.Contract.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDovud.Repository
{
    public class BaseRepository<T,TId> : IRepositoryBase<T,TId> where T : class
    {
        public BaseRepository()
        {
        }

        public Task CreateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(TId id)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        void CreateAsync<T>
    }
}
