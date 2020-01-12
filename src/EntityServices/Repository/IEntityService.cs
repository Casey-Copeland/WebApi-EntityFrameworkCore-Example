using System;
using System.Linq;
using System.Threading.Tasks;
using WebApi_EntityFrameworkCore_Example.EntityServices.Entities;

namespace WebApi_EntityFrameworkCore_Example.EntityServices.Repository
{
    public interface IEntityService<TEntity> where TEntity : class, IEntity
    {
        IQueryable<TEntity> GetAsQueryable();

        Task<TEntity> GetByGuid(Guid guid);

        Task Create(TEntity entity);

        Task Update(Guid guid, TEntity entity);

        Task Delete(Guid guid);
    }
}
