using MediatR;
using Microsoft.AspNetCore.Identity;
using Physio.Application.Abstractions;
using Physio.Domain.Entities;
using Physio.Domain.Enums;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Authenticate.Commands.Register;

internal sealed class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<AuthenticationResponse>>
{
    private readonly IJwtProvider _jwtProvider;
    private readonly UserManager<UserEntity> _userManager;
    public RegisterCommandHandler(IJwtProvider jwtProvider, UserManager<UserEntity> userManager)
    {
        _jwtProvider = jwtProvider;
        _userManager = userManager;
    }
    public async Task<Result<AuthenticationResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var accountType = (AccountTypeEnum)request.credentials.accountType;
        var identityUser = new UserEntity
        {
            Email = request.credentials.email,
            NormalizedEmail = request.credentials.email,
            NormalizedUserName = request.credentials.email,
            UserName = request.credentials.email,

            LoginType = accountType
        };

        var username = identityUser.UserName;

        var user = await _userManager.CreateAsync(identityUser, request.credentials.password);

        if (user.Succeeded)
        {
            await _userManager.AddToRoleAsync(identityUser, accountType.ToString());
            return new AuthenticationResponse(await _jwtProvider.GenerateAsync(identityUser, null));
        }
        var error = user.Errors.First();
        return Result.Failure<AuthenticationResponse>(new Error(error.Code, error.Description));
    }
}
