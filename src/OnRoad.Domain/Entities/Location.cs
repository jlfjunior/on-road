using OnRoad.SharedKernel;

namespace OnRoad.Domain.Entities;


public class Location : IEntity
{

    public Location(Guid customerId, Guid vehicleId, DateOnly startDate)
    {
        CustomerId = customerId;
        VehicleId = vehicleId;
        StartDate = startDate;
        Id = Guid.NewGuid();
    }
    
    public Guid Id { get; private set; }
    public Guid CustomerId { get; private set; }
    public Guid VehicleId { get; private set; }
    public Guid PlanId { get; private set; }
    public int PlanVersion { get; set; }
    public DateOnly StartDate { get; private set; }
    public DateOnly EndDate { get; private set; }
    public DateOnly FinishedAt { get; private set; }
    public decimal Amount { get; private set; }
    public decimal Penalty { get; private set; }

    public void WithPlan(Guid id, int version, int durationInDays, decimal dailyRate)
    {
        PlanId = id;
        PlanVersion = version;
        EndDate = StartDate.AddDays(durationInDays);
        Amount = dailyRate * durationInDays;
    }

    public void Finish(DateOnly finishedAt, decimal extraDayRate, decimal penaltyFee)
    {
        FinishedAt = finishedAt;
        
        
        if (FinishedAt < EndDate)
        {
            var days = EndDate.DayNumber - FinishedAt.DayNumber;
            var penalty = days * Penalty;
            Amount -= penalty;
        }
        else if (FinishedAt > EndDate)
        {
            var extraDays = FinishedAt.DayNumber - StartDate.DayNumber;
            var extraAmount = extraDays * extraDayRate;
            Amount += extraAmount;
        }
    }
}