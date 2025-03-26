namespace OnRoad.API.Domain;

public interface IAggregate : IEntity
{
    public IEnumerable<IDomainEvent> DomainEvents { get; }
}

public abstract class Aggregate : Entity, IAggregate
{
    private readonly List<IDomainEvent> _domainEvents = new ();
    
    public void RaiseEvent(IDomainEvent @event)
    {
        _domainEvents.Add(@event);
    }

    public IEnumerable<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
}