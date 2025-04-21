using OnRoad.API.Domain;

namespace OnRoad.API.Infrastructure;

public interface IPlanRepository : IRepository<Plan>
{
    Task<Plan> GetAsync(Guid id, int version);
}