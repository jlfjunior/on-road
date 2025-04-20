using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnRoad.API.Domain;

namespace OnRoad.API.Infrastructure;

public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ToTable("Vehicles");
        builder.HasKey(vehicle => vehicle.Id);

        builder.Property(vehicle => vehicle.Model)
            .IsRequired();
    }
}