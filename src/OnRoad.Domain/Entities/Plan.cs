using OnRoad.SharedKernel;

namespace OnRoad.Domain.Entities;

public class Plan : IEntity
{
    public Plan(string description, int durationInDays, decimal dailyRate, decimal extraDayRate, decimal penaltyFee)
    {
        Description = description;
        DurationInDays = durationInDays;
        DailyRate = dailyRate;
        ExtraDayRate = extraDayRate;
        PenaltyFee = penaltyFee;
        Id = Guid.NewGuid();
        Version = 1;
    }
    
    public Guid Id { get; private set; }
    public int Version { get; private set; }
    public string Description { get; private set; }
    public int DurationInDays { get; private set; }
    public decimal DailyRate { get; private set; }
    public decimal ExtraDayRate { get; private set; }
    public decimal PenaltyFee { get; private set; }

    public void Update(decimal dailyRate, decimal extraDayRate, decimal penaltyFee)
    {
        Version++;
    }
}