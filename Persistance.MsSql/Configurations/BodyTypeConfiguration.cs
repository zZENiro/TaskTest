using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.MsSql.Configurations;

public class BodyTypeConfiguration : BaseConfiguration<BodyType>
{
    public override void Configure(EntityTypeBuilder<BodyType> builder)
    {
        base.Configure(builder);

        builder.HasData(
            new BodyType
            {
                Id = Guid.NewGuid(),
                Name = "Седан"
            },
            new BodyType()
            {
                Id = Guid.NewGuid(),
                Name = "Хэтчбек"
            },
            new BodyType()
            {
                Id = Guid.NewGuid(),
                Name = "Универсал"
            },
            new BodyType()
            {
                Id = Guid.NewGuid(),
                Name = "Минивэн"
            },
            new BodyType()
            {
                Id = Guid.NewGuid(),
                Name = "Внедорожник"
            },
            new BodyType()
            {
                Id = Guid.NewGuid(),
                Name = "Купе"
            });
    }
}