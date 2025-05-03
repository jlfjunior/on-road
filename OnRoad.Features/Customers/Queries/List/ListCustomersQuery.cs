using MediatR;

namespace OnRoad.Features.Customers.Queries.List;

public record ListCustomersQuery() : IRequest<IEnumerable<CustomerResponse>>;