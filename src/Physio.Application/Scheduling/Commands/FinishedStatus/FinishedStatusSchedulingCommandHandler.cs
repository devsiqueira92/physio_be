using MediatR;
using Physio.Domain;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Scheduling.Commands.FinishedStatus;

internal sealed class FinishedStatusSchedulingCommandHandler : IRequestHandler<FinishedStatusSchedulingCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISchedulingRepository _schedulingRepository;
    private readonly IStatusSchedulingRepository _statusSchedulingRepository;
    public FinishedStatusSchedulingCommandHandler(ISchedulingRepository schedulingRepository, IStatusSchedulingRepository statusSchedulingRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _schedulingRepository = schedulingRepository;
        _statusSchedulingRepository = statusSchedulingRepository;
    }
    public async Task<Result> Handle(FinishedStatusSchedulingCommand request, CancellationToken cancellationToken)
    {
        var scheduling = await _schedulingRepository.GetAsync(request.id);
        if (scheduling is not null)
        {
            var status = await _statusSchedulingRepository.GetByEnumAsync(StatusSchedulingEnum.Finalizado);
            scheduling.UpdateStatus(status.Id, request.userId);

            _schedulingRepository.Update(scheduling);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }

        return Result.Failure<SchedulingResponse>(DomainErrors.Generic.NotFound);
    }
}
