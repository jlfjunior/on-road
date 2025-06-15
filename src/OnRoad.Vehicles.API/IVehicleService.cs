using OnRoad.Vehicles.API.Domain;

namespace OnRoad.Vehicles.API;

public interface IVehicleService
{
    Task<IEnumerable<Vehicle>> AllAsync();
    Task<Vehicle> AddAsync(string model);
    Task DeleteAsync(Guid vehicleId);
}