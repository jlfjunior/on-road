using MongoDB.Driver;
using OnRoad.Contracts.API.Domain;

namespace OnRoad.Contracts.API;

public class PlanService : IPlanService
{
    private readonly IMongoCollection<Plan> _collection;

    public PlanService(IMongoDatabase database)
    {
        _collection = database.GetCollection<Plan>("plans");
    }
    
    public async Task<IEnumerable<Plan>> AllAsync()
    {
        var plans = await _collection.Find(plan => true).ToListAsync();

        return plans;
    }

    public Task<Plan> AddAsync(string description, int durationInDays, decimal dailyRate, decimal extraDayRate, decimal penaltyFee)
    {
        throw new NotImplementedException();
    }
}