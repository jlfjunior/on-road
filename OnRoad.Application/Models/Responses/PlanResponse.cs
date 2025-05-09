namespace OnRoad.Application.Models.Responses;

public record PlanResponse(Guid Id, string Description, decimal DurationInDays, int Version);