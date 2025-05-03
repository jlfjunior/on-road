using MediatR;
using OnRoad.API.Features.Contracts.Plans.Responses;

namespace OnRoad.Features.Contracts.Plans.Commands.Update;

public record UpdatePlanCommand(
    Guid Id,
    decimal DailyRate,
    decimal ExtraDayRate,
    decimal PenaltyFee) : IRequest<PlanResponse>;