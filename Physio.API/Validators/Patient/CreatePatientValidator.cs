using FluentValidation;
using Physio.Shared.Communications.Requests;

namespace Physio.API.Validators.Patient;

public class CreatePatientValidator : AbstractValidator<PatientCreateRequest>
{
    public CreatePatientValidator()
    {
        RuleFor(x => x.name).NotEmpty().WithMessage("Name can't be null");
        RuleFor(x => x.birthDate).NotEmpty().WithMessage("Date of Birth can't be null");
        RuleFor(x => x.contact).NotEmpty().WithMessage("Contact can't be null");

        RuleFor(x => x.birthDate.Year).LessThanOrEqualTo(d => DateTime.UtcNow.Year).WithMessage("Date of Birth can be grater than now");
    }
}
