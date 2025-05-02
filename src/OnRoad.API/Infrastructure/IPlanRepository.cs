using OnRoad.Domain;
using OnRoad.Domain.Entities;

namespace OnRoad.API.Infrastructure;

public interface IPlanRepository : IRepository<Plan>
{
    Task<Plan> GetAsync(Guid id, int version);
}