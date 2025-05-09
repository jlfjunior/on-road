using MediatR;
using OnRoad.Application.Models.Responses;

namespace OnRoad.Application.Contracts.Locations.Queries;

public record ListContractsQuery : IRequest<IEnumerable<LocationResponse>>;