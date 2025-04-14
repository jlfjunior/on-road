using MediatR;

namespace OnRoad.API.Features.Customers.Queries.List;

public record ListCustomersQuery() : IRequest<IEnumerable<CustomerResponse>>;