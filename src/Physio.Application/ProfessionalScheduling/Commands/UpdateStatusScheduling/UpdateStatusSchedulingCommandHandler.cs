using MediatR;
using Physio.Domain;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ProfessionalScheduling.Commands.UpdateStatusProfessionalScheduling;

internal sealed class UpdateStatusProfessionalSchedulingCommandHandler : IRequestHandler<UpdateStatusProfessionalSchedulingCommand, Result>
{
    private readonly IProfessionalSchedulingRepository _professionalSchedulingRepository;
    private readonly IStatusSchedulingRepository _statusSchedulingRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateStatusProfessionalSchedulingCommandHandler(IProfessionalSchedulingRepository professionalSchedulingRepository, IStatusSchedulingRepository statusSchedulingRepository, IUnitOfWork unitOfWork)
    {
        _professionalSchedulingRepository = professionalSchedulingRepository;
        _statusSchedulingRepository = statusSchedulingRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateStatusProfessionalSchedulingCommand request, CancellationToken cancellationToken)
    {
        var professionalScheduling = await _professionalSchedulingRepository.GetAsync(request.scheduling.id);
        if (professionalScheduling is not null)
        {
            var status = (StatusSchedulingEnum)request.scheduling.schedulingStatus;

            var professionalSchedulingStatus = await _statusSchedulingRepository.GetByEnumAsync(status);

            var result = professionalScheduling.UpdateStatus(professionalSchedulingStatus.Id, request.userId);

            if (result.IsSuccess)
            {
                _professionalSchedulingRepository.Update(professionalScheduling);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Result.Success();
            }
            return Result.Failure<SchedulingResponse>(result.Error);
        }
        return Result.Failure<SchedulingResponse>(DomainErrors.Generic.UpdateError);
    }
}
