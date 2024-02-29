using MediatR;
using Physio.Domain;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ClinicScheduling.Commands.UpdateStatusClinicScheduling;

internal sealed class UpdateStatusClinicSchedulingCommandHandler : IRequestHandler<UpdateStatusClinicSchedulingCommand, Result>
{
    private readonly IClinicSchedulingRepository _clinicSchedulingRepository;
    private readonly IStatusSchedulingRepository _statusSchedulingRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateStatusClinicSchedulingCommandHandler(IClinicSchedulingRepository clinicSchedulingRepository, IStatusSchedulingRepository statusSchedulingRepository, IUnitOfWork unitOfWork)
    {
        _clinicSchedulingRepository = clinicSchedulingRepository;
        _statusSchedulingRepository = statusSchedulingRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateStatusClinicSchedulingCommand request, CancellationToken cancellationToken)
    {
        var clinicScheduling = await _clinicSchedulingRepository.GetAsync(request.scheduling.id);
        if (clinicScheduling is not null)
        {
            var status = (StatusSchedulingEnum)request.scheduling.schedulingStatus;

            var clinicSchedulingStatus = await _statusSchedulingRepository.GetByEnumAsync(status);

            var result = clinicScheduling.UpdateStatus(clinicSchedulingStatus.Id, request.userId);

            if (result.IsSuccess)
            {
                _clinicSchedulingRepository.Update(clinicScheduling);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Result.Success();
            }
            return Result.Failure<SchedulingResponse>(result.Error);
        }
        return Result.Failure<SchedulingResponse>(DomainErrors.Generic.UpdateError);
    }
}
