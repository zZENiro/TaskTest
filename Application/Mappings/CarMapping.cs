using Application.Models.Requests;
using Application.Models.Views;
using Domain.Entities;
using Mapster;

namespace Application.Mappings;

public static class CarMapping
{
    public static TypeAdapterConfig ConfigureCarModelsMapping(this TypeAdapterConfig config)
    {
        config.ForType<CreateCarRequestModel, Car>();

        config.ForType<Car, CarModel>()
            .Map(dst => dst.BodyType, src => src.BodyType!.Name)
            .Map(dst => dst.Brand, src => src.Brand!.Name);

        config.ForType<UpdateCarRequestModel, Car>();
        
        return config;
    }
}