using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnRoad.API.Domain;

namespace OnRoad.API.Infrastructure;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");
        builder.HasKey(customer => customer.Id);

        builder.Property(customer => customer.Id);
        builder.Property(customer => customer.FullName);
        builder.Property(customer => customer.DocumentId);
    }
}