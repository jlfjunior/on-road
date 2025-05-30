using MediatR;
using Microsoft.Extensions.Logging;
using OnRoad.Application.Models.Responses;
using OnRoad.Domain;
using OnRoad.Domain.Exceptions;

namespace OnRoad.Application.Commands.UpdatePlan;

public class UpdatePlanHandler : IRequestHandler<UpdatePlanCommand, PlanResponse>
{
    readonly ILogger<UpdatePlanHandler> _logger;
    readonly IPlanRepository _planRepository;

    public UpdatePlanHandler(ILogger<UpdatePlanHandler> logger, IPlanRepository planRepository)
    {
        _logger = logger;
        _planRepository = planRepository;
    }
    
    public async Task<PlanResponse> Handle(UpdatePlanCommand request, CancellationToken cancellationToken)
    {
        var plan = await _planRepository.GetAsync(request.Id);
        
        if (plan == null)
            throw new DomainException($"Plan with id {request.Id} does not exist");
        
        plan.Update(request.DailyRate, request.ExtraDayRate, request.PenaltyFee);

        await _planRepository.StoreAsync(plan);
        
        var response = new PlanResponse(plan.Id, plan.Description, plan.DurationInDays, plan.Version);
        
        _logger.LogInformation($"Updated plan: {plan.Id} - {plan.Description}");
        
        return response;
    }
}