using MediatR;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Scheduling.Commands.Delete;

internal sealed class DeleteSchedulingCommandHandler : IRequestHandler<DeleteSchedulingCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISchedulingRepository _schedulingRepository;
    public DeleteSchedulingCommandHandler(ISchedulingRepository schedulingRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _schedulingRepository = schedulingRepository;
    }
    public async Task<Result> Handle(DeleteSchedulingCommand request, CancellationToken cancellationToken)
    {

        var scheduling = await _schedulingRepository.GetAsync(request.scheduling);
        if (scheduling is not null)
        {
            scheduling.Delete(request.scheduling);

            _schedulingRepository.Update(scheduling);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }

        return Result.Failure<SchedulingResponse>(DomainErrors.Generic.UpdateError);
    }
}
