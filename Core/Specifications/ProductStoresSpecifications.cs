using Ardalis.Specification;
using EctakoTest.Core.Entities.ProductAggregate;
using EctakoTest.Core.Entities.StoreAggregate;

namespace EctakoTest.Core.Specifications;

public class ProductStoresSpecifications : Specification<Store>
{
    public ProductStoresSpecifications(int id)
    {
        Query.Include(s => s.Products)
            .ThenInclude(p => p.Group)
            .Where(s => s.Products.Select(p => p.Id).Contains(id));
    }
}