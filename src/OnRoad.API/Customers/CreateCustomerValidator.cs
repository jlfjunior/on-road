using FluentValidation;

namespace OnRoad.API.Customers;

public class CreateCustomerValidator : AbstractValidator <CreateCustomerRequest>
{
    public string FullName { get; set; }
    public string DocumentId { get; set; }
}