using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Addresses");
        builder.HasKey(a => a.Id);

        builder.Property(a => a.City).IsRequired().HasColumnType("varchar(100)");
        builder.Property(a => a.Street).IsRequired().HasColumnType("varchar(100)");
        builder.Property(a => a.Number).IsRequired().HasColumnType("integer");
        builder.Property(a => a.Zipcode).IsRequired().HasColumnType("varchar(20)");

        builder.OwnsOne(a => a.Geolocation, geolocation =>
        {
            geolocation.Property(g => g.Latitude).IsRequired().HasColumnName("Latitude").HasColumnType("varchar(50)");
            geolocation.Property(g => g.Longitude).IsRequired().HasColumnName("Longitude").HasColumnType("varchar(50)");
        });
    }
}
