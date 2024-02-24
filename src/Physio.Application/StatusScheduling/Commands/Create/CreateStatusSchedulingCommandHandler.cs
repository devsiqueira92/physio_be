using MediatR;
using Physio.Domain.Entities;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.StatusScheduling.Commands.Create;

internal sealed class CreateStatusSchedulingCommandHandler : IRequestHandler<CreateStatusSchedulingCommand, Result<StatusSchedulingResponse>>
{
    private readonly IStatusSchedulingRepository _statusSchedulingRepository;
    private readonly IUnitOfWork _unitOfWork;



    public CreateStatusSchedulingCommandHandler(IStatusSchedulingRepository statusSchedulingRepository, IUnitOfWork unitOfWork)
    {
        _statusSchedulingRepository = statusSchedulingRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<StatusSchedulingResponse>> Handle(CreateStatusSchedulingCommand request, CancellationToken cancellationToken)
    {
        var newStatusScheduling = StatusSchedulingEntity.Create(request.statusScheduling.statusName, request.userId);
        if (newStatusScheduling.IsSuccess)
        {
            await _statusSchedulingRepository.CreateAsync(newStatusScheduling.Value, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new StatusSchedulingResponse(newStatusScheduling.Value.Id, newStatusScheduling.Value.Name);
        }

        return Result.Failure<StatusSchedulingResponse>(newStatusScheduling.Error);

    }
}
