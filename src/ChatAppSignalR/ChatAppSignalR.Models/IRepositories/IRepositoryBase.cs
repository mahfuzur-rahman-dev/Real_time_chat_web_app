using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChatAppSignalR.Models.IRepositories
{
    public interface IRepositoryBase<TEntity, TKey>
        where TEntity : class
        where TKey : IComparable
    {
        Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> GetByIdAsync(TKey id);
        Task<int> GetCountAsync(Expression<Func<TEntity, bool>> filter = null);

        Task AddAsync(TEntity entity);
        Task EditAsync(TEntity entityToUpdate);
        Task RemoveAsync(TEntity entityToDelete);
        Task RemoveByIdAsync(TKey id);

    }
}
