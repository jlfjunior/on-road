using MediatR;
using OnRoad.API.Features.Contracts.Locations.Responses;

namespace OnRoad.API.Features.Contracts.Locations.Commands.Create;

public record CreateLocationCommand(
    Guid CustomerId, 
    Guid VehicleId, 
    Guid PlanId, 
    DateOnly StartDate) : IRequest<LocationResponse>;