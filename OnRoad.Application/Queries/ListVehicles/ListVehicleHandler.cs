using MediatR;
using Microsoft.Extensions.Logging;
using OnRoad.API.Features.Vehicles.Queries.List;
using OnRoad.Application.Models.Responses;
using OnRoad.Domain.Entities;
using OnRoad.SharedKernel;

namespace OnRoad.Application.Vehicles.Queries.List;

public class ListVehicleHandler : IRequestHandler<ListVehiclesQuery, IEnumerable<VehicleResponse>>
{
    readonly ILogger<ListVehicleHandler> _logger;
    readonly IRepository<Vehicle> _repository;

    public ListVehicleHandler(ILogger<ListVehicleHandler> logger, IRepository<Vehicle> repository)
    {
        _logger = logger;
        _repository = repository;
    }
    
    public async Task<IEnumerable<VehicleResponse>> Handle(ListVehiclesQuery request, CancellationToken cancellationToken)
    {
        var vehicles = await _repository.GetAllAsync();
        var response = vehicles.Select(x => new VehicleResponse(x.Id, x.Model));
        
        return response;
    }
}