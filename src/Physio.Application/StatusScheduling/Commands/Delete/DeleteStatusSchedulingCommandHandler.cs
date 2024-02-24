using MediatR;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.StatusScheduling.Commands.Delete;

internal sealed class DeleteStatusSchedulingCommandHandler : IRequestHandler<DeleteStatusSchedulingCommand, Result>
{
    private readonly IStatusSchedulingRepository _statusSchedulingRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteStatusSchedulingCommandHandler(IStatusSchedulingRepository statusSchedulingRepository, IUnitOfWork unitOfWork)
    {
        _statusSchedulingRepository = statusSchedulingRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteStatusSchedulingCommand request, CancellationToken cancellationToken)
    {
        var statusScheduling = await _statusSchedulingRepository.GetAsync(Guid.Parse(request.statusScheduling));
        if (statusScheduling is not null)
        {
            statusScheduling.Delete(request.userId);

            _statusSchedulingRepository.Update(statusScheduling);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }

        return Result.Failure<StatusSchedulingResponse>(DomainErrors.Generic.UpdateError);

    }
}
