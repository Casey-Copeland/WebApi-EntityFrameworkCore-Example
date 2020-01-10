using System;
using WebApi_EntityFrameworkCore_Example.EntityServices.Entities;

namespace WebApi_EntityFrameworkCore_Example.UnitTests.Entities
{
    public class UnitTestEntity : IDbEntity
    {
        public int Id { get; }
        public DateTime? DateCreated { get; }
        public DateTime? DateModified { get; }
        public Guid Guid { get; }
    }
}
