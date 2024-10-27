using System.Linq.Expressions;
using Application.Models.Requests;
using Application.Models.Views;
using Domain.Entities;
using Domain.Repository;
using Mapster;

namespace Application.Services;

/// <summary>
/// Сервис с базовым функционалом для работы с автомобилями.
/// </summary>
public class CarService(
    IRepositoryFactory factory,
    TypeAdapterConfig mapperConfig,
    IRepositoryFactory repositoryFactory)
    : ModuleService<Car>(factory, mapperConfig)
{
    /// <summary>
    /// Создание записи автомобиля.
    /// </summary>
    public async Task<CarModel> CreateAsync(CreateCarRequestModel request, CancellationToken token)
    {
        var carRepository = repositoryFactory.GetRepository<Car>();

        var result = await Repository.AddEntityAsync(request.Adapt<Car>(), token);

        var newCar = await carRepository.GetEntitiesAsync(
            predicate: c => c.Id == result.Id, 
            token: token,
            includes: new Expression<Func<Car, object>>[]
            {
                c => c.BodyType!,
                c => c.Brand!
            });
        
        return newCar.First().Adapt<CarModel>(MapperConfig);
    }

    /// <summary>
    /// Обновление данных об автомобиле.
    /// </summary>
    public async Task<bool> UpdateAsync(UpdateCarRequestModel request, CancellationToken token)
    {
        return await Repository.UpdateEntitiesAsync(
            predicate: c => c.Id == request.Id,
            updateAction: cars =>
            {
                foreach (var car in cars)
                {
                    if (request.BodyTypeId.HasValue &&
                        request.BodyTypeId != car.BodyTypeId)
                        car.BodyTypeId = request.BodyTypeId.Value;

                    if (request.BrandId.HasValue &&
                        request.BrandId != car.BrandId)
                        car.BrandId = request.BrandId.Value;
                    
                    if (!string.IsNullOrEmpty(request.Model) &&
                        request.Model != car.Model)
                        car.Model = request.Model;
                    
                    if (request.SeatsCount.HasValue &&
                        request.SeatsCount != car.SeatsCount)
                        car.SeatsCount = request.SeatsCount.Value;
                    
                    if (!string.IsNullOrEmpty(request.DealerSiteUrl) &&
                        request.DealerSiteUrl != car.DealerSiteUrl)
                        car.DealerSiteUrl = request.DealerSiteUrl;
                }
            }, token: token);
    }
}