using Ardalis.Specification;
using EctakoTest.Core.Entities.ProductAggregate;
using EctakoTest.Core.Entities.StoreAggregate;

namespace EctakoTest.Core.Specifications;

public class StoreProductsSpecifications : Specification<Product>
{
    public StoreProductsSpecifications(int id)
    {
        Query.Include(s => s.Group)
            .Include(p => p.Stores)
            .Where(s => s.Stores.Select(p => p.Id).Contains(id));
    }
}