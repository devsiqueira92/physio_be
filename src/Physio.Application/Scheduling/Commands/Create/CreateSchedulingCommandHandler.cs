using MediatR;
using Physio.Domain;
using Physio.Domain.Entities;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Scheduling.Commands.Create;

internal sealed class CreateSchedulingCommandHandler : IRequestHandler<CreateSchedulingCommand, Result<SchedulingResponse>>
{
    private readonly ISchedulingRepository _schedulingRepository;
    private readonly IStatusSchedulingRepository _statusSchedulingRepository;
    private readonly IUnitOfWork _unitOfWork;



    public CreateSchedulingCommandHandler(ISchedulingRepository schedulingRepository, IStatusSchedulingRepository statusSchedulingRepository, IUnitOfWork unitOfWork)
    {
        _schedulingRepository = schedulingRepository;
        _statusSchedulingRepository = statusSchedulingRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<SchedulingResponse>> Handle(CreateSchedulingCommand request, CancellationToken cancellationToken)
    {
        var isPatientUnavailable = await _schedulingRepository.CheckIfPatientIsAvailableAsync(request.scheduling.date, request.scheduling.patientId, request.scheduling.professionalId, cancellationToken);
        if (isPatientUnavailable)
            return Result.Failure<SchedulingResponse>(DomainErrors.Scheduling.PatientUnavailable);

        var isProfessionalUnavailable = await _schedulingRepository.CheckIfProfessionalIsAvailableAsync(request.scheduling.date, request.scheduling.professionalId, cancellationToken);
        if (isProfessionalUnavailable)
            return Result.Failure<SchedulingResponse>(DomainErrors.Scheduling.ProfessionalUnavailable);

        var schedulingStatus = await _statusSchedulingRepository.GetByEnumAsync(StatusSchedulingEnum.Agendado);

        var newScheduling = SchedulingEntity.Create(request.scheduling.date, 
                request.scheduling.patientId, 
                request.scheduling.professionalId, 
                schedulingStatus.Id,
                request.scheduling.clinicId,
                request.scheduling.schedulingType,
                request.userId
        );

        if (newScheduling.IsSuccess)
        {
            await _schedulingRepository.CreateAsync(newScheduling.Value, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new SchedulingResponse(newScheduling.Value.Id, newScheduling.Value.Date, newScheduling.Value.PatientId, newScheduling.Value.ProfessionalId, newScheduling.Value.SchedulingStatusId);
        }

        return Result.Failure<SchedulingResponse>(newScheduling.Error);

    }
}
