using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Persistance.MsSql;

namespace Persistance.Repository;

public class ApplicationRepositoryFactory(IDbContextFactory<ApplicationDbContext> contextFactory) : IRepositoryFactory
{
    public IRepository<T> GetRepository<T>() where T : class
    {
        return new ApplicationRepository<T>(contextFactory);
    }
}