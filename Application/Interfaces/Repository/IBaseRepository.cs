using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repository
{
    public interface IBaseRepository<TEntity>
        where TEntity : class,new()
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<bool> Delete(TEntity entity);
        Task<TEntity> Get(Expression<Func<TEntity, bool>> filter);
        Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null);
    }
}
