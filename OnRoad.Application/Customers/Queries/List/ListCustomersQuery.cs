using MediatR;

namespace OnRoad.Application.Customers.Queries.List;

public record ListCustomersQuery() : IRequest<IEnumerable<CustomerResponse>>;