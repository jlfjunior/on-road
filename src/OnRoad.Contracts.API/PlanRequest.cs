namespace OnRoad.Contracts.API;

public class PlanRequest
{
    public string Description { get; set; }
    public int DurationInDays { get; set; }
    public decimal DailyRate { get; set; }
    public decimal ExtraDayRate { get; set; }
    public decimal PenaltyFee { get; set; }
}