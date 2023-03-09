using Ardalis.Specification;
using EctakoTest.Core.Entities.StoreAggregate;

namespace EctakoTest.Core.Specifications;

public class StoreWithExternalsSpecifications : Specification<Store>
{
    public StoreWithExternalsSpecifications()
    {
        Query.Include(p => p.Products)
            .ThenInclude(p => p.Group);
    }
}