namespace OnRoad.SharedKernel;

public interface IEvent
{
    public Guid EventId { get; set; }
    public DateTime TimeStamp { get; set; }
}