using EctakoTest.Core.Interfaces;

namespace EctakoTest.Core.Entities;

public abstract class BaseEntity : IBaseEntity
{
    public int Id { get; set; }
}