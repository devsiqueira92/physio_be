using FluentValidation;
using Physio.Shared.Communications.Requests;

namespace Physio.API.Validators.Scheduling;

public class UpdateSchedulingValidator : AbstractValidator<SchedulingCreateRequest>
{
    public UpdateSchedulingValidator()
    {
        RuleFor(x => x.date).NotEmpty().WithMessage("Name can't be null");
    }
}
