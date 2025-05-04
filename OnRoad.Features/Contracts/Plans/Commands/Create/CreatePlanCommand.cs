using MediatR;
using OnRoad.Features.Contracts.Plans.Responses;

namespace OnRoad.Features.Contracts.Plans.Commands.Create;

public record CreatePlanCommand(
    string Description,
    int DurationInDays,
    decimal DailyRate,
    decimal ExtraDayRate,
    decimal PenaltyFee) : IRequest<PlanResponse>;