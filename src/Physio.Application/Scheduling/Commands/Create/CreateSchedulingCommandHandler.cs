using MediatR;
using Physio.Domain.Entities;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;
using static Physio.Domain.Errors.DomainErrors;

namespace Physio.Application.Scheduling.Commands.Create;

/// <summary>
/// Creating a new scheduling as Professional
/// </summary>
internal sealed class CreateSchedulingCommandHandler : IRequestHandler<CreateSchedulingCommand, Result<SchedulingResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISchedulingRepository _schedulingRepository;
    private readonly IStatusSchedulingRepository _schedulingStatusRepository;
    private readonly IProfessionalRepository _professionalRepository;
    public CreateSchedulingCommandHandler(ISchedulingRepository schedulingRepository, IStatusSchedulingRepository schedulingStatusRepository, IProfessionalRepository professionalRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _schedulingStatusRepository = schedulingStatusRepository;
        _schedulingRepository = schedulingRepository;
        _professionalRepository = professionalRepository;
    }

    public async Task<Result<SchedulingResponse>> Handle(CreateSchedulingCommand request, CancellationToken cancellationToken)
    {
        var professional = await _professionalRepository.GetByUserIdAsync(request.userId.ToString(), cancellationToken);

        //check if Patient, Professional and Date are available
        var isAvailable = await _schedulingRepository.CheckIfPatientIsAvailableAsync(request.scheduling.date, request.scheduling.patientId, professional.Id);

        if (isAvailable) 
            return Result.Failure<SchedulingResponse>(DomainErrors.Scheduling.ProfessionalUnavailable);

        //status must be Agendado
        var statusAgendado = await _schedulingStatusRepository.GetByEnumAsync(Domain.StatusSchedulingEnum.Agendado);

        //create new Scheduling
        var scheduling = SchedulingEntity.Create(
            request.scheduling.date,
            request.scheduling.patientId,
            professional.Id,
            statusAgendado.Id,
            request.scheduling.schedulingTypeId,
            request.userId
        );

        //save
        if(scheduling.IsSuccess)
        {
            await _schedulingRepository.CreateAsync(scheduling.Value, cancellationToken);
            await _unitOfWork.SaveChangesAsync();

            return new SchedulingResponse(scheduling.Value.Id, scheduling.Value.Date, scheduling.Value.PatientId, scheduling.Value.ProfessionalId, schedulingTypeId: scheduling.Value.SchedulingTypeId);
        }
        return Result.Failure<SchedulingResponse>(DomainErrors.Generic.CreateError);
    }
}
