using MediatR;

namespace OnRoad.API.Domain;


public class Contract : Aggregate
{

    public Contract(Guid customerId, Guid vehicleId, DateTime startDate)
    {
        CustomerId = customerId;
        VehicleId = vehicleId;
        StartDate = startDate;
    }

    public Guid PlanId { get; private set; }
    public Guid CustomerId { get; private set; }
    public Guid VehicleId { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime FinishDate { get; private set; }
    public DateTime FinishedAt { get; private set; }
    public decimal Amount { get; private set; }
    public decimal Penalty { get; private set; }

    public void Finish(DateTime finishedAt, decimal dailyValue, decimal penalty)
    {
        if (finishedAt < StartDate)
            throw new ArgumentOutOfRangeException(nameof(finishedAt));
        
        FinishedAt = finishedAt;
        
        var days = finishedAt.Subtract(FinishDate).Days;

        if (days > 0)
        {
            Penalty = days * penalty;
        }
        
        var daily = FinishedAt.Subtract(StartDate).Days;
        Amount = (daily * dailyValue) + Penalty;
    }
}

public class ContractCreated : IDomainEvent
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public Guid VehicleId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime ScheduledFor { get; set; }
    
    public DateTimeOffset Timestamp { get; } = DateTimeOffset.Now;
}