using MediatR;
using Physio.Domain.Entities;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ClinicScheduling.Commands.Create;

/// <summary>
/// Creating a new scheduling as Clinic
/// </summary>
internal sealed class CreateClinicSchedulingCommandHandler : IRequestHandler<CreateClinicSchedulingCommand, Result<SchedulingResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISchedulingRepository _schedulingRepository;

    private readonly IClinicSchedulingRepository _clinicSchedulingRepository;
    private readonly IClinicRepository _clinicRepository;
    private readonly IStatusSchedulingRepository _schedulingStatusRepository;
    public CreateClinicSchedulingCommandHandler(ISchedulingRepository schedulingRepository, IClinicSchedulingRepository clinicSchedulingRepository, IClinicRepository clinicRepository, IStatusSchedulingRepository schedulingStatusRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _schedulingStatusRepository = schedulingStatusRepository;
        _schedulingRepository = schedulingRepository;
        _clinicRepository = clinicRepository;
        _clinicSchedulingRepository = clinicSchedulingRepository;
    }

    public async Task<Result<SchedulingResponse>> Handle(CreateClinicSchedulingCommand request, CancellationToken cancellationToken)
    {
        //check if Patient, Professional and Date are available
        var isUnavailable = await _schedulingRepository.CheckIfPatientIsAvailableAsync(request.scheduling.date, request.scheduling.patientId, request.scheduling.professionalId);

        if (isUnavailable) 
            return Result.Failure<SchedulingResponse>(DomainErrors.Scheduling.ProfessionalUnavailable);

        var clinic = await _clinicRepository.GetByUserIdAsync(request.userId, cancellationToken);
        if(clinic is null)
            return Result.Failure<SchedulingResponse>(DomainErrors.Clinic.ClinicNotFound);

        //status must be Agendado
        var statusAgendado = await _schedulingStatusRepository.GetByEnumAsync(Domain.StatusSchedulingEnum.Agendado);

        Guid userId = Guid.Parse(request.userId);

        //create new Scheduling
        var scheduling = SchedulingEntity.Create(
            request.scheduling.date,
            request.scheduling.patientId,
            request.scheduling.professionalId,
            statusAgendado.Id,
            request.scheduling.schedulingTypeId,
            userId
        );

        //save
        if(scheduling.IsSuccess)
        {
            var clinicScheduling = ClinicSchedulingEntity.Create(clinic.Id, scheduling.Value, userId);

            await _clinicSchedulingRepository.CreateAsync(clinicScheduling.Value, cancellationToken);
            await _unitOfWork.SaveChangesAsync();

            return new SchedulingResponse(scheduling.Value.Id, scheduling.Value.Date, scheduling.Value.PatientId, scheduling.Value.ProfessionalId, scheduling.Value.SchedulingStatusId);
        }
        return Result.Failure<SchedulingResponse>(DomainErrors.Generic.CreateError);
    }
}
