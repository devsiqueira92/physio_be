using FluentValidation;
using Physio.Shared.Communications.Requests;

namespace Physio.API.Validators.Auth;

public class LoginValidator : AbstractValidator<LoginRequest>
{
    public LoginValidator()
    {
        RuleFor(x => x.email).NotEmpty().WithMessage("Email can't be null");
        RuleFor(x => x.password).NotEmpty().WithMessage("Password can't be null");
    }
}
