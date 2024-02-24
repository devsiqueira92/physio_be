using FluentValidation;
using Physio.Shared.Communications.Requests;

namespace Physio.API.Validators.Clinic;

public class CreateClinicValidator : AbstractValidator<ClinicCreateRequest>
{
    public CreateClinicValidator()
    {
        RuleFor(x => x.name).NotEmpty().WithMessage("Name can't be null");
    }
}
