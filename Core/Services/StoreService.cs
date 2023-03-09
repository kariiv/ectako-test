using EctakoTest.Core.Entities.StoreAggregate;
using EctakoTest.Core.Interfaces;
using EctakoTest.Core.Interfaces.services;
using EctakoTest.Core.Specifications;

namespace EctakoTest.Core.Services;

public class StoreService : AsyncService<Store>, IStoreService
{
    public StoreService(IAsyncRepository<Store> repository) : base(repository) { }

    public new Task<IEnumerable<Store>> GetAllAsync(CancellationToken cancellationToken) =>
        Repository.ListAsync(new StoreWithExternalsSpecifications(), cancellationToken);
}