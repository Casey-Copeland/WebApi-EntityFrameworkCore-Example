using System;

namespace WebApi_EntityFrameworkCore_Example.EntityServices.Entities
{
    public interface IDbEntity : IEntity
    {
        int Id { get; }
        DateTime? DateCreated { get; }
        DateTime? DateModified { get; }
    }
}