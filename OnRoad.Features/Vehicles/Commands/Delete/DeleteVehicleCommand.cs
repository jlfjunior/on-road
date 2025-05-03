using MediatR;

namespace OnRoad.API.Features.Vehicles.Commands.Delete;

public record DeleteVehicleCommand(Guid Id) : IRequest;