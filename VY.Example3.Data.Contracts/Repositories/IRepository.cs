using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VY.Example3.Data.Contracts.Repositories
{
    public interface IRepository<TEntity,in TKey>
    {
        Task AddAsync(TEntity entity);
        Task AddAsync (IEnumerable<TEntity> entities);
        Task RemoveAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(TKey id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task SaveChanges();
    }
}
