using MediatR;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ProfessionalScheduling.Commands.Delete;

internal sealed class DeleteProfessionalSchedulingCommandHandler : IRequestHandler<DeleteProfessionalSchedulingCommand, Result>
{
    private readonly IProfessionalSchedulingRepository _professionalSchedulingRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProfessionalSchedulingCommandHandler(IProfessionalSchedulingRepository professionalSchedulingRepository, IUnitOfWork unitOfWork)
    {
        _professionalSchedulingRepository = professionalSchedulingRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteProfessionalSchedulingCommand request, CancellationToken cancellationToken)
    {
        var professionalScheduling = await _professionalSchedulingRepository.GetAsync(Guid.Parse(request.scheduling));
        if (professionalScheduling is not null)
        {
            professionalScheduling.Delete(request.userId);

            _professionalSchedulingRepository.Update(professionalScheduling);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }

        return Result.Failure<SchedulingResponse>(DomainErrors.Generic.UpdateError);

    }
}
