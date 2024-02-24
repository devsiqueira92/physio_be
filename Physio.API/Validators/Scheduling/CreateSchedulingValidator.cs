using FluentValidation;
using Physio.Shared.Communications.Requests;

namespace Physio.API.Validators.Scheduling;

public class CreateSchedulingValidator : AbstractValidator<SchedulingCreateRequest>
{
    public CreateSchedulingValidator()
    {
        RuleFor(x => x.date).NotEmpty().WithMessage("Date can't be null");
    }
}
