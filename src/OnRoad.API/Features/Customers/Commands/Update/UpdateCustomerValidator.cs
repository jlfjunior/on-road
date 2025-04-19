using FluentValidation;

namespace OnRoad.API.Features.Customers.Update;

public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerValidator()
    {
        RuleFor(customer => customer.FullName)
            .NotEmpty();
    }
}