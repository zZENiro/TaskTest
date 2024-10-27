using System.Linq.Expressions;

namespace Domain.Repository;

public interface IRepository<T> where T : class
{
    Task<bool> UpdateEntitiesAsync(
        Expression<Func<T, bool>> predicate,
        Action<T[]> updateAction,
        int expectedCount = 0,
        CancellationToken token = default,
        params Expression<Func<T, object>>[] includes);
    
    Task<List<T>> GetEntitiesAsync(
        Expression<Func<T, bool>>? predicate = null,
        int? take = null,
        int? skip = null,
        CancellationToken token = default,
        params Expression<Func<T, object>>[] includes);
    
    Task<bool> RemoveEntitiesAsync(
        Expression<Func<T, bool>> predicate,
        CancellationToken token = default);

    public Task<T> AddEntityAsync(T entity, CancellationToken token = default);
}