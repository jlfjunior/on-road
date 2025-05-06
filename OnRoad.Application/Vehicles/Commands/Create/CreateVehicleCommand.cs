using MediatR;
using OnRoad.Application.Vehicles.Responses;

namespace OnRoad.Application.Vehicles.Commands.Create;

public record CreateVehicleCommand(string Model) : IRequest<VehicleResponse>;