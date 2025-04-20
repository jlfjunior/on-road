using MediatR;
using OnRoad.API.Domain;
using OnRoad.API.Features.Vehicles.Responses;
using OnRoad.API.Infrastructure;

namespace OnRoad.API.Features.Vehicles.Commands.Create;

public class CreateVehicleHandler : IRequestHandler<CreateVehicleCommand, VehicleResponse>
{
    readonly ILogger<CreateVehicleHandler> _logger;
    readonly IRepository<Vehicle> _repository;
    
    public CreateVehicleHandler(ILogger<CreateVehicleHandler> logger, IRepository<Vehicle> repository)
    {
        _logger = logger;
        _repository = repository;
    }
    
    public async Task<VehicleResponse> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = new Vehicle(request.Model);
        
        await _repository.StoreAsync(vehicle);
        
        _logger.LogInformation($"Created vehicle with id: {vehicle.Id}");
        
        return new VehicleResponse(vehicle.Id, vehicle.Model);
    }
}