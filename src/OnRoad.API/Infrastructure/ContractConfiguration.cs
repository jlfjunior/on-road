using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnRoad.API.Domain;

namespace OnRoad.API.Infrastructure;

public class ContractConfiguration : IEntityTypeConfiguration<Contract>
{
    public void Configure(EntityTypeBuilder<Contract> builder)
    {
        builder.HasKey(contract => contract.Id);
        
        builder.Property(contract => contract.CustomerId)
            .IsRequired();
        
        builder.Property(contract => contract.VehicleId)
            .IsRequired();

        builder.Property(contract => contract.PlanId)
            .IsRequired();

        builder.Property(contract => contract.StartDate)
            .IsRequired();
        
        builder.Property(contract => contract.FinishDate)
            .IsRequired();

        builder.Property(contract => contract.Penalty);

        builder.Property(contract => contract.FinishedAt);

        builder.Property(contract => contract.Amount);
    }
}