using FluentValidation;

namespace OnRoad.Features.Customers.Commands.Create;

public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerValidator()
    {
        RuleFor(customer => customer.FullName)
            .NotEmpty();
        
        RuleFor(customer => customer.DocumentTax)
            .NotEmpty();

        RuleFor(customer => customer.BirthDate)
            .GreaterThan(DateOnly.MinValue);
    }
}