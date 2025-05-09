using MediatR;
using OnRoad.Application.Models.Responses;

namespace OnRoad.Application.Commands.CreateLocation;

public record CreateLocationCommand(
    Guid CustomerId, 
    Guid VehicleId, 
    Guid PlanId, 
    DateOnly StartDate) : IRequest<LocationResponse>;