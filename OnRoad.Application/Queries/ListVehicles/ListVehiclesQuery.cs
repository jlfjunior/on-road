using MediatR;
using OnRoad.Application.Models.Responses;

namespace OnRoad.API.Features.Vehicles.Queries.List;

public record ListVehiclesQuery() : IRequest<IEnumerable<VehicleResponse>>;