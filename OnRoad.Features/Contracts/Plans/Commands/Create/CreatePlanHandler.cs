using MediatR;
using Microsoft.Extensions.Logging;
using OnRoad.API.Features.Contracts.Plans.Responses;
using OnRoad.Domain.Entities;
using OnRoad.Domain.Exceptions;
using OnRoad.Infrastructure.Repositories;

namespace OnRoad.Features.Contracts.Plans.Commands.Create;

public class CreatePlanHandler : IRequestHandler<CreatePlanCommand, PlanResponse>
{
    readonly ILogger<CreatePlanHandler> _logger;
    readonly IPlanRepository _planRepository;

    public CreatePlanHandler(ILogger<CreatePlanHandler> logger, IPlanRepository planRepository)
    {
        _logger = logger;
        _planRepository = planRepository;
    }

    public async Task<PlanResponse> Handle(CreatePlanCommand request, CancellationToken cancellationToken)
    {
        var exists = await _planRepository.GetAllAsync(x => x.DurationInDays == request.DurationInDays);
        
        if (exists.Any())
            throw new DomainException($"Plan {request.Description} already exists");
        
        var plan = new Plan(request.Description, request.DurationInDays, request.DailyRate, request.ExtraDayRate, request.PenaltyFee);

        await _planRepository.StoreAsync(plan);
        
        var response = new PlanResponse(plan.Id, plan.Description, plan.DurationInDays, plan.Version);
        
        return response;
    }
}