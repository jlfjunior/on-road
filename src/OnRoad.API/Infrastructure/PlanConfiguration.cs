using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnRoad.Domain;
using OnRoad.Domain.Entities;

namespace OnRoad.API.Infrastructure;

public class PlanConfiguration : IEntityTypeConfiguration<Plan>
{
    public void Configure(EntityTypeBuilder<Plan> builder)
    {
        builder.ToTable("Plans");
        
        builder.HasKey(plan => new { plan.Id, plan.Version});

        builder.Property(plan => plan.Version);
        builder.Property(plan => plan.Description);
        builder.Property(plan => plan.DurationInDays);
        builder.Property(plan => plan.DailyRate);
        builder.Property(plan => plan.PenaltyFee);
        builder.Property(plan => plan.ExtraDayRate);
    }
}