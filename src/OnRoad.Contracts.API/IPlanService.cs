using OnRoad.Contracts.API.Domain;

namespace OnRoad.Contracts.API;

public interface IPlanService
{
    Task<IEnumerable<Plan>> AllAsync();
    Task<Plan> AddAsync(string description, int durationInDays, decimal dailyRate, decimal extraDayRate, decimal penaltyFee);
}