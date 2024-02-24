using MediatR;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.StatusScheduling.Commands.Update;

internal sealed class UpdateStatusSchedulingCommandHandler : IRequestHandler<UpdateStatusSchedulingCommand, Result>
{
    private readonly IStatusSchedulingRepository _statusSchedulingRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateStatusSchedulingCommandHandler(IStatusSchedulingRepository statusSchedulingRepository, IUnitOfWork unitOfWork)
    {
        _statusSchedulingRepository = statusSchedulingRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateStatusSchedulingCommand request, CancellationToken cancellationToken)
    {
        var statusScheduling = await _statusSchedulingRepository.GetAsync(request.statusScheduling.id);
        if (statusScheduling is not null)
        {
            statusScheduling.Update(request.statusScheduling.statusName, request.userId);

            _statusSchedulingRepository.Update(statusScheduling);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }

        return Result.Failure<StatusSchedulingResponse>(DomainErrors.Generic.UpdateError);

    }
}
