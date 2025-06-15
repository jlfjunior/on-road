using OnRoad.Vehicles.API.Domain;

namespace OnRoad.Vehicles.API;

public class VehicleResponse
{
    public Guid Id { get; set; }
    public string Model { get; set; }

    public static VehicleResponse  Map(Vehicle vehicle)
    {
        return new VehicleResponse
        {
            Id = vehicle.Id,
            Model = vehicle.Model,
        };
    }
}