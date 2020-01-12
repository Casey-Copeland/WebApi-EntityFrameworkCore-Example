using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApi_EntityFrameworkCore_Example.EntityServices.Database;
using WebApi_EntityFrameworkCore_Example.EntityServices.Entities;

namespace WebApi_EntityFrameworkCore_Example.EntityServices.Repository
{
    public class DbEntityService<TEntity> : IEntityService<TEntity> where TEntity : class, IDbEntity
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public DbEntityService(IDbContextFactory<ExampleDbContext> dbContextFactory)
        {
            _dbContext = dbContextFactory.CreateDbContext();
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task Create(TEntity entity)
        {
            _dbSet.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid guid)
        {
            var entity = await GetByGuid(guid);
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<TEntity> GetAsQueryable()
        {
            return _dbSet.AsNoTracking(); //Returning with AsNoTracking as entity updates should always be done by CRUD operations directly and this gives significant performance improvements in readonly scenarios
        }

        public async Task<TEntity> GetByGuid(Guid guid)
        {
            return await GetAsQueryable().FirstOrDefaultAsync(e => e.Guid == guid);
        }

        public async Task Update(Guid guid, TEntity entity)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
