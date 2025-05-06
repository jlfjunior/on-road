using FluentValidation;

namespace OnRoad.Application.Customers.Commands.Update;

public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerValidator()
    {
        RuleFor(customer => customer.FullName)
            .NotEmpty();
    }
}