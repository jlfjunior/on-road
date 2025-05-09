using MediatR;

namespace OnRoad.Application.Commands.DeleteVehicle;

public record DeleteVehicleCommand(Guid Id) : IRequest;