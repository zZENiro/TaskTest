using System.Linq.Expressions;
using Domain.Entities;
using Domain.Repository;
using Mapster;

namespace Application.Services;

public abstract class ModuleService<T> where T : BaseEntity
{
    protected IRepository<T> Repository { get; }

    protected TypeAdapterConfig MapperConfig { get; }

    protected ModuleService(IRepositoryFactory factory, TypeAdapterConfig mapperConfig)
    {
        Repository = factory.GetRepository<T>();
        MapperConfig = mapperConfig;
    }

    /// <summary>
    /// Метод удаления сущности.
    /// </summary>
    public async Task<bool> RemoveAsync(
        Expression<Func<T, bool>> predicate,
        CancellationToken token)
    {
        return await Repository.RemoveEntitiesAsync(predicate, token);
    }
    
    /// <summary>
    /// Метод поиска сущностей с заданным типом модели.
    /// </summary>
    /// <typeparam name="U">Тип возвращаемой модели.</typeparam>
    public async Task<List<U>?> FindAsync<U>(
        Expression<Func<T, bool>>? predicate,
        int? take,
        int? skip,
        CancellationToken token = default,
        params Expression<Func<T, object>>[] includes)
        where U : class
    {
        var entities = await Repository.GetEntitiesAsync(
            predicate,
            take: take,
            skip: skip,
            includes: includes,
            token: token);
        
        return entities?.Adapt<List<U>>(MapperConfig);
    }
};