using MediatR;
using OnRoad.API.Features.Contracts.Locations.Responses;

namespace OnRoad.API.Features.Contracts.Locations.Commands.Finish;

public record FinishLocationCommand(Guid Id, DateOnly FinishedAt) : IRequest<LocationResponse>;