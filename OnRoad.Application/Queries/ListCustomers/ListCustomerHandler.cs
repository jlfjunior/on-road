using MediatR;
using Microsoft.Extensions.Logging;
using OnRoad.Domain.Entities;
using OnRoad.SharedKernel;

namespace OnRoad.Application.Customers.Queries.List;

public class ListCustomerHandler : IRequestHandler<ListCustomersQuery, IEnumerable<CustomerResponse>>
{
    private readonly ILogger<ListCustomerHandler> _logger;
    private readonly IRepository<Customer> _repository;

    public ListCustomerHandler(ILogger<ListCustomerHandler> logger, IRepository<Customer> repository)
    {
        _logger = logger;
        _repository = repository;
    }

    public async Task<IEnumerable<CustomerResponse>> Handle(ListCustomersQuery request, CancellationToken cancellationToken)
    {
        var customers = await _repository.GetAllAsync();

        return customers.Select(customer =>
            new CustomerResponse(customer.Id, customer.FullName, customer.BirthDate, customer.DocumentTax));
    }
}