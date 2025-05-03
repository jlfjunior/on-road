using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnRoad.Domain.Entities;

namespace OnRoad.Infrastructure.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("Locations");
        
        builder.HasKey(location => location.Id);

        builder.Property(location => location.CustomerId)
            .IsRequired();
        builder.Property(location => location.VehicleId)
            .IsRequired();
        builder.Property(location => location.PlanId)
            .IsRequired();
        builder.Property(location => location.PlanVersion)
            .IsRequired();
        
        builder.Property(location => location.Amount);
        builder.Property(location => location.Penalty);
        builder.Property(location => location.StartDate);
        builder.Property(location => location.FinishedAt);
        builder.Property(location => location.EndDate);
    }
}