using FluentValidation;
using Physio.Shared.Communications.Requests;

namespace Physio.API.Validators.Professional;

public class UpdateProfessionalValidator : AbstractValidator<ProfessionalCreateRequest>
{
    public UpdateProfessionalValidator()
    {
        RuleFor(x => x.name).NotEmpty().WithMessage("Name can't be null");
    }
}
