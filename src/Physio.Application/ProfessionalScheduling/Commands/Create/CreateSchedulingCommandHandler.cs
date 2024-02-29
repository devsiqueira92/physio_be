using MediatR;
using Physio.Domain;
using Physio.Domain.Entities;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ProfessionalScheduling.Commands.Create;

internal sealed class CreateProfessionalSchedulingCommandHandler : IRequestHandler<CreateProfessionalSchedulingCommand, Result<SchedulingResponse>>
{
    private readonly IProfessionalSchedulingRepository _professionalSchedulingRepository;
    private readonly IStatusSchedulingRepository _statusSchedulingRepository;

    private readonly IUnitOfWork _unitOfWork;



    public CreateProfessionalSchedulingCommandHandler(IProfessionalSchedulingRepository professionalSchedulingRepository, IStatusSchedulingRepository statusSchedulingRepository, IUnitOfWork unitOfWork)
    {
        _professionalSchedulingRepository = professionalSchedulingRepository;
        _statusSchedulingRepository = statusSchedulingRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<SchedulingResponse>> Handle(CreateProfessionalSchedulingCommand request, CancellationToken cancellationToken)
    {
        var isPatientUnavailable = await _professionalSchedulingRepository.CheckIfPatientIsAvailableAsync(request.scheduling.date, request.scheduling.patientId, request.scheduling.professionalId, cancellationToken);
        if (isPatientUnavailable)
            return Result.Failure<SchedulingResponse>(DomainErrors.Scheduling.PatientUnavailable);

        var isProfessionalUnavailable = await _professionalSchedulingRepository.CheckIfProfessionalIsAvailableAsync(request.scheduling.date, request.scheduling.professionalId, cancellationToken);
        if (isProfessionalUnavailable)
            return Result.Failure<SchedulingResponse>(DomainErrors.Scheduling.ProfessionalUnavailable);

        var schedulingStatus = await _statusSchedulingRepository.GetByEnumAsync(StatusSchedulingEnum.Agendado);

        var newProfessionalScheduling = ProfessionalSchedulingEntity.Create(request.scheduling.date,
                request.scheduling.patientId,
                request.scheduling.professionalId,
                schedulingStatus.Id,
                Guid.Parse(request.scheduling.schedulingType),
                request.userId
        );

        if (newProfessionalScheduling.IsSuccess)
        {
            await _professionalSchedulingRepository.CreateAsync(newProfessionalScheduling.Value, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new SchedulingResponse(newProfessionalScheduling.Value.Id, newProfessionalScheduling.Value.Date, newProfessionalScheduling.Value.PatientId, newProfessionalScheduling.Value.ProfessionalId, newProfessionalScheduling.Value.SchedulingStatusId);
        }

        return Result.Failure<SchedulingResponse>(newProfessionalScheduling.Error);

    }



}
