using MediatR;
using Physio.Domain.Entities;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Professional.Commands.Create;

internal sealed class CreateProfessionalCommandHandler : IRequestHandler<CreateProfessionalCommand, Result<ProfessionalResponse>>
{
    private readonly IProfessionalRepository _professionalRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProfessionalCommandHandler(IProfessionalRepository professionalRepository, IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _professionalRepository = professionalRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ProfessionalResponse>> Handle(CreateProfessionalCommand request, CancellationToken cancellationToken)
    {
        var userIsUnavailable = await _professionalRepository.CheckAvailabilityAsync(request.userId.ToString(), cancellationToken);
        if (userIsUnavailable)
            return Result.Failure<ProfessionalResponse>(DomainErrors.Professional.ProfessionalAlreadyRegistred);

        var newProfessional = ProfessionalEntity.Create(
                request.professional.name,
                request.professional.birthDate,
                request.professional.contact,
                request.professional.registerNumber,
                request.professional.appointmentValue,
                request.userId
            );

        if (newProfessional.IsSuccess)
        {
            await _professionalRepository.CreateAsync(newProfessional.Value, cancellationToken);
            await _userRepository.RegisterUser(request.userId.ToString(), cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ProfessionalResponse(
                newProfessional.Value.Id, 
                newProfessional.Value.Name, 
                newProfessional.Value.BirthDate,
                newProfessional.Value.Contact,
                newProfessional.Value.RegisterNumber,
                newProfessional.Value.AppointmentValue
            );
        }

        return Result.Failure<ProfessionalResponse>(newProfessional.Error);
    }
}
