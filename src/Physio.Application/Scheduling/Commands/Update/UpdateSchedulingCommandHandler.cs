using MediatR;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Scheduling.Commands.Update;

internal sealed class UpdateSchedulingCommandHandler : IRequestHandler<UpdateSchedulingCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISchedulingRepository _schedulingRepository;
    public UpdateSchedulingCommandHandler(ISchedulingRepository schedulingRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _schedulingRepository = schedulingRepository;
    }
    public async Task<Result> Handle(UpdateSchedulingCommand request, CancellationToken cancellationToken)
    {
        var scheduling = await _schedulingRepository.GetAsync(request.scheduling.id);
        if (scheduling is not null)
        {
            scheduling.Update(request.scheduling.date, request.scheduling.patientId, request.scheduling.professionalId, request.scheduling.schedulingStatusId, request.scheduling.schedulingTypeId, request.userId);

            _schedulingRepository.Update(scheduling);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }

        return Result.Failure<SchedulingResponse>(DomainErrors.Generic.UpdateError);
    }
}
