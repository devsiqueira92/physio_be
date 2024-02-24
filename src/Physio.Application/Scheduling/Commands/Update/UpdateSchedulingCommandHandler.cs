using MediatR;
using Physio.Domain;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Scheduling.Commands.Update;

internal sealed class UpdateSchedulingCommandHandler : IRequestHandler<UpdateSchedulingCommand, Result>
{
    private readonly ISchedulingRepository _schedulingRepository;
    private readonly IStatusSchedulingRepository _statusSchedulingRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSchedulingCommandHandler(ISchedulingRepository schedulingRepository, IStatusSchedulingRepository statusSchedulingRepository, IUnitOfWork unitOfWork)
    {
        _schedulingRepository = schedulingRepository;
        _statusSchedulingRepository = statusSchedulingRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateSchedulingCommand request, CancellationToken cancellationToken)
    {
        var isPatientUnavailable = await _schedulingRepository.CheckIfPatientIsAvailableAsync(request.scheduling.date, request.scheduling.patientId, request.scheduling.professionalId, cancellationToken);
        if (isPatientUnavailable)
            return Result.Failure<SchedulingResponse>(DomainErrors.Scheduling.PatientUnavailable);

        var isProfessionalUnavailable = await _schedulingRepository.CheckIfProfessionalIsAvailableAsync(request.scheduling.date, request.scheduling.professionalId, cancellationToken);
        if (isProfessionalUnavailable)
            return Result.Failure<SchedulingResponse>(DomainErrors.Scheduling.ProfessionalUnavailable);

        var scheduling = await _schedulingRepository.GetAsync(request.scheduling.id);
        if (scheduling is not null)
        {

            var schedulingStatus = await _statusSchedulingRepository.GetByEnumAsync(StatusSchedulingEnum.Agendado);
            var result = scheduling.Update(request.scheduling.date, request.scheduling.patientId, request.scheduling.professionalId, schedulingStatus.Id, request.userId);

            if (result.IsSuccess)
            {
                _schedulingRepository.Update(scheduling);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Result.Success();
            }
            return Result.Failure<SchedulingResponse>(result.Error);
        }
        return Result.Failure<SchedulingResponse>(DomainErrors.Generic.UpdateError);
    }
}
