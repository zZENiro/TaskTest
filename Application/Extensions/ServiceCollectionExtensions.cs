using Application.Mappings;
using Application.Services;
using Application.Validation;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterMappingConfig(this IServiceCollection serviceCollection)
    {
        var config = new TypeAdapterConfig();
        config.ConfigureCarModelsMapping();

        return serviceCollection.AddSingleton(config);
    }

    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        return services
            .AddScoped<CreateCarValidator>()
            .AddScoped<UpdateCarValidator>();
    }

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<CarService>();

        return services;
    }
}