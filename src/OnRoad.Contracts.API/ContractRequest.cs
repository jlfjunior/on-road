namespace OnRoad.Contracts.API;

public class ContractRequest
{
    public Guid CustomerId { get; set; }
    public Guid VehicleId { get; set; }
    public DateOnly StartDate { get; set; }
}