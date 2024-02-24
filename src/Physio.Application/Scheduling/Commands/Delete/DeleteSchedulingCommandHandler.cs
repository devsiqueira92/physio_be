using MediatR;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Scheduling.Commands.Delete;

internal sealed class DeleteSchedulingCommandHandler : IRequestHandler<DeleteSchedulingCommand, Result>
{
    private readonly ISchedulingRepository _schedulingRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSchedulingCommandHandler(ISchedulingRepository schedulingRepository, IUnitOfWork unitOfWork)
    {
        _schedulingRepository = schedulingRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteSchedulingCommand request, CancellationToken cancellationToken)
    {
        var scheduling = await _schedulingRepository.GetAsync(Guid.Parse(request.scheduling));
        if (scheduling is not null)
        {
            scheduling.Delete(request.userId);

            _schedulingRepository.Update(scheduling);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }

        return Result.Failure<SchedulingResponse>(DomainErrors.Generic.UpdateError);

    }
}
