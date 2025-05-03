using MediatR;
using OnRoad.Features.Contracts.Locations.Responses;

namespace OnRoad.Features.Contracts.Locations.Commands.Create;

public record CreateLocationCommand(
    Guid CustomerId, 
    Guid VehicleId, 
    Guid PlanId, 
    DateOnly StartDate) : IRequest<LocationResponse>;