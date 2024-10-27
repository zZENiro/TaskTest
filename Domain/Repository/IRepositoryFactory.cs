namespace Domain.Repository;

public interface IRepositoryFactory
{
    public IRepository<T> GetRepository<T>() where T : class;
}