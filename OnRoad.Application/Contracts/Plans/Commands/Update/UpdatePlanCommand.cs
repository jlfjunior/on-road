using MediatR;
using OnRoad.Application.Contracts.Plans.Responses;

namespace OnRoad.Application.Contracts.Plans.Commands.Update;

public record UpdatePlanCommand(
    Guid Id,
    decimal DailyRate,
    decimal ExtraDayRate,
    decimal PenaltyFee) : IRequest<PlanResponse>;