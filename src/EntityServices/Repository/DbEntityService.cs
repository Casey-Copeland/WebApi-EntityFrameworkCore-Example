using System;
using System.Linq;
using System.Threading.Tasks;
using WebApi_EntityFrameworkCore_Example.EntityServices.Entities;

namespace WebApi_EntityFrameworkCore_Example.EntityServices.Repository
{
    public class DbEntityService<TEntity> : IEntityService<TEntity> where TEntity : class, IDbEntity
    {
        public Task Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid guid)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByGuid(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task Update(Guid guid, TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
