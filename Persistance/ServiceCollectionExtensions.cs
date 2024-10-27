using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Persistance.MsSql;

namespace Persistance.Repository;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration,
        string connectionStringName = "Db")
    {
        return services
            .AddPooledDbContextFactory<ApplicationDbContext>(options =>
                ((DbContextOptionsBuilder<ApplicationDbContext>)options)
                .SetDbContextOptions(configuration.GetConnectionString(connectionStringName)
                                     ?? throw new ArgumentNullException(nameof(connectionStringName))))

            .AddScoped<IRepositoryFactory, ApplicationRepositoryFactory>();
    }

    private static DbContextOptionsBuilder<ApplicationDbContext> SetDbContextOptions(
        this DbContextOptionsBuilder<ApplicationDbContext> builder, string connectionString)
    {
        builder.UseSqlServer(connectionString, options => options
                .CommandTimeout(120))
            .LogTo(Console.WriteLine, LogLevel.Information);

        return builder;
    }
}