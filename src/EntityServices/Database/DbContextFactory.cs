using Microsoft.EntityFrameworkCore;

namespace WebApi_EntityFrameworkCore_Example.EntityServices.Database
{
    public interface IDbContextFactory<TDbContext> where TDbContext : DbContext
    {
        TDbContext CreateDbContext();
    }

    public class DbContextFactory<TDbContext> : IDbContextFactory<TDbContext> where TDbContext : DbContext
    {
        public TDbContext CreateDbContext()
        {
            throw new System.NotImplementedException();
        }
    }
}
