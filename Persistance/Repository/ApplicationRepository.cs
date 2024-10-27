using System.Linq.Expressions;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Persistance.MsSql;

namespace Persistance.Repository;

public class ApplicationRepository<T> : IRepository<T> where T : class
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;
    
    public ApplicationRepository(IDbContextFactory<ApplicationDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }
    
    public async Task<bool> UpdateEntitiesAsync(Expression<Func<T, bool>> predicate, Action<T[]> updateAction, int expectedCount = 0,
        CancellationToken token = default, params Expression<Func<T, object>>[] includes)
    {
        await using var context = await _contextFactory.CreateDbContextAsync(token);

        var query = WithIncludes(context.Set<T>().Where(predicate), includes);

        var existing = await query.ToArrayAsync();
        if (existing.Length == 0)
            return false;

        updateAction(existing);
        await context.SaveChangesAsync(token);
        if (expectedCount == 0)
            return true;

        // Дополнительно проверяем, все ли запланированные объекты были найдены для изменения.
        return expectedCount == existing.Length;
    }

    public async Task<List<T>> GetEntitiesAsync(Expression<Func<T, bool>>? predicate = null, int? take = null, int? skip = null,
        CancellationToken token = default, params Expression<Func<T, object>>[] includes)
    {
        await using var context = await _contextFactory.CreateDbContextAsync(token);

        var query = context
            .Set<T>()
            .AsNoTracking();

        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        if (take != null && skip != null)
        {
            query = query
                .Skip(skip.Value)
                .Take(take.Value);
        }

        query = WithIncludes(query, includes);

        return await query.ToListAsync(token);
    }

    public async Task<bool> RemoveEntitiesAsync(Expression<Func<T, bool>> predicate, CancellationToken token = default)
    {
        await using var context = await _contextFactory.CreateDbContextAsync(token);

        var entities = await context.Set<T>().Where(predicate).ToListAsync(token);
        if (entities.Count == 0)
            return false;

        context.Set<T>().RemoveRange(entities);
        await context.SaveChangesAsync(token);
        return true;
    }

    public async Task<T> AddEntityAsync(T entity, CancellationToken token = default)
    {
        await using var context = await _contextFactory.CreateDbContextAsync(token);

        await context.Set<T>().AddAsync(entity, token);
        await context.SaveChangesAsync(token);

        return entity;
    }

    private IQueryable<T> WithIncludes(
        IQueryable<T> query,
        Expression<Func<T, object>>[] includes)
    {
        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return query;
    }
}