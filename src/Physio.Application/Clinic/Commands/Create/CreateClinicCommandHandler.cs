using MediatR;
using Physio.Domain.Entities;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Clinic.Commands.Create;

internal sealed class CreateClinicCommandHandler : IRequestHandler<CreateClinicCommand, Result<ClinicResponse>>
{
    private readonly IClinicRepository _clinicRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateClinicCommandHandler(IClinicRepository clinicRepository, IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _clinicRepository = clinicRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ClinicResponse>> Handle(CreateClinicCommand request, CancellationToken cancellationToken)
    {
        var userIsUnavailable = await _clinicRepository.CheckAvailabilityAsync(request.userId.ToString(), cancellationToken);
        if (userIsUnavailable)
            return Result.Failure<ClinicResponse>(DomainErrors.Clinic.ClinicAlreadyRegistred);

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
            await _userRepository.RegisterUser(request.userId.ToString(), cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ClinicResponse(
                newClinic.Value.Id,
                newClinic.Value.Name
                //newClinic.Value.BirthDate,
                //newClinic.Value.Contact,
                //newClinic.Value.RegisterNumber,
                //newClinic.Value.AppointmentValue
            );
        }

        return Result.Failure<ClinicResponse>(newClinic.Error);
    }
}
