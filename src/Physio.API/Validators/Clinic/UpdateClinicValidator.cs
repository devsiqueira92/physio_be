using FluentValidation;
using Physio.Shared.Communications.Requests;

namespace Physio.API.Validators.Clinic;

public class UpdateClinicValidator : AbstractValidator<ClinicCreateRequest>
{
    public UpdateClinicValidator()
    {
        RuleFor(x => x.name).NotEmpty().WithMessage("Name can't be null");
    }
}
