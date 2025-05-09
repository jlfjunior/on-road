using FluentValidation;

namespace OnRoad.Application.Commands.UpdatePlan;

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