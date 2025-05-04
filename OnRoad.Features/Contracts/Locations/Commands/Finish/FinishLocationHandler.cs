using MediatR;
using Microsoft.Extensions.Logging;
using OnRoad.Domain;
using OnRoad.Domain.Entities;
using OnRoad.Features.Contracts.Locations.Responses;
using OnRoad.SharedKernel;

namespace OnRoad.Features.Contracts.Locations.Commands.Finish;

public class FinishLocationHandler : IRequestHandler<FinishLocationCommand, LocationResponse>
{
    private readonly ILogger<FinishLocationHandler> _logger;
    private readonly IRepository<Location> _locationRepository;
    private readonly IPlanRepository _planRepository;


    public FinishLocationHandler(ILogger<FinishLocationHandler> logger, IRepository<Location> locationRepository, IPlanRepository planRepository)
    {
        _logger = logger;
        _locationRepository = locationRepository;
        _planRepository = planRepository;
    }
    
    public async Task<LocationResponse> Handle(FinishLocationCommand request, CancellationToken cancellationToken)
    {
        var location = await _locationRepository.GetAsync(request.Id);
        var plan = await _planRepository.GetAsync(location.PlanId, location.PlanVersion);
        
        location.Finish(request.FinishedAt, plan.ExtraDayRate, plan.PenaltyFee);
            
        var response = new LocationResponse(plan.Id);
        
        _logger.LogInformation($"Finished location: {location.Id}");
        
        return response;
    }
}