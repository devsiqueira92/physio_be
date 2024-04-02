using MediatR;
using Physio.Domain.Entities;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.SchedulingType.Commands.Create;

internal sealed class CreateSchedulingTypeCommandHandler : IRequestHandler<CreateSchedulingTypeCommand, Result<SchedulingTypeResponse>>
{
    private readonly ISchedulingTypeRepository _schedulingTypeRepository;
    private readonly IUnitOfWork _unitOfWork;



    public CreateSchedulingTypeCommandHandler(ISchedulingTypeRepository schedulingTypeRepository, IUnitOfWork unitOfWork)
    {
        _schedulingTypeRepository = schedulingTypeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<SchedulingTypeResponse>> Handle(CreateSchedulingTypeCommand request, CancellationToken cancellationToken)
    {
        var newSchedulingType = SchedulingTypeEntity.Create(request.schedulingType.typeName, request.userId);
        if (newSchedulingType.IsSuccess)
        {
            await _schedulingTypeRepository.CreateAsync(newSchedulingType.Value, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new SchedulingTypeResponse(newSchedulingType.Value.Id, newSchedulingType.Value.Name);
        }

        return Result.Failure<SchedulingTypeResponse>(newSchedulingType.Error);

    }
}
