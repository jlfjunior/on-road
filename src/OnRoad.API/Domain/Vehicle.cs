using OnRoad.SharedKernel;

namespace OnRoad.API.Domain;

public class Vehicle : IEntity
{
    public Vehicle(string model)
    {
        Id = Guid.NewGuid();
        Model = model;
    }
    
    public Guid Id { get; private set; }
    public string Model { get; private set; }
}