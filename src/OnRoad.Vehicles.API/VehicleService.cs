using MongoDB.Driver;
using OnRoad.Vehicles.API.Domain;

namespace OnRoad.Vehicles.API;

public class VehicleService : IVehicleService
{
    private readonly IMongoCollection<Vehicle> _collection;

    public VehicleService(IMongoDatabase database)
    {
        _collection = database.GetCollection<Vehicle>("vehicles");
    }
    
    public async Task<IEnumerable<Vehicle>> AllAsync()
    {
        var vehicles = await _collection.FindAsync(FilterDefinition<Vehicle>.Empty);
        
        return vehicles.ToList();
    }

    public async Task<Vehicle> AddAsync(string model)
    {
        var vehicle = new Vehicle(model);
        await _collection.InsertOneAsync(vehicle);
        
        return vehicle;
    }

    public async Task DeleteAsync(Guid vehicleId)
    {
        var filter = Builders<Vehicle>.Filter.Eq(x => x.Id, vehicleId);
        await _collection.DeleteOneAsync(filter);
    }
}