using MediatR;
using OnRoad.API.Features.Vehicles.Responses;

namespace OnRoad.Features.Vehicles.Commands.Create;

public record CreateVehicleCommand(string Model) : IRequest<VehicleResponse>;