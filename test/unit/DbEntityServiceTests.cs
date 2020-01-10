using WebApi_EntityFrameworkCore_Example.EntityServices.Repository;
using WebApi_EntityFrameworkCore_Example.UnitTests.Entities;
using Xunit;

namespace WebApi_EntityFrameworkCore_Example.UnitTests
{
    public class DbEntityServiceTests
    {
        [Fact]
        public void CreateAddsEntityToDb()
        {
            //Given the following setup
            var dbEntityService = new DbEntityService<UnitTestEntity>();
            var unitTestEntity = new UnitTestEntity();

            //When the create method is called
            dbEntityService.Create(unitTestEntity);

            //Then the entity should exist in the database
            //TODO: Implement this
            Assert.True(false); //Placeholder until more code is added that will allow this to work
        }

        [Fact]
        public void DeleteRemovesEntityFromDb()
        {
            //Given the following setup
            var dbEntityService = new DbEntityService<UnitTestEntity>();
            var unitTestEntity = new UnitTestEntity();

            //When the delete method is called
            dbEntityService.Delete(unitTestEntity.Guid);

            //Then the entity should be removed from the database
            //TODO: Implement this
            Assert.True(false); //Placeholder until more code is added that will allow this to work
        }

        [Fact]
        public void GetAllGetsAllEntitiesFromDb()
        {
            //Given the following setup
            var dbEntityService = new DbEntityService<UnitTestEntity>();

            //When the GetAll method is called
            dbEntityService.GetAll();

            //Then we should get all the entities in the database
            //TODO: Implement this
            Assert.True(false); //Placeholder until more code is added that will allow this to work
        }

        [Fact]
        public void GetByGuidGetsEntityFromDb()
        {
            //Given the following setup
            var dbEntityService = new DbEntityService<UnitTestEntity>();
            var unitTestEntity = new UnitTestEntity();

            //When the GetByGuid method is called
            dbEntityService.GetByGuid(unitTestEntity.Guid);

            //Then we should get the entity from the database with the matching guid
            //TODO: Implement this
            Assert.True(false); //Placeholder until more code is added that will allow this to work
        }

        [Fact]
        public void UpdateUpdatesEntityInDb()
        {
            //Given the following setup
            var dbEntityService = new DbEntityService<UnitTestEntity>();
            var unitTestEntity = new UnitTestEntity();

            //When the update method is called
            dbEntityService.Update(unitTestEntity.Guid, unitTestEntity);

            //Then we should find that the entity was updated in the database
            //TODO: Implement this
            Assert.True(false); //Placeholder until more code is added that will allow this to work
        }
    }
}
