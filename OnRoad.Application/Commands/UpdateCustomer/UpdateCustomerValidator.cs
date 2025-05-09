using FluentValidation;

namespace OnRoad.Application.Commands.UpdateCustomer;

public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerValidator()
    {
        RuleFor(customer => customer.FullName)
            .NotEmpty();
    }
}