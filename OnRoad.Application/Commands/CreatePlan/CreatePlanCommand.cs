using MediatR;
using OnRoad.Application.Models.Responses;

namespace OnRoad.Application.Commands.CreatePlan;

public record CreatePlanCommand(
    string Description,
    int DurationInDays,
    decimal DailyRate,
    decimal ExtraDayRate,
    decimal PenaltyFee) : IRequest<PlanResponse>;