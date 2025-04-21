using FluentValidation;

namespace OnRoad.API.Features.Contracts.Plans.Commands.Create;

public class CreatePlanValidator : AbstractValidator<CreatePlanCommand>
{
    public CreatePlanValidator()
    {
        RuleFor(command => command.DailyRate)
            .GreaterThan(0);

        RuleFor(command => command.Description)
            .NotEmpty();
        
        RuleFor(command => command.PenaltyFee)
            .GreaterThan(0);
        
        RuleFor(command => command.DurationInDays)
            .GreaterThanOrEqualTo(1);
        
        RuleFor(command => command.ExtraDayRate)
            .GreaterThan(0);
    }
}