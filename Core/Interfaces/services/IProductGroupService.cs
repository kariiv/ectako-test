using EctakoTest.Core.Entities.ProductAggregate;

namespace EctakoTest.Core.Interfaces.services;

public interface IProductGroupService : IAsyncService<ProductGroup>
{
    Task<IEnumerable<ProductGroup>> GetAsTreeAsync(CancellationToken cancellationToken);
    
}