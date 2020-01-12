using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_EntityFrameworkCore_Example.EntityServices.Database;
using WebApi_EntityFrameworkCore_Example.EntityServices.Repository;
using WebApi_EntityFrameworkCore_Example.UnitTests.Entities;
using Xunit;

namespace WebApi_EntityFrameworkCore_Example.UnitTests
{
    public class DbEntityServiceTests
    {
        [Fact]
        public async Task CreateAddsEntityToDb()
        {
            //Given the following setup
            var unitTestEntity = new UnitTestEntity()
            {
                Guid = Guid.NewGuid()
            };
            var unitTestEntities = new List<UnitTestEntity>()
            {
                unitTestEntity
            };

            var dbContextMock = new Mock<ExampleDbContext>();

            dbContextMock.Setup(x => x.Set<UnitTestEntity>()).ReturnsDbSet(unitTestEntities);

            var dbContextFactoryMock = new Mock<IDbContextFactory<ExampleDbContext>>();
            dbContextFactoryMock.Setup(x => x.CreateDbContext()).Returns(dbContextMock.Object);

            var dbEntityService = new DbEntityService<UnitTestEntity>(dbContextFactoryMock.Object);

            //When the create method is called
            await dbEntityService.Create(unitTestEntity);

            //Then the entity should exist in the database
            dbContextMock.Verify(mock => mock.Set<UnitTestEntity>().Add(unitTestEntity));
            dbContextMock.Verify(mock => mock.SaveChangesAsync(default));
        }

        [Fact]
        public async Task DeleteRemovesEntityFromDb()
        {
            //Given the following setup
            var unitTestEntity = new UnitTestEntity()
            {
                Guid = Guid.NewGuid()
            };
            var unitTestEntities = new List<UnitTestEntity>()
            {
                unitTestEntity
            };

            var dbContextMock = new Mock<ExampleDbContext>();

            dbContextMock.Setup(x => x.Set<UnitTestEntity>()).ReturnsDbSet(unitTestEntities);

            var dbContextFactoryMock = new Mock<IDbContextFactory<ExampleDbContext>>();
            dbContextFactoryMock.Setup(x => x.CreateDbContext()).Returns(dbContextMock.Object);

            var dbEntityService = new DbEntityService<UnitTestEntity>(dbContextFactoryMock.Object);

            //When the delete method is called
            await dbEntityService.Delete(unitTestEntity.Guid);

            //Then the entity should be removed from the database
            dbContextMock.Verify(mock => mock.Set<UnitTestEntity>().Remove(unitTestEntity));
            dbContextMock.Verify(mock => mock.SaveChangesAsync(default));
        }

        [Fact]
        public async Task GetAllGetsAllEntitiesFromDb()
        {
            //Given the following setup
            var unitTestEntities = new List<UnitTestEntity>()
            {
                new UnitTestEntity(), new UnitTestEntity(), new UnitTestEntity(), new UnitTestEntity(), new UnitTestEntity()
            };

            var dbContextMock = new Mock<ExampleDbContext>();

            dbContextMock.Setup(x => x.Set<UnitTestEntity>()).ReturnsDbSet(unitTestEntities);

            var dbContextFactoryMock = new Mock<IDbContextFactory<ExampleDbContext>>();
            dbContextFactoryMock.Setup(x => x.CreateDbContext()).Returns(dbContextMock.Object);

            var dbEntityService = new DbEntityService<UnitTestEntity>(dbContextFactoryMock.Object);

            //When the GetAll method is called
            var results = await dbEntityService.GetAsQueryable().ToListAsync();

            //Then we should get all the entities in the database
            Assert.True(results.Count == unitTestEntities.Count);
        }

        [Fact]
        public async Task GetByGuidGetsEntityFromDb()
        {
            //Given the following setup
            var unitTestEntity = new UnitTestEntity()
            {
                Guid = Guid.NewGuid()
            };
            var unitTestEntities = new List<UnitTestEntity>()
            {
                unitTestEntity
            };

            var dbContextMock = new Mock<ExampleDbContext>();

            dbContextMock.Setup(x => x.Set<UnitTestEntity>()).ReturnsDbSet(unitTestEntities);

            var dbContextFactoryMock = new Mock<IDbContextFactory<ExampleDbContext>>();
            dbContextFactoryMock.Setup(x => x.CreateDbContext()).Returns(dbContextMock.Object);

            var dbEntityService = new DbEntityService<UnitTestEntity>(dbContextFactoryMock.Object);

            //When the GetByGuid method is called
            var result = await dbEntityService.GetByGuid(unitTestEntity.Guid);

            //Then we should get the entity from the database with the matching guid
            Assert.Equal(unitTestEntity.Guid, result.Guid);
        }

        [Fact]
        public async Task UpdateUpdatesEntityInDb()
        {
            //Given the following setup
            var unitTestEntity = new UnitTestEntity()
            {
                Guid = Guid.NewGuid()
            };
            var unitTestEntities = new List<UnitTestEntity>()
            {
                unitTestEntity
            };

            var dbContextMock = new Mock<ExampleDbContext>();

            dbContextMock.Setup(x => x.Set<UnitTestEntity>()).ReturnsDbSet(unitTestEntities);

            var dbContextFactoryMock = new Mock<IDbContextFactory<ExampleDbContext>>();
            dbContextFactoryMock.Setup(x => x.CreateDbContext()).Returns(dbContextMock.Object);

            var dbEntityService = new DbEntityService<UnitTestEntity>(dbContextFactoryMock.Object);

            //When the update method is called
            await dbEntityService.Update(unitTestEntity.Guid, unitTestEntity);

            //Then we should find that the entity was updated in the database
            dbContextMock.Verify(mock => mock.Set<UnitTestEntity>().Update(unitTestEntity));
            dbContextMock.Verify(mock => mock.SaveChangesAsync(default));
        }
    }
}
