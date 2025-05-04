using OnRoad.Domain.Entities;
using OnRoad.SharedKernel;

namespace OnRoad.Domain;

public interface IPlanRepository : IRepository<Plan>
{
    Task<Plan> GetAsync(Guid id, int version);
}