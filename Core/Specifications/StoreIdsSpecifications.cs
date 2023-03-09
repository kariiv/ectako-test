using Ardalis.Specification;
using EctakoTest.Core.Entities.StoreAggregate;

namespace EctakoTest.Core.Specifications;

public class StoreIdsSpecifications : Specification<Store>
{
    public StoreIdsSpecifications(params int[] ids)
    {
        Query.Where(p => ids.Contains(p.Id));
    }
}