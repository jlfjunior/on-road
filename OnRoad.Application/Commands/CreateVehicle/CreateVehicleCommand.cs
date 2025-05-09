using MediatR;
using OnRoad.Application.Models.Responses;

namespace OnRoad.Application.Commands.CreateVehicle;

public record CreateVehicleCommand(string Model) : IRequest<VehicleResponse>;