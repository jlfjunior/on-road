using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using OnRoad.SharedKernel;

namespace OnRoad.Vehicles.API.Domain;

public class Vehicle : IEntity
{
    public Vehicle(string model)
    {
        Id = Guid.CreateVersion7();
        Model = model;
    }
    
    [BsonId, BsonRepresentation(BsonType.String)]
    public Guid Id { get; private set; }
    
    [BsonElement("model")]
    public string Model { get; private set; }
}