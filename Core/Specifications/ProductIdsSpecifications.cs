using Ardalis.Specification;
using EctakoTest.Core.Entities.ProductAggregate;
using EctakoTest.Core.Entities.StoreAggregate;

namespace EctakoTest.Core.Specifications;

public class ProductIdsSpecifications : Specification<Product>
{
    public ProductIdsSpecifications(params int[] ids)
    {
        Query.Where(p => ids.Contains(p.Id));
    }
}