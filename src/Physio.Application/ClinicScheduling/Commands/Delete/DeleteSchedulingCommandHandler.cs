using MediatR;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ClinicScheduling.Commands.Delete;

internal sealed class DeleteClinicSchedulingCommandHandler : IRequestHandler<DeleteClinicSchedulingCommand, Result>
{
    private readonly IClinicSchedulingRepository _clinicSchedulingRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteClinicSchedulingCommandHandler(IClinicSchedulingRepository clinicSchedulingRepository, IUnitOfWork unitOfWork)
    {
        _clinicSchedulingRepository = clinicSchedulingRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteClinicSchedulingCommand request, CancellationToken cancellationToken)
    {
        var clinicScheduling = await _clinicSchedulingRepository.GetAsync(Guid.Parse(request.scheduling));
        if (clinicScheduling is not null)
        {
            clinicScheduling.Delete(request.userId);

            _clinicSchedulingRepository.Update(clinicScheduling);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }

        return Result.Failure<SchedulingResponse>(DomainErrors.Generic.UpdateError);

    }
}
