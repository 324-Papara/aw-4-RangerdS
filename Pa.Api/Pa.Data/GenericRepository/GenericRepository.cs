
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Pa.Base.Entity;
using Pa.Data.Context;
using System.Linq.Expressions;

namespace Pa.Data.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly PaMsDbContext _msContext;
        public GenericRepository(PaMsDbContext msContext)
        {
            this._msContext = msContext;
        }

        public async Task Save()
        {
            await _msContext.SaveChangesAsync();
        }

        // Get All with Filter and Include
        // await _genericRepository.GetAll(x => x.IsActive, x => x.Include(y => y.User));
        public async Task<List<TEntity>> GetAll(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            IQueryable<TEntity> query = _msContext.Set<TEntity>().Where(x => x.IsActive);

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (include != null)
            {
                query = include(query);
            }

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetById(long id)
        {
            var entity = await _msContext.Set<TEntity>().Where(x => x.IsActive).FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
                return null;
            return entity;
        }

        public async Task Insert(TEntity entity)
        {
            entity.IsActive = true;
            entity.CreateUserId = 1;
            entity.CreateTime = DateTime.UtcNow;
            await _msContext.Set<TEntity>().AddAsync(entity);
        }

        public async Task Update(long id, TEntity entity)
        {
            var entityToUpdate = await GetById(id);
            if (entityToUpdate == null)
                throw new Exception("Factory to update not fount!");


            // Add Update User info and Update Time
            entity.UpdateUserId = 2;
            entity.UpdateTime = DateTime.UtcNow;

            _msContext.Set<TEntity>().Update(entity);
            _msContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task Delete(TEntity entity)
        {
            var entityToDelete = await GetById(entity.Id);
            if (entityToDelete == null)
                return;

            // Using Soft Delete
            entity.IsActive = false;
            entity.DeleteUserId = 3;
            entity.DeleteTime = DateTime.UtcNow;

            _msContext.Set<TEntity>().Update(entity);
            _msContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task Delete(long id)
        {
            var entity = await GetById(id);
            await Delete(entity);
        }
    }
}
