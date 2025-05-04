using MediatR;

namespace OnRoad.Features.Vehicles.Commands.Delete;

public record DeleteVehicleCommand(Guid Id) : IRequest;