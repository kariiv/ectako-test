using Ardalis.Specification;
using EctakoTest.Core.Entities.StoreAggregate;

namespace EctakoTest.Core.Specifications;

public class StoresWithExternalsSpecifications : Specification<Store>
{
    public StoresWithExternalsSpecifications()
    {
        Query.Include(p => p.Products)
            .ThenInclude(p => p.Group);
    }
    public StoresWithExternalsSpecifications(int[] ids)
    {
        Query.Where(p => ids.Contains(p.Id))
            .Include(p => p.Products)
            .ThenInclude(p => p.Group);
    }
}