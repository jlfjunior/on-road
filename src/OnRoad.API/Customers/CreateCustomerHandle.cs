using MediatR;
using OnRoad.API.Domain;

namespace OnRoad.API.Customers;

public class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest>
{
    readonly ILogger<CreateCustomerHandler> _logger;

    public CreateCustomerHandler(ILogger<CreateCustomerHandler> logger)
    {
        _logger = logger;
    }
    
    public async Task Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        var customer = new Customer
        {
            FullName = request.FullName,
            DocumentId = request.DocumentId,
        };
    }
}