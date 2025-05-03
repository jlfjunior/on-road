using MediatR;
using Microsoft.Extensions.Logging;
using OnRoad.API.Features.Vehicles.Commands.Delete;
using OnRoad.Domain.Entities;
using OnRoad.Domain.Exceptions;
using OnRoad.Infrastructure.Repositories;

namespace OnRoad.Features.Vehicles.Commands.Delete;

public class DeleteVehicleHandler : IRequestHandler<DeleteVehicleCommand>
{
    readonly ILogger<DeleteVehicleHandler> _logger;
    readonly IRepository<Vehicle> _repository;
    
    public DeleteVehicleHandler(ILogger<DeleteVehicleHandler> logger, IRepository<Vehicle> repository)
    {
        _logger = logger;
        _repository = repository;
    }
    
    public async Task Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = await _repository.GetAsync(request.Id);
        
        if (vehicle == null)
            throw new DomainException($"Vehicle with id {request.Id} does not exist");

        await _repository.DeleteAsync(vehicle);
        
        _logger.LogInformation($"Vehicle with id {request.Id} was deleted");
    }
}