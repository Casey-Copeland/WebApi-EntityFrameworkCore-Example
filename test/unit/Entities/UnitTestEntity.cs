using System;
using WebApi_EntityFrameworkCore_Example.EntityServices.Entities;

namespace WebApi_EntityFrameworkCore_Example.UnitTests.Entities
{
    public class UnitTestEntity : IDbEntity
    {
        public int Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public Guid Guid { get; set; }
    }
}
