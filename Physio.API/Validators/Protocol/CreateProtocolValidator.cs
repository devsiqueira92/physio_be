using FluentValidation;
using Physio.Shared.Communications.Requests;

namespace Physio.API.Validators.Protocol;

public class CreateProtocolValidator : AbstractValidator<ProtocolCreateRequest>
{
    public CreateProtocolValidator()
    {
        RuleFor(x => x.name).NotEmpty().WithMessage("Name can't be null");
        RuleFor(x => x.description).NotEmpty().WithMessage("Description can't be null");
    }
}
