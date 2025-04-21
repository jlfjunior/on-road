using MediatR;
using OnRoad.API.Features.Contracts.Plans.Responses;

namespace OnRoad.API.Features.Contracts.Plans.Commands.Update;

public record UpdatePlanCommand(
    Guid Id,
    decimal DailyRate,
    decimal ExtraDayRate,
    decimal PenaltyFee) : IRequest<PlanResponse>;