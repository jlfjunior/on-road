using OnRoad.Contracts.API.Domain;

namespace OnRoad.Contracts.API;

public interface IContractService
{
    Task<IEnumerable<Contract>> AllAsync();
    Task<Contract> AddAsync(Guid customerId, Guid vehicleId, DateOnly startDate);
}