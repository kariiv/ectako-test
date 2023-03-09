using EctakoTest.Core.Entities.ProductAggregate;
using EctakoTest.Core.Entities.StoreAggregate;
using EctakoTest.Core.Interfaces;
using EctakoTest.Core.Interfaces.services;
using EctakoTest.Core.Specifications;

namespace EctakoTest.Core.Services;

public class StoreService : AsyncService<Store>, IStoreService
{
    private readonly IAsyncRepository<Product> _productRepository;
    public StoreService(IAsyncRepository<Store> repository, IAsyncRepository<Product> productRepository) : base(repository)
    {
        _productRepository = productRepository;
    }

    
    public new async Task<Store> GetAsync(int id, CancellationToken cancellationToken)
    {
        var item = await base.GetAsync(id, cancellationToken);
        if (item is null) return item;
        await _productRepository.ListAsync(new StoreProductsSpecifications(item.Id), cancellationToken);
        return item;
    }
    
    public new Task<IEnumerable<Store>> GetAllAsync(CancellationToken cancellationToken) =>
        Repository.ListAsync(new StoresWithExternalsSpecifications(), cancellationToken);
}