using FluentValidation;

namespace OnRoad.Features.Contracts.Plans.Commands.Update;

public class UpdatePlanValidator : AbstractValidator<UpdatePlanCommand>
{
    public UpdatePlanValidator()
    {
        RuleFor(command => command.DailyRate)
            .GreaterThan(0);

        RuleFor(command => command.Id)
            .NotEmpty();
        
        RuleFor(command => command.PenaltyFee)
            .GreaterThan(0);
        
        RuleFor(command => command.ExtraDayRate)
            .GreaterThan(0);
    }
}