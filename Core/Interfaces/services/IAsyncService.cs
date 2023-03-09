namespace EctakoTest.Core.Interfaces.services;

public interface IAsyncService<TEntity> where TEntity : IBaseEntity
{
    Task<TEntity> GetAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    Task<TEntity> RemoveAsync(TEntity entity, CancellationToken cancellationToken = default);
}