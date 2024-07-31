using Microsoft.EntityFrameworkCore.Query;
using Pa.Base.Entity;
using System.Linq.Expressions;

namespace Pa.Data.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task Save();
        Task<TEntity> GetById(long id);
        Task<List<TEntity>> GetAll(
            Expression<Func<TEntity, bool>> filter = null
            , Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
        Task Insert(TEntity Entity);
        Task Update(long id, TEntity Entity);
        Task Delete(TEntity Entity);
        Task Delete(long id);

    }
}
