namespace OnRoad.API.Domain;

public class Plan : Aggregate
{
    public Plan(string description, int days, decimal dailyValue, decimal penalty)
    {
        Description = description;
        Days = days;
        DailyValue = dailyValue;
        Penalty = penalty;
    }
    
    public string Description { get; private set; }
    public int Days { get; private set; }
    public decimal DailyValue { get; private set; }
    public decimal Penalty { get; private set; }
}


public class PlanCreated
{
    public string Description { get; set; }
    public int Days { get; set; }
    public decimal DailyValue { get; set; }
    public decimal Penalty { get; set; }

    public DateTimeOffset Timestamp { get; } = DateTimeOffset.UtcNow;
}