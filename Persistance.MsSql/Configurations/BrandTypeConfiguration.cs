using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.MsSql.Configurations;

public class BrandTypeConfiguration : BaseConfiguration<Brand>
{
    public override void Configure(EntityTypeBuilder<Brand> builder)
    {
        base.Configure(builder);

        builder.HasData(
            new Brand
            {
                Id = Guid.NewGuid(),
                Name = "Audi"
            },
            new Brand
            {
                Id = Guid.NewGuid(),
                Name = "Ford"
            },
            new Brand
            {
                Id = Guid.NewGuid(),
                Name = "Jeep"
            },
            new Brand
            {
                Id = Guid.NewGuid(),
                Name = "Nissan"
            },
            new Brand
            {
                Id = Guid.NewGuid(),
                Name = "Toyota"
            });
    }
}