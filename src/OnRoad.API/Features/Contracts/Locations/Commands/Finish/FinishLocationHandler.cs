using MediatR;
using OnRoad.API.Features.Contracts.Locations.Responses;
using OnRoad.API.Infrastructure;
using OnRoad.Domain;
using OnRoad.Domain.Entities;

namespace OnRoad.API.Features.Contracts.Locations.Commands.Finish;

public class FinishLocationHandler : IRequestHandler<FinishLocationCommand, LocationResponse>
{
    private readonly ILogger<FinishLocationHandler> _logger;
    private readonly IRepository<Location> _locationRepository;
    private readonly IPlanRepository _planRepository;
    
    public async Task<LocationResponse> Handle(FinishLocationCommand request, CancellationToken cancellationToken)
    {
        var location = await _locationRepository.GetAsync(request.Id);
        var plan = await _planRepository.GetAsync(location.PlanId, location.PlanVersion);
        
        location.Finish(request.FinishedAt, plan.ExtraDayRate, plan.PenaltyFee);
            
        var locationReponse = new LocationResponse(Guid.Empty);
        
        _logger.LogInformation("");
        
        return locationReponse;
    }
}