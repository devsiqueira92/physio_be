using MediatR;
using Physio.Domain;
using Physio.Domain.Entities;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ClinicScheduling.Commands.Create;

internal sealed class CreateClinicSchedulingCommandHandler : IRequestHandler<CreateClinicSchedulingCommand, Result<SchedulingResponse>>
{
    private readonly IClinicSchedulingRepository _clinicSchedulingRepository;
    private readonly IStatusSchedulingRepository _statusSchedulingRepository;

    private readonly IClinicRepository _clinicRepository;
    private readonly IUnitOfWork _unitOfWork;



    public CreateClinicSchedulingCommandHandler(IClinicSchedulingRepository clinicSchedulingRepository, IStatusSchedulingRepository statusSchedulingRepository, IClinicRepository clinicRepository, IUnitOfWork unitOfWork)
    {
        _clinicSchedulingRepository = clinicSchedulingRepository;
        _statusSchedulingRepository = statusSchedulingRepository;
        _clinicRepository = clinicRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<SchedulingResponse>> Handle(CreateClinicSchedulingCommand request, CancellationToken cancellationToken)
    {
        var isPatientUnavailable = await _clinicSchedulingRepository.CheckIfPatientIsAvailableAsync(request.scheduling.date, request.scheduling.patientId, request.scheduling.professionalId, cancellationToken);
        if (isPatientUnavailable)
            return Result.Failure<SchedulingResponse>(DomainErrors.Scheduling.PatientUnavailable);

        var isProfessionalUnavailable = await _clinicSchedulingRepository.CheckIfProfessionalIsAvailableAsync(request.scheduling.date, request.scheduling.professionalId, cancellationToken);
        if (isProfessionalUnavailable)
            return Result.Failure<SchedulingResponse>(DomainErrors.Scheduling.ProfessionalUnavailable);

        var schedulingStatus = await _statusSchedulingRepository.GetByEnumAsync(StatusSchedulingEnum.Agendado);

        var clinic = await _clinicRepository.GetUserIdAsync(request.userId.ToString());

        
        var newClinicScheduling = ClinicSchedulingEntity.Create(request.scheduling.date,
                request.scheduling.patientId,
                request.scheduling.professionalId,
                schedulingStatus.Id,
                clinic.Id,
                Guid.Parse(request.scheduling.schedulingType),
                request.userId
        );

        if (newClinicScheduling.IsSuccess)
        {
            await _clinicSchedulingRepository.CreateAsync(newClinicScheduling.Value, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new SchedulingResponse(newClinicScheduling.Value.Id, newClinicScheduling.Value.Date, newClinicScheduling.Value.PatientId, newClinicScheduling.Value.ProfessionalId, newClinicScheduling.Value.SchedulingStatusId);
        }

        return Result.Failure<SchedulingResponse>(newClinicScheduling.Error);

    }



}
