using MediatR;

namespace OnRoad.Application.Vehicles.Commands.Delete;

public record DeleteVehicleCommand(Guid Id) : IRequest;