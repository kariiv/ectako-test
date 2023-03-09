using EctakoTest.Core.Entities.ProductAggregate;
using EctakoTest.Core.Interfaces;
using EctakoTest.Core.Interfaces.services;

namespace EctakoTest.Core.Services;

public class ProductGroupService : AsyncService<ProductGroup>, IProductGroupService
{
    public ProductGroupService(IAsyncRepository<ProductGroup> repository) : base(repository) { }
    
    public new async Task<ProductGroup> GetAsync(int id, CancellationToken cancellationToken)
    {
        var item = await base.GetAsync(id, cancellationToken);
        if (item.ParentId is not null && item.Parent is null)
            item.Parent = await GetAsync(item.ParentId.Value, cancellationToken);
        return item;
    }

    public async Task<IEnumerable<ProductGroup>> GetAsTreeAsync(CancellationToken cancellationToken)
    {
        var all = await GetAllAsync(cancellationToken);
        return all.Where(i => i.ParentId == null).ToList();
    }
}