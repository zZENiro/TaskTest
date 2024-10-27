using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.MsSql.Configurations;

public class CarConfiguration : BaseConfiguration<Car>
{
    public override void Configure(EntityTypeBuilder<Car> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.Model).HasMaxLength(1000).IsRequired();
        builder.Property(e => e.DealerSiteUrl).HasMaxLength(1000).IsRequired(false);

        builder.HasIndex(e => e.BrandId);
        builder.HasIndex(e => e.BodyTypeId);
    }
}