using MediatR;
using Physio.Application.Abstractions;
using Physio.Domain.Entities;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Clinic.Commands.Create;

internal sealed class CreateClinicCommandHandler : IRequestHandler<CreateClinicCommand, Result<AuthenticationResponse>>
{
    private readonly IClinicRepository _clinicRepository;
    private readonly IUserRepository _userRepository;
    private readonly IJwtProvider _jwtProvider;
    private readonly IUnitOfWork _unitOfWork;

    public CreateClinicCommandHandler(IClinicRepository clinicRepository, IUserRepository userRepository, IJwtProvider jwtProvider, IUnitOfWork unitOfWork)
    {
        _clinicRepository = clinicRepository;
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AuthenticationResponse>> Handle(CreateClinicCommand request, CancellationToken cancellationToken)
    {
        var userIsUnavailable = await _clinicRepository.CheckAvailabilityAsync(request.userId.ToString(), cancellationToken);
        if (userIsUnavailable)
            return Result.Failure<AuthenticationResponse>(DomainErrors.Clinic.ClinicAlreadyRegistred);

        var newClinic = ClinicEntity.Create(
                request.clinic.name,
                request.clinic.address,
                request.clinic.contact,
                request.clinic.identificationNumber,
                request.userId
            );

        if (newClinic.IsSuccess)
        {
            await _clinicRepository.CreateAsync(newClinic.Value, cancellationToken);
            var user = await _userRepository.RegisterUser(request.userId.ToString(), cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var renewToken = await _jwtProvider.GenerateAsync(user, newClinic.Value.Id);

            return new AuthenticationResponse(renewToken);
        }

        return Result.Failure<AuthenticationResponse>(newClinic.Error);
    }
}
