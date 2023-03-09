using Ardalis.Specification;
using EctakoTest.Core.Entities.ProductAggregate;

namespace EctakoTest.Core.Specifications;

public class ProductsWithExternalsSpecifications : Specification<Product>
{
    public ProductsWithExternalsSpecifications()
    {
        Query.Include(p => p.Stores)
            .Include(p => p.Group);
    }
    
    public ProductsWithExternalsSpecifications(int[] ids)
    {
        Query.Where(p => ids.Contains(p.Id))
            .Include(p => p.Stores)
            .Include(p => p.Group);
    }
}