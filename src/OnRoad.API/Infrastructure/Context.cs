using Microsoft.EntityFrameworkCore;

namespace OnRoad.API.Infrastructure;

public class Context : DbContext
{
    public Context(DbContextOptions options) 
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
    }
}