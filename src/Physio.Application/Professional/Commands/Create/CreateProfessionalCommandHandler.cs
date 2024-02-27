using MediatR;
using Physio.Application.Abstractions;
using Physio.Domain.Entities;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Professional.Commands.Create;

internal sealed class CreateProfessionalCommandHandler : IRequestHandler<CreateProfessionalCommand, Result<AuthenticationResponse>>
{
    private readonly IProfessionalRepository _professionalRepository;
    private readonly IUserRepository _userRepository;
    private readonly IJwtProvider _jwtProvider;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProfessionalCommandHandler(IProfessionalRepository professionalRepository, IUserRepository userRepository, IJwtProvider jwtProvider, IUnitOfWork unitOfWork)
    {
        _professionalRepository = professionalRepository;
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AuthenticationResponse>> Handle(CreateProfessionalCommand request, CancellationToken cancellationToken)
    {
        var userIsUnavailable = await _professionalRepository.CheckAvailabilityAsync(request.userId.ToString(), cancellationToken);
        if (userIsUnavailable)
            return Result.Failure<AuthenticationResponse>(DomainErrors.Professional.ProfessionalAlreadyRegistred);

        var newProfessional = ProfessionalEntity.Create(
                request.professional.name,
                request.professional.birthDate,
                request.professional.registerNumber,
                request.professional.appointmentValue,
                request.userId
            );

        if (newProfessional.IsSuccess)
        {
            await _professionalRepository.CreateAsync(newProfessional.Value, cancellationToken);
            var user = await _userRepository.RegisterUser(request.userId.ToString(), cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            var renewToken = await _jwtProvider.GenerateAsync(user, null);

            return new AuthenticationResponse(renewToken);
        }

        return Result.Failure<AuthenticationResponse>(newProfessional.Error);
    }
}
