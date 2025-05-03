using OnRoad.Domain.Entities;

namespace OnRoad.Infrastructure.Repositories;

public interface IPlanRepository : IRepository<Plan>
{
    Task<Plan> GetAsync(Guid id, int version);
}