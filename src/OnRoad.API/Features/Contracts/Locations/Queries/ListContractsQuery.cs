using MediatR;
using OnRoad.API.Features.Contracts.Locations.Responses;

namespace OnRoad.API.Features.Contracts.Locations.Queries;

public record ListContractsQuery : IRequest<IEnumerable<LocationResponse>>;