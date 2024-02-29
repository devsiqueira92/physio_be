using MediatR;
using Physio.Domain;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ClinicScheduling.Commands.Update;

internal sealed class UpdateClinicSchedulingCommandHandler : IRequestHandler<UpdateClinicSchedulingCommand, Result>
{
    private readonly IClinicSchedulingRepository _clinicSchedulingRepository;
    private readonly IStatusSchedulingRepository _statusSchedulingRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateClinicSchedulingCommandHandler(IClinicSchedulingRepository clinicSchedulingRepository, IStatusSchedulingRepository statusSchedulingRepository, IUnitOfWork unitOfWork)
    {
        _clinicSchedulingRepository = clinicSchedulingRepository;
        _statusSchedulingRepository = statusSchedulingRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateClinicSchedulingCommand request, CancellationToken cancellationToken)
    {
        var isPatientUnavailable = await _clinicSchedulingRepository.CheckIfPatientIsAvailableAsync(request.scheduling.date, request.scheduling.patientId, request.scheduling.professionalId, cancellationToken);
        if (isPatientUnavailable)
            return Result.Failure<SchedulingResponse>(DomainErrors.Scheduling.PatientUnavailable);

        var isProfessionalUnavailable = await _clinicSchedulingRepository.CheckIfProfessionalIsAvailableAsync(request.scheduling.date, request.scheduling.professionalId, cancellationToken);
        if (isProfessionalUnavailable)
            return Result.Failure<SchedulingResponse>(DomainErrors.Scheduling.ProfessionalUnavailable);

        var scheduling = await _clinicSchedulingRepository.GetAsync(request.scheduling.id);
        if (scheduling is not null)
        {

            var schedulingStatus = await _statusSchedulingRepository.GetByEnumAsync(StatusSchedulingEnum.Agendado);
            var result = scheduling.Update(request.scheduling.date, request.scheduling.patientId, request.scheduling.professionalId, schedulingStatus.Id, request.scheduling.clinicId, request.scheduling.schedulingType, request.userId);

            if (result.IsSuccess)
            {
                _clinicSchedulingRepository.Update(scheduling);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Result.Success();
            }
            return Result.Failure<SchedulingResponse>(result.Error);
        }
        return Result.Failure<SchedulingResponse>(DomainErrors.Generic.UpdateError);
    }
}
