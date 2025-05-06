using MediatR;
using OnRoad.Application.Contracts.Locations.Responses;

namespace OnRoad.Application.Contracts.Locations.Queries;

public record ListContractsQuery : IRequest<IEnumerable<LocationResponse>>;