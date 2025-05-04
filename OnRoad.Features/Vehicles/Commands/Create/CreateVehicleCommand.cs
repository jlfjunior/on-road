using MediatR;
using OnRoad.Features.Vehicles.Responses;

namespace OnRoad.Features.Vehicles.Commands.Create;

public record CreateVehicleCommand(string Model) : IRequest<VehicleResponse>;