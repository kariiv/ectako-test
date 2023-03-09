using EctakoTest.Core.Entities.ProductAggregate;
using EctakoTest.Core.Entities.StoreAggregate;
using EctakoTest.Core.Interfaces;
using EctakoTest.Core.Interfaces.services;
using EctakoTest.Core.Specifications;

namespace EctakoTest.Core.Services;

public class ProductService : AsyncService<Product>, IProductService
{
    private readonly IProductGroupService _productGroupService;
    private readonly IAsyncRepository<ProductGroup> _productGroupRepository;
    private readonly IAsyncRepository<Store> _storeRepository;
    
    public ProductService(IAsyncRepository<Product> repository, IAsyncRepository<ProductGroup> productGroupRepository, IAsyncRepository<Store> storeRepository, IProductGroupService productGroupService) :
        base(repository)
    {
        _productGroupService = productGroupService;
        _productGroupRepository = productGroupRepository;
        _storeRepository = storeRepository;
    }

    public new async Task<Product> GetAsync(int id, CancellationToken cancellationToken)
    {
        var item = await base.GetAsync(id, cancellationToken);
        if (item is null) return item;
        item.Group ??= await _productGroupService.GetAsync(item.GroupId, cancellationToken);
        await _storeRepository.ListAsync(new ProductStoresSpecifications(item.Id), cancellationToken);
        return item;
    }
    
    public new async Task<Product> CreateAsync(Product entity, CancellationToken cancellationToken)
    {
        var stores = await GuardAgainstInvalidStoreList(entity.Stores.Select(s => s.Id), cancellationToken);
        entity.SetStores(stores.ToArray());
        
        await GuardAgainstInvalidGroup(entity.GroupId);
        entity.CalculateTax();
        await base.CreateAsync(entity, cancellationToken);
        return await GetAsync(entity.Id, cancellationToken);
    }

    public new async Task<Product> UpdateAsync(Product entity, CancellationToken cancellationToken)
    {
        await GuardAgainstInvalidGroup(entity.GroupId);
        return await base.UpdateAsync(entity, cancellationToken);
    }
    
    public new Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken) => 
        Repository.ListAsync(new ProductsWithExternalsSpecifications(), cancellationToken);

    private async Task<IEnumerable<Store>> GuardAgainstInvalidStoreList(IEnumerable<int> storeIds, CancellationToken cancellationToken)
    {
        var stores = await _storeRepository.ListAsync(new StoreIdsSpecifications(storeIds.Distinct().ToArray()), cancellationToken);
        if (stores.Count() != storeIds.Count())
            throw new ArgumentException("Invalid Store list, check for duplicates or ids!", nameof(Product.Stores));
        return stores;
    }
    
    private async Task GuardAgainstInvalidGroup(int groupId)
    {
        if (await _productGroupRepository.GetByIdAsync(groupId) == null)
            throw new ArgumentException("Group with id not found!", nameof(groupId));
    }
}