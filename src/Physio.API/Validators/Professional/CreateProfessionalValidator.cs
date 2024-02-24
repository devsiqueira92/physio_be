using FluentValidation;
using Physio.Shared.Communications.Requests;

namespace Physio.API.Validators.Professional;

public class CreateProfessionalValidator : AbstractValidator<ProfessionalCreateRequest>
{
    public CreateProfessionalValidator()
    {
        RuleFor(x => x.name).NotEmpty().WithMessage("Name can't be null");
    }
}
