using HDovud.Contract.Repositories;
using HDovud.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDovud.Repository
{
    public class BaseRepository<T,TId> : IRepositoryBase<T,TId> where T : class
    {
        private readonly DataContext Context;

        public BaseRepository(DataContext context)
        {
            this.Context = context;
        }

        public virtual async Task CreateAsync(T entity) => await Context.Set<T>().AddAsync(entity);

        public void Delete(T entity) => Context.Set<T>().Remove(entity);

        public async Task<T> GetById(TId id) => await Context.Set<T>().FindAsync(id);

        public async Task SaveAsync() => await Context.SaveChangesAsync();

        public void Update(T entity) => Context.Set<T>().Update(entity);

    }
}
