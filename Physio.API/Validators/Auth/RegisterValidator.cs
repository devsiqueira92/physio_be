using FluentValidation;
using Physio.Shared.Communications.Requests;

namespace Physio.API.Validators.Auth;

public class RegisterValidator : AbstractValidator<RegisterRequest>
{
    public RegisterValidator()
    {
        RuleFor(x => x.email).NotEmpty().WithMessage("Email can't be null");
        RuleFor(x => x.password).NotEmpty().WithMessage("Password can't be null");
        RuleFor(x => x.confirmPassword).NotEmpty().WithMessage("Password can't be null");

        RuleFor(x => x.password).Equal(s => s.confirmPassword).WithMessage("Password's must be equals");
    }
}
