using MediatR;
using OnRoad.Features.Contracts.Locations.Responses;

namespace OnRoad.Features.Contracts.Locations.Commands.Finish;

public record FinishLocationCommand(Guid Id, DateOnly FinishedAt) : IRequest<LocationResponse>;