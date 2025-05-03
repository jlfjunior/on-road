using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnRoad.Domain.Entities;

namespace OnRoad.Infrastructure.Configurations;

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