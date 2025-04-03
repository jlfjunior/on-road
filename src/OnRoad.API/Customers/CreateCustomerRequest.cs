using MediatR;

namespace OnRoad.API.Customers;

public class CreateCustomerRequest : IRequest
{
    public string FullName { get; set; }
    public string DocumentId { get; set; }
}