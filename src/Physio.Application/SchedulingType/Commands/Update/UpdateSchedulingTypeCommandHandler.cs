using MediatR;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.SchedulingType.Commands.Update;

internal sealed class UpdateSchedulingTypeCommandHandler : IRequestHandler<UpdateSchedulingTypeCommand, Result>
{
    private readonly ISchedulingTypeRepository _schedulingTypeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSchedulingTypeCommandHandler(ISchedulingTypeRepository schedulingTypeRepository, IUnitOfWork unitOfWork)
    {
        _schedulingTypeRepository = schedulingTypeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateSchedulingTypeCommand request, CancellationToken cancellationToken)
    {
        var schedulingType = await _schedulingTypeRepository.GetAsync(request.schedulingType.id);
        if (schedulingType is not null)
        {
            schedulingType.Update(request.schedulingType.typeName, request.userId);

            _schedulingTypeRepository.Update(schedulingType);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }

        return Result.Failure<SchedulingTypeResponse>(DomainErrors.Generic.UpdateError);

    }
}
