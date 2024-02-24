using MediatR;
using Physio.Domain;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Scheduling.Commands.UpdateStatusScheduling;

internal sealed class UpdateStatusSchedulingCommandHandler : IRequestHandler<UpdateStatusSchedulingCommand, Result>
{
    private readonly ISchedulingRepository _schedulingRepository;
    private readonly IStatusSchedulingRepository _statusSchedulingRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateStatusSchedulingCommandHandler(ISchedulingRepository schedulingRepository, IStatusSchedulingRepository statusSchedulingRepository, IUnitOfWork unitOfWork)
    {
        _schedulingRepository = schedulingRepository;
        _statusSchedulingRepository = statusSchedulingRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateStatusSchedulingCommand request, CancellationToken cancellationToken)
    {
        var scheduling = await _schedulingRepository.GetAsync(request.scheduling.id);
        if (scheduling is not null)
        {
            var status = (StatusSchedulingEnum)request.scheduling.schedulingStatus;

            var schedulingStatus = await _statusSchedulingRepository.GetByEnumAsync(status);

            var result = scheduling.UpdateStatus(schedulingStatus.Id, request.userId);

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
