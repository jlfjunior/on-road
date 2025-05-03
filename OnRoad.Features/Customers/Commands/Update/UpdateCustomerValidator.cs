using FluentValidation;

namespace OnRoad.Features.Customers.Commands.Update;

public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerValidator()
    {
        RuleFor(customer => customer.FullName)
            .NotEmpty();
    }
}