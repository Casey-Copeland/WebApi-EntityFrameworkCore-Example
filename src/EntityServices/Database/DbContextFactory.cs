using Microsoft.EntityFrameworkCore;

namespace WebApi_EntityFrameworkCore_Example.EntityServices.Database
{
    public interface IDbContextFactory<TDbContext> where TDbContext : DbContext
    {
        TDbContext CreateDbContext();
    }

    public class DbContextFactory<TDbContext> : IDbContextFactory<TDbContext> where TDbContext : DbContext, new()
    {
        public TDbContext CreateDbContext()
        {
            return new TDbContext();
        }
    }
}
