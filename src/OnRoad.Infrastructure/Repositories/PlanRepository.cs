using Microsoft.EntityFrameworkCore;
using OnRoad.API.Infrastructure;
using OnRoad.Domain;
using OnRoad.Domain.Entities;

namespace OnRoad.Infrastructure.Repositories;

public class PlanRepository : Repository<Plan>, IPlanRepository
{
    public PlanRepository(OnRoadContext dbContext) 
        : base(dbContext)
    {
    }

    public async Task<Plan> GetAsync(Guid id)
    {
        var plan = await DbContext.Set<Plan>()
            .Where(plan => plan.Id == id)
            .OrderBy(plan => plan.Version)
            .LastOrDefaultAsync();
        
        return plan;
    }

    public async Task StoreAsync(Plan entity)
    { 
        DbContext.Set<Plan>().Add(entity);
        await DbContext.SaveChangesAsync();    
    }

    public async Task<Plan> GetAsync(Guid id, int version)
    {
        var plan = await DbContext.Set<Plan>()
            .Where(plan => plan.Id == id)
            .Where(plan => plan.Version == version)
            .SingleOrDefaultAsync();
        
        return plan;
    }
}