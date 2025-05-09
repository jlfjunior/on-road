using MediatR;
using OnRoad.Application.Models.Responses;

namespace OnRoad.Application.Commands.FinishLocation;

public record FinishLocationCommand(Guid Id, DateOnly FinishedAt) : IRequest<LocationResponse>;