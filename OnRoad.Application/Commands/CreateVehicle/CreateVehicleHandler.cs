using MediatR;
using Microsoft.Extensions.Logging;
using OnRoad.Application.Models.Responses;
using OnRoad.Domain.Entities;
using OnRoad.SharedKernel;

namespace OnRoad.Application.Commands.CreateVehicle;

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