using MediatR;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.SchedulingType.Commands.Delete;

internal sealed class DeleteSchedulingTypeCommandHandler : IRequestHandler<DeleteSchedulingTypeCommand, Result>
{
    private readonly ISchedulingTypeRepository _schedulingTypeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSchedulingTypeCommandHandler(ISchedulingTypeRepository schedulingTypeRepository, IUnitOfWork unitOfWork)
    {
        _schedulingTypeRepository = schedulingTypeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteSchedulingTypeCommand request, CancellationToken cancellationToken)
    {
        var schedulingType = await _schedulingTypeRepository.GetAsync(Guid.Parse(request.schedulingType));
        if (schedulingType is not null)
        {
            schedulingType.Delete(request.userId);

            _schedulingTypeRepository.Update(schedulingType);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }

        return Result.Failure<SchedulingTypeResponse>(DomainErrors.Generic.UpdateError);

    }
}
