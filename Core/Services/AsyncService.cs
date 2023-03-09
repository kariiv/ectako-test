using EctakoTest.Core.Interfaces;
using EctakoTest.Core.Interfaces.services;

namespace EctakoTest.Core.Services;

public class AsyncService<T> : IAsyncService<T>  where T : IBaseEntity
{
    protected readonly IAsyncRepository<T> Repository;
    
    public AsyncService(IAsyncRepository<T> repository)
    {
        Repository = repository;
    }
    
    public Task<T> GetAsync(int id, CancellationToken cancellationToken) => 
        Repository.GetByIdAsync(id, cancellationToken);
    
    public Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken) => 
        Repository.ListAllAsync(cancellationToken);

    public Task<T> CreateAsync(T entity, CancellationToken cancellationToken) =>
        Repository.AddAsync(entity, cancellationToken);
    
    public async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken) {
        await Repository.UpdateAsync(entity, cancellationToken);
        return entity;
    }

    public async Task<T> RemoveAsync(T entity, CancellationToken cancellationToken) {
        await Repository.DeleteAsync(entity, cancellationToken);
        return entity;
    }
}