namespace OnRoad.API.Domain;

public interface IDomainEvent
{
    public DateTimeOffset Timestamp { get; }
}