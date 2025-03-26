using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnRoad.API.Domain;

namespace OnRoad.API.Infrastructure;

public class PlanConfiguration : IEntityTypeConfiguration<Plan>
{
    public void Configure(EntityTypeBuilder<Plan> builder)
    {
        builder.HasKey(plan => plan.Id);
        
        builder
            .Property(plan => plan.Description)
            .HasMaxLength(50)
            .IsRequired();
        
        builder
            .Property(plan => plan.Days)
            .IsRequired();
        
        builder
            .Property(plan => plan.DailyValue)
            .IsRequired();
        
        builder
            .Property(plan => plan.Penalty)
            .IsRequired();
    }
}