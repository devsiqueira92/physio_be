using MediatR;
using Microsoft.AspNetCore.Identity;
using Physio.Application.Abstractions;
using Physio.Domain.Entities;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Authenticate.Commands.Login;

internal sealed class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, Result<AuthenticationResponse>>
{
    private readonly IJwtProvider _jwtProvider;
    private readonly IClinicRepository _clinicRepository;
    private readonly UserManager<UserEntity> _userManager;

    public AuthenticateCommandHandler(IJwtProvider jwtProvider, UserManager<UserEntity> userManager, IClinicRepository clinicRepository)
    {
        _jwtProvider = jwtProvider;
        _userManager = userManager;
        _clinicRepository = clinicRepository;
    }

    public async Task<Result<AuthenticationResponse>> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.credentials.email);
        if (user is not null)
        {
            bool isValid = await _userManager.CheckPasswordAsync(user, request.credentials.password);
            if (isValid)
            {
                var clinic = await _clinicRepository.GetUserIdAsync(user.Id);
                string token = await _jwtProvider.GenerateAsync(user, clinic?.Id);
                return new AuthenticationResponse(token);
            }
                
        }

        return Result.Failure<AuthenticationResponse>(DomainErrors.Auth.InvalidUser);
    }
}
