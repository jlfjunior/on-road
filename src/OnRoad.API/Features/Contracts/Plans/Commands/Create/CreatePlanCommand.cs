using MediatR;
using OnRoad.API.Features.Contracts.Plans.Responses;

namespace OnRoad.API.Features.Contracts.Plans.Commands.Create;

public record CreatePlanCommand(
    string Description,
    int DurationInDays,
    decimal DailyRate,
    decimal ExtraDayRate,
    decimal PenaltyFee) : IRequest<PlanResponse>;