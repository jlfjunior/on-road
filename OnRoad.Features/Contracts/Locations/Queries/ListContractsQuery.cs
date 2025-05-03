using MediatR;
using OnRoad.Features.Contracts.Locations.Responses;

namespace OnRoad.Features.Contracts.Locations.Queries;

public record ListContractsQuery : IRequest<IEnumerable<LocationResponse>>;