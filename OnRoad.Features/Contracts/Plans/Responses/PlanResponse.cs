namespace OnRoad.Features.Contracts.Plans.Responses;

public record PlanResponse(Guid Id, string Description, decimal DurationInDays, int Version);