using MediatR;
using OnRoad.Features.Vehicles.Responses;

namespace OnRoad.API.Features.Vehicles.Queries.List;

public record ListVehiclesQuery() : IRequest<IEnumerable<VehicleResponse>>;