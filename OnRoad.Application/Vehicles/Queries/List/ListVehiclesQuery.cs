using MediatR;
using OnRoad.Application.Vehicles.Responses;

namespace OnRoad.API.Features.Vehicles.Queries.List;

public record ListVehiclesQuery() : IRequest<IEnumerable<VehicleResponse>>;