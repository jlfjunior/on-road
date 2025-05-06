using MediatR;
using OnRoad.Application.Contracts.Locations.Responses;

namespace OnRoad.Application.Contracts.Locations.Commands.Finish;

public record FinishLocationCommand(Guid Id, DateOnly FinishedAt) : IRequest<LocationResponse>;