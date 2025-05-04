using MediatR;
using Microsoft.Extensions.Logging;
using OnRoad.Domain.Entities;
using OnRoad.Features.Contracts.Locations.Responses;
using OnRoad.Infrastructure.Repositories;

namespace OnRoad.Features.Contracts.Locations.Commands.Create;

public class CreateLocationHandler : IRequestHandler<CreateLocationCommand, LocationResponse>
{
    readonly ILogger<CreateLocationHandler> _logger;
    readonly IRepository<Location> _locationRepository;
    readonly IPlanRepository _planRepository;
    readonly IRepository<Customer> _customerRepository;
    readonly IRepository<Vehicle> _vehicleRepository;

    public CreateLocationHandler(ILogger<CreateLocationHandler> logger, 
        IRepository<Location> locationRepository, 
        IPlanRepository planRepository,
        IRepository<Customer> customerRepository, 
        IRepository<Vehicle> vehicleRepository)
    {
        _logger = logger;
        _locationRepository = locationRepository;
        _planRepository = planRepository;
        _customerRepository = customerRepository;
        _vehicleRepository = vehicleRepository;
    }
    
    public async Task<LocationResponse> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetAsync(request.CustomerId);
        var vehicle = await _vehicleRepository.GetAsync(request.VehicleId);
        var plan = await _planRepository.GetAsync(request.PlanId);

        var location = new Location(customer.Id, vehicle.Id, request.StartDate);
        
        location.WithPlan(plan.Id, plan.Version, plan.DurationInDays, plan.DailyRate);
        
        await _locationRepository.StoreAsync(location);

        var response = new LocationResponse(location.Id);
        
        _logger.LogInformation($"Contract with id: {location.Id} for customer with id: {customer.Id}");
        
        return response;
    }
}