using WebApi_EntityFrameworkCore_Example.EntityServices.Database;
using WebApi_EntityFrameworkCore_Example.UnitTests.Database;
using Xunit;

namespace WebApi_EntityFrameworkCore_Example.UnitTests
{
    public class DbContextFactoryUnitTests
    {
        [Fact]
        public void CreateDbContextReturnsDbContext()
        {
            //Given the following setup
            var dbContextFactory = new DbContextFactory<UnitTestDbContext>() as IDbContextFactory<UnitTestDbContext>;

            //When the CreateDbContext method is called
            var dbContext = dbContextFactory.CreateDbContext();

            //Then we should have a valid DbContext of the correct type
            Assert.True(dbContext is UnitTestDbContext);
        }
    }
}
