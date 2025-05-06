using Microsoft.EntityFrameworkCore;

namespace OnRoad.Infrastructure;

public class OnRoadContext : DbContext
{
    public OnRoadContext(DbContextOptions<OnRoadContext> options) 
        : base(options)
    { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OnRoadContext).Assembly);
    }
}