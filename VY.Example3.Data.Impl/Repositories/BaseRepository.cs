using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VY.Example3.Data.Contracts.Repositories;

namespace VY.Example3.Data.Impl.Repositories
{
    public class BaseRepository<TContext, TEntity, TKey> : IRepository<TEntity, TKey> where TEntity: class
        where TContext : DbContext
    {
        protected TContext Context;
        protected DbSet<TEntity> DbSet;
        public BaseRepository(TContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }

        public async Task AddAsync(IEnumerable<TEntity> entities)
        {
            await DbSet.AddRangeAsync(entities);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task RemoveAsync(TEntity entity)
        {
            await Task.Run(() => DbSet.Remove(entity));
        }

        public async Task SaveChanges()
        {
            await Context.SaveChangesAsync();
        }
    }
}
