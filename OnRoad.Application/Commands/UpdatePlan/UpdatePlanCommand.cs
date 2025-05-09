using MediatR;
using OnRoad.Application.Models.Responses;

namespace OnRoad.Application.Commands.UpdatePlan;

public record UpdatePlanCommand(
    Guid Id,
    decimal DailyRate,
    decimal ExtraDayRate,
    decimal PenaltyFee) : IRequest<PlanResponse>;