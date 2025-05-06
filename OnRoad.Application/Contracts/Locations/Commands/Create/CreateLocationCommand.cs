using MediatR;
using OnRoad.Application.Contracts.Locations.Responses;

namespace OnRoad.Application.Contracts.Locations.Commands.Create;

public record CreateLocationCommand(
    Guid CustomerId, 
    Guid VehicleId, 
    Guid PlanId, 
    DateOnly StartDate) : IRequest<LocationResponse>;