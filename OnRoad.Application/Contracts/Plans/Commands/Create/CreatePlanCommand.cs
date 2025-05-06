using MediatR;
using OnRoad.Application.Contracts.Plans.Responses;

namespace OnRoad.Application.Contracts.Plans.Commands.Create;

public record CreatePlanCommand(
    string Description,
    int DurationInDays,
    decimal DailyRate,
    decimal ExtraDayRate,
    decimal PenaltyFee) : IRequest<PlanResponse>;